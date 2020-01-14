namespace Tests.Extensions

open System
open Stringier
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type IsSubscriptTests() =
    [<DataTestMethod>]
    [<DataRow(true, '₂')>]
    [<DataRow(true, 'ₐ')>]
    [<DataRow(false, '⁷')>]
    [<DataRow(false, '2')>]
    member _.``is subscript`` (exp:bool, ch:char) =
        Assert.AreEqual(exp, ch.IsSubscript())