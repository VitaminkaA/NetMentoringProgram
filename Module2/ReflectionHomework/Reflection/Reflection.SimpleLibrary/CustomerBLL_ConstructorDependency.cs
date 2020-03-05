using Reflection.Container.Attributes;

namespace Reflection.SampleLibrary
{
    [ImportConstructor]
    public class CustomerBLL_ConstructorDependency
    {
        public readonly ICustomerDAL CustomerDAL;
        public readonly Logger Logger;

        public CustomerBLL_ConstructorDependency(ICustomerDAL dal, Logger logger)
        {
            CustomerDAL = dal;
            Logger = logger;
        }
    }
}
