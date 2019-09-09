namespace Benchmarks

open System.Text.Patterns
open FParsec
open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Diagnosers

[<ClrJob>]
[<MemoryDiagnoser>]
type FailureComparison() =
    let pattern = Pattern.Number * 3 >> '-' >> Pattern.Number * 3 >> '-' >> Pattern.Number * 4;
    let parsec = attempt (digit .>>. digit .>>. digit .>>. pchar '-' .>>. digit .>>. digit .>>. digit .>>. pchar '-' .>>. digit .>>. digit .>>. digit .>>. digit)

    [<Benchmark>]
    member this.PatternFail() = pattern.Consume("555-555-Narwhal");

    [<Benchmark>]
    member this.ParsecFail() = run parsec "555-555-Narwhal"