using Reflection.SimpleLibrary;
using System;

namespace Reflection.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container.Container();
            container.AddType(typeof(CustomerBLL_ConstructorDependency));
            //container.AddType(typeof(CustomerBLL_PropertyDependency));
            //container.AddType(typeof(CustomerDAL),typeof(ICustomerDAL));


            var customerBLLConstructorDependency = 
                (CustomerDAL)container.CreateInstance(typeof(CustomerBLL_ConstructorDependency));
            //var customerBLLPropertyDependency =
            //    (CustomerDAL)container.CreateInstance(typeof(CustomerBLL_PropertyDependency));


            Console.WriteLine("Hello World!");
        }
    }
}
