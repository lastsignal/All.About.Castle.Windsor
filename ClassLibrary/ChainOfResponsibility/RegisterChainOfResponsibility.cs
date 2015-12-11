using Castle.MicroKernel.Registration;
using NUnit.Framework;

namespace ClassLibrary.ChainOfResponsibility
{
	[TestFixture]
	public class RegisterChainOfResponsibility : TestBase
	{
		[TestFixtureSetUp]
		public void Startup()
		{
			Container.Register(
				Component
					.For<IChainItem>().ImplementedBy<ChainItem1>()
					.DependsOn(Dependency.OnComponent<IChainItem, ChainItem2>()),
				Component
					.For<IChainItem>().ImplementedBy<ChainItem2>()
					.DependsOn(Dependency.OnComponent<IChainItem, ChainItem3>()),
				Component
					.For<IChainItem>()
					.ImplementedBy<ChainItem3>()
				);
		}

		[Test]
		public void TestMethod1()
		{
			var service = Container.Resolve<IChainItem>();
			
			service.HandleTheJob();
		}
	}
}