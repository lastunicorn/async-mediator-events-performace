using AsyncMediator;

namespace Application01.UseCases;

internal abstract class CommandBase<TCommand> : ICommandHandler<TCommand>
    where TCommand : ICommand
{
    public IMediator Mediator { get; }

    protected CommandBase(IMediator mediator)
    {
        Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public Task<ICommandWorkflowResult> Handle(TCommand command)
    {
        DoHandle(command);
        Mediator.ExecuteDeferredEvents();

        return Task.FromResult<ICommandWorkflowResult>(CommandWorkflowResult.Ok());
    }

    protected abstract void DoHandle(TCommand command);
}