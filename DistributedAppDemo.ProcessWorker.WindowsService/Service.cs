using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DistributedAppDemo.ProcessWorker.WindowsService
{
    partial class Service : ServiceBase
    {
        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Trace.TraceInformation("Starting service 'DistributedAppDemo.ProcessWorker.WindowsService'...");
        }

        protected override void OnStop()
        {
            Trace.TraceInformation("Stopping service 'DistributedAppDemo.ProcessWorker.WindowsService'...");
        }

        public void Start(string[] args)
        {
            OnStart(args);
        }
    }
}
