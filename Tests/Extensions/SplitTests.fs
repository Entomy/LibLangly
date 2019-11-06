namespace Tests.Extensions

open System
open Stringier.Extensions
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type SplitTests () =
    [<TestMethod>]
    member _.``split ',' "comma,separated,values"`` () =
        CollectionAssert.AreEqual([|"comma";"separated";"values"|], split ',' "comma,separated,values")

    [<TestMethod>]
    member _.``split ", " "comma, separated, values, 1,300"`` () =
        CollectionAssert.AreEqual([|"comma";"separated";"values";"1,300"|], split ", " "comma, separated, values, 1,300")
    
    [<TestMethod>]
    member _.``split [|',';';'|] "comma,or;semicolon;separated,values"`` () =
        CollectionAssert.AreEqual([|"comma";"or";"semicolon";"separated";"values"|], split [|',';';'|] "comma,or;semicolon;separated,values")