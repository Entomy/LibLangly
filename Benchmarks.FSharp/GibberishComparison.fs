namespace Benchmarks

open System
open System.IO
open System.Text
open System.Text.Patterns
open FParsec
open BenchmarkDotNet.Attributes

[<ClrJob>]
[<MemoryDiagnoser>]
type GibberishComparison() =
    let patternWord:Pattern = +(check "letter" (new Func<Char,Boolean>(fun (char) -> 'a' <= char && char <= 'z')))
    let patternSpace:Pattern = +' '
    let pattern:Pattern = +(patternWord || patternSpace) >> Pattern.EndOfSource

    let parsecWord = many1Chars (anyOf "abcdefghijklmnopqrstuvwxyz")
    let parsecSpace = many1Chars (pchar ' ')
    let parsec = many(parsecWord <|> parsecSpace) .>>. eof

    let gibberish = Gibberish.Generate(4)
    let badGibberish = Gibberish.Generate(4, Bad=true)

    [<Benchmark>]
    member this.PatternGood() =
        let mutable source = new Source(gibberish)
        let result = pattern.Consume(&source)
        ()

    [<Benchmark>]
    member this.PatternBad() =
        let mutable source = new Source(badGibberish)
        let result = pattern.Consume(&source)
        ()

    [<Benchmark>]
    member this.FParsecGood() =
        let result = run parsec gibberish
        ()

    [<Benchmark>]
    member this.FParsecBad() =
        let result = run parsec badGibberish
        ()