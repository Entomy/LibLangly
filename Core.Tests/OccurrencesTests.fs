namespace Extensions

open System
open System.IO
open Stringier.Extensions
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type OccurrencesTests() =
       
    [<TestMethod>]
    member _.``occurrences 'l' "hello"`` () =
        Assert.AreEqual(2, occurrences 'l' "hello")

    [<TestMethod>]
    member _.``occurrences '?' "hello"`` () =
        Assert.AreEqual(0, occurrences '?' "hello")

    [<TestMethod>]
    member _.``occurrences [|'e';'o'|] "hello"`` () =
        Assert.AreEqual(2, occurrences [|'e';'o'|] "hello")

    [<TestMethod>]
    member _.``occurrences [|'e';'o'|] [|"hello";"world";"how";"are";"you";"today?"|]`` () =
        Assert.AreEqual(7, occurrences [|'e';'o'|] [|"hello";"world";"how";"are";"you";"today?"|])