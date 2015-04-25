namespace SpecificationTestPatterns
{
    using System;

    public class Context<TSystemUnderTest> : IDisposable
    {
        public TSystemUnderTest SUT { get; protected set; }

        public void Dispose()
        {
            Cleanup();
        }

        protected virtual void Cleanup()
        {
            
        }
    }
}