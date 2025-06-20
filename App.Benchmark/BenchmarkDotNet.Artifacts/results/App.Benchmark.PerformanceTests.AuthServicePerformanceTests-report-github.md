```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.4351)
AMD Ryzen 7 5800HS with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.300
  [Host]     : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX2
  Job-IYLCES : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX2

IterationCount=5  WarmupCount=2  

```
| Method                          | Mean              | Error             | StdDev           | Gen0      | Gen1     | Allocated |
|-------------------------------- |------------------:|------------------:|-----------------:|----------:|---------:|----------:|
| RegisterUser_Performance        | 218,018,833.33 ns | 38,323,668.784 ns | 5,930,630.156 ns | 1000.0000 | 333.3333 | 9161171 B |
| LoginUser_Performance           |          22.70 ns |          1.790 ns |         0.465 ns |    0.0057 |        - |      48 B |
| GetAllUsers_Performance         |  11,132,865.00 ns |  2,482,301.360 ns |   644,645.782 ns |  562.5000 | 312.5000 | 4738170 B |
| MixedAuthOperations_Performance |  68,792,784.44 ns | 18,934,751.295 ns | 4,917,294.792 ns |  555.5556 | 333.3333 | 4818054 B |
