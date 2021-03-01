namespace Langly

open System
open Xunit
open Langly.DataStructures.Lists

module NumericsTests =

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.Max_nint), MemberType = typeof<Numerics_Data>)>]
    let ``Max_nativeint`` (expected:double, values:nativeint array) =
        let chain = new Chain<nativeint>() |> add values
        Assert.Equal(expected, max chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.Max_nuint), MemberType = typeof<Numerics_Data>)>]
    let ``Max_unativeint`` (expected:double, values:unativeint array) =
        let chain = new Chain<unativeint>() |> add values
        Assert.Equal(expected, max chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.Max_SByte), MemberType = typeof<Numerics_Data>)>]
    let ``Max_int8`` (expected:single, values:int8 array) =
        let chain = new Chain<int8>() |> add values
        Assert.Equal(expected, max chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.Max_Byte), MemberType = typeof<Numerics_Data>)>]
    let ``Max_uint8`` (expected:single, values:uint8 array) =
        let chain = new Chain<uint8>() |> add values
        Assert.Equal(expected, max chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.Max_Int16), MemberType = typeof<Numerics_Data>)>]
    let ``Max_int16`` (expected:single, values:int16 array) =
        let chain = new Chain<int16>() |> add values
        Assert.Equal(expected, max chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.Max_UInt16), MemberType = typeof<Numerics_Data>)>]
    let ``Max_uint16`` (expected:single, values:uint16 array) =
        let chain = new Chain<uint16>() |> add values
        Assert.Equal(expected, max chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.Max_Int32), MemberType = typeof<Numerics_Data>)>]
    let ``Max_int32`` (expected:double, values:int32 array) =
        let chain = new Chain<int32>() |> add values
        Assert.Equal(expected, max chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.Max_UInt32), MemberType = typeof<Numerics_Data>)>]
    let ``Max_uint32`` (expected:double, values:uint32 array) =
        let chain = new Chain<uint32>() |> add values
        Assert.Equal(expected, max chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.Max_Int64), MemberType = typeof<Numerics_Data>)>]
    let ``Max_int64`` (expected:double, values:int64 array) =
        let chain = new Chain<int64>() |> add values
        Assert.Equal(expected, max chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.Max_UInt64), MemberType = typeof<Numerics_Data>)>]
    let ``Max_uint64`` (expected:double, values:uint64 array) =
        let chain = new Chain<uint64>() |> add values
        Assert.Equal(expected, max chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.Max_Single), MemberType = typeof<Numerics_Data>)>]
    let ``Max_single`` (expected:single, values:single array) =
        let chain = new Chain<single>() |> add values
        Assert.Equal(expected, max chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.Max_Double), MemberType = typeof<Numerics_Data>)>]
    let ``Max_double`` (expected:double, values:double array) =
        let chain = new Chain<double>() |> add values
        Assert.Equal(expected, max chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.Max_Decimal), MemberType = typeof<Numerics_Data>)>]
    let ``Max_decimal`` (expected:decimal, values:decimal array) =
        let chain = new Chain<decimal>() |> add values
        match chain with
        | null -> Assert.Throws<Exceptions.ArgumentNullException>(fun () -> max chain |> ignore) |> ignore
        | chain when chain.Count = 0n -> Assert.Throws<Exceptions.ArgumentEmptyException>(fun () -> max chain |> ignore) |> ignore
        | _ -> Assert.Equal(expected, max chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.Mean_nint), MemberType = typeof<Numerics_Data>)>]
    let ``Mean_nativeint`` (expected:double, values:nativeint array, kind:Mean) =
        let chain = new Chain<nativeint>() |> add values
        Assert.Equal(expected, mean kind chain)


    [<Theory>]
    [<MemberData(nameof(Numerics_Data.Mean_nuint), MemberType = typeof<Numerics_Data>)>]
    let ``Mean_unativeint`` (expected:double, values:unativeint array, kind:Mean) =
        let chain = new Chain<unativeint>() |> add values
        Assert.Equal(expected, mean kind chain)
