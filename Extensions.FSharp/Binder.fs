namespace Stringier

open System

module Bindings =
    type Binder =
        static member Contains(source:string, value:char) = source.Contains(value)
        static member Contains(source:string, value:string) = source.Contains(value)
        static member Contains(source:seq<string>, value:char) = source.Contains(value)
        static member Contains(source:seq<string>, value:string) = source.Contains(value)
        static member FuzzyEquals(source:string, other:string) = source.FuzzyEquals(other)
        static member FuzzyEquals(source:string, other:ReadOnlySpan<Char>) = source.FuzzyEquals(other)
        static member FuzzyEquals(source:ReadOnlySpan<Char>, other:string) = source.FuzzyEquals(other)
        static member FuzzyEquals(source:ReadOnlySpan<Char>, other:ReadOnlySpan<Char>) = source.FuzzyEquals(other)
        static member FuzzyEquals2(source:string, other:string, maxEdits:int32) = source.FuzzyEquals(other, maxEdits)
        static member FuzzyEquals2(source:string, other:ReadOnlySpan<Char>, maxEdits:int32) = source.FuzzyEquals(other, maxEdits)
        static member FuzzyEquals2(source:ReadOnlySpan<Char>, other:string, maxEdits:int32) = source.FuzzyEquals(other, maxEdits)
        static member FuzzyEquals2(source:ReadOnlySpan<Char>, other:ReadOnlySpan<Char>, maxEdits:int32) = source.FuzzyEquals(other, maxEdits)
        static member IsPalindrome(source:string) = source.IsPalindrome()
        static member IsPalindrome(source:ReadOnlySpan<Char>) = source.IsPalindrome()
        static member Join(sequence:char[]) = sequence.Join()
        static member Join(sequence:seq<char>) = sequence.Join()
        static member Join(sequence:seq<string>) = sequence.Join()
        static member Join2(sequence:seq<char>, separator:char) = sequence.Join(separator)
        static member Join2(sequence:seq<string>, separator:char) = sequence.Join(separator)
        static member Join2(sequence:seq<obj>, separator:char) = sequence.Join(separator)
        static member Occurrences(source:string, value:char) = source.Occurrences(value)
        static member Occurrences(source:string, values:char[]) = source.Occurrences(values)
        static member Occurrences(source:seq<string>, value:char) = source.Occurrences(value)
        static member Occurrences(source:seq<string>, values:char[]) = source.Occurrences(values)
        static member Repeat(text:char, count:int32) = text.Repeat(count)
        static member Repeat(text:string, count:int32) = text.Repeat(count)
        static member Split(source:string, separator:char) = source.Split(separator)
        static member Split(source:string, separators:char[]) = source.Split(separators)
        static member Split(source:string, separator:string) = source.Split(separator)
        static member Split(source:string, separators:string[]) = source.Split(separators)

    let inline _contains< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Contains : ^a * ^b -> ^c)> value source = ((^t or ^a) : (static member Contains : ^a * ^b -> ^c)(source, value))

    let inline _fuzzyEqual< ^t, ^a, ^b when (^t or ^a) : (static member FuzzyEquals : ^a * ^b -> bool)> other source = ((^t or ^a) : (static member FuzzyEquals : ^a * ^b -> bool)(source, other))

    let inline _fuzzyEqual2< ^t, ^a, ^b when (^t or ^a) : (static member FuzzyEquals : ^a * ^b * int32 -> bool)> other maxEdits source = ((^t or ^a) : (static member FuzzyEquals : ^a * ^b * int32 -> bool)(source, other, maxEdits))

    let inline _isPalindrome< ^t, ^a when (^t or ^a) : (static member IsPalindrome : ^a -> bool)> source = ((^t or ^a) : (static member IsPalindrome : ^a -> bool)(source))

    let inline _join< ^t, ^a, ^b when (^t or ^a) : (static member Join : ^a -> ^b)> sequence = ((^t or ^a) : (static member Join : ^a -> ^b)(sequence))

    let inline _join2< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Join2: ^a * ^b -> ^c)> separator sequence = ((^t or ^a) : (static member Join2 : ^a * ^b -> ^c)(sequence, separator))

    let inline _occurrences< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Occurrences : ^a * ^b -> ^c)> value source = ((^t or ^a) : (static member Occurrences : ^a * ^b -> ^c)(source, value))

    let inline _repeat< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Repeat : ^a * ^b -> ^c)> count text = ((^t or ^a) : (static member Repeat : ^a * ^b -> ^c)(text, count))

    let inline _split< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Split : ^a * ^b -> ^c)> separator source = ((^t or ^a) : (static member Split : ^a * ^b -> ^c)(source, separator))