using Program;
using System;
using System.Linq;

namespace AnomalyDetection
{
    class Program
    {
        static void Main(string[] args)
        {
            int appId;
            if (!int.TryParse(args[0], out appId))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            var anomalyDetectionService = new AnomalyDetectionService(appId);

            var report = anomalyDetectionService.Run();

            PrintReportToConsole(report);
        }

        private static void PrintReportToConsole(Report report)
        {
            Console.WriteLine((report.Anomalies.Any() ? $"{report.Application} - The following anomalies were detected" : "{report.Application} - No anomalies were detected") + $" using {report.Algorithm} algorithm");

            foreach (var a in report.Anomalies)
            {
                Console.WriteLine($"{a.Date} - {a.Value}");
            }
        }
    }
}