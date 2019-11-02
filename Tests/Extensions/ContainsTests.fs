namespace Tests.Extensions

open System;
open Stringier.Extensions;
open Xunit;

module ContainsTests =
    [<Fact>]
    let ``contains 'a' "apple"`` () =
        Assert.True(contains 'a' "apple")

    [<Fact>]
    let ``contains 'a' "hello"`` () =
        Assert.False(contains 'a' "hello")

    [<Fact>]
    let ``contains 'g' ["ab";"cd";"ef";"gh"]`` () =
        Assert.True(contains 'g' ["ab";"cd";"ef";"gh"])

    [<Fact>]
    let ``contains 'i' ["ab";"cd";"ef";"gh"]`` () =
        Assert.False(contains 'i' ["ab";"cd";"ef";"gh"])

    [<Fact>]
    let ``contains 'g' [|"ab";"cd";"ef";"gh"|]`` () =
        Assert.True(contains 'g' [|"ab";"cd";"ef";"gh"|])

    [<Fact>]
    let ``contains 'i' [|"ab";"cd";"ef";"gh"|]`` () =
        Assert.False(contains 'i' [|"ab";"cd";"ef";"gh"|])

    [<Fact>]
    let ``contains "hello" "hello world"`` () =
        Assert.True(contains "hello" "hello world")

    [<Fact>]
    let ``contains "hello" "goodnight everyone"`` () =
        Assert.False(contains "hello" "goodnight everyone")

    [<Fact>]
    let ``contains "cd" ["ab";"cd";"ef";"gh"]`` ( ) =
        Assert.True(contains "cd" ["ab";"cd";"ef";"gh"])

    [<Fact>]
    let ``contains "de" ["ab";"cd";"ef";"gh"]`` () =
        Assert.False(contains "de" ["ab";"cd";"ef";"gh"])

    [<Fact>]
    let ``contains "cd" [|"ab";"cd";"ef";"gh"|]`` ( ) =
        Assert.True(contains "cd" ["ab";"cd";"ef";"gh"])

    [<Fact>]
    let ``contains "de" [|"ab";"cd";"ef";"gh"|]`` () =
        Assert.False(contains "de" ["ab";"cd";"ef";"gh"])