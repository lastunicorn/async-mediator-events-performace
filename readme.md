# AsyncMediator - Event Performance

AsyncMediator is a clone of MediatR. Here is the GitHub repo:

- https://github.com/jpv001/AsyncMediator

## Overview

### Initial Problem

In one of the applications where I once worked, the execution of the use cases was typically split over multiple commands, queries and domain events. A command or query was allowed to call other commands and queries and was raising events handled in the same component to continue executing steps of the use case.

These  commands, queries and domain events were created using the AsyncMediator library.

The intended benefit (that I could deduce) was to create smaller chunks of executable logic that could be reused in multiple use cases. But the benefits were obscured by the complexity introduced by this approach.

### Architectural Concerns

Commands and queries are useful and provide benefits when they are used for sending requests from Presentation Layer (or other Primary Adapters) into Business Layer.

Domain Events are useful for signaling domain state changes back to the Presentation Layer or other decoupled components like plug-ins.

On the other hand, when the Business Layer need to call logic from the same Business Layer a simple method call would be the most appropriate approach.

### Performance Concerns

Even if the architecture does have a big impact on maintainability and development, before discussing these approaches from an architectural point of view, which I will keep for another time, let's find out what is the performance impact.

### Questions

So the questions that I will focus on in this demo are:

- What is the time of raising and handling domain events using AsyncMediator?
- And how does it compare with a simple method call?

## Approach

### Same Command Base Class

The domain events are not executed automatically after they are created. To execute them, AsyncMediator offers the `Mediator.ExecuteDeferredEvents()` method that must be manually called.

For the purpose of this measurements, I created a base class for a command that executes the deferred events at the end of its `Handle` method. This class was used in all benchmarks. This means that, even if no domain events were created, the `ExecuteDeferredEvents()` is called anyway.

```c#
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
```

### Three Scenarios

Then, I created three command handlers (in three projects) which execute the same code in three different ways:

- Instantiate 10 classes one by one and call a method from each instance.
- Raise a domain event handled by 10 different vent handlers.
- Raise three domain events, each one handled by their own event handler.

