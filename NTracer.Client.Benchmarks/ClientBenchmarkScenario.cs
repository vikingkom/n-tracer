using System;
using System.Collections.Generic;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using Moq;
using NTracer.Client.CallContext;
using NTracer.Client.Core;
using NTracer.Communication;

namespace NTracer.Client.Benchmarks
{
    public class ClientBenchmarkScenario
    {
        private readonly TracedScopeContextProvider _contextProvider;
        private readonly StubTracedScopeContextProvider _stubContextProvider;
        public ClientBenchmarkScenario()
        {
            var remote = new RemoteSenderHandler(new RemoteServiceClient(new Uri("http://localhost:32671/")));
            remote.Connect("TestInstanceName", new TracerValue("key", "value")).Wait();
            _contextProvider = new TracedScopeContextProvider(new Processor(new IHandler[]{ new ConsoleHandler(), remote }));
            _stubContextProvider = new StubTracedScopeContextProvider();
            //Trace.Listeners.Add(new ConsoleTraceListener());
        }

        [Benchmark]
        public void MakeRealScopes()
        {
            var array = new List<ITracedScope>();
            for (int i = 0; i < 10; i++)
            {
                array.Add(_contextProvider.CreateScope());
            }
            array.ForEach(f=>f.Dispose());
        }

        [Benchmark]
        public void MakeStubScopes()
        {
            var array = new List<ITracedScope>();
            for (int i = 0; i < 10; i++)
            {
                array.Add(_stubContextProvider.CreateScope());
            }
            array.ForEach(f => f.Dispose());
        }
    }
}