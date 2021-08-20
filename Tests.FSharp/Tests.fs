namespace Langly

open System
open Collectathon
open Numbersome
open Stringier
open Stringier.Patterns
open Xunit

module Tests =

    [<Fact>]
    let ``op_UnaryPlus`` () =
        Assert.Equal(1y, +1y)
        Assert.Equal(1s, +1s)
        Assert.Equal(1l, +1l)
        Assert.Equal(1L, +1L)
        Assert.Equal(1n, +1n)
        Assert.Equal(1uy, +1uy)
        Assert.Equal(1us, +1us)
        Assert.Equal(1ul, +1ul)
        Assert.Equal(1uL, +1uL)
        Assert.Equal(1un, +1un)
        Assert.Equal(1.0f, +1.0f)
        Assert.Equal(1.0, +1.0)
        Assert.Equal(1.0m, +1.0m)

    [<Fact>]
    let ``op_UnaryNegation`` () =
        Assert.Equal(0y - 1y, -1y)
        Assert.Equal(0s - 1s, -1s)
        Assert.Equal(0l - 1l, -1l)
        Assert.Equal(0L - 1L, -1L)
        Assert.Equal(0n - 1n, -1n)
        Assert.Equal(0.0f - 1.0f, -1.0f)
        Assert.Equal(0.0 - 1.0, -1.0)
        Assert.Equal(0.0m - 1.0m, -1.0m)

    [<Fact>]
    let ``op_Addition`` () =
        Assert.Equal(2y, 1y + 1y)
        Assert.Equal(2s, 1s + 1s)
        Assert.Equal(2l, 1l + 1l)
        Assert.Equal(2L, 1L + 1L)
        Assert.Equal(2n, 1n + 1n)
        Assert.Equal(2uy, 1uy + 1uy)
        Assert.Equal(2us, 1us + 1us)
        Assert.Equal(2ul, 1ul + 1ul)
        Assert.Equal(2uL, 1uL + 1uL)
        Assert.Equal(2un, 1un + 1un)
        Assert.Equal(2.0f, 1.0f + 1.0f)
        Assert.Equal(2.0, 1.0 + 1.0)
        Assert.Equal(2.0m, 1.0m + 1.0m)

    [<Fact>]
    let ``op_Subtraction`` () =
        Assert.Equal(0y, 1y - 1y)
        Assert.Equal(0u, 1u - 1u)
        Assert.Equal(0l, 1l - 1l)
        Assert.Equal(0L, 1L - 1L)
        Assert.Equal(0n, 1n - 1n)
        Assert.Equal(0uy, 1uy - 1uy)
        Assert.Equal(0us, 1us - 1us)
        Assert.Equal(0ul, 1ul - 1ul)
        Assert.Equal(0uL, 1uL - 1uL)
        Assert.Equal(0un, 1un - 1un)
        Assert.Equal(0.0f, 1.0f - 1.0f)
        Assert.Equal(0.0, 1.0 - 1.0)
        Assert.Equal(0.0m, 1.0m - 1.0m)

    [<Fact>]
    let ``op_Multiply`` () =
        Assert.Equal(4y, 2y * 2y)
        Assert.Equal(4s, 2s * 2s)
        Assert.Equal(4l, 2l * 2l)
        Assert.Equal(4L, 2L * 2L)
        Assert.Equal(4n, 2n * 2n)
        Assert.Equal(4uy, 2uy * 2uy)
        Assert.Equal(4us, 2us * 2us)
        Assert.Equal(4ul, 2ul * 2ul)
        Assert.Equal(4uL, 2uL * 2uL)
        Assert.Equal(4un, 2un * 2un)
        Assert.Equal(4.0f, 2.0f * 2.0f)
        Assert.Equal(4.0, 2.0 * 2.0)
        Assert.Equal(4.0m, 2.0m * 2.0m)

    [<Fact>]
    let ``op_Division`` () =
        Assert.Equal(1y, 2y / 2y)
        Assert.Equal(1s, 2s / 2s)
        Assert.Equal(1l, 2l / 2l)
        Assert.Equal(1L, 2L / 2L)
        Assert.Equal(1n, 2n / 2n)
        Assert.Equal(1uy, 2uy / 2uy)
        Assert.Equal(1us, 2us / 2us)
        Assert.Equal(1ul, 2ul / 2ul)
        Assert.Equal(1uL, 2uL / 2uL)
        Assert.Equal(1un, 2un / 2un)
        Assert.Equal(1.0f, 2.0f / 2.0f)
        Assert.Equal(1.0, 2.0 / 2.0)
        Assert.Equal(1.0m, 2.0m / 2.0m)

    [<Fact>]
    let ``op_Modulus`` () =
        Assert.Equal(0y, 2y % 2y)
        Assert.Equal(0s, 2s % 2s)
        Assert.Equal(0l, 2l % 2l)
        Assert.Equal(0L, 2L % 2L)
        Assert.Equal(0n, 2n % 2n)
        Assert.Equal(0uy, 2uy % 2uy)
        Assert.Equal(0us, 2us % 2us)
        Assert.Equal(0ul, 2ul % 2ul)
        Assert.Equal(0uL, 2uL % 2uL)
        Assert.Equal(0un, 2un % 2un)
        Assert.Equal(0.0f, 2.0f % 2.0f)
        Assert.Equal(0.0, 2.0 % 2.0)
        Assert.Equal(0.0m, 2.0m % 2.0m)

    [<Fact>]
    let ``op_ShiftLeft`` () =
        Assert.Equal(2, 1 <<< 1)
        Assert.Equal(4, 1 <<< 2)
        Assert.Equal(bnd[| 2; 3; 4; 0 |], bnd[| 1; 2; 3; 4 |] <<< 1)

    [<Fact>]
    let ``op_ShiftRight`` () =
        Assert.Equal(2, 4 >>> 1)
        Assert.Equal(1, 4 >>> 2)
        Assert.Equal(bnd[| 0; 1; 2; 3 |], bnd[| 1; 2; 3; 4 |] >>> 1)

    [<Fact>]
    let ``op_BitwiseAnd`` () =
        Assert.Equal(1y, 1y &&& 3y)
        Assert.Equal(1s, 1s &&& 3s)
        Assert.Equal(1l, 1l &&& 3l)
        Assert.Equal(1L, 1L &&& 3L)
        Assert.Equal(1n, 1n &&& 3n)
        Assert.Equal(1uy, 1uy &&& 3uy)
        Assert.Equal(1us, 1us &&& 3us)
        Assert.Equal(1ul, 1ul &&& 3ul)
        Assert.Equal(1uL, 1uL &&& 3uL)
        Assert.Equal(1un, 1un &&& 3un)

    [<Fact>]
    let ``op_BitwiseOr`` () =
        Assert.Equal(3y, 1y ||| 3y)
        Assert.Equal(3s, 1s ||| 3s)
        Assert.Equal(3l, 1l ||| 3l)
        Assert.Equal(3L, 1L ||| 3L)
        Assert.Equal(3n, 1n ||| 3n)
        Assert.Equal(3uy, 1uy ||| 3uy)
        Assert.Equal(3us, 1us ||| 3us)
        Assert.Equal(3ul, 1ul ||| 3ul)
        Assert.Equal(3uL, 1uL ||| 3uL)
        Assert.Equal(3un, 1un ||| 3un)

    [<Fact>]
    let ``op_ExclusiveOr`` () =
        Assert.Equal(2y, 1y ^^^ 3y)
        Assert.Equal(2s, 1s ^^^ 3s)
        Assert.Equal(2l, 1l ^^^ 3l)
        Assert.Equal(2L, 1L ^^^ 3L)
        Assert.Equal(2n, 1n ^^^ 3n)
        Assert.Equal(2uy, 1uy ^^^ 3uy)
        Assert.Equal(2us, 1us ^^^ 3us)
        Assert.Equal(2ul, 1ul ^^^ 3ul)
        Assert.Equal(2uL, 1uL ^^^ 3uL)
        Assert.Equal(2un, 1un ^^^ 3un)

    [<Fact>]
    let ``Arrays`` () =
        let ba:int boundedarray = bnd[|1;2;3;4;5|]
        let da:int dynamicarray = dyn[|1;2;3;4;5|]
        ()

    [<Fact>]
    let ``Lists`` () =
        let sll:int singlylinked = sll[1;2;3;4;5]
        ()

    [<Fact>]
    let ``Counters`` () =
        let counter:char counter = Counter<char>()
        ()

    [<Fact>]
    let ``Random`` () =
        let random:random = random
        ()

    [<Fact>]
    let ``Sets`` () =
        let set:int set = Set<int>([|1;2;3;4|])
        ()

    [<Fact>]
    let ``Categories`` () =
        let category:category = Category.WhiteSpace
        ()

    [<Fact>]
    let ``Patterns`` () =
        let stringLiteral:pattern = p"hello"
        let charLiteral:pattern = p '!'
        let arrayLiteral:pattern = p[|'h';'e';'l';'l';'o'|]
        ()

    [<Fact>]
    let ``Rope`` () =
        let rope:rope = Rope()
        ()
