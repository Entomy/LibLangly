namespace Tests.FSharp

open System
open System.Text.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type LiteralTests() =
    [<TestMethod>]
    member this.Constructor() =
        let defaultComparison = p"Hello"
        ()