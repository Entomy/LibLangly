namespace Extensions

open System
open Stringier
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type EqualsTests() =
    [<TestMethod>]
    member _.``mixed String/Span`` () =
        let mutable string = "hello"
        let mutable span = "hello".AsSpan()
        Assert.IsTrue(string.Equals(span, StringComparison.InvariantCulture))
        Assert.IsTrue(span.Equals(string, StringComparison.InvariantCulture))
        string <- "encyclopædia"
        span <- "encyclopaedia".AsSpan()
        Assert.IsTrue(string.Equals(span, StringComparison.InvariantCulture))
        Assert.IsTrue(span.Equals(string, StringComparison.InvariantCulture))