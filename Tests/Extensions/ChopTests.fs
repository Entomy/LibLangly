namespace Tests.Extensions

open System;
open Stringier.Extensions;
open Xunit;

module ChopTests =
    [<Fact>]
    let Chop0 () =
        Assert.Throws(typeof<ArgumentOutOfRangeException>, fun () -> chop 0 "hello world" |> ignore);

    [<Fact>]
    let Chop1 () =
        Assert.Equal<seq<string>>([|"h";"e";"l";"l";"o";" ";"w";"o";"r";"l";"d"|], chop 1 "hello world")

    [<Fact>]
    let Chop2 () =
        Assert.Equal<seq<string>>([|"he";"ll";"o ";"wo";"rl";"d"|], chop 2 "hello world");

    [<Fact>]
    let Chop3 () =
        Assert.Equal<seq<string>>([|"hel";"lo ";"wor";"ld"|], chop 3 "hello world");

    [<Fact>]
    let Chop4 () =
        Assert.Equal<seq<string>>([|"hell";"o wo";"rld"|], chop 4 "hello world");

    [<Fact>]
    let Chop5 () =
        Assert.Equal<seq<string>>([|"hello";" worl";"d"|], chop 5 "hello world");

    [<Fact>]
    let Chop6 () =
        Assert.Equal<seq<string>>([|"hello ";"world"|], chop 6 "hello world");

    [<Fact>]
    let Chop7 () =
        Assert.Equal<seq<string>>([|"hello w";"orld"|], chop 7 "hello world");

    [<Fact>]
    let Chop8 () =
        Assert.Equal<seq<string>>([|"hello wo";"rld"|], chop 8 "hello world");

    [<Fact>]
    let Chop9 () =
        Assert.Equal<seq<string>>([|"hello wor";"ld"|], chop 9 "hello world");

    [<Fact>]
    let Chop10 () =
        Assert.Equal<seq<string>>([|"hello worl";"d"|], chop 10 "hello world");

    [<Fact>]
    let Chop11 () =
        Assert.Equal<seq<string>>([|"hello world"|], chop 11 "hello world");

    [<Fact>]
    let Chop12 () =
        Assert.Equal<seq<string>>([|"hello world"|], chop 12 "hello world");