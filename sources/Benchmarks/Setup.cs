using Application01.UseCases.Demo1;
using Application02.UseCases.Demo2;
using Application03.UseCases.Demo3;
using AsyncMediator;
using Autofac;
using System.Reflection;

namespace Benchmarks;

internal static class Setup
{
    public static IContainer CreateAndSetupContainer()
    {
        ContainerBuilder builder = new();
        SetupContainer(builder);

        return builder.Build();
    }

    private static void SetupContainer(ContainerBuilder builder)
    {
        builder.Register<MultiInstanceFactory>(context =>
        {
            IComponentContext localContext = context.Resolve<IComponentContext>();
            return type => (IEnumerable<object>)localContext.Resolve(typeof(IEnumerable<>).MakeGenericType(type));
        });

        builder.Register<SingleInstanceFactory>(context =>
        {
            IComponentContext localContext = context.Resolve<IComponentContext>();
            return type => localContext.Resolve(type);
        });

        builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();

        Assembly[] useCaseAssemblies = new[]
        {
            typeof(Demo1Command).Assembly,
            typeof(Demo2Command).Assembly,
            typeof(Demo3Command).Assembly
        };

        builder.RegisterAssemblyTypes(useCaseAssemblies).AsClosedTypesOf(typeof(IEventHandler<>));
        builder.RegisterAssemblyTypes(useCaseAssemblies).AsClosedTypesOf(typeof(ICommandHandler<>));
        builder.RegisterAssemblyTypes(useCaseAssemblies).AsClosedTypesOf(typeof(IQuery<,>));
        builder.RegisterAssemblyTypes(useCaseAssemblies).AsClosedTypesOf(typeof(ILookupQuery<>));
    }
}
