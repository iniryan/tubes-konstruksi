```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.4061)
AMD Ryzen 7 5800HS with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
  Job-INWRHL : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2

IterationCount=5  WarmupCount=2  

```
| Method                             | Mean           | Error            | StdDev          | Gen0   | Allocated |
|----------------------------------- |---------------:|-----------------:|----------------:|-------:|----------:|
| TambahPengaduan_Massal_Performance | 8,169,057.9 ns | 18,164,781.99 ns | 4,717,336.21 ns |      - |   6.41 KB |
| CariPengaduan_Performance          |       713.3 ns |         59.71 ns |        15.51 ns | 0.2098 |   1.72 KB |
| UpdatePengaduan_Performance        | 1,809,298.3 ns |    187,203.32 ns |    48,616.11 ns |      - |  10.31 KB |
| HapusPengaduan_Performance         | 1,835,275.9 ns |     88,118.86 ns |    22,884.19 ns |      - |   5.78 KB |
