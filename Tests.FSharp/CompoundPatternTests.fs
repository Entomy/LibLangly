namespace Tests.FSharp

open System.Text.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type CompoundPatternTests() =
    [<TestMethod>]
    member this.Identifier() =
        let pattern = Pattern.Letter >> +(Pattern.Letter || Pattern.DecimalDigitNumber || '_')
        
        let mutable result = pattern.Consume("hello")
        Assert.That.Captures("hello", result)
        
        result <- pattern.Consume("example_name")
        Assert.That.Captures("example_name", result)

        result <- pattern.Consume("_fail")
        Assert.That.Fails(result)

    [<TestMethod>]
    member this.IPv4Address() =
        let digit = (~~(('1' || '2') >> Pattern.DecimalDigitNumber) || Pattern.DecimalDigitNumber) >> ~~Pattern.DecimalDigitNumber
        let address = digit >> '.' >> digit >> '.' >> digit >> '.' >> digit

        
        Assert.That.Captures("1", digit.Consume("1"))
        Assert.That.Captures("11", digit.Consume("11"))
        Assert.That.Captures("111", digit.Consume("111"))

        let mutable result = address.Consume("192.168.1.1")
        Assert.That.Captures("192.168.1.1", result)

    [<TestMethod>]
    member this.NumberInBracket() =
        let number = '[' >> Pattern.Number >> ']'
        let numberList = +(number >> ~~(+Pattern.SpaceSeparator)) >> "[c]"
        Assert.That.Captures("[1] [2] [c]", numberList.Consume("[1] [2] [c]"))


    [<TestMethod>]
    member this.PhoneNumber() =
        let number = Pattern.Number * 3 >> '-' >> Pattern.Number * 3 >> '-' >> Pattern.Number * 4
        let result = number.Consume("555-555-5555")
        Assert.That.Succeeds(result)
        Assert.That.Captures("555-555-5555", result)

    [<TestMethod>]
    member this.WebAddress() =
        let protocol = "http" >> ~~'s' >> "://"
        let host = +(Pattern.Letter || Pattern.Number || '-') >> '.' >> ~~(+(Pattern.Letter || Pattern.Number || '-') >> '.') >> Pattern.Letter * 3
        let location = +('/' >> +(Pattern.Letter || Pattern.Number || '-' || '_'))
        let address = ~~protocol >> host >> ~~location
        let mutable result = address.Consume("www.google.com")
        Assert.That.Captures("www.google.com", result)
        result <- address.Consume("http://www.google.com")
        Assert.That.Captures("http://www.google.com", result)
        result <- address.Consume("http://www.google.com/about")
        Assert.That.Captures("http://www.google.com/about", result)