```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.5189/23H2/2023Update/SunValley3)
Intel Core Ultra 7 165U, 1 CPU, 14 logical and 12 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 8.0.15 (8.0.1525.16413), X64 RyuJIT AVX2
  Job-CLRBUU : .NET 8.0.15 (8.0.1525.16413), X64 RyuJIT AVX2

IterationCount=100  

```
| Method               | Mean        | Error     | StdDev      |
|--------------------- |------------:|----------:|------------:|
| SimpleClasses        |    993.1 ns |  32.69 ns |    93.80 ns |
| OneDomainEvent       |  7,674.3 ns | 156.92 ns |   442.59 ns |
| MultipleDomainEvents | 16,662.1 ns | 423.71 ns | 1,242.67 ns |
