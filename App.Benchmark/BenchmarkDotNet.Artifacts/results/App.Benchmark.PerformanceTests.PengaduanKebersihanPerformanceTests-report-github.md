```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.4351)
AMD Ryzen 7 5800HS with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.300
  [Host]     : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX2
  Job-IYLCES : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX2

IterationCount=5  WarmupCount=2  

```
| Method                             | Mean        | Error      | StdDev    | Gen0       | Gen1       | Gen2    | Allocated |
|----------------------------------- |------------:|-----------:|----------:|-----------:|-----------:|--------:|----------:|
| TambahPengaduan_Massal_Performance | 1,586.69 ms | 372.662 ms | 96.779 ms | 15000.0000 |  9000.0000 |       - | 124.11 MB |
| CariPengaduan_Performance          |   670.39 ms |  38.890 ms | 10.100 ms | 23000.0000 | 17000.0000 |       - | 189.94 MB |
| UpdatePengaduan_Performance        | 1,212.01 ms |  93.864 ms | 14.526 ms | 15000.0000 | 12000.0000 |       - | 125.02 MB |
| UbahStatus_Performance             |   616.69 ms |   6.947 ms |  1.075 ms | 19000.0000 | 15000.0000 |       - | 158.29 MB |
| HapusPengaduan_Performance         |   708.21 ms |  66.134 ms | 10.234 ms | 14000.0000 | 12000.0000 |       - | 112.89 MB |
| HitungStatistik_Performance        |    21.63 ms |   1.144 ms |  0.297 ms |  1093.7500 |  1000.0000 | 31.2500 |   8.85 MB |
