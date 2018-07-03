using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTracer.Server.Core.Sink;
using NTracer.Server.Core.Sink.Configuration;

namespace NTracer.Server.Core.Tests
{
    [TestClass]
    public class SinkBuilderTests
    {
        [TestMethod]
        public void BuildSinkConfiguration1()
        {
            var builder = new SinkConfigurationBuilder();
            var config = builder.Build(f => f.ByName("web api", c =>c.WithClosure().WithLogs().WithParent()));
        }
    }
}
