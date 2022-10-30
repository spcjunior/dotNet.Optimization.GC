# dotNet.Optimization.GC


references
 - https://youtube.com/playlist?list=PLkpjQs-GfEMMnpee9DgjhZl1JEqyAWIm9
 - https://eximia.co/melhorando-a-performance-de-aplicacoes-net-com-value-types-bem-implementados/





| Method |       Mean |    Error |   StdDev |     Median |         Gen0 |    Allocated |
|------- |-----------:|---------:|---------:|-----------:|-------------:|-------------:|
|  CpfV1 | 1,800.8 ms | 34.07 ms | 55.98 ms | 1,776.8 ms | 1101000.0000 | 1728000544 B |
|  CpfV2 |   912.1 ms | 22.85 ms | 63.71 ms |   881.9 ms |  244000.0000 |  384000544 B |
|  CpfV3 | 1,093.7 ms | 21.45 ms | 30.06 ms | 1,083.7 ms |            - |        592 B |
|  CpfV4 |   238.4 ms |  2.94 ms |  2.75 ms |   237.2 ms |            - |       1275 B |

*Legends*

 - Mean      : Arithmetic mean of all measurements
 - Error     : Half of 99.9% confidence interval
 - StdDev    : Standard deviation of all measurements
 - Median    : Value separating the higher half of all measurements (50th percentile)
 - Gen0      : GC Generation 0 collects per 1000 operations
 - Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
 - 1 ms      : 1 Millisecond (0.001 sec)
