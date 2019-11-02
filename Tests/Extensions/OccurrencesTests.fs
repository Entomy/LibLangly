namespace Tests.Extensions

open System
open Stringier.Extensions
open Xunit

module OccurrencesTests =
    [<Fact>]
    let ``occurrences 'l' "hello"`` () =
        Assert.Equal(2, occurrences 'l' "hello")

    [<Fact>]
    let ``occurrences '?' "hello"`` () =
        Assert.Equal(0, occurrences '?' "hello")

    [<Fact>]
    let ``occurrences [|'e';'o'|] "hello"`` () =
        Assert.Equal(2, occurrences [|'e';'o'|] "hello")

    [<Fact>]
    let ``occurrences [|'e';'o'|] [|"hello";"world";"how";"are";"you";"today?"|]`` () =
        Assert.Equal(7, occurrences [|'e';'o'|] [|"hello";"world";"how";"are";"you";"today?"|])