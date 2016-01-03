using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using NUnit.Framework;

namespace ClassLibrary.Collections
{
    [TestFixture]
    public class RegisterCollections : TestBase
    {
        [TestFixtureSetUp]
        public void Startup()
        {
            Container.Kernel.Resolver.AddSubResolver(new ArrayResolver(Container.Kernel));

            Container.Register(
                Component
                    .For<IDependent>().ImplementedBy<Dependent>(),
                Classes
                    .FromThisAssembly()
                    .BasedOn<IService>()
                    .WithService.FirstInterface());
        }

        [Test]
        public void TestMethod1()
        {
            var dependent = Container.Resolve<IDependent>();

            dependent.ListDependencyCollection();
        }
    }
}
