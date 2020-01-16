namespace Stringier

[<AutoOpen>]
module EditDistance =
    /// <summary>
    /// Calculates the Hamming edit-distance between source and other
    /// </summary>
    let hamming(source:string)(other:string):int32 = Metrics.HammingDistance(source, other);

    /// <summary>
    /// Calculates the Levenshtein edit-distance between source and other
    /// </summary>
    let levenshtein(source:string)(other:string):int32 = Metrics.LevenshteinDistance(source, other);