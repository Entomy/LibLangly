using System;
using Xunit;

namespace Langly.DataStructures.Lists {
	public class Chain1_Tests {
		[Fact]
		public void Constructor() {
			Chain<Int32> chain = new Chain<Int32>();
		}

		[Theory]
		[InlineData(new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 })]
		public void Add_Element(Int32[] expected) {
			Chain<Int32> chain = new Chain<Int32>();
			foreach (Int32 item in expected) {
				_ = chain.Add(item);
			}
			Assert.Equal(expected, chain);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 })]
		public void Add_Memory(Int32[] expected, Int32[] slicePoints) {
			Chain<Int32> chain = new Chain<Int32>();
			Int32 i = 0;
			foreach (Int32 sp in slicePoints) {
				_ = chain.Add(expected[i..sp]);
				i = sp;
			}
			Assert.Equal(expected, chain);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 })]
		public void Add_Span(Int32[] expected, Int32[] slicePoints) {
			Chain<Int32> chain = new Chain<Int32>();
			Int32 i = 0;
			foreach (Int32 sp in slicePoints) {
				_ = chain.Add(expected.AsSpan()[i..sp]);
				i = sp;
			}
			Assert.Equal(expected, chain);
		}

		[Theory]
		[InlineData(new Int32[] { })]
		[InlineData(new Int32[] { 1 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 })]
		public void Indexer_Element(Int32[] expected) {
			Chain<Int32> chain = new Chain<Int32>();
			foreach (Int32 item in expected) {
				_ = chain.Add(item);
			}
			for (nint i = 0; i < expected.Length; i++) {
				Assert.Equal(expected[i], chain[i]);
			}
		}

		[Theory]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 })]
		public void Indexer_Memory(Int32[] expected, Int32[] slicePoints) {
			Chain<Int32> chain = new Chain<Int32>();
			Int32 i = 0;
			foreach (Int32 sp in slicePoints) {
				_ = chain.Add(expected[i..sp]);
				i = sp;
			}
			for (i = 0; i < expected.Length; i++) {
				Assert.Equal(expected[i], chain[i]);
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
		public void Insert_Element_Element(Int32[] expected, Int32[] initial, Int32 index, Int32 element) {
			Chain<Int32> chain = new Chain<Int32>();
			foreach (Int32 item in initial) {
				_ = chain.Add(item);
			}
			_ = chain.Insert(index, element);
			Assert.Equal(expected, chain);
		}

		[Theory]
		[InlineData(new Int32[] { 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 0, 0)]
		[InlineData(new Int32[] { 1, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 1, 0)]
		[InlineData(new Int32[] { 1, 2, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 2, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 3, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 4, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 5, 0)]
		[InlineData(new Int32[] { 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 0, 0)]
		[InlineData(new Int32[] { 1, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 1, 0)]
		[InlineData(new Int32[] { 1, 2, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 2, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 3, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 4, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 5, 0)]
		[InlineData(new Int32[] { 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 0, 0)]
		[InlineData(new Int32[] { 1, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 1, 0)]
		[InlineData(new Int32[] { 1, 2, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 2, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 3, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 4, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 5, 0)]
		[InlineData(new Int32[] { 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 0, 0)]
		[InlineData(new Int32[] { 1, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 1, 0)]
		[InlineData(new Int32[] { 1, 2, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 2, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 3, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 4, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 5, 0)]
		public void Insert_Element_Memory(Int32[] expected, Int32[] initial, Int32[] slicePoints, Int32 index, Int32 element) {
			Chain<Int32> chain = new Chain<Int32>();
			Int32 i = 0;
			foreach (Int32 sp in slicePoints) {
				_ = chain.Add(initial[i..sp]);
				i = sp;
			}
			_ = chain.Insert(index, element);
			Assert.Equal(expected, chain);
		}

		[Theory]
		[InlineData(new Int32[] { 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 0, 0)]
		[InlineData(new Int32[] { 1, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 1, 0)]
		[InlineData(new Int32[] { 1, 2, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 2, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 3, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 4, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 5, 0)]
		[InlineData(new Int32[] { 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 0, 0)]
		[InlineData(new Int32[] { 1, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 1, 0)]
		[InlineData(new Int32[] { 1, 2, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 2, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 3, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 4, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 5, 0)]
		[InlineData(new Int32[] { 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 0, 0)]
		[InlineData(new Int32[] { 1, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 1, 0)]
		[InlineData(new Int32[] { 1, 2, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 2, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 3, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 4, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 5, 0)]
		[InlineData(new Int32[] { 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 0, 0)]
		[InlineData(new Int32[] { 1, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 1, 0)]
		[InlineData(new Int32[] { 1, 2, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 2, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 3, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 4, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 5, 0)]
		public void Insert_Element_Span(Int32[] expected, Int32[] initial, Int32[] slicePoints, Int32 index, Int32 element) {
			Chain<Int32> chain = new Chain<Int32>();
			Int32 i = 0;
			foreach (Int32 sp in slicePoints) {
				_ = chain.Add(initial.AsSpan()[i..sp]);
				i = sp;
			}
			_ = chain.Insert(index, element);
			Assert.Equal(expected, chain);
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 0, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 0, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 0, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 3, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 4, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 5, new Int32[] { 0, 0 })]
		public void Insert_Memory_Element(Int32[] expected, Int32[] initial, Int32 index, Int32[] elements) {
			Chain<Int32> chain = new Chain<Int32>();
			foreach (Int32 item in initial) {
				_ = chain.Add(item);
			}
			_ = chain.Insert(index, elements);
			Assert.Equal(expected, chain);
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 0, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 0, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 0, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 3, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 4, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 5, new Int32[] { 0, 0 })]
		public void Insert_Span_Element(Int32[] expected, Int32[] initial, Int32 index, Int32[] elements) {
			Chain<Int32> chain = new Chain<Int32>();
			foreach (Int32 item in initial) {
				_ = chain.Add(item);
			}
			_ = chain.Insert(index, elements.AsSpan());
			Assert.Equal(expected, chain);
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 0, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 1, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 0, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 2, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 0, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 3, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 4, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 5, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 0, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 1, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 0, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 2, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 0, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 3, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 4, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 5, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 0, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 1, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 0, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 2, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 0, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 3, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 4, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 5, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 0, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 1, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 0, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 2, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 0, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 3, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 4, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 5, new Int32[] { 0, 0 })]
		public void Insert_Memory_Memory(Int32[] expected, Int32[] initial, Int32[] slicePoints, Int32 index, Int32[] elements) {
			Chain<Int32> chain = new Chain<Int32>();
			Int32 i = 0;
			foreach (Int32 sp in slicePoints) {
				_ = chain.Add(initial[i..sp]);
				i = sp;
			}
			_ = chain.Insert(index, elements);
			Assert.Equal(expected, chain);
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 0, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 1, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 0, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 2, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 0, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 3, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 4, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 5, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 0, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 1, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 0, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 2, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 0, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 3, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 4, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 5, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 0, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 1, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 0, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 2, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 0, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 3, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 4, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 5, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 0, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 1, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 0, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 2, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 0, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 3, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 4, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 5, new Int32[] { 0, 0 })]
		public void Insert_Span_Span(Int32[] expected, Int32[] initial, Int32[] slicePoints, Int32 index, Int32[] elements) {
			Chain<Int32> chain = new Chain<Int32>();
			Int32 i = 0;
			foreach (Int32 sp in slicePoints) {
				_ = chain.Add(initial.AsSpan()[i..sp]);
				i = sp;
			}
			_ = chain.Insert(index, elements.AsSpan());
			Assert.Equal(expected, chain);
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
			Chain<Int32> chain = new Chain<Int32>();
			foreach (Int32 item in initial) {
				_ = chain.Add(item);
			}
			_ = chain.Replace(search, replace);
			Assert.Equal(expected, chain);
		}

		[Theory]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 0, 0)]
		[InlineData(new Int32[] { 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 1, 0)]
		[InlineData(new Int32[] { 1, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 2, 0)]
		[InlineData(new Int32[] { 1, 2, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 3, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 4, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 5, 0)]
		[InlineData(new Int32[] { 0, 2, 0, 2, 0 }, new Int32[] { 1, 2, 1, 2, 1 }, new Int32[] { 5 }, 1, 0)]
		[InlineData(new Int32[] { 0, 0, 0, 0, 0 }, new Int32[] { 1, 1, 1, 1, 1 }, new Int32[] { 5 }, 1, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 0, 0)]
		[InlineData(new Int32[] { 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 1, 0)]
		[InlineData(new Int32[] { 1, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 2, 0)]
		[InlineData(new Int32[] { 1, 2, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 3, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 4, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 5, 0)]
		[InlineData(new Int32[] { 0, 2, 0, 2, 0 }, new Int32[] { 1, 2, 1, 2, 1 }, new Int32[] { 2, 5 }, 1, 0)]
		[InlineData(new Int32[] { 0, 0, 0, 0, 0 }, new Int32[] { 1, 1, 1, 1, 1 }, new Int32[] { 2, 5 }, 1, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 0, 0)]
		[InlineData(new Int32[] { 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 1, 0)]
		[InlineData(new Int32[] { 1, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 2, 0)]
		[InlineData(new Int32[] { 1, 2, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 3, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 4, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 5, 0)]
		[InlineData(new Int32[] { 0, 2, 0, 2, 0 }, new Int32[] { 1, 2, 1, 2, 1 }, new Int32[] { 2, 4, 5 }, 1, 0)]
		[InlineData(new Int32[] { 0, 0, 0, 0, 0 }, new Int32[] { 1, 1, 1, 1, 1 }, new Int32[] { 2, 4, 5 }, 1, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 0, 0)]
		[InlineData(new Int32[] { 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 1, 0)]
		[InlineData(new Int32[] { 1, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 2, 0)]
		[InlineData(new Int32[] { 1, 2, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 3, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 4, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 5, 0)]
		[InlineData(new Int32[] { 0, 2, 0, 2, 0 }, new Int32[] { 1, 2, 1, 2, 1 }, new Int32[] { 1, 5 }, 1, 0)]
		[InlineData(new Int32[] { 0, 0, 0, 0, 0 }, new Int32[] { 1, 1, 1, 1, 1 }, new Int32[] { 1, 5 }, 1, 0)]
		public void Replace_Memory(Int32[] expected, Int32[] initial, Int32[] slicePoints, Int32 search, Int32 replace) {
			Chain<Int32> chain = new Chain<Int32>();
			Int32 i = 0;
			foreach (Int32 sp in slicePoints) {
				_ = chain.Add(initial[i..sp]);
				i = sp;
			}
			_ = chain.Replace(search, replace);
			Assert.Equal(expected, chain);
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
			Chain<Int32> chain = new Chain<Int32>(Filter.Sparse).Add(values);
			Assert.Equal(expected, chain[index]);
		}

		[Theory]
		[InlineData("[]", null)]
		[InlineData("[]", new Int32[] { })]
		[InlineData("[1, 2, 3, 4, 5]", new Int32[] { 1, 2, 3, 4, 5 })]
		public void ToString(String expected, Int32[] values) {
			Chain<Int32> chain = new Chain<Int32>().Add(values);
			Assert.Equal(expected, chain.ToString());
		}

		[Theory]
		[InlineData("[]", null, 5)]
		[InlineData("[]", null, 3)]
		[InlineData("[]", new Int32[] { }, 5)]
		[InlineData("[]", new Int32[] { }, 3)]
		[InlineData("[1, 2, 3, 4, 5]", new Int32[] { 1, 2, 3, 4, 5 }, 5)]
		[InlineData("[1, 2, 3...]", new Int32[] { 1, 2, 3, 4, 5 }, 3)]
		public void ToString_Amount(String expected, Int32[] values, Int32 amount) {
			Chain<Int32> chain = new Chain<Int32>().Add(values);
			Assert.Equal(expected, chain.ToString(amount));
		}
	}
}
