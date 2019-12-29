namespace Tests.Extensions

open System
open System.IO
open Stringier.Extensions
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type LinesTests() =
    [<TestMethod>]
    member _.``lines`` () =
        let source = "Some example text." + Path.DirectorySeparatorChar.ToString() + "With some line breaks." + Path.DirectorySeparatorChar.ToString() + "Which should be split up."
        CollectionAssert.AreEqual([|"Some example text.";"With some line breaks.";"Which should be split up."|], lines source)