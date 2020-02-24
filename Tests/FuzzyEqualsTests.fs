namespace Extensions

open System
open Stringier
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type FuzzyEqualsTests() =
    [<DataTestMethod>]
    [<DataRow(true, "bob", "bob")>]
    [<DataRow(true, "bob", "mob")>]
    [<DataRow(false, "bob", "mom")>]
    member _.``fuzzyEquals string string`` (exp:bool, src:string, oth:string) =
        Assert.AreEqual(exp, src |> fuzzyEqual oth)