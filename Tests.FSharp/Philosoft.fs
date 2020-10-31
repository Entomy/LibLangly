namespace Philosoft

open Collectathon.Arrays
open System
open Xunit

module FSharp =
    [<Fact>]
    let ``Add`` () =
        let array = DynamicArray<Int32>(8n)
        Assert.Equal(0n, array.Length)
        array |> add 1 |> ignore
        Assert.Equal(1n, array.Length)
        Assert.Equal(1, array.[0n])
        array |> add [| 2; 3; 4 |] |> ignore
        Assert.Equal(4n, array.Length)
        Assert.Equal(1, array.[0n])
        Assert.Equal(2, array.[1n])
        Assert.Equal(3, array.[2n])
        Assert.Equal(4, array.[3n])

    [<Fact>]
    let ``Clear`` () =
        let array = DynamicArray<Int32>(8n)
                    |> add [| 1; 2; 3; 4; 5 |]
        Assert.Equal(5n, array.Length);
        clear array
        Assert.Equal(0n, array.Length);

    [<Fact>]
    let ``Clone`` () =
        let array = DynamicArray<Int32>(8n)
                    |> add [| 1; 2; 3; 4; 5 |]
        let copy = clone array
        Assert.Equal<DynamicArray<Int32>>(array, copy)

    [<Fact>]
    let ``Contains`` () =
        let array = DynamicArray<Int32>(8n)
                    |> add [| 1; 2; 3; 4; 5 |]
        Assert.False(array |> contains 0)
        Assert.True(array |> contains 1)
        Assert.True(array |> contains 3)
        Assert.True(array |> contains 5)
        Assert.False(array |> contains 6)

    [<Fact>]
    let ``Fold`` () =
        let array = DynamicArray<Int32>(8n)
                    |> add [| 1; 2; 3; 4; 5 |]
        let sum = array
                    |> fold (fun (a)(b) -> a + b) 0
        Assert.Equal(15, sum)

    [<Fact>]
    let ``Map`` () =
        let array = DynamicArray<Int32>(8n)
                    |> add [| 1; 2; 3; 4; 5 |]
                    |> map (fun (x) -> x * 2)
        Assert.Equal([| 2; 4; 6; 8; 10 |], array)

    [<Fact>]
    let ``Occurrences`` () =
        let array = DynamicArray<Int32>(8n)
                    |> add [| 1; 2; 3; 4; 5 |]
        Assert.Equal(0n, array |> occurrences 0)
        Assert.Equal(1n, array |> occurrences 1)

    [<Fact>]
    let ``Remove`` () =
        let array = DynamicArray<Int32>(8n)
                    |> add [| 0; 1; 0; 2; 0; 3; 0; 4; 0; 5; 0 |]
                    |> remove 0
        Assert.Equal([| 1; 2; 3; 4; 5 |], array)

    [<Fact>]
    let ``Stack`` () =
        let array = DynamicArray<Int32>(8n) |> push [| 1; 2; 3 |]
        let first = pop array
        Assert.Equal(3, first);
