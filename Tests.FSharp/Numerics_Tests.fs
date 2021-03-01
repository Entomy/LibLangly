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
    [<MemberData(nameof(Numerics_Data.ArithmeticMean_nint), MemberType = typeof<Numerics_Data>)>]
    let ``ArithmeticMean_nativeint`` (expected:double, values:nativeint array) =
        let chain = new Chain<nativeint>() |> add values
        Assert.Equal(expected, mean.arithmetic chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.ArithmeticMean_nuint), MemberType = typeof<Numerics_Data>)>]
    let ``ArithmeticMean_unativeint`` (expected:double, values:unativeint array) =
        let chain = new Chain<unativeint>() |> add values
        Assert.Equal(expected, mean.arithmetic chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.ArithmeticMean_SByte), MemberType = typeof<Numerics_Data>)>]
    let ``ArithmeticMean_int8`` (expected:double, values:int8 array) =
        let chain = new Chain<int8>() |> add values
        Assert.Equal(expected, mean.arithmetic chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.ArithmeticMean_Byte), MemberType = typeof<Numerics_Data>)>]
    let ``ArithmeticMean_uint8`` (expected:double, values:uint8 array) =
        let chain = new Chain<uint8>() |> add values
        Assert.Equal(expected, mean.arithmetic chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.ArithmeticMean_Int16), MemberType = typeof<Numerics_Data>)>]
    let ``ArithmeticMean_int16`` (expected:double, values:int16 array) =
        let chain = new Chain<int16>() |> add values
        Assert.Equal(expected, mean.arithmetic chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.ArithmeticMean_UInt16), MemberType = typeof<Numerics_Data>)>]
    let ``ArithmeticMean_uint16`` (expected:double, values:uint16 array) =
        let chain = new Chain<uint16>() |> add values
        Assert.Equal(expected, mean.arithmetic chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.ArithmeticMean_Int32), MemberType = typeof<Numerics_Data>)>]
    let ``ArithmeticMean_int32`` (expected:double, values:int32 array) =
        let chain = new Chain<int32>() |> add values
        Assert.Equal(expected, mean.arithmetic chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.ArithmeticMean_UInt32), MemberType = typeof<Numerics_Data>)>]
    let ``ArithmeticMean_uint32`` (expected:double, values:uint32 array) =
        let chain = new Chain<uint32>() |> add values
        Assert.Equal(expected, mean.arithmetic chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.ArithmeticMean_Int64), MemberType = typeof<Numerics_Data>)>]
    let ``ArithmeticMean_int64`` (expected:double, values:int64 array) =
        let chain = new Chain<int64>() |> add values
        Assert.Equal(expected, mean.arithmetic chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.ArithmeticMean_UInt64), MemberType = typeof<Numerics_Data>)>]
    let ``ArithmeticMean_uint64`` (expected:double, values:uint64 array) =
        let chain = new Chain<uint64>() |> add values
        Assert.Equal(expected, mean.arithmetic chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.ArithmeticMean_Single), MemberType = typeof<Numerics_Data>)>]
    let ``ArithmeticMean_single`` (expected:double, values:single array) =
        let chain = new Chain<single>() |> add values
        Assert.Equal(expected, mean.arithmetic chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.ArithmeticMean_Double), MemberType = typeof<Numerics_Data>)>]
    let ``ArithmeticMean_double`` (expected:double, values:double array) =
        let chain = new Chain<double>() |> add values
        Assert.Equal(expected, mean.arithmetic chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.GeometricMean_nint), MemberType = typeof<Numerics_Data>)>]
    let ``GeometricMean_nativeint`` (expected:double, values:nativeint array) =
        let chain = new Chain<nativeint>() |> add values
        Assert.Equal(expected, mean.geometric chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.GeometricMean_nuint), MemberType = typeof<Numerics_Data>)>]
    let ``GeometricMean_unativeint`` (expected:double, values:unativeint array) =
        let chain = new Chain<unativeint>() |> add values
        Assert.Equal(expected, mean.geometric chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.GeometricMean_SByte), MemberType = typeof<Numerics_Data>)>]
    let ``GeometricMean_int8`` (expected:double, values:int8 array) =
        let chain = new Chain<int8>() |> add values
        Assert.Equal(expected, mean.geometric chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.GeometricMean_Byte), MemberType = typeof<Numerics_Data>)>]
    let ``GeometricMean_uint8`` (expected:double, values:uint8 array) =
        let chain = new Chain<uint8>() |> add values
        Assert.Equal(expected, mean.geometric chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.GeometricMean_Int16), MemberType = typeof<Numerics_Data>)>]
    let ``GeometricMean_int16`` (expected:double, values:int16 array) =
        let chain = new Chain<int16>() |> add values
        Assert.Equal(expected, mean.geometric chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.GeometricMean_UInt16), MemberType = typeof<Numerics_Data>)>]
    let ``GeometricMean_uint16`` (expected:double, values:uint16 array) =
        let chain = new Chain<uint16>() |> add values
        Assert.Equal(expected, mean.geometric chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.GeometricMean_Int32), MemberType = typeof<Numerics_Data>)>]
    let ``GeometricMean_int32`` (expected:double, values:int32 array) =
        let chain = new Chain<int32>() |> add values
        Assert.Equal(expected, mean.geometric chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.GeometricMean_UInt32), MemberType = typeof<Numerics_Data>)>]
    let ``GeometricMean_uint32`` (expected:double, values:uint32 array) =
        let chain = new Chain<uint32>() |> add values
        Assert.Equal(expected, mean.geometric chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.GeometricMean_Int64), MemberType = typeof<Numerics_Data>)>]
    let ``GeometricMean_int64`` (expected:double, values:int64 array) =
        let chain = new Chain<int64>() |> add values
        Assert.Equal(expected, mean.geometric chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.GeometricMean_UInt64), MemberType = typeof<Numerics_Data>)>]
    let ``GeometricMean_uint64`` (expected:double, values:uint64 array) =
        let chain = new Chain<uint64>() |> add values
        Assert.Equal(expected, mean.geometric chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.GeometricMean_Single), MemberType = typeof<Numerics_Data>)>]
    let ``GeometricMean_single`` (expected:double, values:single array) =
        let chain = new Chain<single>() |> add values
        Assert.Equal(expected, mean.geometric chain)

    [<Theory>]
    [<MemberData(nameof(Numerics_Data.GeometricMean_Double), MemberType = typeof<Numerics_Data>)>]
    let ``GeometricMean_double`` (expected:double, values:double array) =
        let chain = new Chain<double>() |> add values
        Assert.Equal(expected, mean.geometric chain)
