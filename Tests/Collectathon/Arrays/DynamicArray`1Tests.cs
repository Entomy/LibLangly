using System;
using Xunit;
using Xunit.Sdk;
using Philosoft;

namespace Collectathon.Arrays {
	public class DynamicArray1_Tests {
		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 })]
		public void Clear(Int32[] array) {
			DynamicArray<Int32> da = array;
			Assert.Equal(array.Length, da.Length);
			da.Clear();
			Assert.Equal(0, da.Length);
			foreach (Int32 item in da) {
				//If this executes at all, the enumerator found elements even though the length was properly cleared.
				throw new FalseException("", null);
			}
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 })]
		public void Clone(Int32[] array) {
			DynamicArray<Int32> da = array;
			DynamicArray<Int32> clone = da.Clone();
			Assert.Equal<Int32>(array, da);
			Assert.Equal<Int32>(array, clone);
			Assert.Equal(da, clone);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 0, false)]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 3, true)]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 5, true)]
		public void Contains(Int32[] array, Int32 item, Boolean expected) {
			DynamicArray<Int32> da = array;
			Assert.Equal(expected, da.Contains(item));
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 })]
		public void Enumerator(Int32[] array) {
			DynamicArray<Int32> da = array;
			Int32 a = 0;
			foreach (Int32 item in da) {
				Assert.Equal(array[a++], item);
			}
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 0, -1)]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 3, 2)]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 5, 4)]
		public void IndexOf(Int32[] array, Int32 item, Int64 expected) {
			DynamicArray<Int32> da = array;
			Assert.Equal(expected, da.IndexOf(item));
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3 }, 0, 0, new[] { 0, 1, 2, 3 })]
		[InlineData(new[] { 1, 2, 3 }, 1, 0, new[] { 1, 0, 2, 3 })]
		[InlineData(new[] { 1, 2, 3 }, 2, 0, new[] { 1, 2, 0, 3 })]
		[InlineData(new[] { 1, 2, 3 }, 3, 0, new[] { 1, 2, 3, 0 })]
		public void Insert(Int32[] array, Int32 index, Int32 element, Int32[] expected) {
			DynamicArray<Int32> da = array;
			da.Insert(index, element);
			Assert.Equal<Int32>(expected, da);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 2, 4, 6, 8, 10 })]
		public void Map(Int32[] array, Int32[] expected) {
			DynamicArray<Int32> da = array;
			da.Map((x) => x * 2);
			Assert.Equal<Int32>(expected, da);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 })]
		public void Queue(Int32[] array) {
			DynamicArray<Int32> queue = new DynamicArray<Int32>(0);
			queue.Enqueue(array);
			Assert.Equal(array.Length, queue.Length);
			for (Int32 a = 0; a < array.Length; a++) {
				Assert.Equal(array[a], queue.Dequeue());
			}
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 2, 4)]
		public void Range(Int32[] array, Int32 start, Int32 end) {
			DynamicArray<Int32> da = array;
			Memory<Int32> memory = da[start..end];
			Int32 a = start;
			foreach (Int32 item in memory.Span) {
				Assert.Equal(array[a++], item);
			}
			Assert.Equal(end, a);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new[] { 2, 4, 6, 8 })]
		public void Remove_Delegate(Int32[] array, Int32[] expected) {
			DynamicArray<Int32> da = array;
			Assert.Equal(array.Length, da.Length);
			da.Remove((x) => x % 2 != 0);
			Assert.Equal<Int32>(expected, da);
		}

		[Theory]
		[InlineData(new[] { 0, 1, 0, 2, 0, 3, 0, 4, 0, 5, 0 }, 0, new[] { 1, 2, 3, 4, 5 })]
		public void Remove_Element(Int32[] array, Int32 item, Int32[] expected) {
			DynamicArray<Int32> da = array;
			Assert.Equal(array.Length, da.Length);
			da.Remove(item);
			Assert.Equal<Int32>(expected, da);
		}
		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 2, 4, new[] { 1, 4, 3, 4, 5 })]
		public void Replace(Int32[] array, Int32 oldItem, Int32 newItem, Int32[] expected) {
			DynamicArray<Int32> da = array;
			da.Replace(oldItem, newItem);
			Assert.Equal<Int32>(expected, da);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 2, 3, 4, 5, 0 })]
		public void ShiftLeft(Int32[] array, Int32[] expected) {
			array.ShiftLeft();
			Assert.Equal(expected, array);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 1, new[] { 2, 3, 4, 5, 0 })]
		public void ShiftLeftBy(Int32[] array, Int32 amount, Int32[] expected) {
			array.ShiftLeft(amount);
			Assert.Equal(expected, array);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 0, 1, 2, 3, 4 })]
		public void ShiftRight(Int32[] array, Int32[] expected) {
			array.ShiftRight();
			Assert.Equal(expected, array);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 1, new[] { 0, 1, 2, 3, 4 })]
		public void ShiftRightBy(Int32[] array, Int32 amount, Int32[] expected) {
			array.ShiftRight(amount);
			Assert.Equal(expected, array);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 2, 2)]
		public void Slice(Int32[] array, Int32 start, Int32 length) {
			DynamicArray<Int32> da = array;
			Memory<Int32> memory = da.Slice(start, length);
			Int32 a = start;
			foreach (Int32 item in memory.Span) {
				Assert.Equal(array[a++], item);
			}
			Assert.Equal(start + length, a);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 })]
		public void Stack(Int32[] array) {
			DynamicArray<Int32> florin = new DynamicArray<Int32>(0);
			florin.Push(array);
			Assert.Equal(array.Length, florin.Length);
			for (Int32 a = array.Length; a-- > 0;) {
				Assert.Equal(array[a], florin.Pop());
			}
		}

		[Fact]
		public void Unique() {
			DynamicArray<Int32> da = new DynamicArray<Int32>(0, Filter.Unique);
			da.Add(1);
			Assert.Equal(1, da.Length);
			Assert.Equal(1, da[0]);
			da.Add(1, 2, 3);
			Assert.Equal(3, da.Length);
			Assert.Equal(1, da[0]);
			Assert.Equal(2, da[1]);
			Assert.Equal(3, da[2]);
		}
	}
}
