using System;
using System.ServiceProcess;

namespace DistributedAppDemo.ProcessWorker.WindowsService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {

            var service = new Service();
            if (!Environment.UserInteractive)
            {
                var servicesToRun = new ServiceBase[] {service};
                ServiceBase.Run(servicesToRun);
            }
            else
            {
                service.Start(args);

                Console.WriteLine("Pulsa [ENTER] para salir...");
                Console.ReadLine();
            }
        }
    }
}
