using AsyncMediator;
using DustInTheWind.DomainEventsPerformance.Infrastructure;

namespace DustInTheWind.DomainEventsPerformance.Application02.UseCases.Demo2;

internal class Demo2CommandHandle : CommandBase<Demo2Command>
{
    public Demo2CommandHandle(IMediator mediator)
        : base(mediator)
    {
    }

    protected override Task<ICommandWorkflowResult> DoHandle(Demo2Command command)
    {
        Demo2Event demo2Event = new();
        Mediator.DeferEvent(demo2Event);

        return Task.FromResult<ICommandWorkflowResult>(CommandWorkflowResult.Ok());
    }
}
