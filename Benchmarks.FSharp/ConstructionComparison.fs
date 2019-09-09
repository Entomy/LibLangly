namespace Benchmarks

open System.Text.Patterns
open FParsec
open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Diagnosers

[<ClrJob>]
[<MemoryDiagnoser>]
type ConstructionComparison() =
    [<Benchmark>]
    member this.PatternLiteral() = p"Hello"

    [<Benchmark>]
    member this.PatternComplex() = Pattern.Number * 3 >> '-' >> Pattern.Number * 3 >> '-' >> Pattern.Number * 4

    [<Benchmark>]
    member this.ParsecLiteral():Parser<_, Unit> = pstring "Hello"

    [<Benchmark>]
    member this.ParsecComplex():Parser<_, Unit> = attempt (digit .>>. digit .>>. digit .>>. pchar '-' .>>. digit .>>. digit .>>. digit .>>. pchar '-' .>>. digit .>>. digit .>>. digit .>>. digit)
