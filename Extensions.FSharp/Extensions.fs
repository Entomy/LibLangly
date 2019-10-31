namespace Stringier

open System

[<AutoOpen>]
module Extensions =
    /// <summary>
    /// Chop the <paramref name="source"/> into chunks of <paramref name="size"/>
    /// </summary>
    /// <param name="source">String to chop</param>
    /// <param name="size">Size of chunks to chop into</param>
    /// <returns>Array of chunks</returns>
    let chop(size:Int32)(source:String):String[] = source.Chop(size)