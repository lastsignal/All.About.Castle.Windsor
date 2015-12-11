using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using NUnit.Framework;

namespace ClassLibrary
{
    [TestFixture]
    public class BasicTest : TestBase
    {
        [TestFixtureSetUp]
        public void Startup()
        {
            Container.Register(
                Component.For<IService>().ImplementedBy<FirstService>()
                );
        }

        [Test]
        public void TestMethod1()
        {
            var service = Container.Resolve<IService>();
            
            service.GetId().ShouldEqual("I am the First Service");
        }
    }

	[TestFixture]
    public class When_duplicate_registration_for_the_same_class : TestBase
    {
        [Test]
        public void TestMethod1()
        {
            Assert.Throws<ComponentRegistrationException>(() =>
                Container.Register(
                    Component.For<IService>().ImplementedBy<FirstService>(),
                    Component.For<IService>().ImplementedBy<FirstService>()
                    ));
        }
    }

    [TestFixture]
    public class When_duplicate_registration_for_multiple_class : TestBase
    {
        [TestFixtureSetUp]
        public void Startup()
        {
            Container.Register(
                Component.For<IService>().ImplementedBy<FirstService>(),
                Component.For<IService>().ImplementedBy<SecondService>()
                );
        }

        [Test]
        public void should_resolve_to_the_first_registration()
        {
            var service = Container.Resolve<IService>();

            service.GetId().ShouldEqual("I am the First Service");
        }
    }

    [TestFixture]
    public class When_duplicate_registration_for_multiple_class_with_default : TestBase
    {
        [TestFixtureSetUp]
        public void Startup()
        {
            Container.Register(
                Component.For<IService>().ImplementedBy<FirstService>(),
                Component.For<IService>().ImplementedBy<SecondService>().IsDefault()
                );
        }

        [Test]
        public void should_resolve_to_the_first_registration()
        {
            var service = Container.Resolve<IService>();

            service.GetId().ShouldEqual("I am the Second Service");
        }
    }

    [TestFixture]
    public class When_named_registration : TestBase
    {
        [TestFixtureSetUp]
        public void Startup()
        {
            Container.Register(
                Component.For<IService>().ImplementedBy<FirstService>().Named("First"),
                Component.For<IService>().ImplementedBy<SecondService>().Named("Second")
                );
        }

        [Test]
        public void should_return_correct_implementation()
        {
            var service = Container.Resolve<IService>("First");
            service.GetId().ShouldEqual("I am the First Service");
            
            service = Container.Resolve<IService>("Second");
            service.GetId().ShouldEqual("I am the Second Service");
        }

        [Test]
        public void should_throw_exception_when_name_does_not_exist()
        {
            Assert.Throws<ComponentNotFoundException>(() =>
            {
                var service = Container.Resolve<IService>("Unknown");
            });
        }
    }

    [TestFixture]
    public class When_register_with_no_implementation : TestBase
    {
        [TestFixtureSetUp]
        public void Startup()
        {
            Container.Register(
                Component.For<IService>()
                );
        }

        [Test]
        public void should_throw_exception()
        {
            Assert.Throws<ComponentRegistrationException>(() =>
            {
                var service = Container.Resolve<IService>();
            });
        }
    }

    [TestFixture]
    public class When_specify_existing_instance : TestBase
    {
        [TestFixtureSetUp]
        public void Startup()
        {
            var existingService = new SecondService { WhoAmI = "I am a stranger" };

            Container.Register(
                Component.For<IService>().Instance(existingService)
                );
        }

        [Test]
        public void should_return_the_specified_one_and_not_the_a_new_one()
        {
            var service = Container.Resolve<IService>();
            service.GetId().ShouldEqual("I am a stranger");
        }
    }
}