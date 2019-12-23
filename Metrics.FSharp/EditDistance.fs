namespace Stringier

[<AutoOpen>]
module EditDistance =
    let hamming(source:string)(other:string) = Metrics.HammingDistance(source, other);

    let levenshtein(source:string)(other:string) = Metrics.HammingDistance(source, other);