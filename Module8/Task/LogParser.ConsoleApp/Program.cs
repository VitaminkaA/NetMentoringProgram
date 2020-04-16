using LogQuery = Interop.MSUtil.LogQueryClassClass;
using TextLineInputFormat = Interop.MSUtil.COMTextLineInputContextClassClass;
using CSVOutputFormat = Interop.MSUtil.COMCSVOutputContextClassClass;
using System;
using System.IO;
using System.Linq;

namespace LogParser.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var dir = AppDomain.CurrentDomain.BaseDirectory.Split("\\")
                .SkipLast(5)
                .ToArray();
            var path = Path.Combine(dir);

            var pathInput = path + @"\MvcMusicStore\logs";
            try
            {
                var numberOfRecordsOutputPath = path +
                                                $"\\MvcMusicStore\\Reports\\Report-NumberOfRecords-{DateTime.Now.ToString("yyyy-MM-dd")}.csv";
                var query = $"SELECT Type as LogType, COUNT(1) as Count " +
                            $"USING TRIM(SUBSTR(Text, 25, 5)) as Type " +
                            $"INTO {numberOfRecordsOutputPath} " +
                            $"FROM {pathInput}\\*.log " +
                            $"WHERE Type IN ('INFO'; 'DEBUG'; 'ERROR') " +
                            $"GROUP BY Type ";
                new LogQuery().ExecuteBatch(query,
                      new TextLineInputFormat(),
                      new CSVOutputFormat { tabs = true });

                var errorsMessagesOutputPath = path +
                    $"\\MvcMusicStore\\Reports\\Report-ErrorsMessages-{DateTime.Now.ToString("yyyy-MM-dd")}.csv";
                var queryErrors = $"SELECT SUBSTR(TYPE, 6) as Messages " +
                                  $"USING SUBSTR(Text, 25) as Type " +
                                  $"INTO {errorsMessagesOutputPath} " +
                                  $"FROM {pathInput}\\*.log " +
                                  $"WHERE Type LIKE 'ERROR%' ";
                new LogQuery().ExecuteBatch(queryErrors,
                    new TextLineInputFormat(),
                    new CSVOutputFormat { tabs = true });
            }
            catch (System.Runtime.InteropServices.COMException exc)
            {
                Console.WriteLine("Unexpected error: " + exc.Message);
            }
        }
    }
}
