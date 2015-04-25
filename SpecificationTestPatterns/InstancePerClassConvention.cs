namespace SpecificationTestPatterns
{
    using System.Linq;
    using Fixie;
    using FluentAssertions;
    using Xunit;

    public class InstancePerClassConvention : Convention
    {
        public InstancePerClassConvention()
        {
            Classes.Where(t => t.Name.StartsWith("When_") && 
                t.Methods().SelectMany(m => m.GetCustomAttributes(typeof(FactAttribute), false)).Any());

            Methods.Where(method => method.IsPublic && (method.IsVoid() || method.IsAsync()));

            ClassExecution.CreateInstancePerClass();
        }
    }
}