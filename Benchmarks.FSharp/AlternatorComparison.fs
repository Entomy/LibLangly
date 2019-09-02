namespace Benchmarks

open System
open System.Text.Patterns
open FParsec
open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Diagnosers

[<ClrJob>]
[<MemoryDiagnoser>]
type AlternatorComparison() =
    let pattern = "Hello" || "Goodbye"
    let parsec = attempt (pstringCI "Hello" <|> pstringCI "Goodbye")

    [<Params("Hello", "Goodbye", "Bacon")>]
    member val Source = "" with get, set

    [<Benchmark>]
    member this.PatternConsume() = pattern.Consume(this.Source)

    [<Benchmark(Baseline = true)>]
    member this.ParsecRun() = run parsec this.Source