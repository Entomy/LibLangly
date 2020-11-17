namespace Logician

open Xunit

module Boolean =
    [<Fact>]
    let ``Not`` () =
        Assert.Equal(false, not true)
        Assert.Equal(true, not false)

    [<Fact>]
    let ``And`` () =
        Assert.Equal(true, true && true)
        Assert.Equal(false, true && false)
        Assert.Equal(false, false && true)
        Assert.Equal(false, false && false)

    [<Fact>]
    let ``Or`` () =
        Assert.Equal(true, true || true)
        Assert.Equal(true, true || false)
        Assert.Equal(true, false || true)
        Assert.Equal(false, false || false)

    [<Fact>]
    let ``XOr`` () =
        Assert.Equal(false, true ^^ true)
        Assert.Equal(true, true ^^ false)
        Assert.Equal(true, false ^^ true)
        Assert.Equal(false, false ^^ false)

    [<Fact>]
    let ``Implies`` () =
        Assert.Equal(true, true --> true)
        Assert.Equal(false, true --> false)
        Assert.Equal(true, false --> true)
        Assert.Equal(true, false --> false)

    [<Fact>]
    let ``Equivalent`` () =
        Assert.Equal(true, true === true)
        Assert.Equal(false, true === false)
        Assert.Equal(false, false === true)
        Assert.Equal(true, false === false)

    [<Fact>]
    let ``Inequivalent`` () =
        Assert.Equal(false, true !== true)
        Assert.Equal(true, true !== false)
        Assert.Equal(true, false !== true)
        Assert.Equal(false, false !== false)

    [<Fact>]
    let ``Contingent`` () =
        Assert.Equal(false, contingent true)
        Assert.Equal(false, contingent false)

    [<Fact>]
    let ``Necessary`` () =
        Assert.Equal(true, necessary true)
        Assert.Equal(false, necessary false)

    [<Fact>]
    let ``Possible`` () =
        Assert.Equal(true, possible true)
        Assert.Equal(false, possible false)

