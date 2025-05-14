using Application01.MyClasses;
using AsyncMediator;
using Infrastructure;

namespace Application01.UseCases.Demo1;

internal class Demo1CommandHandler : CommandBase<Demo1Command>
{
    public Demo1CommandHandler(IMediator mediator)
        : base(mediator)
    {
    }

    protected override Task<ICommandWorkflowResult> DoHandle(Demo1Command command)
    {
        MyClass01 myClass01 = new();
        myClass01.DoSomething();

        MyClass02 myClass02 = new();
        myClass02.DoSomething();

        MyClass03 myClass03 = new();
        myClass03.DoSomething();

        MyClass04 myClass04 = new();
        myClass04.DoSomething();

        MyClass05 myClass05 = new();
        myClass05.DoSomething();

        MyClass06 myClass06 = new();
        myClass06.DoSomething();

        MyClass07 myClass07 = new();
        myClass07.DoSomething();

        MyClass08 myClass08 = new();
        myClass08.DoSomething();

        MyClass09 myClass09 = new();
        myClass09.DoSomething();

        MyClass10 myClass10 = new();
        myClass10.DoSomething();

        return Task.FromResult<ICommandWorkflowResult>(CommandWorkflowResult.Ok());
    }
}
