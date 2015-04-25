namespace SpecificationTestPatterns
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json.Linq;

    public class Person
    {
        public Person()
        { }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static ParseResult Parse(string person)
        {
            var token = JToken.Parse(person);

            if (HasCorrectMembers(token))
            {
                var deserializeObject = token.ToObject<Person>();
                return ParseResult.Success(deserializeObject);
            }

            return ParseResult.Failed();
        }

        static bool HasCorrectMembers(JToken token)
        {
            var propertyNames = token.GetPropertyNames();
            return HasCorrectMembers(propertyNames);
        }

        static bool HasCorrectMembers(IReadOnlyCollection<string> propertyNames)
        {
            return propertyNames.Count == 2 && (propertyNames.Contains("firstname", StringComparer.OrdinalIgnoreCase) &&
                                                propertyNames.Contains("lastname", StringComparer.OrdinalIgnoreCase));
        }
    }
}