namespace Patterns

open System
open Stringier.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type MutableTests() =

    [<TestMethod>]
    member _.``constructor`` () =
        let _pattern = Pattern.Mutable()
        ()

    [<TestMethod>]
    member _.``mutate and consume`` () =
        let pattern = Pattern.Mutable()
        pattern >> "hello" >> ' ' >> "world" |> ignore
        //If you check the pattern at this point, you'll see it's as you would expect.
        ResultAssert.Captures("hello world", pattern.Consume("hello world!"));

        (not pattern).Seal()
        //If you check the pattern at this point, you'll see it was negated. In a non-mutable context a new pattern would have been created here, and returned here, that was left unassigned. Instead the already assigned pattern has been mutated.
        ResultAssert.Captures("bacon cakes", pattern.Consume("bacon cakes!"));

        let pattern = pattern.Then('!')
        //Since the pattern has been made ReadOnly (Sealed), this call works as it would normally, and if you check at this point, will be a normal pattern who's head has been string concatenated. I've created a new let-binding so that the previous one still exists (the debugger still sees it), and you can see that the previous pattern stays the same.
        ResultAssert.Captures("bacon cakes!", pattern.Consume("bacon cakes!"))