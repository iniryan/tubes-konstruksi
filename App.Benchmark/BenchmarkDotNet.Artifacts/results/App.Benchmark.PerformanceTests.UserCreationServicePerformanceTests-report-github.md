```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.4351)
AMD Ryzen 7 5800HS with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.300
  [Host]     : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX2
  Job-IYLCES : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX2

IterationCount=5  WarmupCount=2  

```
| Method                                      | Mean      | Error     | StdDev    | Gen0      | Gen1      | Gen2     | Allocated |
|-------------------------------------------- |----------:|----------:|----------:|----------:|----------:|---------:|----------:|
| CreateNewUser_Performance                   | 318.42 ms | 16.468 ms |  4.277 ms | 5000.0000 | 4500.0000 |        - |  40.14 MB |
| CreateUserWithSpecialCharacters_Performance | 169.85 ms |  7.101 ms |  1.099 ms | 3000.0000 | 2333.3333 |        - |  24.35 MB |
| CreateDuplicateUsernames_Performance        | 346.93 ms | 85.094 ms | 22.099 ms | 5000.0000 | 3000.0000 |        - |  42.08 MB |
| GetAllUsers_Performance                     |  31.83 ms |  1.541 ms |  0.238 ms | 1750.0000 | 1375.0000 |        - |  14.11 MB |
| GetTotalUsersCount_Performance              |  64.37 ms |  2.121 ms |  0.328 ms | 3500.0000 | 2625.0000 |        - |  28.59 MB |
| MixedUserCreationOperations_Performance     | 115.50 ms |  2.698 ms |  0.701 ms | 2800.0000 | 2000.0000 | 400.0000 |  22.42 MB |
