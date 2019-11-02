namespace Stringier

open System
open System.Collections.Generic

[<AutoOpen>]
module Extensions =
    /// <summary>
    /// Chop the <paramref name="source"/> into chunks of <paramref name="size"/>
    let chop(size:int32)(source:string):string[] = source.Chop(size)

    /// <summary>
    /// Trim and replace multiple spaces with a single space
    /// </summary>
    let clean(source:string):string = source.Clean();

    /// <summary>
    /// Trim and replace multiples of the specified character with just a single character
    /// </summary>
    let clean2(char:char)(source:string):string = source.Clean(char);

    let contains(value:obj)(source:obj):bool =
        match value, source with
        | (:? char as char), (:? string as string) -> string.Contains(char)
        | (:? char as char), (:? seq<string> as sequence) -> sequence.Contains(char)
        | (:? string as string), (:? string as text) -> text.Contains(string)
        | (:? string as string), (:? seq<string> as sequence) -> sequence.Contains(string)
        | _ -> raise(ArgumentException("Not sure how to handle this combination of type arguments"))

    /// <summary>
    /// Ensures the source begins with the required string, adding it if necessary.
    /// </summary>
    let ensureBegins(required:string)(source:string) = source.EnsureBeginsWith(required)

    /// <summary>
    /// Ensures the source ends with the required string, adding it if necessary.
    /// </summary>
    let ensureEnds(required:string)(source:string) = source.EnsureEndsWith(required)

    let inline internal ijoin< ^t, ^a, ^b when (^t or ^a) : (static member Join : ^a -> ^b)> sequence = ((^t or ^a) : (static  member Join : ^a -> ^b)(sequence))

    /// <summary>
    /// Joins the sequence into a string.
    /// </summary>
    let join(sequence:obj) =
        match sequence with
        | :? IEnumerable<char> as charSeq -> ijoin<StringierExtensions, IEnumerable<char>, string> charSeq
        | :? IEnumerable<string> as stringSeq -> ijoin<StringierExtensions, IEnumerable<string>, string> stringSeq
        | _ -> raise(ArgumentException("Not sure how to join this sequence"))

    let inline internal ijoin2< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Join : ^a * ^b -> ^c)> separator sequence = ((^t or ^a) : (static  member Join : ^a * ^b -> ^c)(sequence, separator))

    /// <summary>
    /// Joins the sequence into a string, interleaving the specified separator
    /// </summary>
    let join2(separator:'a)(sequence:obj) = 
        match sequence with
        | :? IEnumerable<char> as charSeq -> ijoin2<StringierExtensions, _, _, string> separator charSeq
        | :? IEnumerable<string> as stringSeq -> ijoin2<StringierExtensions, _, _, string> separator stringSeq
        | _ -> raise(ArgumentException("Not sure how to join this sequence"))
    

    /// <summary>
    /// Separate the <paramref name="String"/> into its lines.
    /// </summary>
    let lines(source:string) = source.Lines()

    /// <summary>
    /// Count all occurences of seek in source
    /// </summary>
    let occurrences(seek:obj)(source:obj) =
        match source, seek with
        | (:? string as string), (:? char as char) -> string.Occurrences(char)
        | (:? string as string), (:? array<char> as chars) -> string.Occurrences(chars)
        | (:? seq<string> as strings), (:? char as char) -> strings.Occurrences(char)
        | (:? seq<string> as strings), (:? array<char> as chars) -> strings.Occurrences(chars)
        | _ -> raise(ArgumentException("Not sure how to count occurences for these types"))

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
    let repeat(count:int32)(text:obj) =
        match text with
        | :? char as char -> char.Repeat(count)
        | :? string as string -> string.Repeat(count)
        | _ -> raise(ArgumentException("Not sure how to repeat the text type; it might not be text"))