using Issue39.Messages;
using NServiceBus;

namespace Issue39.Handlers
{
    public class TestEventHandler : IHandleMessages<TestEvent>
    {
        public void Handle(TestEvent message)
        {

        }
    }
}