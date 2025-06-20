```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.4351)
AMD Ryzen 7 5800HS with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.300
  [Host]     : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX2
  Job-DTNNVI : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX2

IterationCount=3  WarmupCount=1  

```
| Method                | Mean | Error |
|---------------------- |-----:|------:|
| CountPengaduan        |   NA |    NA |
| CreateSinglePengaduan |   NA |    NA |

Benchmarks with issues:
  SimpleFasilitasPerformanceTests.CountPengaduan: Job-DTNNVI(IterationCount=3, WarmupCount=1)
  SimpleFasilitasPerformanceTests.CreateSinglePengaduan: Job-DTNNVI(IterationCount=3, WarmupCount=1)
