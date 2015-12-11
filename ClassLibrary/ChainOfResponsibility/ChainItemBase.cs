using System;

namespace ClassLibrary.ChainOfResponsibility
{
	public abstract class ChainItemBase : IChainItem
	{
		protected delegate void Handler();

		public IChainItem NextHandler { get; set; }

		public abstract bool CanHandleTheJob();
		public abstract void HandleTheJob();

		protected void ExecuteHandler(Handler handler)
		{
			if (CanHandleTheJob())
			{
				handler();
			}
			else if (NextHandler != null)
			{
				NextHandler.HandleTheJob();
			}
			else
			{
				Console.WriteLine("no item in the chain can handle the job");
			}
		}
	}
}