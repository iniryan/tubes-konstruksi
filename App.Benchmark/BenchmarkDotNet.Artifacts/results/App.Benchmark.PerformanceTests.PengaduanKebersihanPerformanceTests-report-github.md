```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.4061)
AMD Ryzen 7 5800HS with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
  Job-JFOPZB : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2

IterationCount=5  WarmupCount=2  

```
| Method                             | Mean            | Error            | StdDev          | Gen0   | Allocated |
|----------------------------------- |----------------:|-----------------:|----------------:|-------:|----------:|
| TambahPengaduan_Massal_Performance | 11,099,883.4 ns | 20,792,288.28 ns | 5,399,691.25 ns |      - |   6.41 KB |
| CariPengaduan_Performance          |        825.3 ns |         89.84 ns |        23.33 ns | 0.2098 |   1.72 KB |
| UpdatePengaduan_Performance        |  2,550,619.8 ns |    107,507.94 ns |    27,919.47 ns |      - |  10.31 KB |
| HapusPengaduan_Performance         |  2,503,578.0 ns |    113,784.46 ns |    29,549.46 ns |      - |   5.78 KB |
