namespace SpecificationTestPatterns
{
    using System;

    public class ParseResult
    {
        private readonly Person _person;

        private ParseResult()
        { }

        private ParseResult(Person person)
        {
            _person = person;
            Parsed = true;
        }

        public bool Parsed { get; private set; }

        public Person Value
        {
            get
            {
                if (!Parsed)
                {
                    throw new InvalidOperationException();
                }
                return _person;
            }
        }

        public static ParseResult Failed()
        {
            return new ParseResult();
        }

        public static ParseResult Success(Person person)
        {
            return new ParseResult(person);
        }
    }
}