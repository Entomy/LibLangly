namespace Streams

open System
open System.IO
open Stringier.Streams
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type StringStreamTests() =
    [<TestMethod>]
    member _.``constructor`` () =
        new StringStream("hello") |> ignore

    [<TestMethod>]
    member _.``reader - English`` () =
        let stream = new StringStream("hello")
        let reader = new StreamReader(stream)
        Assert.AreEqual("hello", reader.ReadToEnd())

    [<TestMethod>]
    member _.``reader - Russian`` () =
        let stream = new StringStream("привет")
        let reader = new StreamReader(stream)
        Assert.AreEqual("привет", reader.ReadToEnd())

    [<TestMethod>]
    member _.``reader - Japanese`` () =
        let stream = new StringStream("こんにちは")
        let reader = new StreamReader(stream)
        Assert.AreEqual("こんにちは", reader.ReadToEnd())

    [<TestMethod>]
    member _.``seek`` () =
        let stream = new StringStream("hello")
        let reader = new StreamReader(stream)
        stream.Seek(3L, SeekOrigin.Begin) |> ignore
        Assert.AreEqual("lo", reader.ReadToEnd())
        stream.Seek(0L, SeekOrigin.Begin) |> ignore
        Assert.AreEqual("hello", reader.ReadToEnd())