module Łukasiewicz =
    [<Fact>]
    let ``Not`` () =
        Assert.Equal(Ł3.False, not Ł3.True)
        Assert.Equal(Ł3.True, not Ł3.False)
        Assert.Equal(Ł3.Unknown, not Ł3.Unknown)

    [<Fact>]
    let ``And`` () =
        Assert.Equal(Ł3.True, Ł3.True && Ł3.True)
        Assert.Equal(Ł3.Unknown, Ł3.True && Ł3.Unknown)
        Assert.Equal(Ł3.False, Ł3.True && Ł3.False)
        Assert.Equal(Ł3.Unknown, Ł3.Unknown && Ł3.True)
        Assert.Equal(Ł3.Unknown, Ł3.Unknown && Ł3.Unknown)
        Assert.Equal(Ł3.False, Ł3.Unknown && Ł3.False)
        Assert.Equal(Ł3.False, Ł3.False && Ł3.True)
        Assert.Equal(Ł3.False, Ł3.False && Ł3.Unknown)
        Assert.Equal(Ł3.False, Ł3.False && Ł3.False)

    [<Fact>]
    let ``Or`` () =
        Assert.Equal(Ł3.True, Ł3.True || Ł3.True)
        Assert.Equal(Ł3.True, Ł3.True || Ł3.Unknown)
        Assert.Equal(Ł3.True, Ł3.True || Ł3.False)
        Assert.Equal(Ł3.True, Ł3.Unknown || Ł3.True)
        Assert.Equal(Ł3.Unknown, Ł3.Unknown || Ł3.Unknown)
        Assert.Equal(Ł3.Unknown, Ł3.Unknown || Ł3.False)
        Assert.Equal(Ł3.True, Ł3.False || Ł3.True)
        Assert.Equal(Ł3.Unknown, Ł3.False || Ł3.Unknown)
        Assert.Equal(Ł3.False, Ł3.False || Ł3.False)

    [<Fact>]
    let ``XOr`` () =
        Assert.Equal(Ł3.False, Ł3.True ^^ Ł3.True)
        Assert.Equal(Ł3.Unknown, Ł3.True ^^ Ł3.Unknown)
        Assert.Equal(Ł3.True, Ł3.True ^^ Ł3.False)
        Assert.Equal(Ł3.Unknown, Ł3.Unknown ^^ Ł3.True)
        Assert.Equal(Ł3.Unknown, Ł3.Unknown ^^ Ł3.Unknown)
        Assert.Equal(Ł3.Unknown, Ł3.Unknown ^^ Ł3.False)
        Assert.Equal(Ł3.False, Ł3.False ^^ Ł3.False)
        Assert.Equal(Ł3.Unknown, Ł3.False ^^ Ł3.Unknown)
        Assert.Equal(Ł3.True, Ł3.False ^^ Ł3.True)

    [<Fact>]
    let ``Implies`` () =
        Assert.Equal(Ł3.True, Ł3.True --> Ł3.True)
        Assert.Equal(Ł3.Unknown, Ł3.True --> Ł3.Unknown)
        Assert.Equal(Ł3.False, Ł3.True --> Ł3.False)
        Assert.Equal(Ł3.True, Ł3.Unknown --> Ł3.True)
        Assert.Equal(Ł3.True, Ł3.Unknown --> Ł3.Unknown)
        Assert.Equal(Ł3.Unknown, Ł3.Unknown --> Ł3.False)
        Assert.Equal(Ł3.True, Ł3.False --> Ł3.True)
        Assert.Equal(Ł3.True, Ł3.False --> Ł3.Unknown)
        Assert.Equal(Ł3.True, Ł3.False --> Ł3.False)

    [<Fact>]
    let ``Equivalent`` () =
        Assert.Equal(Ł3.True, Ł3.True === Ł3.True)
        Assert.Equal(Ł3.Unknown, Ł3.True === Ł3.Unknown)
        Assert.Equal(Ł3.False, Ł3.True === Ł3.False)
        Assert.Equal(Ł3.Unknown, Ł3.Unknown === Ł3.True)
        Assert.Equal(Ł3.True, Ł3.Unknown === Ł3.Unknown)
        Assert.Equal(Ł3.Unknown, Ł3.Unknown === Ł3.False)
        Assert.Equal(Ł3.False, Ł3.False === Ł3.True)
        Assert.Equal(Ł3.Unknown, Ł3.False === Ł3.Unknown)
        Assert.Equal(Ł3.True, Ł3.False === Ł3.False)

    [<Fact>]
    let ``Inequivalent`` () =
        Assert.Equal(Ł3.False, Ł3.True !== Ł3.True)
        Assert.Equal(Ł3.Unknown, Ł3.True !== Ł3.Unknown)
        Assert.Equal(Ł3.True, Ł3.True !== Ł3.False)
        Assert.Equal(Ł3.Unknown, Ł3.Unknown !== Ł3.True)
        Assert.Equal(Ł3.Unknown, Ł3.Unknown !== Ł3.Unknown)
        Assert.Equal(Ł3.Unknown, Ł3.Unknown !== Ł3.False)
        Assert.Equal(Ł3.True, Ł3.False !== Ł3.True)
        Assert.Equal(Ł3.Unknown, Ł3.False !== Ł3.Unknown)
        Assert.Equal(Ł3.False, Ł3.False !== Ł3.False)

    [<Fact>]
    let ``Contingent`` () =
        Assert.Equal(false, contingent Ł3.True)
        Assert.Equal(true, contingent Ł3.Unknown)
        Assert.Equal(false, contingent Ł3.False)

    [<Fact>]
    let ``Necessary`` () =
        Assert.Equal(true, necessary Ł3.True)
        Assert.Equal(false, necessary Ł3.Unknown)
        Assert.Equal(false, necessary Ł3.False)

    [<Fact>]
    let ``Possible`` () =
        Assert.Equal(true, possible Ł3.True)
        Assert.Equal(true, possible Ł3.Unknown)
        Assert.Equal(false, possible Ł3.False)
