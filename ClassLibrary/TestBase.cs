using Castle.Windsor;
using NUnit.Framework;

namespace ClassLibrary
{
    [TestFixture]
    public class TestBase
    {
        protected IWindsorContainer Container;

        [TestFixtureSetUp]
        public void Setup()
        {
            Container = new WindsorContainer();
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            Container.Dispose();
        }
    }
}
