using System;
using Xunit;
using Xunit.Sdk;
using Langly;

namespace Collectathon.Arrays {
	public class DynamicArray2_Tests {
		[Theory]
		[InlineData(new[] { 'a', 'b', 'c', 'd', 'e' }, new[] { "Alfa", "Bravo", "Charlie", "Delta", "Echo" })]
		public void Clear(Char[] indicies, String[] elements) {
			DynamicArray<Char, String> da = new DynamicArray<Char, String>(5) { indicies.Zip(elements) };
			Assert.Equal(indicies.Length, da.Length);
			da.Clear();
			Assert.Equal(0, da.Length);
			foreach (Association<Char, String> item in da) {
				//If this executes at all, the enumerator found elements even though the length was properly cleared.
				throw new FalseException("", null);
			}
		}

		[Theory]
		[InlineData(new[] { 'a', 'b', 'c', 'd', 'e' }, new[] { "Alfa", "Bravo", "Charlie", "Delta", "Echo" })]
		public void Clone(Char[] indicies, String[] elements) {
			DynamicArray<Char, String> da = new DynamicArray<Char, String>(5) { indicies.Zip(elements) };
			DynamicArray<Char, String> clone = da.Clone();
			Assert.Equal(da, clone);
		}

		[Theory]
		[InlineData(new[] { 'a', 'b', 'c', 'd', 'e' }, new[] { "Alfa", "Bravo", "Charlie", "Delta", "Echo" }, "Foxtrot", false)]
		[InlineData(new[] { 'a', 'b', 'c', 'd', 'e' }, new[] { "Alfa", "Bravo", "Charlie", "Delta", "Echo" }, "Charlie", true)]
		[InlineData(new[] { 'a', 'b', 'c', 'd', 'e' }, new[] { "Alfa", "Bravo", "Charlie", "Delta", "Echo" }, "Echo", true)]
		public void Contains(Char[] indicies, String[] elements, String item, Boolean expected) {
			DynamicArray<Char, String> da = new DynamicArray<Char, String>(0) { indicies.Zip(elements) };
			Assert.Equal(expected, da.Elements.Contains(item));
		}

		[Theory]
		[InlineData(new[] { 'a', 'b', 'c', 'd', 'e' }, new[] { "Alfa", "Bravo", "Charlie", "Delta", "Echo" })]
		public void Enumerator(Char[] indicies, String[] elements) {
			DynamicArray<Char, String> da = new DynamicArray<Char, String>(5);
			Int32 i = 0;
			foreach (Association<Char, String> item in da) {
				Assert.Equal(new Association<Char, String>(indicies[i], elements[i++]), item);
			}
		}

		[Theory]
		[InlineData(new[] { 'a', 'b', 'c', 'd', 'e' }, new[] { "Alfa", "Bravo", "Charlie", "Delta", "Echo" }, 'a', true)]
		[InlineData(new[] { 'a', 'b', 'c', 'd', 'e' }, new[] { "Alfa", "Bravo", "Charlie", "Delta", "Echo" }, 'c', true)]
		[InlineData(new[] { 'a', 'b', 'c', 'd', 'e' }, new[] { "Alfa", "Bravo", "Charlie", "Delta", "Echo" }, 'e', true)]
		[InlineData(new[] { 'a', 'b', 'c', 'd', 'e' }, new[] { "Alfa", "Bravo", "Charlie", "Delta", "Echo" }, 'f', false)]
		public void Indexer(Char[] indicies, String[] elements, Char item, Boolean expected) {
			DynamicArray<Char, String> da = new DynamicArray<Char, String>(8) { indicies.Zip(elements) };
			if (expected) {
				_ = da[item];
			} else {
				Assert.Throws<ArgumentIndexNotValidException>(() => da[item]);
			}
		}
	}
}
