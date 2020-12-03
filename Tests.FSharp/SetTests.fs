namespace Langly.DataStructures.Sets

open Langly
open Xunit

module SetTests =
    [<Fact>]
    let ``Compliment`` () =
        // Identities
        Assert.Equal(Set<int>.Empty, not Set<int>.Universe)
        Assert.Equal(Set<int>.Universe, not Set<int>.Empty)
        // General
        let singles = Set.Range(0, 9)
        let nonSingles = not singles
        Assert.True(nonSingles |> contains -10)
        Assert.False(nonSingles |> contains 0)
        Assert.False(nonSingles |> contains 5)
        Assert.False(nonSingles |> contains 9)
        Assert.True(nonSingles |> contains 10)

    [<Fact>]
    let ``Difference`` () =
        let singles = Set.Range(0, 9)
        let primes = Set.From([|2;3;5;7;11|])
        let nonPrimeSingles = singles - primes
        Assert.True(nonPrimeSingles |> contains 0)
        Assert.True(nonPrimeSingles |> contains 1)
        Assert.False(nonPrimeSingles |> contains 2)
        Assert.False(nonPrimeSingles |> contains 3)
        Assert.True(nonPrimeSingles |> contains 4)
        Assert.False(nonPrimeSingles |> contains 5)
        Assert.True(nonPrimeSingles |> contains 6)
        Assert.False(nonPrimeSingles |> contains 7)
        Assert.True(nonPrimeSingles |> contains 8)
        Assert.True(nonPrimeSingles |> contains 9)

    [<Fact>]
    let ``Disjunction`` () =
        let singles = Set.Range(0, 9)
        let primes = Set.From([|2;3;5;7;11|])
        let singleOrPrime = singles <> primes
        Assert.False(singleOrPrime |> contains 7)
        Assert.True(singleOrPrime |> contains 8)
        Assert.True(singleOrPrime |> contains 9)
        Assert.False(singleOrPrime |> contains 10)
        Assert.True(singleOrPrime |> contains 11)

    [<Fact>]
    let ``Intersection`` () =
        let evens = Set.From(fun (x) -> x % 2 == 0)
        let primes = Set.From([|2;3;5;7;11|])
        let evenPrimes = evens && primes
        Assert.False(evenPrimes |> contains 0)
        Assert.False(evenPrimes |> contains 1)
        Assert.True(evenPrimes |> contains 2)
        Assert.False(evenPrimes |> contains 3)
        Assert.False(evenPrimes |> contains 4)
        Assert.False(evenPrimes |> contains 5)
        Assert.False(evenPrimes |> contains 6)
        Assert.False(evenPrimes |> contains 7)
        Assert.False(evenPrimes |> contains 8)

    [<Fact>]
    let ``Union`` () =
        let evens = Set.From(fun (x) -> x % 2 == 0)
        let odds = Set.From(fun (x) -> x % 2 != 0)
        let universe = evens || odds
        Assert.True(universe |> contains -10)
        Assert.True(universe |> contains 0)
        Assert.True(universe |> contains 10)

