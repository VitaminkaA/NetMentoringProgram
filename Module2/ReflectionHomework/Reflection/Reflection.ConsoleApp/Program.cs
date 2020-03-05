using System;
using System.Reflection;
using Reflection.SampleLibrary;

namespace Reflection.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Adding types through assembly:");

            var container1 = new Container.Container();
            container1.AddAssembly(Assembly.Load("Reflection.SampleLibrary"));
            var customerBLLConstructorDependency1 =
                (CustomerBLL_ConstructorDependency)container1.CreateInstance(typeof(CustomerBLL_ConstructorDependency));

            Console.WriteLine($"CustomerBLL_ConstructorDependency: {customerBLLConstructorDependency1.CustomerDAL.GetCustomerName()}");
            var customerBLLPropertyDependency1 =
                (CustomerBLL_PropertyDependency)container1.CreateInstance(typeof(CustomerBLL_PropertyDependency));
            Console.WriteLine($"CustomerBLL_PropertyDependency: {customerBLLPropertyDependency1.CustomerDAL.GetCustomerName()}");
            var iCustomerDAL1 = (CustomerDAL)container1.CreateInstance(typeof(ICustomerDAL));
            Console.WriteLine($"iCustomerDAL: {iCustomerDAL1.GetCustomerName()}");
            var customerDAL1 = container1.CreateInstance<ICustomerDAL>();
            Console.WriteLine($"CustomerDAL: {customerDAL1.GetCustomerName()}");

            Console.WriteLine();
            Console.WriteLine("Add types through AddType:");

            var container = new Container.Container();
            container.AddType(typeof(CustomerBLL_ConstructorDependency));
            container.AddType(typeof(CustomerBLL_PropertyDependency));
            container.AddType(typeof(Logger));
            container.AddType(typeof(CustomerDAL), typeof(ICustomerDAL));
            
            var customerBLLConstructorDependency =
                (CustomerBLL_ConstructorDependency)container.CreateInstance(typeof(CustomerBLL_ConstructorDependency));
            Console.WriteLine($"CustomerBLL_ConstructorDependency: {customerBLLConstructorDependency.CustomerDAL.GetCustomerName()}");
            var customerBLLPropertyDependency =
                (CustomerBLL_PropertyDependency)container.CreateInstance(typeof(CustomerBLL_PropertyDependency));
            Console.WriteLine($"CustomerBLL_PropertyDependency: {customerBLLPropertyDependency.CustomerDAL.GetCustomerName()}");
            var iCustomerDAL = (CustomerDAL)container.CreateInstance(typeof(ICustomerDAL));
            Console.WriteLine($"iCustomerDAL: {iCustomerDAL.GetCustomerName()}");
            var customerDAL = container.CreateInstance<ICustomerDAL>();
            Console.WriteLine($"CustomerDAL: {customerDAL.GetCustomerName()}");
        }
    }
}
