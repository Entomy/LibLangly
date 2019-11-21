namespace Tests.Patterns

open System
open Stringier.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type RealWorldTests() =
    
    [<TestMethod>]
    member _.``backtracking`` () =
        let end1 = "end" >> span ' ' >> "first"
        let end2 = "end" >> span ' ' >> "second"
        let mutable source = Source("end second")
        //f backtracking doesn't occur, parsing end2 will fail, because "end" and the space will have been consumed
        ResultAssert.Fails(end1.Consume(&source))
        ResultAssert.Captures("end second", end2.Consume(&source))

    [<TestMethod>]
    member _.``comment`` () =
        let pattern = Pattern.LineComment("--")
        let mutable result = Result()

        result <- pattern.Consume("--This is a comment\n")
        ResultAssert.Captures("--This is a comment", result)

        result <- pattern.Consume("--This is a comment\nExample_Function();")
        ResultAssert.Captures("--This is a comment", result)

    [<TestMethod>]
    member _.``identifier`` () =
        let pattern = Pattern.Check("pattern",
                                   (fun (char:char) -> char.IsLetter()), true,
                                   (fun (char:char) -> char.IsLetter() || char = '_'), true,
                                   (fun (char:char) -> char.IsLetter() || char = '_'), false)
        ResultAssert.Captures("hello", pattern.Consume("hello"))
        ResultAssert.Captures("example_name", pattern.Consume("example_name"))
        ResultAssert.Fails(pattern.Consume("_fail"))

    [<TestMethod>]
    member _.``IPv4 address`` () =
        let digit = Pattern.Check("digit",
                                 (fun (char:char) -> '0' <= char && char <= '2'), false,
                                 (fun (char:char) -> '0' <= char && char <= '9'), false,
                                 (fun (char:char) -> '0' <= char && char <= '9'), true)
        let address = digit >> '.' >> digit >> '.' >> digit >> '.' >> digit

        ResultAssert.Captures("1", digit.Consume("1"))
        ResultAssert.Captures("11", digit.Consume("11"))
        ResultAssert.Captures("111", digit.Consume("111"))

        ResultAssert.Captures("192.168.1.1", address.Consume("192.168.1.1"))

    [<TestMethod>]
    member _.``named statement`` () =
        let identifier = Pattern.Check("identifier", Bias.Head,
                                      (fun (char:char) -> char.IsLetter() || char = '_'),
                                      (fun (char:char) -> char.IsLetterOrDigit() || char = '_'),
                                      (fun (char:char) -> char.IsLetterOrDigit()))
        let mutable result = identifier.Consume("Name")
        ResultAssert.Captures("Name", result)

        let mutable capture = ref null
        let statement = "statement" >> span Pattern.Separator >> (identifier => capture)
        result <- statement.Consume("statement Name")
        ResultAssert.Captures("statement Name", result)
        CaptureAssert.Captures("Name", capture)

    [<TestMethod>]
    member _.``phone number`` () =
        let pattern = Pattern.Number * 3 >> '-' >> Pattern.Number * 3 >> '-' >> Pattern.Number * 4
        let result = pattern.Consume("555-555-5555")
        ResultAssert.Captures("555-555-5555", result)

    [<TestMethod>]
    member _.``string literal`` () =
        let pattern = Pattern.StringLiteral("\"", "\\\"")
        ResultAssert.Captures("\"hello\\\"world\"", pattern.Consume("\"hello\\\"world\""))

    [<TestMethod>]
    member _.``web address`` () =
        let protocol = "http" >> option 's' >> "://"
        let host = span(Pattern.Letter || Pattern.Number || '-') >> '.' >> (Pattern.Letter * 3 >> Pattern.EndOfSource || span(Pattern.Letter || Pattern.Number || '-') >> '.' >> Pattern.Letter * 3)
        let location = span('/' >> span(Pattern.Letter || Pattern.Number || '-' || '_'))
        let address = option protocol >> host >> option location

        ResultAssert.Captures("http://", protocol.Consume("http://"))
        ResultAssert.Captures("https://", protocol.Consume("https://"))

        ResultAssert.Captures("google.com", host.Consume("google.com"))
        ResultAssert.Captures("www.google.com", host.Consume("www.google.com"))

        ResultAssert.Captures("/about", location.Consume("/about"))

        ResultAssert.Captures("http://www.google.com", address.Consume("http://www.google.com"))
        ResultAssert.Captures("https://www.google.com/about", address.Consume("https://www.google.com/about"))