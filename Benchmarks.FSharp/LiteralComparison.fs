namespace Benchmarks

open System.Text.Patterns
open FParsec
open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Diagnosers

[<ClrJob>]
[<MemoryDiagnoser>]
type LiteralComparison() =
    let pattern = p"Hello"
    let parsec = attempt (pstringCI "Hello")

    [<Params("Hello", "World", "H")>]
    member val Source = "" with get, set

    [<Benchmark>]
    member this.PatternConsume() = pattern.Consume(this.Source)

    [<Benchmark(Baseline = true)>]
    member this.ParsecRun() = run parsec this.Source