
using System.Diagnostics.Tracing;

namespace ExampleApp
{
    public class TestEventSource : EventSource
    {
       private static readonly TestEventSource _log = new TestEventSource();
       public static TestEventSource Log => _log;

       [Event(1000, Message = "Test Event", Level = EventLevel.Informational)]
       public void TestEvent()
       {
           WriteEvent(1000);
       }
    }
}
