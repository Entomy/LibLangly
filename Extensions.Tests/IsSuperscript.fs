namespace Extensions

open System
open Stringier
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type IsSuperscriptTests() =
    [<DataTestMethod>]
    [<DataRow(true, '²')>]
    [<DataRow(true, '³')>]
    [<DataRow(true, '⁽')>]
    [<DataRow(false, '₄')>]
    [<DataRow(false, '2')>]
    member _.``is superscript`` (exp:bool, ch:char) =
        Assert.AreEqual(exp, ch.IsSuperscript())