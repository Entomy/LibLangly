namespace Extensions

open System
open Stringier.Extensions
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type JoinTests() =
    
    [<TestMethod>]
    member _.``join ['a';'b';'c';'d']`` () =
        Assert.AreEqual("abcd", join ['a';'b';'c';'d'])

    [<TestMethod>]
    member _.``join [|'a';'b';'c';'d'|]`` () =
        Assert.AreEqual("abcd", join [|'a';'b';'c';'d'|])

    [<TestMethod>]
    member _.``join ["This";"Winds";"Up";"Camel";"Case"]`` () =
        Assert.AreEqual("ThisWindsUpCamelCase", join ["This";"Winds";"Up";"Camel";"Case"])

    [<TestMethod>]
    member _.``join2 '-' ['a';'b';'c';'d']`` () =
        Assert.AreEqual("a-b-c-d", join2 '-' ['a';'b';'c';'d'])

    [<TestMethod>]
    member _.``join2 '-' [|'a';'b';'c';'d'|]`` () =
        Assert.AreEqual("a-b-c-d", join2 '-' [|'a';'b';'c';'d'|])

    [<TestMethod>]
    member _.``join2 '-' ["hello";"how";"are";"you";"today?"]`` () =
        Assert.AreEqual("hello-how-are-you-today?", join2 '-' ["hello";"how";"are";"you";"today?"])