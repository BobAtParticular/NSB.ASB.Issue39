using System;
using Issue39.Messages;
using NServiceBus;
using NServiceBus.Saga;

namespace Issue39.HasSagas.Host
{
    public class TestSaga : Saga<TestSagaData>, IAmStartedByMessages<TestEvent>
    {
        private readonly IBus _bus;

        public TestSaga(IBus bus)
        {
            _bus = bus;
        }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<TestSagaData> mapper)
        {
            mapper.ConfigureMapping<TestEvent>(msg => msg.TestId).ToSaga(saga => saga.TestId);
        }

        public void Handle(TestEvent message)
        {
            Data.TestId = message.TestId;

            _bus.Send<TestCommand>(cmd => cmd.TestId = Guid.NewGuid());
        }
    }

    public class TestSagaData : ContainSagaData
    {
        public Guid TestId { get; set; }
    }
}
