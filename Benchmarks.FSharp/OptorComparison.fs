namespace Benchmarks

open System.Text.Patterns
open FParsec
open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Diagnosers

[<ClrJob>]
[<MemoryDiagnoser>]
type OptorComparison() =
    let pattern = ~~"Hello"
    let parsec = attempt (opt (pstringCI "Hello"))

    [<Params("Hello", "World")>]
    member val Source = "" with get, set

    [<Benchmark>]
    member this.PatternConsume() = pattern.Consume(this.Source)

    [<Benchmark>]
    member this.ParsecRun() = run parsec this.Source
