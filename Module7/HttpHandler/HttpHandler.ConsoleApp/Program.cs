using HttpHandler.ConsoleApp.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace HttpHandler.ConsoleApp
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    var listener = new HttpListener();
        //    listener.Prefixes.Add("http://+:81/");
        //    listener.Start();

        //    do
        //    {
        //        var context = listener.GetContext();
        //        var request = context.Request;
        //        var response = context.Response;

        //        if (request.Url.PathAndQuery == "/~close")
        //        {
        //            response.Close();
        //            break;
        //        }

        //        var name = request.Url.ParseQueryString()["name"];

        //        var answerString = string.IsNullOrEmpty(name) ?
        //            "Hello, anonimus!" : $"Hello,{name}";

        //        var buffer = Encoding.UTF8.GetBytes(answerString);
        //        response.ContentLength64 = buffer.Length;
        //        response.StatusCode = (int)HttpStatusCode.OK;

        //        response.OutputStream.Write(buffer, 0, buffer.Length);
        //        response.OutputStream.Close();

        //    }
        //    while (true);

        //    listener.Stop();

        //    Console.WriteLine("Hello World!");
        //}

        public static void Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureHostConfiguration(configureHost =>
                configureHost.AddJsonFile("hostsettings.json", optional: true, reloadOnChange: true))
                .ConfigureAppConfiguration((hostContext, configApp) =>
                configApp.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true));
            CreateServiceProvider()
               .GetService<Application>()
               .Run();
        }

        private static IServiceProvider CreateServiceProvider()
        {
            return new ServiceCollection()
                .RegisterDependencies()
                .BuildServiceProvider();
        }
    }
}
