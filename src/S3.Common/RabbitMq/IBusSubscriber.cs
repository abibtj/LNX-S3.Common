using System;
using S3.Common.Messages;
using S3.Common.Types;

namespace S3.Common.RabbitMq
{
    public interface IBusSubscriber
    {
        IBusSubscriber SubscribeCommand<TCommand>(string @namespace = null, string queueName = null,
            Func<TCommand, S3Exception, IRejectedEvent> onError = null)
            where TCommand : ICommand;

        IBusSubscriber SubscribeEvent<TEvent>(string @namespace = null, string queueName = null,
            Func<TEvent, S3Exception, IRejectedEvent> onError = null) 
            where TEvent : IEvent;
    }
}
