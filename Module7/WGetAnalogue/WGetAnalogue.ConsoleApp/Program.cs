using System;
using System.Text;
using System.Threading.Tasks;
using WGetAnalogue.Library;

namespace WGetAnalogue.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var res = Console.ReadLine();

            MyClass myCass = new MyClass();
            foreach (var VARIABLE in Encoding.GetEncodings())
            {
                Console.WriteLine(VARIABLE.DisplayName); 
            }



            var rese = await myCass.GetText(res);
            Console.WriteLine(rese);
        }
    }
}
