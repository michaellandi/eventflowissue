using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Diagnostics.EventFlow;

namespace ExampleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var running = true;
            Console.CancelKeyPress += (s, e) =>
                {
                    e.Cancel = true;
                    running = false;
                };

            using (var diagnostics = DiagnosticPipelineFactory.CreatePipeline(Directory.GetCurrentDirectory() + "/eventFlowConfig.json"))
            {
                while (running)
                {
                    TestEventSource.Log.TestEvent();
                    Thread.Sleep(1000);
                }

                Environment.Exit(0);
            }
        }
    }
}
