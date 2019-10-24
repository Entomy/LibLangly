namespace Benchmarks

open System
open BenchmarkDotNet.Running

module Program =
    [<EntryPoint>]
    let main argv = 
        BenchmarkRunner.Run<AlternatorComparison>() |> ignore
        BenchmarkRunner.Run<ConcatenatorComparison>() |> ignore
        BenchmarkRunner.Run<LiteralComparison>() |> ignore
        BenchmarkRunner.Run<NegatorComparison>() |> ignore
        BenchmarkRunner.Run<OptorComparison>() |> ignore
        BenchmarkRunner.Run<SpannerComparison>() |> ignore
        BenchmarkRunner.Run<FailureComparison>() |> ignore
        BenchmarkRunner.Run<ConstructionComparison>() |> ignore
        BenchmarkRunner.Run<CompoundPatternComparison>() |> ignore
        BenchmarkRunner.Run<GibberishComparison>() |> ignore
        0
