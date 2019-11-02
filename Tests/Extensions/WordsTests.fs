namespace Tests.Extensions

open System
open Stringier.Extensions
open Xunit

module WordsTests =
    [<Fact>]
    let ``words "hello world"`` () =
        Assert.Equal<seq<string>>([|"hello";"world"|], words "hello world")