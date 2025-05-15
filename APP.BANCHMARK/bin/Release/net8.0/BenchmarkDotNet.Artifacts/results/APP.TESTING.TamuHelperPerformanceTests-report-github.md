```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.5335/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12650H, 1 CPU, 16 logical and 10 physical cores
.NET SDK 9.0.203
  [Host]     : .NET 8.0.15 (8.0.1525.16413), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.15 (8.0.1525.16413), X64 RyuJIT AVX2


```
| Method           | Mean     | Error   | StdDev  |
|----------------- |---------:|--------:|--------:|
| TestCariTamu     | 456.9 μs | 1.88 μs | 1.57 μs |
| TestHitungHarian | 310.7 μs | 2.95 μs | 2.61 μs |
