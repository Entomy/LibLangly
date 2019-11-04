namespace Tests.Patterns

open System;
open Stringier.Patterns;
open Xunit;

module SourceTests =
    [<Fact>]
    let ``Construct from String`` () =
        let source = new Source("hello")
        Assert.Equal("hello", source.ToString())

    [<Fact>]
    let ``Construct from String, preconvert`` () =
        let source = new Source("hello", true)
        Assert.Equal("HELLO", source.ToString())