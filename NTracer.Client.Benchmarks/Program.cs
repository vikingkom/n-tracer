using System;
using BenchmarkDotNet.Running;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NTracer.Client.Benchmarks
{
   public class Program
    {
        public static void Main(string[] args)
        {
            Run();
            //var summary = BenchmarkRunner.Run<ClientBenchmarkScenario>();
            Console.ReadLine();
        }

        private static void Run()
        {
            var scenario = new ClientBenchmarkScenario();
            scenario.MakeRealScopes();
            scenario.MakeStubScopes();
        }
    }
}
