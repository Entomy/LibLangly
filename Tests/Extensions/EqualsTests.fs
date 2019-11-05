namespace Tests.Extensions

open System;
open Stringier.Extensions;
open Xunit;

module EqualsTests =
    [<Fact>]
    let ``mixed String/Span`` () =
        let mutable string = "hello"
        let mutable span = "hello".AsSpan()
        Assert.True(string.Equals(span, StringComparison.InvariantCulture))
        Assert.True(span.Equals(string, StringComparison.InvariantCulture))
        string <- "encyclopædia"
        span <- "encyclopaedia".AsSpan()
        Assert.True(string.Equals(span, StringComparison.InvariantCulture))
        Assert.True(span.Equals(string, StringComparison.InvariantCulture))