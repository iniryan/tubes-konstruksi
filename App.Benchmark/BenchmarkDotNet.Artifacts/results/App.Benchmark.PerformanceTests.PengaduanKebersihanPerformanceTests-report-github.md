```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.4061)
AMD Ryzen 7 5800HS with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
  Job-JBIEIR : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2

IterationCount=5  WarmupCount=2  

```
| Method                             | Mean           | Error            | StdDev          | Gen0   | Allocated |
|----------------------------------- |---------------:|-----------------:|----------------:|-------:|----------:|
| TambahPengaduan_Massal_Performance | 8,497,595.6 ns | 17,383,161.40 ns | 4,514,351.82 ns |      - |   7.81 KB |
| CariPengaduan_Performance          |       694.1 ns |         29.02 ns |         7.54 ns | 0.2098 |   1.72 KB |
| UpdatePengaduan_Performance        | 1,841,493.5 ns |     57,165.12 ns |     8,846.37 ns |      - |  10.31 KB |
| HapusPengaduan_Performance         | 1,825,720.8 ns |     71,409.95 ns |    18,544.94 ns |      - |   5.78 KB |
