namespace Langly

open System
open Collectathon.Arrays
open Collectathon.Stacks
open Numbersome
open Xunit

module Tests =
    [<Fact>]
    let ``Add`` () =
        let array = dynamic[| |]
        array
        |> add 1
        |> ignore
        Assert.Equal([ 1 ], array)
        array
        |> add 2
        |> add 3
        |> ignore
        Assert.Equal([ 1; 2; 3 ], array)
        array
        |> add [| 4; 5 |]
        |> ignore
        Assert.Equal([ 1; 2; 3; 4; 5 ], array)

    [<Fact>]
    let ``Capacity`` () =
        let array = new BoundedArray<int32>(8n)
        Assert.Equal(8n, capacity array)

    [<Fact>]
    let ``Clear`` () =
        let array = bounded[| 1; 2; 3; 4; 5 |]
        Assert.Equal(5n, count array)
        array
        |> clear
        |> ignore
        Assert.Equal(0n, count array)

    [<Fact>]
    let ``Contains`` () =
        let array = dynamic[| 1; 2; 3; 4; 5 |]
        Assert.False(array |> contains 0)
        Assert.True(array |> contains 1)
        Assert.True(array |> contains 2)
        Assert.True(array |> contains 3)
        Assert.True(array |> contains 4)
        Assert.True(array |> contains 5)
        Assert.False(array |> contains 6)

    [<Fact>]
    let ``ContainsAll`` () =
        let array = dynamic[| 1; 2; 3; 4; 5 |]
        Assert.True(array |> containsAll [| 3; 4; 5 |])
        Assert.False(array |> containsAll [| 4; 5; 6 |])

    [<Fact>]
    let ``ContainsAny`` () =
        let array = dynamic[| 1; 2; 3; 4; 5 |]
        Assert.True(array |> containsAny [| 0; 1; 2 |])
        Assert.True(array |> containsAny [| 5; 6; 7 |])
        Assert.False(array |> containsAny [| 0; 6 |])

    [<Fact>]
    let ``Fold`` () =
        let array = dynamic[| 1; 2; 3; 4; 5 |]
        Assert.Equal(15, array |> fold (fun (l)(r) -> l + r) 0)
        Assert.Equal(120, array |> fold (fun (l)(r) -> l * r) 1)

    [<Fact>]
    let ``Grow`` () =
        let array = dynamic[| |] |> grow
        Assert.True((capacity array) > 8n)

    [<Fact>]
    let ``IndexOfFirst`` () =
        let array = dynamic[| 1; 2; 1; 2; 1 |]
        Assert.Equal(0n, array |> indexOfFirst 1)
        Assert.Equal(1n, array |> indexOfFirst 2)

    [<Fact>]
    let ``IndexOfLast`` () =
        let array = dynamic[| 1; 2; 1; 2; 1 |]
        Assert.Equal(4n, array |> indexOfLast 1)
        Assert.Equal(3n, array |> indexOfLast 2)

    [<Fact(Skip = "Not implemented yet")>]
    let ``Insert`` () = raise(NotImplementedException()) |> ignore

    [<Fact>]
    let ``Occurrences`` () =
        let array = dynamic[| 1; 2; 1; 2; 1 |]
        Assert.Equal(3n, array |> occurrences 1)
        Assert.Equal(2n, array |> occurrences 2)

    [<Fact>]
    let ``Product`` () =
        let array = bounded[| 1; 2; 3; 4; 5 |]
        Assert.Equal(120.0, product array)

    [<Fact(Skip = "Not implemented yet")>]
    let ``Readable`` () = raise(NotImplementedException()) |> ignore

    [<Fact>]
    let ``Replace`` () =
        let array = dynamic[| 1; 2; 1; 2; 1 |]
        array
        |> replace 1 0
        |> ignore
        Assert.Equal([ 0; 2; 0; 2; 0 ], array)

    [<Fact(Skip = "Not implemented yet")>]
    let ``Seek`` () = raise(NotImplementedException()) |> ignore

    [<Fact(Skip = "Not implemented yet")>]
    let ``Seekable`` () = raise(NotImplementedException()) |> ignore

    [<Fact(Skip = "Not implemented yet")>]
    let ``Shift`` () = raise(NotImplementedException()) |> ignore

    [<Fact(Skip = "Not implemented yet")>]
    let ``Shrink`` () = raise(NotImplementedException()) |> ignore

    [<Fact(Skip = "Not implemented yet")>]
    let ``Slice`` () = raise(NotImplementedException()) |> ignore

    [<Fact>]
    let ``Stack`` () =
        let stack = stack<double>()
        stack
        |> write -1.0
        |> Stack.abs
        |> ignore
        Assert.Equal(1.0, peek stack)
        stack
        |> write 2.0
        |> Stack.add
        |> ignore
        Assert.Equal(3.0, peek stack)
        stack
        |> Stack.cbrt
        |> ignore
        Assert.Equal(Math.Cbrt(3.0), peek stack)

    [<Fact>]
    let ``Sum`` () =
        let array = bounded[| 1; 2; 3; 4; 5 |]
        Assert.Equal(15.0, sum array)

    [<Fact(Skip = "Not implemented yet")>]
    let ``Write`` () = raise(NotImplementedException()) |> ignore

    [<Fact(Skip = "Not implemented yet")>]
    let ``Writable`` () = raise(NotImplementedException()) |> ignore
