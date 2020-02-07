namespace Patterns.Tracing

open System
open Stringier.Patterns
open Stringier.Patterns.Debugging
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TraceTests() =
    [<TestMethod>]
    member _.``collect`` () =
        let mutable trace = Trace()
        let mutable source = Source("hello world")
        let mutable result = "hello".Consume(&source, trace)
        for step in trace do
            Assert.AreEqual("hello", step.Text);

        trace <- Trace()
        source <- Source("hello world")
        result <- ("hello" >> " "/=Compare.CaseInsensitive >> "world").Consume(&source, trace)
        let exp = ["hello"; " "; "world"]
        let mutable e = 0
        for step in trace do
            Assert.AreEqual(exp.[e], step.Text)
            e <- e + 1