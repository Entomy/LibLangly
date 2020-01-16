namespace Stringier

[<AutoOpen>]
module Search =
    /// <summary>
    /// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the pattern, if found, in the source, else returns -1.
    /// </summary>
    let horspool(source:string)(pattern:string):int32 = Search.Horspool(source, pattern)

    /// <summary>
    /// Performs the Rabin-Karp string-search, finding the starting index of the pattern, if found, in the source, else returns -1.
    /// </summary>
    let rabinKarp(source:string)(pattern:string):int32 = Search.RabinKarp(source, pattern)