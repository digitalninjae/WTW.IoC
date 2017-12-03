namespace Container.Tests
{
    public class ConstructorTestType : IConstructorTestType
    {
        public ITestType TestType { get; set; }
        public ITestType2 TestType2 { get; set; }

        public ConstructorTestType(ITestType testType, ITestType2 testType2)
        {
            TestType = testType;
            TestType2 = testType2;
        }
    }
}