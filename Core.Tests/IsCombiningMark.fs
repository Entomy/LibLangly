namespace Extensions

open System
open Stringier
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type IsCombiningMarkTests() =
    [<DataTestMethod>]
    [<DataRow(true, '̃')>]
    [<DataRow(true, '᪵')>]
    [<DataRow(false, 'a')>]
    [<DataRow(false, '2')>]
    member _.``is combining mark`` (exp:bool, ch:char) =
        Assert.AreEqual(exp, ch.IsCombiningMark())