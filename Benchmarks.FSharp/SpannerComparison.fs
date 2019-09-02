namespace Benchmarks

open System.Text.Patterns
open FParsec
open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Diagnosers

[<ClrJob>]
[<MemoryDiagnoser>]
type SpannerComparison() =
    let pattern = +"Hi!"
    let parsec = attempt (many1Strings (pstringCI "Hi!"))

    [<Params("Hi!Hi!", "Hi!Hi!Hi!", "Hi!", "Okay?")>]
    member val Source = "" with get, set

    [<Benchmark>]
    member this.PatternConsume() = pattern.Consume(this.Source)

    [<Benchmark(Baseline = true)>]
    member this.ParsecRun() = run parsec this.Source