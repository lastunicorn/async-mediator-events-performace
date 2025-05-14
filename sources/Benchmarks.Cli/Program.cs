using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Json;
using BenchmarkDotNet.Running;
using System.Reflection;

namespace Benchmarks.Cli
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Assembly benchmarksAssembly = typeof(DemoBenchmarks).Assembly;
            BenchmarkSwitcher benchmarkSwitcher = BenchmarkSwitcher.FromAssembly(benchmarksAssembly);
            IConfig config = ManualConfig
                .Create(DefaultConfig.Instance)
                .WithOptions(ConfigOptions.DisableOptimizationsValidator)
                .AddExporter(JsonExporter.Full);

            _ = benchmarkSwitcher.Run(args, config);
        }
    }
}
