using Issue39.Messages;
using NServiceBus;

namespace Issue39.Handlers
{
    public class TestCommandHandler : IHandleMessages<TestCommand>
    {
        private readonly IBus _bus;

        public TestCommandHandler(IBus bus)
        {
            _bus = bus;
        }

        public void Handle(TestCommand message)
        {
            _bus.Publish<TestEvent>(evt => evt.TestId = message.TestId);
        }
    }
}
