using AsyncMediator;
using Autofac;
using BenchmarkDotNet.Attributes;
using DustInTheWind.DomainEventsPerformance.Application01.UseCases.Demo1;
using DustInTheWind.DomainEventsPerformance.Application02.UseCases.Demo2;
using DustInTheWind.DomainEventsPerformance.Application03.UseCases.Demo3;

namespace DustInTheWind.DomainEventsPerformance.Benchmarks;

[SimpleJob()]
[IterationCount(100)]
public class DemoBenchmarks
{
    private IContainer container;

    [GlobalSetup]
    public void GlobalSetup()
    {
        container = Setup.CreateAndSetupContainer();
    }

    [Benchmark]
    public async Task SimpleClasses()
    {
        IMediator mediator = container.Resolve<IMediator>();
        Demo1Command command = new();
        await mediator.Send(command);
    }

    [Benchmark]
    public async Task OneDomainEvent()
    {
        IMediator mediator = container.Resolve<IMediator>();
        Demo2Command command = new();
        await mediator.Send(command);
    }

    [Benchmark]
    public async Task MultipleDomainEvents()
    {
        IMediator mediator = container.Resolve<IMediator>();
        Demo3Command command = new();
        await mediator.Send(command);
    }
}
