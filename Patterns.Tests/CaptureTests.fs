namespace Patterns

open System
open Stringier.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type CaptureTests() =

    [<TestMethod>]
    member _.``constructor`` () =
        let mutable capture = ref null
        let _pattern = ('a' || 'b' || 'c') => capture
        ()

    [<TestMethod>]
    member _.``consume`` () =
        let mutable capture = ref null
        let mutable pattern = ('a' || 'b' || 'c') => capture
           
        ResultAssert.Captures("a", pattern.Consume("a"))
        CaptureAssert.Captures("a", capture)

        pattern <- ('a' || 'b' || 'c') => capture >> '!'

        ResultAssert.Fails(pattern.Consume("a"))

        ResultAssert.Captures("a!", pattern.Consume("a!"))
        CaptureAssert.Captures("a", capture)

        pattern <- ('a' || 'b' || 'c') => capture >> ',' >> capture

        ResultAssert.Captures("b,b", pattern.Consume("b,b"))
        ResultAssert.Fails(pattern.Consume("b,a"))