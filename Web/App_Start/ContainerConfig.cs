using Container = IoC.Container;

namespace Web
{
    public static class ContainerConfig
    {
        public static Container Container { get; private set; }
        public static void RegisterContainer()
        {
            Container = new IoC.Container();

            Container.Register<IUserRepo, UserRepo>();
            Container.Register<IProductRepo, ProductRepo>();
        }
    }
}