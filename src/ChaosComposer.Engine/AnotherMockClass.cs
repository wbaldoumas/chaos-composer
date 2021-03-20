namespace ChaosComposer.Engine
{
    public class AnotherMockClass
    {
        public static void Stub()
        {
            var mockclass = new MockClass();
            mockclass.SomeCodeWithoutTestCoverage();
        }
    }
}