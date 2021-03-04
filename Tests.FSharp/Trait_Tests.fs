namespace Langly

open System
open Langly
open Langly.DataStructures.Lists
open Xunit

module Trait_Tests =
    [<Fact>]
    let ``Add`` () =
        let chain = new Chain<int32>()
        chain
        |> add 1
        |> ignore
        Assert.Equal([ 1 ], chain)
        chain
        |> add 2
        |> add 3
        |> ignore
        Assert.Equal([ 1; 2; 3 ], chain)
        chain
        |> add [| 4; 5 |]
        |> ignore
        Assert.Equal([ 1; 2; 3; 4; 5 ], chain)

    [<Fact(Skip = "Not implemented yet")>]
    let ``Capacity`` () = raise(NotImplementedException()) |> ignore

    [<Fact>]
    let ``Clear`` () =
        let chain = new Chain<int32>()
        chain
        |> add [| 1; 2; 3; 4; 5 |]
        |> ignore
        Assert.Equal(5n, count chain)
        chain
        |> clear
        |> ignore
        Assert.Equal(0n, count chain)

    [<Fact>]
    let ``Contains`` () =
        let chain = new Chain<int32>()
        chain
        |> add [| 1; 2; 3; 4; 5 |]
        |> ignore
        Assert.False(chain |> contains 0)
        Assert.True(chain |> contains 1)
        Assert.True(chain |> contains 2)
        Assert.True(chain |> contains 3)
        Assert.True(chain |> contains 4)
        Assert.True(chain |> contains 5)
        Assert.False(chain |> contains 6)

    [<Fact>]
    let ``ContainsAny`` () =
        let chain = new Chain<int32>()
        chain
        |> add [| 1; 2; 3; 4; 5 |]
        |> ignore
        Assert.True(chain |> containsAny [| 0; 1; 2 |])
        Assert.True(chain |> containsAny [| 5; 6; 7 |])
        Assert.False(chain |> containsAny [| 0; 6 |])

    [<Fact>]
    let ``ContainsAll`` () =
        let chain = new Chain<int32>()
        chain
        |> add [| 1; 2; 3; 4; 5 |]
        |> ignore
        Assert.True(chain |> containsAll [| 3; 4; 5 |])
        Assert.False(chain |> containsAll [| 4; 5; 6 |])

    [<Fact>]
    let ``Fold`` () =
        let chain = new Chain<int32>()
        chain
        |> add [| 1; 2; 3; 4; 5 |]
        |> ignore
        Assert.Equal(15, chain |> fold (fun (l)(r) -> l + r) 0)
        Assert.Equal(120, chain |> fold (fun (l)(r) -> l * r) 1)

    [<Fact(Skip = "Not implemented yet")>]
    let ``Grow`` () = raise(NotImplementedException()) |> ignore

    [<Fact>]
    let ``IndexOfFirst`` () =
        let chain = new Chain<int32>()
        chain
        |> add [| 1; 2; 1; 2; 1 |]
        |> ignore
        Assert.Equal(0n, chain |> indexOfFirst 1)
        Assert.Equal(1n, chain |> indexOfFirst 2)

    [<Fact>]
    let ``IndexOfLast`` () =
        let chain = new Chain<int32>()
        chain
        |> add [| 1; 2; 1; 2; 1 |]
        |> ignore
        Assert.Equal(4n, chain |> indexOfLast 1)
        Assert.Equal(3n, chain |> indexOfLast 2)

    [<Fact>]
    let ``Insert`` () =
        let chain = new Chain<int32>()
        chain
        |> add [| 1; 2; 3; 4; 5 |]
        |> insert 0n 0
        |> ignore
        Assert.Equal([ 0; 1; 2; 3; 4; 5 ], chain)
        chain
        |> insert 6n 6
        |> ignore
        Assert.Equal([ 0; 1; 2; 3; 4; 5; 6 ], chain)

    [<Fact>]
    let ``Occurrences`` () =
        let chain = new Chain<int32>()
        chain
        |> add [| 1; 2; 1; 2; 1 |]
        |> ignore
        Assert.Equal(3n, chain |> occurrences 1)
        Assert.Equal(2n, chain |> occurrences 2)

    [<Fact(Skip = "Not implemented yet")>]
    let ``Readable`` () = raise(NotImplementedException()) |> ignore

    [<Fact>]
    let ``Replace`` () =
        let chain = new Chain<int32> ()
        chain
        |> add [| 1; 2; 1; 2; 1 |]
        |> replace 1 0
        |> ignore
        Assert.Equal([ 0; 2; 0; 2; 0 ], chain)

    [<Fact(Skip = "Not implemented yet")>]
    let ``Seek`` () = raise(NotImplementedException()) |> ignore

    [<Fact(Skip = "Not implemented yet")>]
    let ``Seekable`` () = raise(NotImplementedException()) |> ignore

    [<Fact(Skip = "Not implemented yet")>]
    let ``Shrink`` () = raise(NotImplementedException()) |> ignore

    [<Fact(Skip = "Not implemented yet")>]
    let ``Write`` () = raise(NotImplementedException()) |> ignore

    [<Fact(Skip = "Not implemented yet")>]
    let ``Writable`` () = raise(NotImplementedException()) |> ignore
