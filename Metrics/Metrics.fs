namespace Stringier

open System

[<AutoOpen>]
module Metrics =
    [<CompiledName("HammingDistance")>]
    let hamming(source:string)(other:string) =
        if source.Length <> other.Length then
            raise(ArgumentException("Must be equal length", other))
        else
            let mutable dist = 0
            (source, other) ||> Seq.iter2 (fun s o -> if s <> o then dist <- dist + 1)
            dist

    [<CompiledName("LevenshteinDistance")>]
    let levenshtein(source:string)(other:string) =
        let n = source.Length
        let m = other.Length

        let d:int32[,] = Array2D.zeroCreate (n+1) (m+1)

        if n = 0 then
            m
        else if m = 0 then
            n
        else
            for i=0 to source.Length do d.[i, 0] <- i
            for j=0 to other.Length do d.[0, j] <- j
            for j=1 to other.Length do
                for i=1 to source.Length do
                    if source.[i - 1] = other.[j - 1] then
                        d.[i, j] <- d.[i - 1, j - 1]
                    else
                        d.[i, j] <- List.min ([
                            d.[i-1, j] + 1;
                            d.[i, j-1] + 1;
                            d.[i-1, j-1] + 1])
            d.[source.Length, other.Length]