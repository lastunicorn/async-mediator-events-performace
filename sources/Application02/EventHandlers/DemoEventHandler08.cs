using AsyncMediator;
using DustInTheWind.DomainEventsPerformance.Application02;
using DustInTheWind.DomainEventsPerformance.Application02.UseCases.Demo2;

namespace DustInTheWind.DomainEventsPerformance.Application02.EventHandlers;

internal class DemoEventHandler08 : IEventHandler<Demo2Event>
{
    public Task Handle(Demo2Event @event)
    {
        StaticLog.Messages.Add("Result from MyClass08");
        return Task.CompletedTask;
    }
}
