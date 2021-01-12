using System;
using Xunit;
using static Langly.DataStructures.Set;

namespace Langly.DataStructures {
	public class Set1_Tests {
		[Fact]
		public void Compliment() {
			// Identities
			Assert.Equal(Empty<Int32>(), !Universe<Int32>());
			Assert.Equal(Universe<Int32>(), !Empty<Int32>());
			// General
			Set<Int32> singles = Set.Range(0, 9);
			Set<Int32> nonSingles = !singles;
			Assert.True(nonSingles.Contains(-10));
			Assert.False(nonSingles.Contains(0));
			Assert.False(nonSingles.Contains(5));
			Assert.False(nonSingles.Contains(9));
			Assert.True(nonSingles.Contains(10));
		}

		[Fact]
		public void Difference() {
			Set<Int32> singles = Set.Range(0, 9);
			Set<Int32> primes = Of(2, 3, 5, 7, 11);
			Set<Int32> nonPrimeSingles = singles - primes;
			Assert.True(nonPrimeSingles.Contains(0));
			Assert.True(nonPrimeSingles.Contains(1));
			Assert.False(nonPrimeSingles.Contains(2));
			Assert.False(nonPrimeSingles.Contains(3));
			Assert.True(nonPrimeSingles.Contains(4));
			Assert.False(nonPrimeSingles.Contains(5));
			Assert.True(nonPrimeSingles.Contains(6));
			Assert.False(nonPrimeSingles.Contains(7));
			Assert.True(nonPrimeSingles.Contains(8));
			Assert.True(nonPrimeSingles.Contains(9));
		}

		[Fact]
		public void Disjunction() {
			Set<Int32> singles = Set.Range(0, 9);
			Set<Int32> primes = Of(2, 3, 5, 7, 11);
			Set<Int32> singleOrPrime = singles ^ primes;
			Assert.False(singleOrPrime.Contains(7));
			Assert.True(singleOrPrime.Contains(8));
			Assert.True(singleOrPrime.Contains(9));
			Assert.False(singleOrPrime.Contains(10));
			Assert.True(singleOrPrime.Contains(11));
		}

		[Theory]
		[InlineData(true, null)]
		[InlineData(false, "")]
		[InlineData(false, "hi")]
		public void Empty(Boolean expected, System.String text) => Assert.Equal(expected, Empty<System.String>().Contains(text));

		[Fact]
		public void Intersection() {
			Set<Int32> evens = Of((Int32 x) => x % 2 == 0);
			Set<Int32> primes = Of(2, 3, 5, 7);
			Set<Int32> evenPrimes = evens & primes;
			Assert.False(evenPrimes.Contains(0));
			Assert.False(evenPrimes.Contains(1));
			Assert.True(evenPrimes.Contains(2));
			Assert.False(evenPrimes.Contains(3));
			Assert.False(evenPrimes.Contains(4));
			Assert.False(evenPrimes.Contains(5));
			Assert.False(evenPrimes.Contains(6));
			Assert.False(evenPrimes.Contains(7));
			Assert.False(evenPrimes.Contains(8));
		}

		[Theory]
		[InlineData(-1, 0, 9, false)]
		[InlineData(0, 0, 9, true)]
		[InlineData(1, 0, 9, true)]
		[InlineData(8, 0, 9, true)]
		[InlineData(9, 0, 9, true)]
		[InlineData(10, 0, 9, false)]
		public void Range(Int32 value, Int32 lower, Int32 upper, Boolean expected) => Assert.Equal(expected, Set.Range(lower, upper).Contains(value));

		[Fact]
		public void Union() {
			Set<Int32> evens = Of((Int32 x) => x % 2 == 0);
			Set<Int32> odds = Of((Int32 x) => x % 2 != 0);
			Set<Int32> universe = evens | odds;
			Assert.True(universe.Contains(-10));
			Assert.True(universe.Contains(0));
			Assert.True(universe.Contains(10));
		}

		[Theory]
		[InlineData(false, null)]
		[InlineData(true, "")]
		[InlineData(true, "hi")]
		public void Universe(Boolean expected, System.String text) => Assert.Equal(expected, Universe<System.String>().Contains(text));
	}
}
