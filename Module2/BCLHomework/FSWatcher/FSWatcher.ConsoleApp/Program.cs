using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using FSWatcher.ConsoleApp.Settings;
using FSWatcher.Library;
using FSWatcher.Library.Entity;
using MessagesResources;
using Microsoft.Extensions.Configuration;
using FSWatcher.ConsoleApp.Extension;
using AutoMapper;
using FSWatcher.ConsoleApp.Mapping;

namespace FSWatcher.ConsoleApp
{
    class Program
    {
        private static volatile bool isRunning = true;

        static void Main(string[] args)
        {
            Console.CancelKeyPress += Cancel;
            
            var config = GetConfiguration();
            var customSettings = config.Configure<CustomSettings>("CustomConfiguration");
            var folders = config.Configure<IEnumerable<FoldersSettings>>("FoldersSettings");
            
            SetCulture(customSettings.Culture);
            var mapper = InitializeAutoMapper();

            var watchers = new List<FolderWatcherService>();
            foreach (var folder in folders)
            {
                var wS = new FolderWatcherService(mapper.Map<FoldersSettings, TrackedFolder>(folder));
                watchers.Add(wS);
                wS.NewFileFound += (newFileInfo) => Console.WriteLine(Messages.NewFileFound, newFileInfo.Name, newFileInfo.DateTime);
                wS.RuleFound += () => Console.WriteLine(Messages.RuleFound);
                wS.RuleNotFound += () => Console.WriteLine(Messages.RuleNotFound);
                wS.SuccessfulFileTransfer += () => Console.WriteLine(Messages.SuccessfulFileTransfer);
                wS.StartWatching();
            }

            while (isRunning) ;

            if (watchers.Any())
                foreach (var watcher in watchers)
                    watcher.Dispose();
        }

        private static void SetCulture(string culture)
        {
            var cultureInfo = CultureInfo.GetCultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }

        private static IConfiguration GetConfiguration()
            => new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

        private static IMapper InitializeAutoMapper()
            => new MapperConfiguration(mc => { mc.AddProfile(new TrackedFolderProfile()); })
                .CreateMapper();

        private static void Cancel(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
            isRunning = false;
        }
    }
}
