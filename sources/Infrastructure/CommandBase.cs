using AsyncMediator;

namespace Infrastructure;

public abstract class CommandBase<TCommand> : ICommandHandler<TCommand>
    where TCommand : ICommand
{
    public IMediator Mediator { get; }

    protected CommandBase(IMediator mediator)
    {
        Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public async Task<ICommandWorkflowResult> Handle(TCommand command)
    {
        ICommandWorkflowResult result = await DoHandle(command);
        await Mediator.ExecuteDeferredEvents();

        return result;
    }

    protected abstract Task<ICommandWorkflowResult> DoHandle(TCommand command);
}