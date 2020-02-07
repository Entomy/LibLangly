namespace Extensions

open System
open Stringier.Extensions
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type WordsTests () =
    
    [<TestMethod>]
    member _.``words "hello world"`` () =
        CollectionAssert.AreEqual([|"hello";"world"|], words "hello world")