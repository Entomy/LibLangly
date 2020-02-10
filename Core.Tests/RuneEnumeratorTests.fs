namespace Core

open System
open System.Buffers
open System.Collections.Generic
open System.Globalization
open System.Linq
open System.Text
open Stringier
open Microsoft.VisualStudio.TestTools.UnitTesting
open OperatorFixes

//! This file uses testing code/approaches also used by the .NET Core runtime. Copyright belongs to the .NET Core Foundation.

[<TestClass>]
type RuneEnumeratorsTests() =
    static member EnumerateData():seq<obj[]> = seq {
        yield [| RuneEnumeratorData(Array.Empty<char>(), Array.Empty<int>()) |]
        yield [| RuneEnumeratorData([|'x';'y';'z'|], [|int 'x';int 'y';int 'z'|]) |]
        yield [| RuneEnumeratorData([|'x';'\uD86D';'\uDF54';'y'|], [|int 'x';0x2B754;int 'y'|]) |] // valid surrogate pair
        yield [| RuneEnumeratorData([|'x';'\uD86D';'y'|], [|int 'x';0xFFFD;int 'y'|]) |] // standalone high surrogate
        yield [| RuneEnumeratorData([|'x';'\uDF54';'y'|], [|int 'x';0xFFFD;int 'y'|]) |] // standalone low surrogate
        yield [| RuneEnumeratorData([|'x';'\uD86D'|], [|int 'x';0xFFFD|]) |] // standalone high surrogate at end of string
        yield [| RuneEnumeratorData([|'x';'\uDF54'|], [|int 'x';0xFFFD|]) |] // standalone low surrogate at end of string
        yield [| RuneEnumeratorData([|'x';'\uD86D';'\uD86D';'y'|], [|int 'x';0xFFFD;0xFFFD;int 'y'|]) |] // two high surrogates should be two replacement chars
        yield [| RuneEnumeratorData([|'x';'\uFFFD';'y'|], [|int 'x';0xFFFD;int 'y'|]) |] // literal U+FFFD
    }

    [<DataTestMethod>]
    [<DynamicData("EnumerateData", DynamicDataSourceType.Method)>]
    member _.``EnumerateRunes``(data:RuneEnumeratorData):unit =
        // Test data is smuggled as char[] instead of straight-up string since the test framework
        // doesn't like invalid UTF-16 literals.

        let asString = String(data.Chars)

        // First, use a straight-up foreach keyword to ensure pattern matching works as expected

        let enumeratedScalarValues = List<Int32>()
        for rune in asString.EnumerateRunes() do
            enumeratedScalarValues.Add(rune.Value)
        CollectionAssert.AreEqual(data.Expected, enumeratedScalarValues.ToArray())

        // Then use LINQ to ensure IEnumerator<...> works as expected

        let enumeratedValues:int[] = (String(data.Chars)).EnumerateRunes().Select(fun (r) -> r.Value).ToArray()
        CollectionAssert.AreEqual(data.Expected, enumeratedValues)