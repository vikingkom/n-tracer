using System;
using System.Data.Common;
using NTracer.Client.Core;

namespace NTracer.Client
{
    public static class TracedScopeHelper
    {
        private const string LayerNameKey = "Name";
        private const string LayerTypeKey = "Type";

        public static ITracedScope SetName(this ITracedScope tracedScope, string name)
        {
            tracedScope.SetProperty(LayerNameKey, name);
            return tracedScope;
        }

        public static ITracedScope SetType(this ITracedScope tracedScope, string type)
        {
            tracedScope.SetProperty(LayerTypeKey, type);
            return tracedScope;
        }

        public static ITracedScope AsCPU(this ITracedScope tracedScope, string name)
        {
            return tracedScope.SetType("cpu").SetName(name);
        }

        public static ITracedScope AsSql(this ITracedScope tracedScope, string provider)
        {
            return tracedScope.SetType("sql").SetName("sql").SetProperty("provider", provider);
        }

        public static ITracedScope As3RdParty(this ITracedScope tracedScope, string name)
        {
            return tracedScope.SetType("3rd party").SetName(name);
        }

        public static ITracedScope SetUniqueValue(this ITracedScope tracedScope, string key)
        {
            return tracedScope.SetProperty(key, Guid.NewGuid().ToString("N"));
        }

        public static ITracedScope SetDbCommandParameters(this ITracedScope tracedScope, DbCommand command)
        {
            tracedScope.SetProperty("sqlcommand text size", command.CommandText.Length * sizeof(char));
            tracedScope.SetProperty("sqlcommand text", command.CommandText);
            tracedScope.SetProperty("sqlcommand type", command.CommandType.ToString());
            return tracedScope;
        }
    }
}