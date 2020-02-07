namespace Extensions

open System
open Stringier
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type FormatTableTests() =
    [<TestMethod>]
    member _.``format table`` () =
        let mutable table = FormatTable(5, Alignment.Left)
        table.Format("one", "two", "three", "four", "five")
        Assert.AreEqual("one│two│three│four│five\n", table.ToString())
        table.Format("six", "seven", "eight", "nine", "ten")
        Assert.AreEqual("one│two  │three│four│five\nsix│seven│eight│nine│ten \n", table.ToString())
        table <- FormatTable(5, Alignment.Right)
        table.Format("one", "two", "three", "four", "five")
        Assert.AreEqual("one│two│three│four│five\n", table.ToString())
        table.Format("six", "seven", "eight", "nine", "ten")
        Assert.AreEqual("one│  two│three│four│five\nsix│seven│eight│nine│ ten\n", table.ToString())
        table <- FormatTable(5, Alignment.Center)
        table.Format("one", "two", "three", "four", "five")
        Assert.AreEqual("one│two│three│four│five\n", table.ToString())
        table.Format("six", "seven", "eight", "nine", "ten")
        Assert.AreEqual("one│ two │three│four│five\nsix│seven│eight│nine│ten \n", table.ToString())