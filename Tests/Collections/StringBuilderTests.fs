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