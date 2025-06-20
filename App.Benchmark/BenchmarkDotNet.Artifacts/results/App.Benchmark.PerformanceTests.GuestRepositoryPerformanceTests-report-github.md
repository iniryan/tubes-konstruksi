```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.4351)
AMD Ryzen 7 5800HS with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.300
  [Host]     : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX2
  Job-IYLCES : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX2

IterationCount=5  WarmupCount=2  

```
| Method                            | Mean      | Error      | StdDev    | Gen0       | Gen1       | Allocated |
|---------------------------------- |----------:|-----------:|----------:|-----------:|-----------:|----------:|
| TambahTamu_Performance            | 725.70 ms |  82.045 ms | 21.307 ms |  5000.0000 |  2000.0000 |  39.99 MB |
| CariTamu_Performance              | 509.40 ms |  98.437 ms | 25.564 ms | 15000.0000 | 10000.0000 | 121.49 MB |
| UpdateTamu_Performance            | 614.44 ms |  28.810 ms |  4.458 ms |  6000.0000 |  5000.0000 |  47.81 MB |
| UbahStatusTamu_Performance        | 419.89 ms | 267.125 ms | 69.371 ms |  7000.0000 |  6000.0000 |  60.24 MB |
| AturWaktuKeluar_Performance       | 511.95 ms | 154.116 ms | 40.023 ms |  5000.0000 |  3000.0000 |  47.67 MB |
| HitungStatistikTamu_Performance   |  20.01 ms |   5.010 ms |  1.301 ms |  1031.2500 |   968.7500 |   8.35 MB |
| TableDrivenOperations_Performance |        NA |         NA |        NA |         NA |         NA |        NA |

Benchmarks with issues:
  GuestRepositoryPerformanceTests.TableDrivenOperations_Performance: Job-IYLCES(IterationCount=5, WarmupCount=2)
