namespace Streams

open System
open System.IO
open Stringier.Streams
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type StreamPipelineTests() =
    [<TestMethod>]
    member _.``flush then dispose`` () =
        let stream = new FileStream("output.txt", FileMode.Create)
        stream |> flush |> dispose

    [<TestMethod>]
    member _.``write pipeline`` () =
        let mutable stream = new FileStream("output.txt", FileMode.Create)
        stream <=< "he" <=< 'l' <=< "lo" <=< 0x21uy
            |> flush
            |> dispose
        stream <- new FileStream("output.txt", FileMode.Open) //The previous stream mode was writable but not readable, we need it to be readable
        let reader = new StreamReader(stream)
        Assert.AreEqual("hello!", reader.ReadToEnd())