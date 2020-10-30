using System;
using System.IO;
using Xunit;
using Xunit.Sdk;
using Philosoft;

namespace Collectathon.Lists {
	public class SinglyLinkedList1_Tests {
		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 })]
		public void Clear(Int32[] array) {
			SinglyLinkedList<Int32> list = new SinglyLinkedList<Int32>() { array };
			Assert.Equal(array.Length, list.Count);
			list.Clear();
			Assert.Equal(0, list.Count);
			foreach (Int32 item in list) {
				//If this executes at all, the enumerator found elements even though the length was properly cleared.
				throw new FalseException("", null);
			}
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 0, false)]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 3, true)]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 5, true)]
		public void Contains(Int32[] array, Int32 item, Boolean expected) {
			SinglyLinkedList<Int32> list = new SinglyLinkedList<Int32>() { array };
			Assert.Equal(expected, list.Contains(item));
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 })]
		public void Enumerator(Int32[] array) {
			SinglyLinkedList<Int32> list = new SinglyLinkedList<Int32>() { array };
			Int32 a = 0;
			foreach (Int32 item in list) {
				Assert.Equal(array[a++], item);
			}
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 0, -1)]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 3, 2)]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 5, 4)]
		public void IndexOf(Int32[] array, Int32 item, Int64 expected) {
			SinglyLinkedList<Int32> list = new SinglyLinkedList<Int32>() { array };
			Assert.Equal(expected, list.IndexOf(item));
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3 }, 0, 0, new[] { 0, 1, 2, 3 })]
		[InlineData(new[] { 1, 2, 3 }, 1, 0, new[] { 1, 0, 2, 3 })]
		[InlineData(new[] { 1, 2, 3 }, 2, 0, new[] { 1, 2, 0, 3 })]
		[InlineData(new[] { 1, 2, 3 }, 3, 0, new[] { 1, 2, 3, 0 })]
		public void Insert(Int32[] array, Int32 index, Int32 element, Int32[] expected) {
			SinglyLinkedList<Int32> list = new SinglyLinkedList<Int32>() { array };
			list.Insert(index, element);
			Assert.Equal<Int32>(expected, list);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 })]
		public void Queue(Int32[] array) {
			SinglyLinkedList<Int32> queue = new SinglyLinkedList<Int32>();
			queue.Enqueue(array);
			Assert.Equal(array.Length, queue.Count);
			for (Int32 a = 0; a < array.Length; a++) {
				Assert.Equal(array[a], queue.Dequeue());
			}
		}


		[Theory]
		[InlineData(new[] { 0, 1, 0, 2, 0, 3, 0, 4, 0, 5, 0 }, 0, new[] { 1, 2, 3, 4, 5 })]
		public void Remove_Element(Int32[] array, Int32 item, Int32[] expected) {
			SinglyLinkedList<Int32> list = new SinglyLinkedList<Int32>() { array };
			Assert.Equal(array.Length, list.Count);
			list.Remove(item);
			Assert.Equal<Int32>(expected, list);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new[] { 2, 4, 6, 8 })]
		public void Remove_Delegate(Int32[] array, Int32[] expected) {
			SinglyLinkedList<Int32> list = new SinglyLinkedList<Int32>() { array };
			Assert.Equal(array.Length, list.Count);
			list.Remove((x) => x % 2 != 0);
			Assert.Equal<Int32>(expected, list);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 2, 4, new[] { 1, 4, 3, 4, 5 })]
		public void Replace(Int32[] array, Int32 oldItem, Int32 newItem, Int32[] expected) {
			SinglyLinkedList<Int32> da = new SinglyLinkedList<Int32>() { array };
			da.Replace(oldItem, newItem);
			Assert.Equal<Int32>(expected, da);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 })]
		public void Stack(Int32[] array) {
			SinglyLinkedList<Int32> florin = new SinglyLinkedList<Int32>();
			florin.Push(array);
			Assert.Equal(array.Length, florin.Count);
			for (Int32 a = array.Length; a-- > 0;) {
				Assert.Equal(array[a], florin.Pop());
			}
		}

		[Fact]
		public void Unique() {
			SinglyLinkedList<Int32> list = new SinglyLinkedList<Int32>(Filter.Unique);
			list.Add(1);
			Assert.Equal(1, list.Count);
			Assert.Equal(1, list[0]);
			list.Add(1, 2, 3);
			Assert.Equal(3, list.Count);
			Assert.Equal(1, list[0]);
			Assert.Equal(2, list[1]);
			Assert.Equal(3, list[2]);
		}
	}
}
