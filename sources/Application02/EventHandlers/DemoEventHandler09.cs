using Application02;
using Application02.UseCases.Demo2;
using AsyncMediator;

namespace Application02.EventHandlers;

internal class DemoEventHandler09 : IEventHandler<Demo2Event>
{
    public Task Handle(Demo2Event @event)
    {
        StaticLog.Messages.Add("Result from MyClass09");
        return Task.CompletedTask;
    }
}
