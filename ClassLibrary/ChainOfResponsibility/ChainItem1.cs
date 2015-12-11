using System;

namespace ClassLibrary.ChainOfResponsibility
{
	public class ChainItem1 : ChainItemBase
	{
		public override bool CanHandleTheJob()
		{
			Console.WriteLine("ChainItem1 is trying to handle...");
			return false;
		}

		public override void HandleTheJob()
		{
			ExecuteHandler(() =>
			{
				// do the job
			});
		}
	}
}