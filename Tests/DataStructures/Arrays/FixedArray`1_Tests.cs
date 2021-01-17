using System;
using Xunit;

namespace Langly.DataStructures.Arrays {
	public class FixedArray1_Tests {
		[Theory]
		[InlineData(new Int32[] { 1 }, new Int32[] { }, 1)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4 }, 5)]
		public void Add_Element(Int32[] expected, Int32[] initial, Int32 element) {
			FixedArray<Int32> array = initial;
			Assert.Equal(expected, array.Add(element));
		}

		[Theory]
		[InlineData(new Int32[] { 1, 2 }, new Int32[] { }, new Int32[] { 1, 2 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3 }, new Int32[] { 4, 5 })]
		public void Add_Memory(Int32[] expected, Int32[] initial, Int32[] elements) {
			FixedArray<Int32> array = initial;
			Assert.Equal(expected, array.Add(elements));
		}

		[Theory]
		[InlineData(new Int32[] { 1, 2 }, new Int32[] { }, new Int32[] { 1, 2 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3 }, new Int32[] { 4, 5 })]
		public void Add_Span(Int32[] expected, Int32[] initial, Int32[] elements) {
			FixedArray<Int32> array = initial;
			Assert.Equal(expected, array.Add(elements.AsSpan()));
		}

		[Theory]
		[InlineData(0, new Int32[] { })]
		[InlineData(5, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Capacity(Int32 expected, Int32[] values) {
			FixedArray<Int32> array = values;
			Assert.Equal(expected, array.Capacity);
		}

		[Fact]
		public void Constructor() {
			FixedArray<Int32> array;
			array = new FixedArray<Int32>(5);
			array = new FixedArray<Int32>(5, Filter.None);
			array = FixedArray<Int32>.Empty;
			array = Array.Empty<Int32>();
			array = (Int32[])null;
			array = Memory<Int32>.Empty;
			array = ReadOnlyMemory<Int32>.Empty;
		}

		[Theory]
		[InlineData(0, new Int32[] { })]
		[InlineData(5, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Count(Int32 expected, Int32[] values) {
			FixedArray<Int32> array = values;
			Assert.Equal(expected, array.Count);
		}

		[Theory]
		[InlineData(new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 })]
		public void Enumerator(Int32[] expected) {
			FixedArray<Int32> array = expected;
			nint i = 0;
			foreach (Int32 item in array) {
				Assert.Equal(expected[i++], item);
			}
		}

		[Theory]
		[InlineData(new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 })]
		public void Indexer(Int32[] expected) {
			FixedArray<Int32> array = expected;
			for (nint i = 0; i < expected.Length; i++) {
				Assert.Equal(expected[i], array[i]);
			}
		}

		[Theory]
		[InlineData(new Int32[] { 0 }, new Int32[] { }, 0, 0)]
		[InlineData(new Int32[] { 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0, 0)]
		[InlineData(new Int32[] { 1, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, 0)]
		[InlineData(new Int32[] { 1, 2, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 3, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 4, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 5, 0)]
		public void Insert_Element(Int32[] expected, Int32[] initial, Int32 index, Int32 element) {
			FixedArray<Int32> array = initial;
			Assert.Equal(expected, array.Insert(index, element));
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 0, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 0, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 0, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 3, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 4, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 5, new Int32[] { 0, 0 })]
		public void Insert_Memory(Int32[] expected, Int32[] initial, Int32 index, Int32[] elements) {
			FixedArray<Int32> array = initial;
			Assert.Equal(expected, array.Insert(index, elements));
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 0, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 0, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 0, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 3, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 4, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 5, new Int32[] { 0, 0 })]
		public void Insert_Span(Int32[] expected, Int32[] initial, Int32 index, Int32[] elements) {
			FixedArray<Int32> array = initial;
			Assert.Equal(expected, array.Insert(index, elements.AsSpan()));
		}

		[Theory]
		[InlineData(new Int32[] { 0 }, new Int32[] { }, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 0)]
		public void Postpend_Element(Int32[] expected, Int32[] initial, Int32 element) {
			FixedArray<Int32> array = initial;
			Assert.Equal(expected, array.Postpend(element));
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 0, 0 })]
		public void Postpend_Memory(Int32[] expected, Int32[] initial, Int32[] elements) {
			FixedArray<Int32> array = initial;
			Assert.Equal(expected, array.Postpend(elements));
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 0, 0 })]
		public void Postpend_Span(Int32[] expected, Int32[] initial, Int32[] elements) {
			FixedArray<Int32> array = initial;
			Assert.Equal(expected, array.Postpend(elements.AsSpan()));
		}

		[Theory]
		[InlineData(new Int32[] { 0 }, new Int32[] { }, 0)]
		[InlineData(new Int32[] { 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0)]
		public void Prepend_Element(Int32[] expected, Int32[] initial, Int32 element) {
			FixedArray<Int32> array = initial;
			Assert.Equal(expected, array.Prepend(element));
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 0, 0 })]
		public void Prepend_Memory(Int32[] expected, Int32[] initial, Int32[] elements) {
			FixedArray<Int32> array = initial;
			Assert.Equal(expected, array.Prepend(elements));
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 0, 0 })]
		public void Prepend_Span(Int32[] expected, Int32[] initial, Int32[] elements) {
			FixedArray<Int32> array = initial;
			Assert.Equal(expected, array.Prepend(elements.AsSpan()));
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, 0, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0, 0)]
		[InlineData(new Int32[] { 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, 0)]
		[InlineData(new Int32[] { 1, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, 0)]
		[InlineData(new Int32[] { 1, 2, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 3, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 4, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 5, 0)]
		[InlineData(new Int32[] { 0, 2, 0, 2, 0 }, new Int32[] { 1, 2, 1, 2, 1 }, 1, 0)]
		[InlineData(new Int32[] { 0, 0, 0, 0, 0 }, new Int32[] { 1, 1, 1, 1, 1 }, 1, 0)]
		public void Replace_Element(Int32[] expected, Int32[] initial, Int32 search, Int32 replace) {
			FixedArray<Int32> array = initial;
			Assert.Equal(expected, array.Replace(search, replace));
		}

		[Theory]
		[InlineData(new[] { 1, 2, 3, 4, 5 }, 2, 2)]
		public void Slice(Int32[] expected, Int32 start, Int32 length) {
			FixedArray<Int32> array = expected;
			FixedArray<Int32> slice = array.Slice(start, length);
			Int32 a = start;
			foreach (Int32 item in slice) {
				Assert.Equal(array[a++], item);
			}
			Assert.Equal(start + length, a);
		}

		[Theory]
		[InlineData(0, new Int32[] { 1, 2, 3, 4, 5 }, -1)]
		[InlineData(1, new Int32[] { 1, 2, 3, 4, 5 }, 0)]
		[InlineData(2, new Int32[] { 1, 2, 3, 4, 5 }, 1)]
		[InlineData(3, new Int32[] { 1, 2, 3, 4, 5 }, 2)]
		[InlineData(4, new Int32[] { 1, 2, 3, 4, 5 }, 3)]
		[InlineData(5, new Int32[] { 1, 2, 3, 4, 5 }, 4)]
		[InlineData(0, new Int32[] { 1, 2, 3, 4, 5 }, 5)]
		public void Sparse(Int32 expected, Int32[] values, Int32 index) {
			FixedArray<Int32> array = new FixedArray<Int32>(values, Filter.Sparse);
			Assert.Equal(expected, array[index]);
		}
	}
}
