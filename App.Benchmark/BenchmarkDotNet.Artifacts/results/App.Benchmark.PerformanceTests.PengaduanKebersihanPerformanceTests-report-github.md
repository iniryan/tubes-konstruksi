```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.4061)
AMD Ryzen 7 5800HS with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
  Job-TYUDTF : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2

IterationCount=5  WarmupCount=2  

```
| Method                             | Mean         | Error          | StdDev        | Gen0   | Allocated |
|----------------------------------- |-------------:|---------------:|--------------:|-------:|----------:|
| TambahPengaduan_Massal_Performance | 59,860.32 μs | 106,290.464 μs | 27,603.296 μs | 3.9063 |  32.66 KB |
| CariPengaduan_Performance          |     14.24 μs |       0.788 μs |      0.205 μs | 1.0376 |   8.59 KB |
| UpdatePengaduan_Performance        | 15,898.00 μs |   7,229.884 μs |  1,877.578 μs |      - |  51.57 KB |
| HapusPengaduan_Performance         | 14,996.81 μs |   2,622.241 μs |    680.988 μs |      - |  28.91 KB |
