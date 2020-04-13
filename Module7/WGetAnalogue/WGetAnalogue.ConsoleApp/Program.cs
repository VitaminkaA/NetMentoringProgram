using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WGetAnalogue.Library;

namespace WGetAnalogue.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var myCass = new SiteLocalCopy();

            myCass.Start += x => Console.WriteLine($"Start :{x}");
            myCass.Finish += x => Console.WriteLine($"Finish :{x}");

            string sitePath1 = "https://localhost:44313/Categories";
            string savePath1 = $"{Directory.GetCurrentDirectory()}\\Example1";
            await myCass.CreateCopyAsync(sitePath1, savePath1, 1, new List<string> { "bmp" });

            string sitePath2 = "https://localhost:44313/Home";
            string savePath2 = $"{Directory.GetCurrentDirectory()}\\Example2";
            await myCass.CreateCopyAsync(sitePath2, savePath2, 3, new List<string> { "bmp", "html" },
                Library.Models.TransitionRestrictionsEnum.NoHigherThanTheOriginalPath);

            string sitePath3 = "https://localhost:44313/Home";
            string savePath3 = $"{Directory.GetCurrentDirectory()}\\Example3";
            await myCass.CreateCopyAsync(sitePath3, savePath3, 3, new List<string> { "bmp", "html" },
                Library.Models.TransitionRestrictionsEnum.NoTransitionRestrictions);

            string sitePath4 = "https://localhost:44313/Home/Privacy";
            string savePath4 = $"{Directory.GetCurrentDirectory()}\\Example4";
            await myCass.CreateCopyAsync(sitePath4, savePath4, 2, new List<string> { "html" },
                Library.Models.TransitionRestrictionsEnum.InsideTheCurrentDomain);

            string sitePath5 = "https://localhost:44313/Home/Privacy";
            string savePath5 = $"{Directory.GetCurrentDirectory()}\\Example5";
            await myCass.CreateCopyAsync(sitePath5, savePath5, 2, new List<string> { "html" },
                Library.Models.TransitionRestrictionsEnum.NoTransitionRestrictions);

            //string sitePath = "https://localhost:44313/Categories/GetImage/1.bmp";
            //string sitePath = "https://www.google.by/";



            Console.WriteLine();
        }
    }
}
