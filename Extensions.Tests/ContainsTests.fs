namespace Extensions

open System
open Stringier.Extensions
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type ContainsTests() =

    [<TestMethod>]
    member _.``contains 'a' "apple"`` () =
        Assert.IsTrue(contains 'a' "apple")

    [<TestMethod>]
    member _.``contains 'a' "hello"`` () =
        Assert.IsFalse(contains 'a' "hello")

    [<TestMethod>]
    member _.``contains 'g' ["ab";"cd";"ef";"gh"]`` () =
        Assert.IsTrue(contains 'g' ["ab";"cd";"ef";"gh"])

    [<TestMethod>]
    member _.``contains 'i' ["ab";"cd";"ef";"gh"]`` () =
        Assert.IsFalse(contains 'i' ["ab";"cd";"ef";"gh"])

    [<TestMethod>]
    member _.``contains 'g' [|"ab";"cd";"ef";"gh"|]`` () =
        Assert.IsTrue(contains 'g' [|"ab";"cd";"ef";"gh"|])

    [<TestMethod>]
    member _.``contains 'i' [|"ab";"cd";"ef";"gh"|]`` () =
        Assert.IsFalse(contains 'i' [|"ab";"cd";"ef";"gh"|])

    [<TestMethod>]
    member _.``contains "hello" "hello world"`` () =
        Assert.IsTrue(contains "hello" "hello world")

    [<TestMethod>]
    member _.``contains "hello" "goodnight everyone"`` () =
        Assert.IsFalse(contains "hello" "goodnight everyone")

    [<TestMethod>]
    member _.``contains "cd" ["ab";"cd";"ef";"gh"]`` () =
        Assert.IsTrue(contains "cd" ["ab";"cd";"ef";"gh"])

    [<TestMethod>]
    member _.``contains "de" ["ab";"cd";"ef";"gh"]`` () =
        Assert.IsFalse(contains "de" ["ab";"cd";"ef";"gh"])

    [<TestMethod>]
    member _.``contains "cd" [|"ab";"cd";"ef";"gh"|]`` () =
        Assert.IsTrue(contains "cd" [|"ab";"cd";"ef";"gh"|])

    [<TestMethod>]
    member _.``contains "de" [|"ab";"cd";"ef";"gh"|]`` () =
        Assert.IsFalse(contains "de" [|"ab";"cd";"ef";"gh"|])