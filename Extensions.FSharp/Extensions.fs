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
    let join(sequence:seq<char>) = ijoin<StringierExtensions, seq<char>, string> sequence

    let inline internal ijoin2< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Join : ^a * ^b -> ^c)> separator sequence = ((^t or ^a) : (static  member Join : ^a * ^b -> ^c)(sequence, separator))

    /// <summary>
    /// Joins the sequence into a string, interleaving the specified separator
    /// </summary>
    let join2(separator:'a)(sequence:seq<char>) = ijoin2<StringierExtensions, _, _, string> separator sequence
    
    /// <summary>
    /// Repeat the char, count times.
    /// </summary>
    let repeat(count:int32)(char:char) = char.Repeat(count)