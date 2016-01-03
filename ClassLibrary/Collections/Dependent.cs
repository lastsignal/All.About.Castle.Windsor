namespace ClassLibrary.Collections
{
    public interface IDependent
    {
        void ListDependencyCollection();
    }

    public class Dependent : IDependent
    {
        public IService[] Services { get; set; }

        public void ListDependencyCollection()
        {
            foreach (var service in Services)
            {
                service.Introduce();
            }
        }
    }
}