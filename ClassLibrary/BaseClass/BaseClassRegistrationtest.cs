using System;
using Castle.MicroKernel.Registration;
using NUnit.Framework;

namespace ClassLibrary.BaseClass
{
	[TestFixture]
	public class BaseClassRegistrationtest : TestBase
	{
		[TestFixtureSetUp]
		public void Startup()
		{
			Container.Register(
				Component.For<IAService>().ImplementedBy<AService>(),
				Component.For<IBService>().ImplementedBy<BService>(),
				Component.For<IApplicationService>().ImplementedBy<ApplicationServcie>());
		}

		[Test]
		public void Base_dependant_service_should_defined()
		{
			var service = Container.Resolve<IApplicationService>();

			service.IsADefined().ShouldBeTrue();
		}

		[Test]
		public void Local_dependant_service_should_defined()
		{
			var service = Container.Resolve<IApplicationService>();

			service.IsBDefined().ShouldBeTrue();
		}

		[Test]
		public void Report_Identifications()
		{
			var service = Container.Resolve<IApplicationService>();

			Console.WriteLine(service.WhoAmI());
			Console.WriteLine(service.WhoIsA());
			Console.WriteLine(service.WhoIsB());
		}
	}
}
