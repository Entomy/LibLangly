namespace Tests.Streams

open System
open System.IO
open Stringier.Streams
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type StreamExtensionsTests() =
    [<TestMethod>]
    member _.``read string`` () =
        use stream = new StringStream("helloworld!")
        CollectionAssert.AreEqual([|0x68uy;0x65uy;0x6Cuy;0x6Cuy;0x6Fuy|], stream.Read(5))

    [<TestMethod>]
    member _.``read/seek string`` () =
        use stream = new StringStream("helloworld!")
        CollectionAssert.AreEqual([|0x68uy;0x65uy;0x6Cuy;0x6Cuy;0x6Fuy|], stream.Read(5))
        stream.Position <- 0L
        CollectionAssert.AreEqual([|0x68uy;0x65uy;0x6Cuy;0x6Cuy;0x6Fuy|], stream.Read(5))

    [<TestMethod>]
    member _.``read file`` () =
        use stream = new FileStream("Test.txt", FileMode.Open)
        CollectionAssert.AreEqual([|0xEFuy;0xBBuy;0xBFuy|], stream.Read(3))
        CollectionAssert.AreEqual([|0x68uy;0x65uy;0x6Cuy;0x6Cuy;0x6Fuy|], stream.Read(5))

    [<TestMethod>]
    member _.``read/seek file`` () =
        use stream = new FileStream("Test.txt", FileMode.Open)
        CollectionAssert.AreEqual([|0xEFuy;0xBBuy;0xBFuy|], stream.Read(3))
        CollectionAssert.AreEqual([|0x68uy;0x65uy;0x6Cuy;0x6Cuy;0x6Fuy|], stream.Read(5))
        stream.Position <- 0L
        CollectionAssert.AreEqual([|0xEFuy;0xBBuy;0xBFuy|], stream.Read(3))
        CollectionAssert.AreEqual([|0x68uy;0x65uy;0x6Cuy;0x6Cuy;0x6Fuy|], stream.Read(5))
