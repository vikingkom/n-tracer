using System.Diagnostics;
using System.Threading.Tasks;
using NTracer.Communication;

namespace NTracer.Client
{
    public class ConsoleHandler : IHandler
    {
        public Task Handle(ScopeEvent[] @events)
        {
            foreach (var scopeEvent in @events)
            {
                Trace.WriteLine(scopeEvent);
            }

            return Task.FromResult(true);
        }
    }
}