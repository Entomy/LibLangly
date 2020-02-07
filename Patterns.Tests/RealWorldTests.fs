namespace Patterns

open System
open Stringier
open Stringier.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type RealWorldTests() =
    
    [<TestMethod>]
    member _.``backtracking`` () =
        let end1 = "end" >> many ' ' >> "first"
        let end2 = "end" >> many ' ' >> "second"
        let mutable source = Source("end second")
        //f backtracking doesn't occur, parsing end2 will fail, because "end" and the space will have been consumed
        ResultAssert.Fails(end1.Consume(&source))
        ResultAssert.Captures("end second", end2.Consume(&source))

    [<TestMethod>]
    member _.``comment`` () =
        let pattern = Pattern.LineComment("--")

        ResultAssert.Captures("--This is a comment", pattern.Consume("--This is a comment\n"))
        ResultAssert.Captures("--This is a comment", pattern.Consume("--This is a comment\nExample_Function();"))

    [<TestMethod>]
    member _.``identifier`` () =
        let pattern = Pattern.Check((fun (char:char) -> char.IsLetter()), true,
                                    (fun (char:char) -> char.IsLetter() || char = '_'), true,
                                    (fun (char:char) -> char.IsLetter() || char = '_'), false)
        ResultAssert.Captures("hello", pattern.Consume("hello"))
        ResultAssert.Captures("example_name", pattern.Consume("example_name"))
        ResultAssert.Fails(pattern.Consume("_fail"))

    [<TestMethod>]
    member _.``IPv4 address`` () =
        let digit = Pattern.Check((fun (char:char) -> '0' <= char && char <= '2'), false,
                                  (fun (char:char) -> '0' <= char && char <= '9'), false,
                                  (fun (char:char) -> '0' <= char && char <= '9'), true)
        let address = digit >> '.' >> digit >> '.' >> digit >> '.' >> digit

        ResultAssert.Captures("1", digit.Consume("1"))
        ResultAssert.Captures("11", digit.Consume("11"))
        ResultAssert.Captures("111", digit.Consume("111"))

        ResultAssert.Captures("192.168.1.1", address.Consume("192.168.1.1"))

    [<TestMethod>]
    member _.``named statement`` () =
        let identifier = Pattern.Check(Bias.Head,
                                      (fun (char:char) -> char.IsLetter() || char = '_'),
                                      (fun (char:char) -> char.IsLetterOrDigit() || char = '_'),
                                      (fun (char:char) -> char.IsLetterOrDigit()))
        ResultAssert.Captures("Name", identifier.Consume("Name"))

        let mutable capture = ref null
        let statement = "statement" >> many Pattern.Separator >> (identifier => capture)
        ResultAssert.Captures("statement Name", statement.Consume("statement Name"))
        CaptureAssert.Captures("Name", capture)

    [<TestMethod>]
    member _.``phone number`` () =
        let pattern = Pattern.Number * 3 >> '-' >> Pattern.Number * 3 >> '-' >> Pattern.Number * 4
        let result = pattern.Consume("555-555-5555")
        ResultAssert.Captures("555-555-5555", result)

    [<TestMethod>]
    member _.``read until end of line`` () =
        let pattern = many (not (';' || Pattern.LineTerminator))
        let result = pattern.Consume("hello")
        ResultAssert.Succeeds(result)
        ResultAssert.Captures("hello", result)

    [<TestMethod>]
    member _.``string literal`` () =
        let pattern = Pattern.StringLiteral("\"", "\\\"")
        ResultAssert.Captures("\"hello\\\"world\"", pattern.Consume("\"hello\\\"world\""))

    [<TestMethod>]
    member _.``web address`` () =
        let protocol = "http" >> maybe 's' >> "://"
        let host = many(Pattern.Letter || Pattern.Number || '-') >> '.' >> (Pattern.Letter * 3 >> Pattern.EndOfSource || many(Pattern.Letter || Pattern.Number || '-') >> '.' >> Pattern.Letter * 3)
        let location = many('/' >> many(Pattern.Letter || Pattern.Number || '-' || '_'))
        let address = maybe protocol >> host >> maybe location

        ResultAssert.Captures("http://", protocol.Consume("http://"))
        ResultAssert.Captures("https://", protocol.Consume("https://"))

        ResultAssert.Captures("google.com", host.Consume("google.com"))
        ResultAssert.Captures("www.google.com", host.Consume("www.google.com"))

        ResultAssert.Captures("/about", location.Consume("/about"))

        ResultAssert.Captures("http://www.google.com", address.Consume("http://www.google.com"))
        ResultAssert.Captures("https://www.google.com/about", address.Consume("https://www.google.com/about"))