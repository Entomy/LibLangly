using System;
using Xunit;

namespace Langly.DataStructures.Arrays {
	public class FixedArray1_Tests {
		[Fact]
		public void Constructor() {
			FixedArray<Int32> array = new FixedArray<Int32>(5);
		}

		[Theory]
		[InlineData(0)]
		[InlineData(1)]
		[InlineData(2)]
		[InlineData(Int16.MaxValue)]
		public void Capacity(Int32 capacity) => Assert.Equal(capacity, new FixedArray<Int32>(capacity).Capacity);

		[Theory]
		[InlineData(0)]
		[InlineData(1)]
		[InlineData(2)]
		[InlineData(Int16.MaxValue)]
		public void Count(Int32 count) => Assert.Equal(count, new FixedArray<Int32>(count).Count);

		[Fact]
		public void Empty() {
			FixedArray<Int32> arr = FixedArray<Int32>.Empty;
			Assert.Equal(0, arr.Capacity);
			Assert.Equal(0, arr.Count);
			Assert.Equal("Fixed[]", arr.ToString());
		}

		[Theory]
		[InlineData(true, new Int32[] { }, new Int32[] { })]
		[InlineData(true, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Equals(Boolean expected, Int32[] first, Int32[] second) {
			FixedArray<Int32> fst = new FixedArray<Int32>(first);
			FixedArray<Int32> snd = new FixedArray<Int32>(second);
			Assert.Equal(expected, fst.Equals(snd));
			Assert.Equal(expected, snd.Equals(fst));
			Assert.Equal(expected, fst == snd);
			Assert.Equal(expected, snd == fst);
		}

		[Theory]
		[InlineData(15, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Fold_Sum(Int32 expected, Int32[] array) => Assert.Equal(expected, new FixedArray<Int32>(array).Fold((l, r) => l + r, 0));

		[Theory]
		[InlineData(-1, -1, new Int32[] { }, 1)]
		[InlineData(0, 0, new Int32[] { 1, 2, 3, 4, 5 }, 1)]
		[InlineData(4, 4, new Int32[] { 1, 2, 3, 4, 5 }, 5)]
		[InlineData(-1, -1, new Int32[] { 1, 2, 3, 4, 5 }, 0)]
		public void IndexOf(Int32 first, Int32 last, Int32[] array, Int32 element) {
			FixedArray<Int32> arr = new FixedArray<Int32>(array);
			Assert.Equal(first, arr.IndexOfFirst(element));
			Assert.Equal(last, arr.IndexOfLast(element));
		}

		[Theory]
		[InlineData(new Int32[] { 2, 4, 6, 8, 10 }, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Map_Double(Int32[] expected, Int32[] array) {
			FixedArray<Int32> arr = new FixedArray<Int32>(array);
			arr.Map((e) => e * 2);
			Assert.Equal(expected, arr);
		}

		[Theory]
		[InlineData(0, new Int32[] { }, 0)]
		[InlineData(0, new Int32[] { 1, 2, 3, 4, 5 }, 0)]
		[InlineData(1, new Int32[] { 1, 2, 3, 4, 5 }, 1)]
		[InlineData(6, new Int32[] { 0, 1, 0, 2, 0, 3, 0, 4, 0, 5, 0 }, 0)]
		public void Occurrences(Int32 expected, Int32[] array, Int32 element) => Assert.Equal(expected, new FixedArray<Int32>(array).Occurrences(element));

		[Theory]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0)]
		[InlineData(new Int32[] { 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 1)]
		[InlineData(new Int32[] { 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 2)]
		public void ShiftLeft(Int32[] expected, Int32[] array, Int32 amount) {
			FixedArray<Int32> arr = new FixedArray<Int32>(array);
			arr.ShiftLeft(amount);
			Assert.Equal(expected, arr);
		}

		[Theory]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0)]
		[InlineData(new Int32[] { 0, 1, 2, 3, 4 }, new Int32[] { 1, 2, 3, 4, 5 }, 1)]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3 }, new Int32[] { 1, 2, 3, 4, 5 }, 2)]
		public void ShiftRight(Int32[] expected, Int32[] array, Int32 amount) {
			FixedArray<Int32> arr = new FixedArray<Int32>(array);
			arr.ShiftRight(amount);
			Assert.Equal(expected, arr);
		}

		[Theory]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0, 5)]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { 1, 2, 3, 4, 5 }, 0, 3)]
		[InlineData(new Int32[] { 2, 3, 4 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, 3)]
		public void Slice(Int32[] expected, Int32[] array, Int32 start, Int32 length) {
			FixedArray<Int32> arr = new FixedArray<Int32>(array);
			Assert.Equal(expected, arr.Slice(start, length));
		}

		[Theory]
		[InlineData("Fixed[]", new Int32[] { })]
		[InlineData("Fixed[1, 2, 3, 4, 5]", new Int32[] { 1, 2, 3, 4, 5 })]
		public void ToString(String expected, Int32[] array) {
			FixedArray<Int32> arr = new FixedArray<Int32>(array);
			Assert.Equal(expected, arr.ToString());
		}
	}
}
