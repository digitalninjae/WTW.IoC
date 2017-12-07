using Xunit;

namespace IoC.Tests
{
    public class ContainerTests
    {
        [Fact]
        public void ContainerCanRegisterTypes()
        {
            var container = new Container();
            container.Register<ITestType, TestType>();
        }

        [Fact]
        public void ContainerCanResolveType()
        {
            var container = new Container();
            container.Register<ITestType, TestType>();

            var result = container.Resolve<ITestType>();

            Assert.NotNull(result);
            Assert.IsType<TestType>(result);
        }

        [Fact]
        public void ContainerSupportsTransientObjects()
        {
            var container = new Container();
            container.Register<ITestType, TestType>();

            var result1 = container.Resolve<ITestType>();
            var result2 = container.Resolve<ITestType>();

            Assert.NotNull(result1);
            Assert.NotNull(result2);

            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void ContainerSupportsSingletonObjects()
        {
            var container = new Container();
            container.Register<ITestType, TestType>(LifeCycleType.Singleton);

            var result1 = container.Resolve<ITestType>();
            var result2 = container.Resolve<ITestType>();

            Assert.NotNull(result1);
            Assert.NotNull(result2);

            Assert.Same(result1, result2);
        }

        [Fact]
        public void ContainerThrowsInformativeExceptionIfTypeNotKnown()
        {
            var container = new Container();
            Assert.Throws<UnknownTypeException>(() => container.Resolve<IUnknownType>());
        }

        [Fact]
        public void ContainerCanResolveTypesForConstructor()
        {
            var container = new Container();
            container.Register<ITestType, TestType>();
            container.Register<ITestType2, TestType2>();
            container.Register<IConstructorTestType, ConstructorTestType>();

            var result = container.Resolve<IConstructorTestType>();

            Assert.NotNull(result);
            Assert.NotNull(result.TestType);
            Assert.NotNull(result.TestType2);

        }
    }
}