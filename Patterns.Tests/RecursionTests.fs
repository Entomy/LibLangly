namespace Patterns

open System
open Stringier.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type RecursionTests() =
    
    [<TestMethod>]
    member _.``right-recursion`` () =
        let pattern = Pattern.Mutable()
        pattern >> "hi!" >> (Pattern.EndOfSource || pattern) |> ignore
        pattern.Seal()
        ResultAssert.Captures("hi!", pattern.Consume("hi!"));
        ResultAssert.Captures("hi!hi!", pattern.Consume("hi!hi!"));
        ResultAssert.Captures("hi!hi!hi!", pattern.Consume("hi!hi!hi!"));
        ResultAssert.Captures("hi!hi!hi!hi!", pattern.Consume("hi!hi!hi!hi!"));

    [<TestMethod>]
    member _.``mutual-recursion`` () =
        //These grammar rules aren't great, and can easily be broken, so don't use them as a reference. They just show that mutual recursion is working.
        let expression = Pattern.Mutable()
        let parenExpression = '(' >> expression >> ')'
        let term = Pattern.DecimalDigitNumber
        let factor = (term || parenExpression) >> ("+" || "-") >> (term || parenExpression)
        expression >> (factor || term || parenExpression) |> ignore
        expression.Seal()

        ResultAssert.Captures("3+2", expression.Consume("3+2"))
        ResultAssert.Captures("3+(1+2)", expression.Consume("3+(1+2)"))
