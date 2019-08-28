``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i5-6500 CPU 3.20GHz (Skylake), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=3.0.100-preview7-012821
  [Host] : .NET Core 2.2.2 (CoreCLR 4.6.27317.07, CoreFX 4.6.27318.02), 64bit RyuJIT
  Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.8.3815.0
  Core   : .NET Core 2.2.2 (CoreCLR 4.6.27317.07, CoreFX 4.6.27318.02), 64bit RyuJIT
  CoreRT : .NET CoreRT 1.0.27527.01 @BuiltBy: dlab14-DDVSOWINAGE101 @Branch: master @Commit: bd07c4e0727fa104d50e28ed70ca9bb480dcbc1b, 64bit AOT


```
|             Method |    Job | Runtime |      Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------- |------- |-------- |----------:|----------:|----------:|-------:|------:|------:|----------:|
|     CommentPattern |    Clr |     Clr | 10.341 us | 0.0454 us | 0.0424 us | 0.6561 |     - |     - |    2102 B |
|       CommentRegex |    Clr |     Clr |  3.029 us | 0.0518 us | 0.0485 us | 1.6861 |     - |     - |    5312 B |
|  IdentifierPattern |    Clr |     Clr |  1.646 us | 0.0088 us | 0.0083 us | 0.0858 |     - |     - |     273 B |
|    IdentifierRegex |    Clr |     Clr |  4.629 us | 0.0678 us | 0.0634 us | 2.1362 |     - |     - |    6724 B |
| IPv4AddressPattern |    Clr |     Clr |  2.046 us | 0.0142 us | 0.0133 us | 0.3319 |     - |     - |    1051 B |
|   IPv4AddressRegex |    Clr |     Clr |  6.582 us | 0.0802 us | 0.0670 us | 2.4948 |     - |     - |    7871 B |
| PhoneNumberPattern |    Clr |     Clr |  1.229 us | 0.0067 us | 0.0062 us | 0.1602 |     - |     - |     505 B |
|   PhoneNumberRegex |    Clr |     Clr |  3.178 us | 0.0276 us | 0.0258 us | 1.4191 |     - |     - |    4469 B |
|      StringPattern |    Clr |     Clr |  2.883 us | 0.0168 us | 0.0157 us | 0.2861 |     - |     - |     907 B |
|        StringRegex |    Clr |     Clr |  4.378 us | 0.0864 us | 0.0888 us | 2.3727 |     - |     - |    7470 B |
|  WebAddressPattern |    Clr |     Clr |  4.432 us | 0.0403 us | 0.0377 us | 0.5646 |     - |     - |    1789 B |
|    WebAddressRegex |    Clr |     Clr | 12.292 us | 0.1782 us | 0.1667 us | 5.7983 |     - |     - |   18262 B |
|     CommentPattern |   Core |    Core | 10.929 us | 0.0511 us | 0.0478 us | 0.6561 |     - |     - |    2096 B |
|       CommentRegex |   Core |    Core |  2.948 us | 0.0317 us | 0.0296 us | 1.3428 |     - |     - |    4232 B |
|  IdentifierPattern |   Core |    Core |  1.545 us | 0.0049 us | 0.0046 us | 0.0858 |     - |     - |     272 B |
|    IdentifierRegex |   Core |    Core |  4.852 us | 0.1153 us | 0.1079 us | 1.7395 |     - |     - |    5480 B |
| IPv4AddressPattern |   Core |    Core |  1.951 us | 0.0146 us | 0.0137 us | 0.3319 |     - |     - |    1048 B |
|   IPv4AddressRegex |   Core |    Core |  6.572 us | 0.0509 us | 0.0425 us | 1.9913 |     - |     - |    6280 B |
| PhoneNumberPattern |   Core |    Core |  1.157 us | 0.0061 us | 0.0057 us | 0.1583 |     - |     - |     504 B |
|   PhoneNumberRegex |   Core |    Core |  3.178 us | 0.0380 us | 0.0355 us | 1.1024 |     - |     - |    3472 B |
|      StringPattern |   Core |    Core |  2.889 us | 0.0223 us | 0.0198 us | 0.2861 |     - |     - |     904 B |
|        StringRegex |   Core |    Core |  4.620 us | 0.0787 us | 0.0736 us | 1.9684 |     - |     - |    6208 B |
|  WebAddressPattern |   Core |    Core |  4.282 us | 0.0282 us | 0.0264 us | 0.5646 |     - |     - |    1784 B |
|    WebAddressRegex |   Core |    Core | 13.305 us | 0.2125 us | 0.1988 us | 5.1117 |     - |     - |   16104 B |
|     CommentPattern | CoreRT |  CoreRT |  9.385 us | 0.0590 us | 0.0492 us | 0.5341 |     - |     - |    1699 B |
|       CommentRegex | CoreRT |  CoreRT |  2.378 us | 0.0467 us | 0.0654 us | 1.2627 |     - |     - |    3964 B |
|  IdentifierPattern | CoreRT |  CoreRT |  1.461 us | 0.0078 us | 0.0073 us | 0.0858 |     - |     - |     271 B |
|    IdentifierRegex | CoreRT |  CoreRT |  3.680 us | 0.0545 us | 0.0509 us | 1.6327 |     - |     - |    5129 B |
| IPv4AddressPattern | CoreRT |  CoreRT |  1.769 us | 0.0193 us | 0.0181 us | 0.3242 |     - |     - |    1021 B |
|   IPv4AddressRegex | CoreRT |  CoreRT |  5.046 us | 0.0836 us | 0.0782 us | 1.8692 |     - |     - |    5871 B |
| PhoneNumberPattern | CoreRT |  CoreRT |  1.109 us | 0.0084 us | 0.0078 us | 0.1583 |     - |     - |     503 B |
|   PhoneNumberRegex | CoreRT |  CoreRT |  2.536 us | 0.0503 us | 0.0932 us | 1.0185 |     - |     - |    3207 B |
|      StringPattern | CoreRT |  CoreRT |  2.567 us | 0.0100 us | 0.0093 us | 0.2556 |     - |     - |     806 B |
|        StringRegex | CoreRT |  CoreRT |  3.371 us | 0.0160 us | 0.0142 us | 1.8578 |     - |     - |    5839 B |
|  WebAddressPattern | CoreRT |  CoreRT |  3.862 us | 0.0197 us | 0.0185 us | 0.5569 |     - |     - |    1771 B |
|    WebAddressRegex | CoreRT |  CoreRT |  9.896 us | 0.0733 us | 0.0685 us | 4.9286 |     - |     - |   15475 B |
