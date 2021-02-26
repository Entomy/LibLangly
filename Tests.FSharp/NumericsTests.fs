namespace Langly

open System
open Xunit
open Langly.DataStructures.Lists

module NumericsTests =

    [<Theory>]
    [<MemberData(nameof(NumericsData.Max_nint), MemberType = typeof<NumericsData>)>]
    let ``Max_nativeint`` (expected:double, values:nativeint array) =
        let chain = new Chain<nativeint>() |> add values
        Assert.Equal(expected, max chain)

    [<Theory>]
    [<MemberData(nameof(NumericsData.Max_nuint), MemberType = typeof<NumericsData>)>]
    let ``Max_unativeint`` (expected:double, values:unativeint array) =
        let chain = new Chain<unativeint>() |> add values
        Assert.Equal(expected, max chain)

    [<Theory>]
    [<MemberData(nameof(NumericsData.Max_SByte), MemberType = typeof<NumericsData>)>]
    let ``Max_int8`` (expected:single, values:int8 array) =
        let chain = new Chain<int8>() |> add values
        Assert.Equal(expected, max chain)

    [<Theory>]
    [<MemberData(nameof(NumericsData.Max_Byte), MemberType = typeof<NumericsData>)>]
    let ``Max_uint8`` (expected:single, values:uint8 array) =
        let chain = new Chain<uint8>() |> add values
        Assert.Equal(expected, max chain)

    [<Theory>]
    [<MemberData(nameof(NumericsData.Max_Int16), MemberType = typeof<NumericsData>)>]
    let ``Max_int16`` (expected:single, values:int16 array) =
        let chain = new Chain<int16>() |> add values
        Assert.Equal(expected, max chain)

    [<Theory>]
    [<MemberData(nameof(NumericsData.Max_UInt16), MemberType = typeof<NumericsData>)>]
    let ``Max_uint16`` (expected:single, values:uint16 array) =
        let chain = new Chain<uint16>() |> add values
        Assert.Equal(expected, max chain)

    [<Theory>]
    [<MemberData(nameof(NumericsData.Max_Int32), MemberType = typeof<NumericsData>)>]
    let ``Max_int32`` (expected:double, values:int32 array) =
        let chain = new Chain<int32>() |> add values
        Assert.Equal(expected, max chain)

    [<Theory>]
    [<MemberData(nameof(NumericsData.Max_UInt32), MemberType = typeof<NumericsData>)>]
    let ``Max_uint32`` (expected:double, values:uint32 array) =
        let chain = new Chain<uint32>() |> add values
        Assert.Equal(expected, max chain)

    [<Theory>]
    [<MemberData(nameof(NumericsData.Max_Int64), MemberType = typeof<NumericsData>)>]
    let ``Max_int64`` (expected:double, values:int64 array) =
        let chain = new Chain<int64>() |> add values
        Assert.Equal(expected, max chain)

    [<Theory>]
    [<MemberData(nameof(NumericsData.Max_UInt64), MemberType = typeof<NumericsData>)>]
    let ``Max_uint64`` (expected:double, values:uint64 array) =
        let chain = new Chain<uint64>() |> add values
        Assert.Equal(expected, max chain)

    [<Theory>]
    [<MemberData(nameof(NumericsData.Max_Single), MemberType = typeof<NumericsData>)>]
    let ``Max_single`` (expected:single, values:single array) =
        let chain = new Chain<single>() |> add values
        Assert.Equal(expected, max chain)

    [<Theory>]
    [<MemberData(nameof(NumericsData.Max_Double), MemberType = typeof<NumericsData>)>]
    let ``Max_double`` (expected:double, values:double array) =
        let chain = new Chain<double>() |> add values
        Assert.Equal(expected, max chain)

    [<Theory>]
    [<MemberData(nameof(NumericsData.Max_Decimal), MemberType = typeof<NumericsData>)>]
    let ``Max_decimal`` (expected:decimal, values:decimal array) =
        let chain = match values with
                    | null -> null
                    | _ -> new Chain<decimal>() |> add values
        match chain with
        | null -> Assert.Throws<Exceptions.ArgumentNullException>(fun () -> max chain |> ignore) |> ignore
        | chain when chain.Count = 0n -> Assert.Throws<Exceptions.ArgumentEmptyException>(fun () -> max chain |> ignore) |> ignore
        | _ -> Assert.Equal(expected, max chain)
