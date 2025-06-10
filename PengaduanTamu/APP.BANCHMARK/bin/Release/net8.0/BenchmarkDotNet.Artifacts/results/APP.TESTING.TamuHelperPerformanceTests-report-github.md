```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.4061)
AMD Ryzen 7 5800HS with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2


```
| Method           | Mean     | Error    | StdDev   | Median   |
|----------------- |---------:|---------:|---------:|---------:|
| TestCariTamu     | 666.6 μs | 11.96 μs | 11.19 μs | 670.0 μs |
| TestHitungHarian | 396.0 μs | 13.02 μs | 37.97 μs | 376.5 μs |
