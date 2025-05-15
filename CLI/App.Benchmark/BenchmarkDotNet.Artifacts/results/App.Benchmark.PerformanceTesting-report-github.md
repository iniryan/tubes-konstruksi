```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.4061)
13th Gen Intel Core i7-1355U, 1 CPU, 12 logical and 10 physical cores
.NET SDK 9.0.204
  [Host]     : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2


```
| Method                          | Mean | Error |
|-------------------------------- |-----:|------:|
| BenchmarkLogin                  |   NA |    NA |
| BenchmarkRegister               |   NA |    NA |
| BenchmarkTambahPengaduan        |   NA |    NA |
| BenchmarkGetAllPengaduan        |   NA |    NA |
| BenchmarkFilterPengaduanStatus1 |   NA |    NA |

Benchmarks with issues:
  PerformanceTesting.BenchmarkLogin: DefaultJob
  PerformanceTesting.BenchmarkRegister: DefaultJob
  PerformanceTesting.BenchmarkTambahPengaduan: DefaultJob
  PerformanceTesting.BenchmarkGetAllPengaduan: DefaultJob
  PerformanceTesting.BenchmarkFilterPengaduanStatus1: DefaultJob
