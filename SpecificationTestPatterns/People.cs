namespace SpecificationTestPatterns
{
    using System.Collections;
    using System.Collections.Generic;

    public class People : IEnumerable<Person>
    {
        readonly List<Person> _items = new List<Person>();

        public IEnumerator<Person> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Person person)
        {
            _items.Add(person);
        }

        public void Add(string person)
        {
            var result = Person.Parse(person);
            if (result.Parsed)
            {
                Add(result.Value);
            }
        }
    }
}