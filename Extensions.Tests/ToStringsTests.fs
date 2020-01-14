namespace Tests.Extensions

open System
open Stringier
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type ToStringsTests() =
    [<TestMethod>]
    member _.``to strings`` () =
        CollectionAssert.AreEqual([|""|], [|null|].ToStrings(String.Empty))
        CollectionAssert.AreEqual([|"1";"2";"3"|], [|1;2;3|].ToStrings())