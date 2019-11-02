namespace Tests.Extensions

open System
open Stringier.Extensions
open Xunit

module PadTests =
    [<Fact>]
    let ``pad 10 "hello"`` () =
        Assert.Equal("  hello   ", pad 10 "hello")

    [<Fact>]
    let ``pad 4 "hello"`` () =
        Assert.Equal("hello", pad 4 "hello")

    [<Fact>]
    let ``pad2 10 '-' "hello"`` () =
        Assert.Equal("--hello---", pad2 10 '-' "hello")