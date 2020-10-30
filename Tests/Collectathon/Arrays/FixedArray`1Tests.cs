using System;
using Philosoft;
using Xunit;

namespace Collectathon.Arrays {
	public class FixedArray1_Tests {
		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 })]
		public void Clone(Int32[] array) {
			FixedArray<Int32> fa = array;
			FixedArray<Int32> clone = fa.Clone();
			Assert.Equal(array, fa);
			Assert.Equal(array, clone);
			Assert.Equal(fa, clone);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 0, false)]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 3, true)]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 5, true)]
		public void Contains(Int32[] array, Int32 item, Boolean expected) {
			FixedArray<Int32> fa = array;
			Assert.Equal(expected, fa.Contains(item));
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 })]
		public void Enumerator(Int32[] array) {
			FixedArray<Int32> fa = array;
			Int32 a = 0;
			foreach (Int32 item in fa) {
				Assert.Equal(array[a++], item);
			}
			Assert.Equal(array.Length, a); //Ensures the enumerator traversed the entire array, no less, no more.
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 15, 120)]
		public void Fold(Int32[] array, Int32 addExpected, Int32 mulExpected) {
			FixedArray<Int32> fa = array;
			Assert.Equal(addExpected, fa.Fold((l, r) => l + r, 0));
			Assert.Equal(mulExpected, fa.Fold((l, r) => l * r, 1));
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 0, -1)]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 3, 2)]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 5, 4)]
		public void IndexOf(Int32[] array, Int32 item, Int64 expected) {
			FixedArray<Int32> fa = array;
			Assert.Equal(expected, fa.IndexOf(item));
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 2, 4, 6, 8, 10 })]
		public void Map(Int32[] array, Int32[] expected) {
			FixedArray<Int32> fa = array;
			fa.Map((x) => x * 2);
			Assert.Equal(expected, fa);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 2, 4)]
		public void Range(Int32[] array, Int32 start, Int32 end) {
			FixedArray<Int32> fa = array;
			Memory<Int32> memory = fa[start..end];
			Int32 a = start;
			foreach (Int32 item in memory.Span) {
				Assert.Equal(array[a++], item);
			}
			Assert.Equal(end, a);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 2, 4, new[] { 1, 4, 3, 4, 5 })]
		public void Replace(Int32[] array, Int32 oldItem, Int32 newItem, Int32[] expected) {
			FixedArray<Int32> fa = array;
			fa.Replace(oldItem, newItem);
			Assert.Equal(expected, fa);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 2, 3, 4, 5, 0 })]
		public void ShiftLeft(Int32[] array, Int32[] expected) {
			FixedArray<Int32> fa = array;
			FixedArray<Int32> op = fa << 1;
			fa.ShiftLeft();
			Assert.Equal(expected, op);
			Assert.Equal(expected, fa);
			Assert.Equal(fa, op);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 1, new[] { 2, 3, 4, 5, 0 })]
		public void ShiftLeftBy(Int32[] array, Int32 amount, Int32[] expected) {
			FixedArray<Int32> fa = array;
			FixedArray<Int32> op = fa << amount;
			fa.ShiftLeft(amount);
			Assert.Equal(expected, op);
			Assert.Equal(expected, fa);
			Assert.Equal(fa, op);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 0, 1, 2, 3, 4 })]
		public void ShiftRight(Int32[] array, Int32[] expected) {
			FixedArray<Int32> fa = array;
			FixedArray<Int32> op = fa >> 1;
			fa.ShiftRight();
			Assert.Equal(expected, op);
			Assert.Equal(expected, fa);
			Assert.Equal(fa, op);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 1, new[] { 0, 1, 2, 3, 4 })]
		public void ShiftRightBy(Int32[] array, Int32 amount, Int32[] expected) {
			FixedArray<Int32> fa = array;
			FixedArray<Int32> op = fa >> amount;
			fa.ShiftRight(amount);
			Assert.Equal(expected, op);
			Assert.Equal(expected, fa);
			Assert.Equal(fa, op);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 2, 2)]
		public void Slice(Int32[] array, Int32 start, Int32 length) {
			FixedArray<Int32> fa = array;
			Memory<Int32> memory = fa.Slice(start, length);
			Int32 a = start;
			foreach (Int32 item in memory.Span) {
				Assert.Equal(array[a++], item);
			}
			Assert.Equal(start + length, a);
		}
	}
}
