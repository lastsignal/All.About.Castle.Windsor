using System;

namespace ClassLibrary.Collections
{
    public interface IService
    {
        void Introduce();
    }

    public class Service1 : IService
    {
        public void Introduce()
        {
            Console.WriteLine("I am implementor 1");
        }
    }

    public class Service2 : IService
    {
        public void Introduce()
        {
            Console.WriteLine("I am implementor 2");
        }
    }

    public class Service3 : IService
    {
        public void Introduce()
        {
            Console.WriteLine("I am implementor 3");
        }
    }
}
