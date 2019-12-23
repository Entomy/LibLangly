namespace Tests.Collections

open System
open Stringier.Collections
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type StringBuilderTests() =

    [<TestMethod>]
    member _.``append string`` () =
        let builder = StringBuilder()
        builder.Append("hello") |> ignore
        builder.Append(' ').Append("world") |> ignore
        ()

    [<TestMethod>]
    member _.``to string`` () =
        let builder = StringBuilder()
        builder.Append("hello") |> ignore
        builder.Append(" ").Append("world") |> ignore
        Assert.AreEqual("hello world", builder.ToString())

    [<TestMethod>]
    member _.``indexer`` () =
        let builder = StringBuilder()
        builder.Append("hello").Append(" ").Append("world") |> ignore
        Assert.AreEqual('h', builder.[0])
        Assert.AreEqual('o', builder.[4])
        Assert.AreEqual(' ', builder.[5])
        Assert.AreEqual('w', builder.[6])
        Assert.AreEqual('d', builder.[10])
        Assert.ThrowsException<IndexOutOfRangeException>(fun () -> builder.[11] |> ignore) |> ignore