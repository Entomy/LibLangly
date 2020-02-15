namespace Core

open System
open System.Globalization
open System.Text
open Stringier
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type GlyphTests() =
    [<DataTestMethod>]
    [<DataRow(0, "\u00E0", "\u00E0")>]
    [<DataRow(0, "\u00E0", "\u0061\u0300")>]
    [<DataRow(0, "\u0061\u0300", "\u00E0")>]
    [<DataRow(0, "\u0061\u0300", "\u0061\u0300")>]
    [<DataRow(1, "\u00C0", "\u00E0")>]
    [<DataRow(1, "\u00C0", "\u0061\u0300")>]
    [<DataRow(1, "\u0041\u0300", "\u00E0")>]
    [<DataRow(1, "\u0041\u0300", "\u0061\u0300")>]
    [<DataRow(-1, "\u00E0", "\u00C0")>]
    [<DataRow(-1, "\u00E0", "\u0041\u0300")>]
    [<DataRow(-1, "\u0061\u0300", "\u00C0")>]
    [<DataRow(-1, "\u0061\u0300", "\u0041\u0300")>]
    member _.``compare - glyph`` (exp:int, first:string, second:string) =
        let a = Glyph(first)
        let b = Glyph(second)

        Assert.AreEqual(exp, Math.Sign(a.CompareTo(b)))
        Assert.AreEqual(exp < 0, a < b)
        Assert.AreEqual(exp <= 0, a <= b)
        Assert.AreEqual(exp > 0, a > b)
        Assert.AreEqual(exp >= 0, a >= b)

    [<DataTestMethod>]
    [<DataRow([|'a'|], "\u0061")>]
    [<DataRow([|'a';'ë'|], "\u0061\u00EB")>]
    [<DataRow([|'a';'ë'|], "\u0061\u0065\u0304")>]
    [<DataRow([|'a';'ç';'ë'|], "\u0061\u00E7\u00EB")>]
    [<DataRow([|'a';'ç';'ë'|], "\u0061\u00E7\u0065\u0304")>]
    [<DataRow([|'a';'ç';'ë'|], "\u0061\u0063\u0327\u00EB")>]
    [<DataRow([|'a';'ç';'ë'|], "\u0061\u0063\u0327\u0065\u0304")>]
    member _.``enumerator - string`` (exp:char[], src:string) =
        let mutable i = 0
        for glyph in src.EnumerateGlyphs() do
            Assert.AreEqual(Glyph(exp.[i]), glyph)
            i <- i + 1

    [<DataTestMethod>]
    [<DataRow([|'a'|], "\u0061")>]
    [<DataRow([|'a';'ë'|], "\u0061\u00EB")>]
    [<DataRow([|'a';'ë'|], "\u0061\u0065\u0304")>]
    [<DataRow([|'a';'ç';'ë'|], "\u0061\u00E7\u00EB")>]
    [<DataRow([|'a';'ç';'ë'|], "\u0061\u00E7\u0065\u0304")>]
    [<DataRow([|'a';'ç';'ë'|], "\u0061\u0063\u0327\u00EB")>]
    [<DataRow([|'a';'ç';'ë'|], "\u0061\u0063\u0327\u0065\u0304")>]
    member _.``enumerator - span`` (exp:char[], src:string) =
        let mutable i = 0
        for glyph in src.AsSpan().EnumerateGlyphs() do
            Assert.AreEqual(Glyph(exp.[i]), glyph)
            i <- i + 1

    [<DataTestMethod>]
    [<DataRow("\u00C0", "\u0041\u0300")>] // À
    [<DataRow("\u00C1", "\u0041\u0301")>] // Á
    [<DataRow("\u00C2", "\u0041\u0302")>] // Â
    [<DataRow("\u00C3", "\u0041\u0303")>] // Ã
    [<DataRow("\u00C4", "\u0041\u0304")>] // Ä
    [<DataRow("\u00C5", "\u0041\u030A")>] // Å
    [<DataRow("\u00C6", "\u0041\u0045")>] // Æ
    [<DataRow("\u00C7", "\u0043\u0327")>] // Ç
    [<DataRow("\u00C8", "\u0045\u0300")>] // È
    [<DataRow("\u00C9", "\u0045\u0301")>] // É
    [<DataRow("\u00CA", "\u0045\u0302")>] // Ê
    [<DataRow("\u00CB", "\u0045\u0304")>] // Ë
    [<DataRow("\u00CC", "\u0049\u0300")>] // Ì
    [<DataRow("\u00CD", "\u0049\u0301")>] // Í
    [<DataRow("\u00CE", "\u0049\u0302")>] // Î
    [<DataRow("\u00CF", "\u0049\u0304")>] // Ï
    [<DataRow("\u00D1", "\u004E\u0303")>] // Ñ
    [<DataRow("\u00D2", "\u004F\u0300")>] // Ò
    [<DataRow("\u00D3", "\u004F\u0301")>] // Ó
    [<DataRow("\u00D4", "\u004F\u0302")>] // Ô
    [<DataRow("\u00D5", "\u004F\u0303")>] // Õ
    [<DataRow("\u00D6", "\u004F\u0304")>] // Ö
    [<DataRow("\u00D9", "\u0055\u0300")>] // Ù
    [<DataRow("\u00DA", "\u0055\u0301")>] // Ú
    [<DataRow("\u00DB", "\u0055\u0302")>] // Û
    [<DataRow("\u00DC", "\u0055\u0304")>] // Ü
    [<DataRow("\u00DD", "\u0059\u0301")>] // Ý
    [<DataRow("\u00E0", "\u0061\u0300")>] // à
    [<DataRow("\u00E1", "\u0061\u0301")>] // á
    [<DataRow("\u00E2", "\u0061\u0302")>] // â
    [<DataRow("\u00E3", "\u0061\u0303")>] // ã
    [<DataRow("\u00E4", "\u0061\u0304")>] // ä
    [<DataRow("\u00E5", "\u0061\u030A")>] // å
    [<DataRow("\u00E6", "\u0061\u0065")>] // æ
    [<DataRow("\u00E8", "\u0065\u0300")>] // è
    [<DataRow("\u00E9", "\u0065\u0301")>] // é
    [<DataRow("\u00EA", "\u0065\u0302")>] // ê
    [<DataRow("\u00EB", "\u0065\u0304")>] // ë
    [<DataRow("\u00EC", "\u0069\u0300")>] // ì
    [<DataRow("\u00ED", "\u0069\u0301")>] // í
    [<DataRow("\u00EE", "\u0069\u0302")>] // î
    [<DataRow("\u00EF", "\u0069\u0304")>] // ï
    [<DataRow("\u00F1", "\u006E\u0303")>] // ñ
    [<DataRow("\u00F2", "\u006F\u0300")>] // ò
    [<DataRow("\u00F3", "\u006F\u0301")>] // ó
    [<DataRow("\u00F4", "\u006F\u0302")>] // ô
    [<DataRow("\u00F5", "\u006F\u0303")>] // õ
    [<DataRow("\u00F6", "\u006F\u0304")>] // ö
    [<DataRow("\u00F9", "\u0075\u0300")>] // ù
    [<DataRow("\u00FA", "\u0075\u0301")>] // ú
    [<DataRow("\u00FB", "\u0075\u0302")>] // û
    [<DataRow("\u00FC", "\u0075\u0304")>] // ü
    [<DataRow("\u00FD", "\u0079\u0301")>] // ý
    [<DataRow("\u00FE", "\u0079\u0304")>] // ÿ
    member _.``equals - sequence`` (first:string, second:string) =
        Assert.AreEqual(Glyph(first), Glyph(second))
        Assert.AreEqual(Glyph(second), Glyph(first))

    [<DataTestMethod>]
    [<DataRow('\u00C0', "\u0041\u0300")>] // À
    [<DataRow('\u00C1', "\u0041\u0301")>] // Á
    [<DataRow('\u00C2', "\u0041\u0302")>] // Â
    [<DataRow('\u00C3', "\u0041\u0303")>] // Ã
    [<DataRow('\u00C4', "\u0041\u0304")>] // Ä
    [<DataRow('\u00C5', "\u0041\u030A")>] // Å
    [<DataRow('\u00C6', "\u0041\u0045")>] // Æ
    [<DataRow('\u00C7', "\u0043\u0327")>] // Ç
    [<DataRow('\u00C8', "\u0045\u0300")>] // È
    [<DataRow('\u00C9', "\u0045\u0301")>] // É
    [<DataRow('\u00CA', "\u0045\u0302")>] // Ê
    [<DataRow('\u00CB', "\u0045\u0304")>] // Ë
    [<DataRow('\u00CC', "\u0049\u0300")>] // Ì
    [<DataRow('\u00CD', "\u0049\u0301")>] // Í
    [<DataRow('\u00CE', "\u0049\u0302")>] // Î
    [<DataRow('\u00CF', "\u0049\u0304")>] // Ï
    [<DataRow('\u00D1', "\u004E\u0303")>] // Ñ
    [<DataRow('\u00D2', "\u004F\u0300")>] // Ò
    [<DataRow('\u00D3', "\u004F\u0301")>] // Ó
    [<DataRow('\u00D4', "\u004F\u0302")>] // Ô
    [<DataRow('\u00D5', "\u004F\u0303")>] // Õ
    [<DataRow('\u00D6', "\u004F\u0304")>] // Ö
    [<DataRow('\u00D9', "\u0055\u0300")>] // Ù
    [<DataRow('\u00DA', "\u0055\u0301")>] // Ú
    [<DataRow('\u00DB', "\u0055\u0302")>] // Û
    [<DataRow('\u00DC', "\u0055\u0304")>] // Ü
    [<DataRow('\u00DD', "\u0059\u0301")>] // Ý
    [<DataRow('\u00E0', "\u0061\u0300")>] // à
    [<DataRow('\u00E1', "\u0061\u0301")>] // á
    [<DataRow('\u00E2', "\u0061\u0302")>] // â
    [<DataRow('\u00E3', "\u0061\u0303")>] // ã
    [<DataRow('\u00E4', "\u0061\u0304")>] // ä
    [<DataRow('\u00E5', "\u0061\u030A")>] // å
    [<DataRow('\u00E6', "\u0061\u0065")>] // æ
    [<DataRow('\u00E8', "\u0065\u0300")>] // è
    [<DataRow('\u00E9', "\u0065\u0301")>] // é
    [<DataRow('\u00EA', "\u0065\u0302")>] // ê
    [<DataRow('\u00EB', "\u0065\u0304")>] // ë
    [<DataRow('\u00EC', "\u0069\u0300")>] // ì
    [<DataRow('\u00ED', "\u0069\u0301")>] // í
    [<DataRow('\u00EE', "\u0069\u0302")>] // î
    [<DataRow('\u00EF', "\u0069\u0304")>] // ï
    [<DataRow('\u00F1', "\u006E\u0303")>] // ñ
    [<DataRow('\u00F2', "\u006F\u0300")>] // ò
    [<DataRow('\u00F3', "\u006F\u0301")>] // ó
    [<DataRow('\u00F4', "\u006F\u0302")>] // ô
    [<DataRow('\u00F5', "\u006F\u0303")>] // õ
    [<DataRow('\u00F6', "\u006F\u0304")>] // ö
    [<DataRow('\u00F9', "\u0075\u0300")>] // ù
    [<DataRow('\u00FA', "\u0075\u0301")>] // ú
    [<DataRow('\u00FB', "\u0075\u0302")>] // û
    [<DataRow('\u00FC', "\u0075\u0304")>] // ü
    [<DataRow('\u00FD', "\u0079\u0301")>] // ý
    [<DataRow('\u00FE', "\u0079\u0304")>] // ÿ
    member _.``equals - char`` (ch:char, sequence:string) =
        Assert.AreEqual(Glyph(sequence), ch)

    [<DataTestMethod>]
    [<DataRow('\u00C0', "\u0041\u0300")>] // À
    [<DataRow('\u00C1', "\u0041\u0301")>] // Á
    [<DataRow('\u00C2', "\u0041\u0302")>] // Â
    [<DataRow('\u00C3', "\u0041\u0303")>] // Ã
    [<DataRow('\u00C4', "\u0041\u0304")>] // Ä
    [<DataRow('\u00C5', "\u0041\u030A")>] // Å
    [<DataRow('\u00C6', "\u0041\u0045")>] // Æ
    [<DataRow('\u00C7', "\u0043\u0327")>] // Ç
    [<DataRow('\u00C8', "\u0045\u0300")>] // È
    [<DataRow('\u00C9', "\u0045\u0301")>] // É
    [<DataRow('\u00CA', "\u0045\u0302")>] // Ê
    [<DataRow('\u00CB', "\u0045\u0304")>] // Ë
    [<DataRow('\u00CC', "\u0049\u0300")>] // Ì
    [<DataRow('\u00CD', "\u0049\u0301")>] // Í
    [<DataRow('\u00CE', "\u0049\u0302")>] // Î
    [<DataRow('\u00CF', "\u0049\u0304")>] // Ï
    [<DataRow('\u00D1', "\u004E\u0303")>] // Ñ
    [<DataRow('\u00D2', "\u004F\u0300")>] // Ò
    [<DataRow('\u00D3', "\u004F\u0301")>] // Ó
    [<DataRow('\u00D4', "\u004F\u0302")>] // Ô
    [<DataRow('\u00D5', "\u004F\u0303")>] // Õ
    [<DataRow('\u00D6', "\u004F\u0304")>] // Ö
    [<DataRow('\u00D9', "\u0055\u0300")>] // Ù
    [<DataRow('\u00DA', "\u0055\u0301")>] // Ú
    [<DataRow('\u00DB', "\u0055\u0302")>] // Û
    [<DataRow('\u00DC', "\u0055\u0304")>] // Ü
    [<DataRow('\u00DD', "\u0059\u0301")>] // Ý
    [<DataRow('\u00E0', "\u0061\u0300")>] // à
    [<DataRow('\u00E1', "\u0061\u0301")>] // á
    [<DataRow('\u00E2', "\u0061\u0302")>] // â
    [<DataRow('\u00E3', "\u0061\u0303")>] // ã
    [<DataRow('\u00E4', "\u0061\u0304")>] // ä
    [<DataRow('\u00E5', "\u0061\u030A")>] // å
    [<DataRow('\u00E6', "\u0061\u0065")>] // æ
    [<DataRow('\u00E8', "\u0065\u0300")>] // è
    [<DataRow('\u00E9', "\u0065\u0301")>] // é
    [<DataRow('\u00EA', "\u0065\u0302")>] // ê
    [<DataRow('\u00EB', "\u0065\u0304")>] // ë
    [<DataRow('\u00EC', "\u0069\u0300")>] // ì
    [<DataRow('\u00ED', "\u0069\u0301")>] // í
    [<DataRow('\u00EE', "\u0069\u0302")>] // î
    [<DataRow('\u00EF', "\u0069\u0304")>] // ï
    [<DataRow('\u00F1', "\u006E\u0303")>] // ñ
    [<DataRow('\u00F2', "\u006F\u0300")>] // ò
    [<DataRow('\u00F3', "\u006F\u0301")>] // ó
    [<DataRow('\u00F4', "\u006F\u0302")>] // ô
    [<DataRow('\u00F5', "\u006F\u0303")>] // õ
    [<DataRow('\u00F6', "\u006F\u0304")>] // ö
    [<DataRow('\u00F9', "\u0075\u0300")>] // ù
    [<DataRow('\u00FA', "\u0075\u0301")>] // ú
    [<DataRow('\u00FB', "\u0075\u0302")>] // û
    [<DataRow('\u00FC', "\u0075\u0304")>] // ü
    [<DataRow('\u00FD', "\u0079\u0301")>] // ý
    [<DataRow('\u00FE', "\u0079\u0304")>] // ÿ
    member _.``equals - rune`` (ch:char, sequence:string) =
        let rune = Rune(ch)
        Assert.AreEqual(Glyph(sequence), rune)

    [<DataTestMethod>]
    [<DataRow("", "")>]
    [<DataRow("\u0061", "\u0061")>]
    [<DataRow("\u0061\u0061", "\u0061\u0061")>]
    [<DataRow("\u0061\u0301\u0061", "\u0061\u0061\u0301")>]
    [<DataRow("\u0065\u0301\u0066\u0061\u0063", "\u0063\u0061\u0066\u0065\u0301")>]
    member _.``reverse - string`` (exp:string, src:string) =
        Assert.AreEqual(exp, src.Reverse())

    [<DataTestMethod>]
    [<DataRow("a", 1, "\u0061\u0062", 0)>]
    [<DataRow("b", 1, "\u0061\u0062", 1)>]
    [<DataRow("á", 1, "\u00E1\u0062", 0)>]
    [<DataRow("b", 1, "\u00E1\u0062", 1)>]
    [<DataRow("á", 2, "\u0061\u0301\u0062", 0)>]
    [<DataRow("b", 1, "\u0061\u0301\u0062", 2)>]
    [<DataRow("a", 1, "\u0061\u00E7", 0)>]
    [<DataRow("ç", 1, "\u0061\u00E7", 1)>]
    [<DataRow("a", 1, "\u0061\u0063\u0327", 0)>]
    [<DataRow("ç", 2, "\u0061\u0063\u0327", 1)>]
    member _.``get glyph at`` (seq:string, exp:int, input:string, index:int) =
        let mutable cons:int = 0
        Assert.AreEqual(Glyph(seq), Glyph.GetGlyphAt(input, index, &cons))
        Assert.AreEqual(exp, cons)

    [<DataTestMethod>]
    [<DataRow("")>]
    [<DataRow("a")>]
    [<DataRow("aa")>]
    [<DataRow("aà")>]
    member _.``split`` (src:string) = Assert.AreEqual(src, Glyph.ToString(Glyph.Split(src)))

    [<DataTestMethod>]
    [<DataRow("\u00E0", "\u00E0")>] // à <=< à
    [<DataRow("\u00E0", "\u00C0")>] // à <=< À
    [<DataRow("\u0061\u0300", "\u00C0")>] // à <=< À
    [<DataRow("\u00E0", "\u0041\u0300")>] // à <=< À
    [<DataRow("\u0061\u0300", "\u0041\u0300")>] // à <=< À
    [<DataRow("\u0069", "\u0049")>] // i <=< I
    member _.``ToLower - Invariant`` (exp:string, sequence:string) = Assert.AreEqual(Glyph(exp), Glyph.ToLowerInvariant(Glyph(sequence)))

    [<DataTestMethod>]
    [<DataRow("\u00E0", "\u00E0")>] // à <=< à
    [<DataRow("\u00E0", "\u00C0")>] // à <=< À
    [<DataRow("\u0061\u0300", "\u00C0")>] // à <=< À
    [<DataRow("\u00E0", "\u0041\u0300")>] // à <=< À
    [<DataRow("\u0061\u0300", "\u0041\u0300")>] // à <=< À
    [<DataRow("\u0131", "\u0049")>] // ı <=< I
    member _.``ToLower - az-AZ`` (exp:string, sequence:string) = Assert.AreEqual(Glyph(exp), Glyph.ToLower(Glyph(sequence), CultureInfo("az-AZ")))

    [<DataTestMethod>]
    [<DataRow("\u00E0", "\u00E0")>] // à <=< à
    [<DataRow("\u00E0", "\u00C0")>] // à <=< À
    [<DataRow("\u0061\u0300", "\u00C0")>] // à <=< À
    [<DataRow("\u00E0", "\u0041\u0300")>] // à <=< À
    [<DataRow("\u0061\u0300", "\u0041\u0300")>] // à <=< À
    [<DataRow("\u0131", "\u0049")>] // ı <=< I
    member _.``ToLower - tr-TR`` (exp:string, sequence:string) = Assert.AreEqual(Glyph(exp), Glyph.ToLower(Glyph(sequence), CultureInfo("tr-TR")))

    [<DataTestMethod>]
    [<DataRow("\u00C0", "\u00C0")>] // À <=< À
    [<DataRow("\u00C0", "\u00E0")>] // À <=< à
    [<DataRow("\u00C0", "\u0061\u0300")>] // À <=< à
    [<DataRow("\u0041\u0300", "\u00E0")>] // À <=< à
    [<DataRow("\u0041\u0300", "\u0061\u0300")>] // À <=< à
    [<DataRow("\u0049", "\u0069")>] // I <=< i
    member _.``ToUpper - Invariant`` (exp:string, sequence:string) = Assert.AreEqual(Glyph(exp), Glyph.ToUpperInvariant(Glyph(sequence)))

    [<DataTestMethod>]
    [<DataRow("\u00C0", "\u00C0")>] // À <=< À
    [<DataRow("\u00C0", "\u00E0")>] // À <=< à
    [<DataRow("\u00C0", "\u0061\u0300")>] // À <=< à
    [<DataRow("\u0041\u0300", "\u00E0")>] // À <=< à
    [<DataRow("\u0041\u0300", "\u0061\u0300")>] // À <=< à
    [<DataRow("\u0130", "\u0069")>] // İ <=< i
    member _.``ToUpper - az-AZ`` (exp:string, sequence:string) = Assert.AreEqual(Glyph(exp), Glyph.ToUpper(Glyph(sequence), CultureInfo("az-AZ")))

    [<DataTestMethod>]
    [<DataRow("\u00C0", "\u00C0")>] // À <=< À
    [<DataRow("\u00C0", "\u00E0")>] // À <=< à
    [<DataRow("\u00C0", "\u0061\u0300")>] // À <=< à
    [<DataRow("\u0041\u0300", "\u00E0")>] // À <=< à
    [<DataRow("\u0041\u0300", "\u0061\u0300")>] // À <=< à
    [<DataRow("\u0130", "\u0069")>] // İ <=< i
    member _.``ToUpper - tr-TR`` (exp:string, sequence:string) = Assert.AreEqual(Glyph(exp), Glyph.ToUpper(Glyph(sequence), CultureInfo("tr-TR")))
