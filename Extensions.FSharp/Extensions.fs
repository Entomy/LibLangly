namespace Stringier

open System

[<AutoOpen>]
module Extensions =
    /// <summary>
    /// Chop the <paramref name="source"/> into chunks of <paramref name="size"/>
    let chop(size:Int32)(source:String):String[] = source.Chop(size)

    /// <summary>
    /// Trim and replace multiple spaces with a single space
    /// </summary>
    let clean(source:String):String = source.Clean();

    /// <summary>
    /// Trim and replace multiples of the specified character with just a single character
    /// </summary>
    let clean2(char:Char)(source:String):String = source.Clean(char);