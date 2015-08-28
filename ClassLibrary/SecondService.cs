namespace ClassLibrary
{
    public class SecondService : IService
    {
        public SecondService()
        {
            WhoAmI = "I am the Second Service";
        }

        public string WhoAmI { get; set; }

        public string GetId()
        {
            return WhoAmI;
        }
    }
}