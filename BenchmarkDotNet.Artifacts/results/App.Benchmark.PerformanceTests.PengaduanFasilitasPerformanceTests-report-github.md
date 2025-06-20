```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.4351)
AMD Ryzen 7 5800HS with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.300
  [Host]     : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX2
  Job-IBHMJY : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX2

IterationCount=3  WarmupCount=1  

```
| Method                               | Mean | Error |
|------------------------------------- |-----:|------:|
| TambahPengaduanFasilitas_Performance |   NA |    NA |
| CariPengaduanFasilitas_Performance   |   NA |    NA |
| UpdatePengaduanFasilitas_Performance |   NA |    NA |
| UbahStatusFasilitas_Performance      |   NA |    NA |
| HitungStatistikFasilitas_Performance |   NA |    NA |

Benchmarks with issues:
  PengaduanFasilitasPerformanceTests.TambahPengaduanFasilitas_Performance: Job-IBHMJY(IterationCount=3, WarmupCount=1)
  PengaduanFasilitasPerformanceTests.CariPengaduanFasilitas_Performance: Job-IBHMJY(IterationCount=3, WarmupCount=1)
  PengaduanFasilitasPerformanceTests.UpdatePengaduanFasilitas_Performance: Job-IBHMJY(IterationCount=3, WarmupCount=1)
  PengaduanFasilitasPerformanceTests.UbahStatusFasilitas_Performance: Job-IBHMJY(IterationCount=3, WarmupCount=1)
  PengaduanFasilitasPerformanceTests.HitungStatistikFasilitas_Performance: Job-IBHMJY(IterationCount=3, WarmupCount=1)
