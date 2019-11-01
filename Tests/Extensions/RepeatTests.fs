namespace Tests.Extensions

open System
open Stringier.Extensions
open Xunit

module RepeatTests =
    [<Fact>]
    let ``repeat 3 'a'`` () =
        Assert.Equal("aaa", repeat 3 'a')