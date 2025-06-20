```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.4351)
AMD Ryzen 7 5800HS with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.300
  [Host]     : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX2
  Job-IYLCES : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX2

IterationCount=5  WarmupCount=2  

```
| Method                              | Mean      | Error     | StdDev    | Gen0       | Gen1      | Allocated |
|------------------------------------ |----------:|----------:|----------:|-----------:|----------:|----------:|
| TambahPengaduanKeamanan_Performance | 615.71 ms | 26.665 ms |  4.126 ms |  4000.0000 | 2000.0000 |  34.64 MB |
| CariPengaduanKeamanan_Performance   | 310.85 ms | 11.117 ms |  2.887 ms | 13000.0000 | 8500.0000 |  105.4 MB |
| UpdatePengaduanKeamanan_Performance | 482.56 ms | 26.556 ms |  6.896 ms |  5000.0000 | 3000.0000 |  41.65 MB |
| UbahStatusKeamanan_Performance      | 207.28 ms | 47.461 ms | 12.325 ms |  6333.3333 | 5000.0000 |  52.54 MB |
| HitungStatistikKeamanan_Performance |  13.44 ms |  3.785 ms |  0.983 ms |   531.2500 |  468.7500 |   4.23 MB |
