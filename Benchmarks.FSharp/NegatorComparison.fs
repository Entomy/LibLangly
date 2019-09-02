namespace Benchmarks

open System.Text.Patterns
open FParsec
open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Diagnosers

[<ClrJob>]
[<MemoryDiagnoser>]
type NegatorComparison() =
    let pattern = -"Hello"
    let parsec = attempt (noneOf "H" .>>. noneOf "e" .>>. noneOf "l" .>>. noneOf "l" .>>. noneOf "o")

    [<Params("World", "Hello")>]
    member val Source = "" with get, set

    [<Benchmark>]
    member this.PatternConsume() = pattern.Consume(this.Source)

    [<Benchmark>]
    member this.ParsecRun() = run parsec this.Source