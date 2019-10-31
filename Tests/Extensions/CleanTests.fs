namespace Tests.Extensions

open System;
open Stringier.Extensions;
open Xunit;

module CleanTests =
    [<Fact>]
    let ``clean "hello world"`` () =
        Assert.Equal("hello world", clean "hello world");

    [<Fact>]
    let ``clean "hello  world"`` () =
        Assert.Equal("hello world", clean "hello  world");

    [<Fact>]
    let ``clean " hello  world "`` () =
        Assert.Equal("hello world", clean " hello  world ");

    [<Fact>]
    let ``clean 'o' "hellooo world"`` () =
        Assert.Equal("hello world", clean2 'o' "hellooo world");