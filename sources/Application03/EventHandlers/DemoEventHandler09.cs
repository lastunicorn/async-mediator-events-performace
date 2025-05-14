using AsyncMediator;
using DustInTheWind.DomainEventsPerformance.Application03.UseCases.Demo3;

namespace DustInTheWind.DomainEventsPerformance.Application03.EventHandlers;

internal class DemoEventHandler09 : IEventHandler<Demo3Event01>
{
    public Task Handle(Demo3Event01 @event)
    {
        StaticLog.Messages.Add("Result from MyClass09");
        return Task.CompletedTask;
    }
}
