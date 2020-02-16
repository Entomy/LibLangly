namespace Stringier

open System

[<AutoOpen>]
module EditDistance =
    type Binder =
        static member Hamming(source:string, other:string) = Metrics.HammingDistance(source, other)
        static member Hamming(source:char[], other:char[]) = Metrics.HammingDistance(source, other)

    let inline private _hamming< ^t, ^a, ^b when (^t or ^a) : (static member Hamming : ^a * ^b -> int)> source other = ((^t or ^a) : (static member Hamming : ^a * ^b -> int)(source, other))

    /// <summary>
    /// Calculates the Hamming edit-distance between source and other
    /// </summary>
    let inline hamming(source:^a)(other:^b):int32 = _hamming<Binder, ^a, ^b> source other

    /// <summary>
    /// Calculates the Levenshtein edit-distance between source and other
    /// </summary>
    let levenshtein(source:string)(other:string):int32 = Metrics.LevenshteinDistance(source, other);