using System;

namespace ClassLibrary.ChainOfResponsibility
{
	public class ChainItem3 : ChainItemBase
	{
		public override bool CanHandleTheJob()
		{
			Console.WriteLine("ChainItem3 is trying to handle...");
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