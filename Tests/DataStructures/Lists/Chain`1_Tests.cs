﻿using System;
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
		[InlineData(0, null)]
		[InlineData(0, new Int32[] { })]
		[InlineData(5, new Int32[] { 1, 2, 3, 4, 5 })]
		[InlineData(5, new Int32[] { 5, 4, 3, 2, 1 })]
		public void Max_nint(Int32 expected, Int32[] values) {
			nint[] vals = null;
			if (values is not null) {
				vals = new nint[values.Length];
				for (nint i = 0; i < values.Length; i++) {
					vals[i] = (nint)values[i];
				}
			}
			Chain<nint> chain = new Chain<nint>().Add(vals);
			Assert.Equal(expected, chain.Max());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new UInt32[] { })]
		[InlineData(5, new UInt32[] { 1, 2, 3, 4, 5 })]
		[InlineData(5, new UInt32[] { 5, 4, 3, 2, 1 })]
		public void Max_nuint(UInt32 expected, UInt32[] values) {
			nuint[] vals = null;
			if (values is not null) {
				vals = new nuint[values.Length];
				for (nint i = 0; i < values.Length; i++) {
					vals[i] = (nuint)values[i];
				}
			}
			Chain<nuint> chain = new Chain<nuint>().Add(vals);
			Assert.Equal(expected, chain.Max());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new SByte[] { })]
		[InlineData(5, new SByte[] { 1, 2, 3, 4, 5 })]
		[InlineData(5, new SByte[] { 5, 4, 3, 2, 1 })]
		public void Max_SByte(Int32 expected, SByte[] values) {
			Chain<SByte> chain = new Chain<SByte>().Add(values);
			Assert.Equal(expected, chain.Max());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new Byte[] { })]
		[InlineData(5, new Byte[] { 1, 2, 3, 4, 5 })]
		[InlineData(5, new Byte[] { 5, 4, 3, 2, 1 })]
		public void Max_Byte(UInt32 expected, Byte[] values) {
			Chain<Byte> chain = new Chain<Byte>().Add(values);
			Assert.Equal(expected, chain.Max());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new Int16[] { })]
		[InlineData(5, new Int16[] { 1, 2, 3, 4, 5 })]
		[InlineData(5, new Int16[] { 5, 4, 3, 2, 1 })]
		public void Max_Int16(Int32 expected, Int16[] values) {
			Chain<Int16> chain = new Chain<Int16>().Add(values);
			Assert.Equal(expected, chain.Max());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new UInt16[] { })]
		[InlineData(5, new UInt16[] { 1, 2, 3, 4, 5 })]
		[InlineData(5, new UInt16[] { 5, 4, 3, 2, 1 })]
		public void Max_UInt16(UInt32 expected, UInt16[] values) {
			Chain<UInt16> chain = new Chain<UInt16>().Add(values);
			Assert.Equal(expected, chain.Max());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new Int32[] { })]
		[InlineData(5, new Int32[] { 1, 2, 3, 4, 5 })]
		[InlineData(5, new Int32[] { 5, 4, 3, 2, 1 })]
		public void Max_Int32(Int32 expected, Int32[] values) {
			Chain<Int32> chain = new Chain<Int32>().Add(values);
			Assert.Equal(expected, chain.Max());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new UInt32[] { })]
		[InlineData(5, new UInt32[] { 1, 2, 3, 4, 5 })]
		[InlineData(5, new UInt32[] { 5, 4, 3, 2, 1 })]
		public void Max_UInt32(UInt32 expected, UInt32[] values) {
			Chain<UInt32> chain = new Chain<UInt32>().Add(values);
			Assert.Equal(expected, chain.Max());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new Int64[] { })]
		[InlineData(5, new Int64[] { 1, 2, 3, 4, 5 })]
		[InlineData(5, new Int64[] { 5, 4, 3, 2, 1 })]
		public void Max_Int64(Int64 expected, Int64[] values) {
			Chain<Int64> chain = new Chain<Int64>().Add(values);
			Assert.Equal(expected, chain.Max());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new UInt64[] { })]
		[InlineData(5, new UInt64[] { 1, 2, 3, 4, 5 })]
		[InlineData(5, new UInt64[] { 5, 4, 3, 2, 1 })]
		public void Max_UInt64(UInt64 expected, UInt64[] values) {
			Chain<UInt64> chain = new Chain<UInt64>().Add(values);
			Assert.Equal(expected, chain.Max());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new Single[] { })]
		[InlineData(5, new Single[] { 1, 2, 3, 4, 5 })]
		[InlineData(5, new Single[] { 5, 4, 3, 2, 1 })]
		public void Max_Single(Single expected, Single[] values) {
			Chain<Single> chain = new Chain<Single>().Add(values);
			Assert.Equal(expected, chain.Max());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new Double[] { })]
		[InlineData(5, new Double[] { 1, 2, 3, 4, 5 })]
		[InlineData(5, new Double[] { 5, 4, 3, 2, 1 })]
		public void Max_Double(Double expected, Double[] values) {
			Chain<Double> chain = new Chain<Double>().Add(values);
			Assert.Equal(expected, chain.Max());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new Int32[] { })]
		[InlineData(5, new Int32[] { 1, 2, 3, 4, 5 })]
		[InlineData(5, new Int32[] { 5, 4, 3, 2, 1 })]
		public void Max_Decimal(Decimal expected, Int32[] values) {
			Decimal[] vals = null;
			if (values is not null) {
				vals = new Decimal[values.Length];
				for (nint i = 0; i < values.Length; i++) {
					vals[i] = values[i];
				}
			}
			Chain<Decimal> chain = new Chain<Decimal>().Add(vals);
			Assert.Equal(expected, chain.Max());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new Int32[] { })]
		[InlineData(1, new Int32[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new Int32[] { 5, 4, 3, 2, 1 })]
		public void Min_nint(Int32 expected, Int32[] values) {
			nint[] vals = null;
			if (values is not null) {
				vals = new nint[values.Length];
				for (nint i = 0; i < values.Length; i++) {
					vals[i] = (nint)values[i];
				}
			}
			Chain<nint> chain = values is not null ? new Chain<nint>().Add(vals) : null;
			Assert.Equal(expected, chain.Min());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new UInt32[] { })]
		[InlineData(1, new UInt32[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new UInt32[] { 5, 4, 3, 2, 1 })]
		public void Min_nuint(UInt32 expected, UInt32[] values) {
			nuint[] vals = null;
			if (values is not null) {
				vals = new nuint[values.Length];
				for (nint i = 0; i < values.Length; i++) {
					vals[i] = (nuint)values[i];
				}
			}
			Chain<nuint> chain = values is not null ? new Chain<nuint>().Add(vals) : null;
			Assert.Equal(expected, chain.Min());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new SByte[] { })]
		[InlineData(1, new SByte[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new SByte[] { 5, 4, 3, 2, 1 })]
		public void Min_SByte(Int32 expected, SByte[] values) {
			Chain<SByte> chain = values is not null ? new Chain<SByte>().Add(values) : null;
			Assert.Equal(expected, chain.Min());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new Byte[] { })]
		[InlineData(1, new Byte[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new Byte[] { 5, 4, 3, 2, 1 })]
		public void Min_Byte(UInt32 expected, Byte[] values) {
			Chain<Byte> chain = values is not null ? new Chain<Byte>().Add(values) : null;
			Assert.Equal(expected, chain.Min());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new Int16[] { })]
		[InlineData(1, new Int16[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new Int16[] { 5, 4, 3, 2, 1 })]
		public void Min_Int16(Int32 expected, Int16[] values) {
			Chain<Int16> chain = values is not null ? new Chain<Int16>().Add(values) : null;
			Assert.Equal(expected, chain.Min());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new UInt16[] { })]
		[InlineData(1, new UInt16[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new UInt16[] { 5, 4, 3, 2, 1 })]
		public void Min_UInt16(UInt32 expected, UInt16[] values) {
			Chain<UInt16> chain = values is not null ? new Chain<UInt16>().Add(values) : null;
			Assert.Equal(expected, chain.Min());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new Int32[] { })]
		[InlineData(1, new Int32[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new Int32[] { 5, 4, 3, 2, 1 })]
		public void Min_Int32(Int32 expected, Int32[] values) {
			Chain<Int32> chain = values is not null ? new Chain<Int32>().Add(values) : null;
			Assert.Equal(expected, chain.Min());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new UInt32[] { })]
		[InlineData(1, new UInt32[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new UInt32[] { 5, 4, 3, 2, 1 })]
		public void Min_UInt32(UInt32 expected, UInt32[] values) {
			Chain<UInt32> chain = values is not null ? new Chain<UInt32>().Add(values) : null;
			Assert.Equal(expected, chain.Min());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new Int64[] { })]
		[InlineData(1, new Int64[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new Int64[] { 5, 4, 3, 2, 1 })]
		public void Min_Int64(Int64 expected, Int64[] values) {
			Chain<Int64> chain = values is not null ? new Chain<Int64>().Add(values) : null;
			Assert.Equal(expected, chain.Min());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new UInt64[] { })]
		[InlineData(1, new UInt64[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new UInt64[] { 5, 4, 3, 2, 1 })]
		public void Min_UInt64(UInt64 expected, UInt64[] values) {
			Chain<UInt64> chain = values is not null ? new Chain<UInt64>().Add(values) : null;
			Assert.Equal(expected, chain.Min());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new Single[] { })]
		[InlineData(1, new Single[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new Single[] { 5, 4, 3, 2, 1 })]
		public void Min_Single(Single expected, Single[] values) {
			Chain<Single> chain = values is not null ? new Chain<Single>().Add(values) : null;
			Assert.Equal(expected, chain.Min());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new Double[] { })]
		[InlineData(1, new Double[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new Double[] { 5, 4, 3, 2, 1 })]
		public void Min_Double(Double expected, Double[] values) {
			Chain<Double> chain = values is not null ? new Chain<Double>().Add(values) : null;
			Assert.Equal(expected, chain.Min());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new Int32[] { })]
		[InlineData(1, new Int32[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new Int32[] { 5, 4, 3, 2, 1 })]
		public void Min_Decimal(Decimal expected, Int32[] values) {
			Decimal[] vals = null;
			if (values is not null) {
				vals = new Decimal[values.Length];
				for (nint i = 0; i < values.Length; i++) {
					vals[i] = values[i];
				}
			}
			Chain<Decimal> chain = values is not null ? new Chain<Decimal>().Add(vals) : null;
			Assert.Equal(expected, chain.Min());
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
		[InlineData(0, null)]
		[InlineData(0, new Int32[] { })]
		[InlineData(15, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Sum_nint(Int32 expected, Int32[] values) {
			nint[] vals = null;
			if (values is not null) {
				vals = new nint[values.Length];
				for (nint i = 0; i < values.Length; i++) {
					vals[i] = (nint)values[i];
				}
			}
			Chain<nint> chain = new Chain<nint>().Add(vals);
			Assert.Equal(expected, chain.Sum());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new UInt32[] { })]
		[InlineData(15, new UInt32[] { 1, 2, 3, 4, 5 })]
		public void Sum_nuint(UInt32 expected, UInt32[] values) {
			nuint[] vals = null;
			if (values is not null) {
				vals = new nuint[values.Length];
				for (nint i = 0; i < values.Length; i++) {
					vals[i] = (nuint)values[i];
				}
			}
			Chain<nuint> chain = new Chain<nuint>().Add(vals);
			Assert.Equal(expected, chain.Sum());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new SByte[] { })]
		[InlineData(15, new SByte[] { 1, 2, 3, 4, 5 })]
		public void Sum_SByte(Int32 expected, SByte[] values) {
			Chain<SByte> chain = new Chain<SByte>().Add(values);
			Assert.Equal(expected, chain.Sum());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new Byte[] { })]
		[InlineData(15, new Byte[] { 1, 2, 3, 4, 5 })]
		public void Sum_Byte(UInt32 expected, Byte[] values) {
			Chain<Byte> chain = new Chain<Byte>().Add(values);
			Assert.Equal(expected, chain.Sum());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new Int16[] { })]
		[InlineData(15, new Int16[] { 1, 2, 3, 4, 5 })]
		public void Sum_Int16(Int32 expected, Int16[] values) {
			Chain<Int16> chain = new Chain<Int16>().Add(values);
			Assert.Equal(expected, chain.Sum());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new UInt16[] { })]
		[InlineData(15, new UInt16[] { 1, 2, 3, 4, 5 })]
		public void Sum_UInt16(UInt32 expected, UInt16[] values) {
			Chain<UInt16> chain = new Chain<UInt16>().Add(values);
			Assert.Equal(expected, chain.Sum());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new Int32[] { })]
		[InlineData(15, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Sum_Int32(Int32 expected, Int32[] values) {
			Chain<Int32> chain = new Chain<Int32>().Add(values);
			Assert.Equal(expected, chain.Sum());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new UInt32[] { })]
		[InlineData(15, new UInt32[] { 1, 2, 3, 4, 5 })]
		public void Sum_UInt32(UInt32 expected, UInt32[] values) {
			Chain<UInt32> chain = new Chain<UInt32>().Add(values);
			Assert.Equal(expected, chain.Sum());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new Int64[] { })]
		[InlineData(15, new Int64[] { 1, 2, 3, 4, 5 })]
		public void Sum_Int64(Int64 expected, Int64[] values) {
			Chain<Int64> chain = new Chain<Int64>().Add(values);
			Assert.Equal(expected, chain.Sum());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new UInt64[] { })]
		[InlineData(15, new UInt64[] { 1, 2, 3, 4, 5 })]
		public void Sum_UInt64(UInt64 expected, UInt64[] values) {
			Chain<UInt64> chain = new Chain<UInt64>().Add(values);
			Assert.Equal(expected, chain.Sum());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new Single[] { })]
		[InlineData(15, new Single[] { 1, 2, 3, 4, 5 })]
		public void Sum_Single(Single expected, Single[] values) {
			Chain<Single> chain = new Chain<Single>().Add(values);
			Assert.Equal(expected, chain.Sum());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new Double[] { })]
		[InlineData(15, new Double[] { 1, 2, 3, 4, 5 })]
		public void Sum_Double(Double expected, Double[] values) {
			Chain<Double> chain = new Chain<Double>().Add(values);
			Assert.Equal(expected, chain.Sum());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new Int32[] { })]
		[InlineData(15, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Sum_Decimal(Decimal expected, Int32[] values) {
			Decimal[] vals = null;
			if (values is not null) {
				vals = new Decimal[values.Length];
				for (nint i = 0; i < values.Length; i++) {
					vals[i] = values[i];
				}
			}
			Chain<Decimal> chain = new Chain<Decimal>().Add(vals);
			Assert.Equal(expected, chain.Sum());
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
