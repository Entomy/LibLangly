namespace Tests.FSharp

open System.IO
open System.Text
open System.Text.Patterns
open System.Text.RegularExpressions
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type GibberishTests () =
    [<TestMethod>]
    member this.PatternTest() =
        let mutable source = new Source(Gibberish.Generate(128))
        let word:Pattern = +(check "letter" (fun (char) -> 'a' <= char && char <= 'z'))
        let space:Pattern = +' '
        let doc:Pattern = +(word || space) >> Pattern.EndOfSource
        ResultAssert.Succeeds(doc.Consume(&source))

    [<TestMethod>]
    member this.RegexTest() =
        let regex = new Regex(@"(?:[a-z]+| +)+$", RegexOptions.Singleline);
        Assert.IsTrue(regex.IsMatch(Gibberish.Generate(128)))