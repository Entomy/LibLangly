namespace Tests.Extensions

open System.IO
open Stringier.Extensions
open Xunit

module LinesTests =
    [<Fact>]
    let ``lines`` () =
        let source = "Some example text." + Path.DirectorySeparatorChar.ToString() + "With some line breaks." + Path.DirectorySeparatorChar.ToString() + "Which should be split up."
        Assert.Equal<seq<string>>([|"Some example text.";"With some line breaks.";"Which should be split up."|], lines source)