namespace Streams

open System
open System.IO
open Stringier.Streams
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TextReaderExtensionTests() =
    [<TestMethod>]
    member _.``read string`` () =
        let stream = new StringStream("helloworld!")
        let reader = new StreamReader(stream)
        Assert.AreEqual("hello", reader.Read(5))
        Assert.AreEqual("world", reader.Read(5))
        Assert.AreEqual("!", reader.Read(5))

    [<TestMethod>]
    member _.``read file`` () =
        let stream = new FileStream("Test.txt", FileMode.Open)
        let reader = new StreamReader(stream)
        Assert.AreEqual("hello", reader.Read(5))
        Assert.AreEqual("world", reader.Read(5))
        Assert.AreEqual("!", reader.Read(5))