namespace Tests

open System
open Stringier
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type GlyphTests() =
    [<DataTestMethod>]
    [<DataRow("\u00C0", "\u0041\u0300")>]
    member _.``constructor - sequence`` (first:string, second:string) =
        Assert.AreEqual(Glyph(first), Glyph(second))
        Assert.AreEqual(Glyph(second), Glyph(first))