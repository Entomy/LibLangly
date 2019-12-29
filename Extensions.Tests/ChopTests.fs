namespace Tests.Extensions

open System
open Stringier.Extensions
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type ChopTests() =

    [<TestMethod>]
    member _.Chop0 () =
        Assert.ThrowsException<ArgumentOutOfRangeException>(fun () -> chop 0 "hello world" |> ignore) |> ignore

    [<TestMethod>]
    member _.Chop1 () =
        CollectionAssert.AreEqual([|"h";"e";"l";"l";"o";" ";"w";"o";"r";"l";"d"|], chop 1 "hello world")

    [<TestMethod>]
    member _.Chop2 () =
        CollectionAssert.AreEqual([|"he";"ll";"o ";"wo";"rl";"d"|], chop 2 "hello world")

    [<TestMethod>]
    member _.Chop3 () =
        CollectionAssert.AreEqual([|"hel";"lo ";"wor";"ld"|], chop 3 "hello world")

    [<TestMethod>]
    member _.Chop4 () =
        CollectionAssert.AreEqual([|"hell";"o wo";"rld"|], chop 4 "hello world")

    [<TestMethod>]
    member _.Chop5 () =
        CollectionAssert.AreEqual([|"hello";" worl";"d"|], chop 5 "hello world")

    [<TestMethod>]
    member _.Chop6 () =
        CollectionAssert.AreEqual([|"hello ";"world"|], chop 6 "hello world")

    [<TestMethod>]
    member _.Chop7 () =
        CollectionAssert.AreEqual([|"hello w";"orld"|], chop 7 "hello world")

    [<TestMethod>]
    member _.Chop8 () =
        CollectionAssert.AreEqual([|"hello wo";"rld"|], chop 8 "hello world")

    [<TestMethod>]
    member _.Chop9 () =
        CollectionAssert.AreEqual([|"hello wor";"ld"|], chop 9 "hello world")

    [<TestMethod>]
    member _.Chop10 () =
        CollectionAssert.AreEqual([|"hello worl";"d"|], chop 10 "hello world")

    [<TestMethod>]
    member _.Chop11 () =
        CollectionAssert.AreEqual([|"hello world"|], chop 11 "hello world")

    [<TestMethod>]
    member _.Chop12 () =
        CollectionAssert.AreEqual([|"hello world"|], chop 12 "hello world")