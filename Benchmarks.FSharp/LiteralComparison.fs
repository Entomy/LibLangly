namespace Benchmarks

open System.Text.Patterns
open FParsec
open BenchmarkDotNet.Attributes

[<ClrJob; CoreJob; CoreRtJob>]
type LiteralComparison() =
    let literal:Pattern = "hello"
