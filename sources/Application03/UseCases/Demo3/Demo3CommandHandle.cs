using AsyncMediator;
using DustInTheWind.DomainEventsPerformance.Infrastructure;

namespace DustInTheWind.DomainEventsPerformance.Application03.UseCases.Demo3;

internal class Demo3CommandHandle : CommandBase<Demo3Command>
{
    public Demo3CommandHandle(IMediator mediator)
        : base(mediator)
    {
    }

    protected override Task<ICommandWorkflowResult> DoHandle(Demo3Command command)
    {
        Demo3Event01 demo2Event = new();
        Mediator.DeferEvent(demo2Event);

        Demo3Event02 demo3Event02 = new();
        Mediator.DeferEvent(demo3Event02);

        Demo3Event03 demo3Event03 = new();
        Mediator.DeferEvent(demo3Event03);

        Demo3Event04 demo3Event04 = new();
        Mediator.DeferEvent(demo3Event04);

        Demo3Event05 demo3Event05 = new();
        Mediator.DeferEvent(demo3Event05);

        Demo3Event06 demo3Event06 = new();
        Mediator.DeferEvent(demo3Event06);

        Demo3Event07 demo3Event07 = new();
        Mediator.DeferEvent(demo3Event07);

        Demo3Event08 demo3Event08 = new();
        Mediator.DeferEvent(demo3Event08);

        Demo3Event09 demo3Event09 = new();
        Mediator.DeferEvent(demo3Event09);

        Demo3Event10 demo3Event10 = new();
        Mediator.DeferEvent(demo3Event10);

        return Task.FromResult<ICommandWorkflowResult>(CommandWorkflowResult.Ok());
    }
}
