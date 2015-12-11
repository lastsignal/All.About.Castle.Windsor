namespace ClassLibrary.ChainOfResponsibility
{
	public interface IChainItem
	{
		bool CanHandleTheJob();
		void HandleTheJob();
	}
}