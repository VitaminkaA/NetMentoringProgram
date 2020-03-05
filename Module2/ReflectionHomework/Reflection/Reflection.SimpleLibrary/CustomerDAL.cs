using Reflection.Container.Attributes;

namespace Reflection.SampleLibrary
{
    [Export(typeof(ICustomerDAL))]
    public class CustomerDAL : ICustomerDAL
    {
        public string GetCustomerName() => "Customer";
    }
}
