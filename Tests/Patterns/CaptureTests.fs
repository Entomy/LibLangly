namespace Tests.Patterns

open System
open Stringier.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type CaptureTests() =

    [<TestMethod>]
    member _.``constructor`` () =
        let mutable capture = null
        let _pattern = ('a' || 'b' || 'c') => &capture
        ()

    [<TestMethod>]
        member _.``consume`` () =
            let mutable capture = Capture()
            let mutable pattern = ('a' || 'b' || 'c') => &capture
            let mutable result = Result()
           
            result <- pattern.Consume("a")
            ResultAssert.Captures("a", result)
            CaptureAssert.Captures("a", capture)

            pattern <- ('a' || 'b' || 'c') => &capture >> '!'

            result <- pattern.Consume("a")
            ResultAssert.Fails(result)

            result <- pattern.Consume("a!")
            ResultAssert.Captures("a!", result)
            CaptureAssert.Captures("a", capture)

            pattern <- ('a' || 'b' || 'c') => &capture >> ',' >> capture