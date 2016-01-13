namespace ClassLibrary.BaseClass
{
	public interface IAService
	{
		string WhoAmI();
	}

	public interface IBService
	{
		string WhoAmI();
	}

	public interface IApplicationService
	{
		string WhoAmI();
		bool IsADefined();
		bool IsBDefined();

		string WhoIsA();
		string WhoIsB();
	}

	public class AService : IAService
	{
		public string WhoAmI()
		{
			return "I am Service A";
		}
	}

	public class BService : IBService
	{
		public string WhoAmI()
		{
			return "I am Service B";
		}
	}

	public class ServiceBase
	{
		public IAService AService { get; set; }
	}

	public class ApplicationServcie : ServiceBase, IApplicationService
	{
		public IBService BService { get; set; }

		public string WhoAmI()
		{
			return "I am Application Service";
		}

		public bool IsADefined()
		{
			return AService != null;
		}

		public bool IsBDefined()
		{
			return BService != null;
		}

		public string WhoIsA()
		{
			return AService.WhoAmI();
		}

		public string WhoIsB()
		{
			return BService.WhoAmI();
		}
	}
}
