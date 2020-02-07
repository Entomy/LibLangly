namespace Streams

open System
open Stringier.Streams
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TextStreamTests() =
    [<TestMethod>]
    member _.``constructor`` () =
        use stream = new TextStream<StringStream>(new StringStream("hello world!"))
        ()

    [<TestMethod>]
    member _.``read/seek string`` () =
        use stream = new TextStream<StringStream>(new StringStream("hello world!"))
        CollectionAssert.AreEqual([|0x68uy;0x65uy;0x6Cuy;0x6Cuy;0x6Fuy|], stream.Read(5))
        stream.Position <- 0L
        CollectionAssert.AreEqual([|0x68uy;0x65uy;0x6Cuy;0x6Cuy;0x6Fuy|], stream.Read(5))
