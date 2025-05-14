using Application03.UseCases.Demo3;
using AsyncMediator;

namespace Application03.EventHandlers;

internal class DemoEventHandler08 : IEventHandler<Demo3Event01>
{
    public Task Handle(Demo3Event01 @event)
    {
        StaticLog.Messages.Add("Result from MyClass08");
        return Task.CompletedTask;
    }
}
