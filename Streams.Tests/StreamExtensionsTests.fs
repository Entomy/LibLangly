namespace Streams

open System
open System.IO
open System.Text
open Stringier.Streams
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type StreamExtensionsTests() =
    [<TestMethod>]
    member _.``read byte - string`` () =
        use stream = new StringStream("helloworld!")
        CollectionAssert.AreEqual([|0x68uy;0x65uy;0x6Cuy;0x6Cuy;0x6Fuy|], stream.Read(5))

    [<TestMethod>]
    member _.``read/seek byte - string`` () =
        use stream = new StringStream("helloworld!")
        CollectionAssert.AreEqual([|0x68uy;0x65uy;0x6Cuy;0x6Cuy;0x6Fuy|], stream.Read(5))
        stream.Position <- 0L
        CollectionAssert.AreEqual([|0x68uy;0x65uy;0x6Cuy;0x6Cuy;0x6Fuy|], stream.Read(5))

    [<TestMethod>]
    member _.``read byte - file`` () =
        use stream = new FileStream("Test.txt", FileMode.Open)
        CollectionAssert.AreEqual([|0xEFuy;0xBBuy;0xBFuy|], stream.Read(3))
        CollectionAssert.AreEqual([|0x68uy;0x65uy;0x6Cuy;0x6Cuy;0x6Fuy|], stream.Read(5))

    [<TestMethod>]
    member _.``read/seek byte - file`` () =
        use stream = new FileStream("Test.txt", FileMode.Open)
        CollectionAssert.AreEqual([|0xEFuy;0xBBuy;0xBFuy|], stream.Read(3))
        CollectionAssert.AreEqual([|0x68uy;0x65uy;0x6Cuy;0x6Cuy;0x6Fuy|], stream.Read(5))
        stream.Position <- 0L
        CollectionAssert.AreEqual([|0xEFuy;0xBBuy;0xBFuy|], stream.Read(3))
        CollectionAssert.AreEqual([|0x68uy;0x65uy;0x6Cuy;0x6Cuy;0x6Fuy|], stream.Read(5))

    [<TestMethod>]
    member _.``read rune - string`` () =
        use stream = new StringStream("AöЖ€𝄞")
        Assert.AreEqual(Rune('A'), stream.ReadRune())
        Assert.AreEqual(Rune('ö'), stream.ReadRune())
        Assert.AreEqual(Rune('Ж'), stream.ReadRune())
        Assert.AreEqual(Rune('€'), stream.ReadRune())
        Assert.AreEqual(Rune(0x1D11E), stream.ReadRune())

    [<TestMethod>]
    member _.``read runes - string`` () =
        use stream = new StringStream("AöЖ€𝄞")
        CollectionAssert.AreEqual([|Rune('A'); Rune('ö'); Rune('Ж')|], stream.ReadRunes(3))
        CollectionAssert.AreEqual([|Rune('€'); Rune(0x1D11E)|], stream.ReadRunes(2))

    [<TestMethod>]
    member _.``read rune - file`` () =
        use stream = new FileStream("Test.txt", FileMode.Open)
        stream.Read(3) |> ignore // Windows created the file with the UTF-8 BOM, so this just skips that
        Assert.AreEqual(Rune('h'), stream.ReadRune())
        Assert.AreEqual(Rune('e'), stream.ReadRune())
        Assert.AreEqual(Rune('l'), stream.ReadRune())
        Assert.AreEqual(Rune('l'), stream.ReadRune())
        Assert.AreEqual(Rune('o'), stream.ReadRune())

    [<TestMethod>]
    member _.``read runes - file`` () =
        use stream = new FileStream("Test.txt", FileMode.Open)
        stream.Read(3) |> ignore // Windows created the file with the UTF-8 BOM, so this just skips that
        CollectionAssert.AreEqual([|Rune('h'); Rune('e'); Rune('l'); Rune('l'); Rune('o')|], stream.ReadRunes(5))