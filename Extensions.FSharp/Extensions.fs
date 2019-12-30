namespace Stringier

open Bindings

[<AutoOpen>]
module Extensions =
    /// <summary>
    /// Chop the <paramref name="source"/> into chunks of <paramref name="size"/>
    /// </summary>
    let chop(size:int32)(source:string):string[] = source.Chop(size)

    /// <summary>
    /// Trim and replace multiple spaces with a single space
    /// </summary>
    let clean(source:string):string = source.Clean();

    /// <summary>
    /// Trim and replace multiples of the specified character with just a single character
    /// </summary>
    let clean2(char:char)(source:string):string = source.Clean(char);

    /// <summary>
    /// Tests whether the value is contained in the source
    /// </summary>
    let inline contains(value)(source):bool = _contains<Binder, _, _, _> value source

    /// <summary>
    /// Ensures the source begins with the required string, adding it if necessary.
    /// </summary>
    let ensureBegins(required:string)(source:string) = source.EnsureBeginsWith(required)

    /// <summary>
    /// Ensures the source ends with the required string, adding it if necessary.
    /// </summary>
    let ensureEnds(required:string)(source:string) = source.EnsureEndsWith(required)

    /// <summary>
    /// Determines whether two specified text objects have roughly the same value.
    /// </summary>
    let inline fuzzyEqual(other)(source):bool = _fuzzyEqual<Binder, _, _> other source

    /// <summary>
    /// Determines whether two specified text objects have roughly the same value.
    /// </summary>
    let inline fuzzyEqual2(other)(maxEdits)(source):bool = _fuzzyEqual2<Binder, _, _> other maxEdits source

    /// <summary>
    /// Joins the sequence into a string.
    /// </summary>
    let inline join(sequence) = _join<Binder, _, _> sequence

    /// <summary>
    /// Joins the sequence into a string, interleaving the specified separator
    /// </summary>
    let inline join2(separator)(sequence) = _join2<Binder, _, _, _> separator sequence
    
    /// <summary>
    /// Separate the <paramref name="String"/> into its lines.
    /// </summary>
    let lines(source:string) = source.Lines()

    /// <summary>
    /// Count all occurences of seek in source
    /// </summary>
    let inline occurrences(seek)(source) = _occurrences<Binder, _, _, _> seek source

    /// <summary>
    /// Returns a new string that center-aligns the characters in this instance by padding them with spaces on both sides, for a specified total length.
    /// </summary>
    let pad(totalWidth)(string:string) = string.Pad(totalWidth)

    /// <summary>
    /// Returns a new string that center-aligns the characters in this instance by padding them with spaces on both sides, for a specified total length.
    /// </summary>
    let pad2(totalWidth)(padding)(string:string) = string.Pad(totalWidth, padding)

    /// <summary>
    /// Repeat the text, count times.
    /// </summary>
    let inline repeat(count:int32)(text:^a):^c = _repeat<Binder, ^a, int32, ^c> count text

    /// <summary>
    /// Splits a string into substrings based on the separator(s).
    /// </summary>
    let inline split(separator)(source) = _split<Binder, _, _, _> separator source

    /// <summary>
    /// Squeezes the string, collapsing all adjacent identical characters to single characters.
    /// </summary>
    let squeeze(string:string) = string.Squeeze()

    /// <summary>
    /// Separate the string into its words.
    /// </summary>
    let words(source:string) = source.Words()