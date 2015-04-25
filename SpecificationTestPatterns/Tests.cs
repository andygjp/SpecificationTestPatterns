namespace SpecificationTestPatterns
{
    using System.Linq;
    using FluentAssertions;
    using Ploeh.AutoFixture;
    using Xunit;
    using Fixture = Ploeh.AutoFixture.Fixture;

    public class When_I_initialize_People_with_Persons
    {
        [Fact]
        public void It_should_contain_expected_number_of_items()
        {
            var fixture = new Fixture();
            var people = new People {fixture.Create<Person>(), fixture.Create<Person>()};
            people.Count().Should().Be(2);
        }
    }

    public class When_I_initialize_People_with_text
    {
        private People people;

        public When_I_initialize_People_with_text()
        {
            // Note - this arrangement/act is executed once only.
            people = new People { "{\"firstName\":\"John\", \"lastName\":\"Smith\"}" };
        }

        [Fact]
        public void It_should_contain_expected_number_of_items()
        {
            people.Count().Should().Be(1);
        }

        [Fact]
        public void It_should_contain_expected_person()
        {
            people.First().ShouldBeEquivalentTo(new Person("John", "Smith"));
        }
    }

    public class When_I_initialize_People_with_text_that_includes_invalid_data
    {
        private People people;

        public When_I_initialize_People_with_text_that_includes_invalid_data()
        {
            // Note - this arrangement/act is executed once only.
            people = new People
            {
                "{\"firstName\":\"John\", \"lastName\":\"Smith\"}",
                "{\"member\":\"John\", \"another_member\":\"Smith\"}"
            };
        }

        [Fact]
        public void It_should_contain_expected_number_of_items()
        {
            people.Count().Should().Be(1);
        }

        [Fact]
        public void It_should_contain_expected_person()
        {
            people.First().ShouldBeEquivalentTo(new Person("John", "Smith"));
        }
    }
}
