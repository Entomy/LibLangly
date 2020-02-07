namespace Patterns

open System
open Stringier.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type SourceStateTests() =

    [<TestMethod>]
    member _.``store and restore`` () =
        let mutable source = Source("hello world")
        let state = source.Store()
        ResultAssert.Succeeds("hello".Consume(&source))
        source.Restore(state)
        //The only way this can succeed is if the restore worked
        ResultAssert.Succeeds("hello".Consume(&source))