namespace Tests.Extensions

open System
open Stringier.Extensions
open Xunit

module JoinTests =
    [<Fact>]
    let ``join ['a';'b';'c';'d']`` () =
        Assert.Equal("abcd", join ['a';'b';'c';'d'])

    [<Fact>]
    let ``join [|'a';'b';'c';'d'|]`` () =
        Assert.Equal("abcd", join [|'a';'b';'c';'d'|])

    [<Fact>]
    let ``join ["This";"Winds";"Up";"Camel";"Case"]`` () =
        Assert.Equal("ThisWindsUpCamelCase", join ["This";"Winds";"Up";"Camel";"Case"]);

    [<Fact>]
    let ``join2 '-' ['a';'b';'c';'d']`` () =
        Assert.Equal("a-b-c-d", join2 '-' ['a';'b';'c';'d'])

    [<Fact>]
    let ``join2 '-' [|'a';'b';'c';'d'|]`` () =
        Assert.Equal("a-b-c-d", join2 '-' [|'a';'b';'c';'d'|])

    [<Fact>]
    let ``join2 '-' ["hello";"how";"are";"you";"today?"]`` () =
        Assert.Equal("hello-how-are-you-today?", join2 '-' ["hello";"how";"are";"you";"today?"])