using Reflection.Container.Attributes;

namespace Reflection.SampleLibrary
{
    public class CustomerBLL_PropertyDependency
    {
        [Import]
        public ICustomerDAL CustomerDAL { get; set; }
        [Import]
        public Logger Logger { get; set; }
    }
}
