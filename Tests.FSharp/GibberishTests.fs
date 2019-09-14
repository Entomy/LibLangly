namespace Tests.FSharp

open System.IO
open System.Text
open System.Text.Patterns
open System.Text.RegularExpressions
open Microsoft.VisualStudio.TestTools.UnitTesting
open FParsec

[<TestClass>]
type GibberishTests () =
    [<TestMethod>]
    member this.PatternTest() =
        let mutable source = new Source(Gibberish.Generate(16))
        let word:Pattern = +(check "letter" (fun (char) -> 'a' <= char && char <= 'z'))
        let space:Pattern = +' '
        let doc:Pattern = +(word || space) >> Source.End
        Assert.That.Succeeds(doc.Consume(&source))

    [<TestMethod>]
    member this.RegexTest() =
        let regex = new Regex(@"(?:[a-z]+| +)+$", RegexOptions.Singleline);
        Assert.IsTrue(regex.IsMatch(Gibberish.Generate(16)))

    [<TestMethod>]
    member this.FParsecTest() =
        let word = many1Chars (anyOf "abcdefghijklmnopqrstuvwxyz")
        let space = many1Chars (pchar ' ')
        let doc = many(word <|> space) .>>. eof
        let result = run doc (Gibberish.Generate(16))
        match result with
        | Success(_, _, _) -> ()
        | Failure(_, _, _) -> Assert.Fail()