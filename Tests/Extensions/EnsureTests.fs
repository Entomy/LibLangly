namespace Tests.Extensions

open System;
open Stringier.Extensions;
open Xunit;

module EnsureTests =
    [<Fact>]
    let ``ensureBegins "Mr " "Bob Saget"`` () =
        Assert.Equal("Mr. Bob Saget", ensureBegins "Mr. " "Bob Saget")

    [<Fact>]
    let ``ensureBegins "Mr " "Mr Bob Saget"`` () =
        Assert.Equal("Mr. Bob Saget", ensureBegins "Mr. " "Mr. Bob Saget")

    [<Fact>]
    let ``ensureEnds " MD" "Gregory House"`` () =
        Assert.Equal("Gregory House MD", ensureEnds " MD" "Gregory House")

    [<Fact>]
    let ``ensureEnds " MD" "Gregory House MD"`` () =
        Assert.Equal("Gregory House MD", ensureEnds " MD" "Gregory House MD")