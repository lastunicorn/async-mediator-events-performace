using AsyncMediator;
using DustInTheWind.DomainEventsPerformance.Application03;
using DustInTheWind.DomainEventsPerformance.Application03.UseCases.Demo3;

namespace DustInTheWind.DomainEventsPerformance.Application03.EventHandlers;

internal class DemoEventHandler02 : IEventHandler<Demo3Event01>
{
    public Task Handle(Demo3Event01 @event)
    {
        StaticLog.Messages.Add("Result from MyClass02");
        return Task.CompletedTask;
    }
}
