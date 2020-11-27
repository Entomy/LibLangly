using System;
using Xunit;
using Xunit.Sdk;

namespace Langly.DataStructures.Arrays {
	public class BoundedArray1_Tests {
		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 })]
		public void Clear(Int32[] array) {
			BoundedArray<Int32> ba = array;
			Assert.Equal(array.Length, ba.Length);
			ba.Clear();
			Assert.Equal(0, ba.Length);
			foreach (Int32 item in ba) {
				//If this executes at all, the enumerator found elements even though the length was properly cleared.
				throw new FalseException("", null);
			}
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 })]
		public void Clone(Int32[] array) {
			BoundedArray<Int32> ba = array;
			BoundedArray<Int32> clone = ba.Clone();
			Assert.Equal<Int32>(array, ba);
			Assert.Equal<Int32>(array, clone);
			Assert.Equal(ba, clone);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 0, false)]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 3, true)]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 5, true)]
		public void Contains(Int32[] array, Int32 item, Boolean expected) {
			BoundedArray<Int32> ba = array;
			Assert.Equal(expected, ba.Contains(item));
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 })]
		public void Enumerator(Int32[] array) {
			BoundedArray<Int32> ba = array;
			Int32 a = 0;
			foreach (Int32 item in ba) {
				Assert.Equal(array[a++], item);
			}
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 15, 120)]
		public void Fold(Int32[] array, Int32 addExpected, Int32 multExpected) {
			BoundedArray<Int32> ba = array;
			Assert.Equal(addExpected, ba.Fold((l, r) => l + r, 0));
			Assert.Equal(multExpected, ba.Fold((l, r) => l * r, 1));
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 0, -1)]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 3, 2)]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 5, 4)]
		public void IndexOf(Int32[] array, Int32 item, Int64 expected) {
			BoundedArray<Int32> ba = array;
			Assert.Equal(expected, ba.IndexOf(item));
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3 }, 0, 0, new[] { 0, 1, 2, 3 })]
		[InlineData(new[] { 1, 2, 3 }, 1, 0, new[] { 1, 0, 2, 3 })]
		[InlineData(new[] { 1, 2, 3 }, 2, 0, new[] { 1, 2, 0, 3 })]
		[InlineData(new[] { 1, 2, 3 }, 3, 0, new[] { 1, 2, 3, 0 })]
		public void Insert(Int32[] array, Int32 index, Int32 element, Int32[] expected) {
			BoundedArray<Int32> ba = new BoundedArray<Int32>(4) { array };
			ba.Insert(index, element);
			Assert.Equal<Int32>(expected, ba);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 2, 4, 6, 8, 10 })]
		public void Map(Int32[] array, Int32[] expected) {
			BoundedArray<Int32> ba = array;
			ba.Map((x) => x * 2);
			Assert.Equal<Int32>(expected, ba);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 })]
		public void Queue(Int32[] array) {
			BoundedArray<Int32> queue = new BoundedArray<Int32>(5);
			queue.Enqueue(array);
			Assert.Equal(array.Length, queue.Length);
			for (Int32 a = 0; a < array.Length; a++) {
				Assert.Equal(array[a], queue.Dequeue());
			}
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 2, 4)]
		public void Range(Int32[] array, Int32 start, Int32 end) {
			BoundedArray<Int32> ba = array;
			Memory<Int32> memory = ba[start..end];
			Int32 a = start;
			foreach (Int32 item in memory.Span) {
				Assert.Equal(array[a++], item);
			}
			Assert.Equal(end, a);
		}

		[Theory]
		[InlineData(new[] { 0, 1, 0, 2, 0, 3, 0, 4, 0, 5, 0 }, 0, new[] { 1, 2, 3, 4, 5 })]
		public void Remove_Element(Int32[] array, Int32 item, Int32[] expected) {
			BoundedArray<Int32> ba = array;
			Assert.Equal(array.Length, ba.Length);
			ba.Remove(item);
			Assert.Equal<Int32>(expected, ba);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new[] { 2, 4, 6, 8 })]
		public void Remove_Delegate(Int32[] array, Int32[] expected) {
			BoundedArray<Int32> ba = array;
			Assert.Equal(array.Length, ba.Length);
			ba.Remove((x) => x % 2 != 0);
			Assert.Equal<Int32>(expected, ba);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 2, 4, new[] { 1, 4, 3, 4, 5 })]
		public void Replace(Int32[] array, Int32 oldItem, Int32 newItem, Int32[] expected) {
			BoundedArray<Int32> ba = array;
			ba.Replace(oldItem, newItem);
			Assert.Equal<Int32>(expected, ba);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 2, 3, 4, 5, 0 })]
		public void ShiftLeft(Int32[] array, Int32[] expected) {
			BoundedArray<Int32> ba = array;
			ba.ShiftLeft();
			Assert.Equal(expected, ba);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 1, new[] { 2, 3, 4, 5, 0 })]
		public void ShiftLeftBy(Int32[] array, Int32 amount, Int32[] expected) {
			BoundedArray<Int32> ba = array;
			Assert.Equal(expected, ba << amount);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 0, 1, 2, 3, 4 })]
		public void ShiftRight(Int32[] array, Int32[] expected) {
			BoundedArray<Int32> ba = array;
			ba.ShiftRight();
			Assert.Equal(expected, ba);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 1, new[] { 0, 1, 2, 3, 4 })]
		public void ShiftRightBy(Int32[] array, Int32 amount, Int32[] expected) {
			BoundedArray<Int32> ba = array;
			Assert.Equal(expected, ba >> amount);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 2, 2)]
		public void Slice(Int32[] array, Int32 start, Int32 length) {
			BoundedArray<Int32> ba = array;
			Memory<Int32> memory = ba.Slice(start, length);
			Int32 a = start;
			foreach (Int32 item in memory.Span) {
				Assert.Equal(array[a++], item);
			}
			Assert.Equal(start + length, a);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 })]
		public void Stack(Int32[] array) {
			BoundedArray<Int32> florin = new BoundedArray<Int32>(5);
			florin.Push(array);
			Assert.Equal(array.Length, florin.Length);
			for (Int32 a = array.Length; a-- > 0;) {
				Assert.Equal(array[a], florin.Pop());
			}
		}

		[Fact]
		public void Unique() {
			BoundedArray<Int32> ba = new BoundedArray<Int32>(8, Filter.Unique);
			ba.Add(1);
			Assert.Equal(1, ba.Length);
			Assert.Equal(1, ba[0]);
			ba.Add(1, 2, 3);
			Assert.Equal(3, ba.Length);
			Assert.Equal(1, ba[0]);
			Assert.Equal(2, ba[1]);
			Assert.Equal(3, ba[2]);
		}
	}
}
