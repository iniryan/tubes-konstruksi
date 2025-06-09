```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.4061)
AMD Ryzen 7 5800HS with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
  Job-RJXFME : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2

IterationCount=5  WarmupCount=2  

```
| Method                             | Mean       | Error       | StdDev     | Gen0    | Allocated |
|----------------------------------- |-----------:|------------:|-----------:|--------:|----------:|
| TambahPengaduan_Massal_Performance | 206.848 ms | 368.9778 ms | 95.8224 ms |       - | 400.63 KB |
| CariPengaduan_Performance          |   1.335 ms |   0.1085 ms |  0.0282 ms |  9.7656 |  85.94 KB |
| UpdatePengaduan_Performance        | 143.216 ms |  43.0436 ms | 11.1783 ms | 62.5000 | 515.65 KB |
| HapusPengaduan_Performance         | 137.976 ms |  10.3671 ms |  1.6043 ms |       - | 289.09 KB |
