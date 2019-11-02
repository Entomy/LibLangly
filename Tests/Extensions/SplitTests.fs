namespace Tests.Extensions

open System
open Stringier.Extensions
open Xunit

module SplitTests =
    [<Fact>]
    let ``split ',' "comma,separated,values"`` () =
        Assert.Equal<seq<string>>([|"comma";"separated";"values"|], split ',' "comma,separated,values")

    [<Fact>]
    let ``split ", " "comma, separated, values, 1,300"`` () =
        Assert.Equal<seq<string>>([|"comma";"separated";"values";"1,300"|], split ", " "comma, separated, values, 1,300")
    
    [<Fact>]
    let ``split [|',';';'|] "comma,or;semicolon;separated,values"`` () =
        Assert.Equal<seq<string>>([|"comma";"or";"semicolon";"separated";"values"|], split [|',';';'|] "comma,or;semicolon;separated,values")