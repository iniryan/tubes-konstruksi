```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.4061)
AMD Ryzen 7 5800HS with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
  Job-SVWLZC : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2

IterationCount=5  WarmupCount=2  

```
| Method                             | Mean         | Error         | StdDev        | Gen0   | Allocated |
|----------------------------------- |-------------:|--------------:|--------------:|-------:|----------:|
| TambahPengaduan_Massal_Performance | 49,867.47 μs | 93,978.866 μs | 24,406.013 μs | 3.9063 |  32.66 KB |
| CariPengaduan_Performance          |     13.79 μs |      1.029 μs |      0.267 μs | 1.0376 |   8.59 KB |
| UpdatePengaduan_Performance        | 11,170.40 μs |  4,621.812 μs |  1,200.270 μs |      - |  51.57 KB |
| HapusPengaduan_Performance         |  9,356.47 μs |  1,766.424 μs |    458.735 μs |      - |  28.91 KB |
