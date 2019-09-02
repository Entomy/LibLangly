namespace Benchmarks

open System.Text.Patterns
open FParsec
open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Diagnosers

[<ClrJob>]
[<MemoryDiagnoser>]
type ConcatenatorComparison() =
    let pattern = "Hello" >> ' ' >> "World"
    let parsec = attempt (pstringCI "Hello" .>>. pchar ' ' .>>. pstringCI "World")

    [<Params("Hello World", "Hello")>]
    member val Source = "" with get, set

    [<Benchmark>]
    member this.PatternConsume() = pattern.Consume(this.Source)

    [<Benchmark(Baseline = true)>]
    member this.ParsecRun() = run parsec this.Source

