```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.4351)
AMD Ryzen 7 5800HS with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.300
  [Host]     : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX2
  Job-IYLCES : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX2

IterationCount=5  WarmupCount=2  

```
| Method                               | Mean | Error |
|------------------------------------- |-----:|------:|
| TambahPengaduanFasilitas_Performance |   NA |    NA |
| CariPengaduanFasilitas_Performance   |   NA |    NA |
| UpdatePengaduanFasilitas_Performance |   NA |    NA |
| UbahStatusFasilitas_Performance      |   NA |    NA |
| HitungStatistikFasilitas_Performance |   NA |    NA |

Benchmarks with issues:
  PengaduanFasilitasPerformanceTests.TambahPengaduanFasilitas_Performance: Job-IYLCES(IterationCount=5, WarmupCount=2)
  PengaduanFasilitasPerformanceTests.CariPengaduanFasilitas_Performance: Job-IYLCES(IterationCount=5, WarmupCount=2)
  PengaduanFasilitasPerformanceTests.UpdatePengaduanFasilitas_Performance: Job-IYLCES(IterationCount=5, WarmupCount=2)
  PengaduanFasilitasPerformanceTests.UbahStatusFasilitas_Performance: Job-IYLCES(IterationCount=5, WarmupCount=2)
  PengaduanFasilitasPerformanceTests.HitungStatistikFasilitas_Performance: Job-IYLCES(IterationCount=5, WarmupCount=2)
