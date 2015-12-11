using System;

namespace ClassLibrary.ChainOfResponsibility
{
	public class ChainItem2 : ChainItemBase
	{
		public override bool CanHandleTheJob()
		{
			Console.WriteLine("ChainItem2 is trying to handle...");
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