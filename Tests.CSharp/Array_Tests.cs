using System;
using Xunit;

namespace Langly {
	public class Array_Tests {
		[Theory]
		[InlineData(new Int32[] { 1 }, new Int32[] { }, 1)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4 }, 5)]
		public void Add_Element(Int32[] expected, Int32[] initial, Int32 element) {
			Assert.Equal(expected, initial.Add(element));
			Assert.Equal(expected, initial.AsMemory().Add(element).ToArray());
			Assert.Equal(expected, ((ReadOnlyMemory<Int32>)initial.AsMemory()).Add(element).ToArray());
		}

		[Theory]
		[InlineData(new Int32[] { 1, 2 }, new Int32[] { }, new Int32[] { 1, 2 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3 }, new Int32[] { 4, 5 })]
		public void Add_Elements(Int32[] expected, Int32[] initial, Int32[] elements) {
			Assert.Equal(expected, initial.Add(elements));
			Assert.Equal(expected, initial.AsMemory().Add(elements).ToArray());
			Assert.Equal(expected, ((ReadOnlyMemory<Int32>)initial.AsMemory()).Add(elements).ToArray());
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
			Assert.Equal(expected, initial.Insert(index, element));
			Assert.Equal(expected, initial.AsMemory().Insert(index, element).ToArray());
			Assert.Equal(expected, ((ReadOnlyMemory<Int32>)initial.AsMemory()).Insert(index, element).ToArray());
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 0, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 0, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 0, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 3, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 4, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 5, new Int32[] { 0, 0 })]
		public void Insert_Elements(Int32[] expected, Int32[] initial, Int32 index, Int32[] elements) {
			Assert.Equal(expected, initial.Insert(index, elements));
			Assert.Equal(expected, initial.AsMemory().Insert(index, elements).ToArray());
			Assert.Equal(expected, ((ReadOnlyMemory<Int32>)initial.AsMemory()).Insert(index, elements).ToArray());
		}

		[Theory]
		[InlineData(new Int32[] { 0 }, new Int32[] { }, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 0)]
		public void Postpend_Element(Int32[] expected, Int32[] initial, Int32 element) {
			Assert.Equal(expected, initial.Postpend(element));
			Assert.Equal(expected, initial.AsMemory().Postpend(element).ToArray());
			Assert.Equal(expected, ((ReadOnlyMemory<Int32>)initial.AsMemory()).Postpend(element).ToArray());
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 0, 0 })]
		public void Postpend_Elements(Int32[] expected, Int32[] initial, Int32[] elements) {
			Assert.Equal(expected, initial.Postpend(elements));
			Assert.Equal(expected, initial.AsMemory().Postpend(elements).ToArray());
			Assert.Equal(expected, ((ReadOnlyMemory<Int32>)initial.AsMemory()).Postpend(elements).ToArray());
		}

		[Theory]
		[InlineData(new Int32[] { 0 }, new Int32[] { }, 0)]
		[InlineData(new Int32[] { 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0)]
		public void Prepend_Element(Int32[] expected, Int32[] initial, Int32 element) {
			Assert.Equal(expected, initial.Prepend(element));
			Assert.Equal(expected, initial.AsMemory().Prepend(element).ToArray());
			Assert.Equal(expected, ((ReadOnlyMemory<Int32>)initial.AsMemory()).Prepend(element).ToArray());
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 0, 0 })]
		public void Prepend_Memory(Int32[] expected, Int32[] initial, Int32[] elements) {
			Assert.Equal(expected, initial.Prepend(elements));
			Assert.Equal(expected, initial.AsMemory().Prepend(elements).ToArray());
			Assert.Equal(expected, ((ReadOnlyMemory<Int32>)initial.AsMemory()).Prepend(elements).ToArray());
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
			Assert.Equal(expected, initial.Replace(search, replace));
			Assert.Equal(expected, initial.AsMemory().Replace(search, replace).ToArray());
			Assert.Equal(expected, ((ReadOnlyMemory<Int32>)initial.AsMemory()).Replace(search, replace).ToArray());
		}

		[Theory]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0)]
		[InlineData(new Int32[] { 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 1)]
		[InlineData(new Int32[] { 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 2)]
		public void ShiftLeft(Int32[] expected, Int32[] initial, Int32 amount) {
			Assert.Equal(expected, initial.ShiftLeft(amount));
			Assert.Equal(expected, initial.AsMemory().ShiftLeft(amount).ToArray());
			Assert.Equal(expected, ((ReadOnlyMemory<Int32>)initial.AsMemory()).ShiftLeft(amount).ToArray());
		}

		[Theory]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0)]
		[InlineData(new Int32[] { 0, 1, 2, 3, 4 }, new Int32[] { 1, 2, 3, 4, 5 }, 1)]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3 }, new Int32[] { 1, 2, 3, 4, 5 }, 2)]
		public void ShiftRight(Int32[] expected, Int32[] initial, Int32 amount) {
			Assert.Equal(expected, initial.ShiftRight(amount));
			Assert.Equal(expected, initial.AsMemory().ShiftRight(amount).ToArray());
			Assert.Equal(expected, ((ReadOnlyMemory<Int32>)initial.AsMemory()).ShiftRight(amount).ToArray());
		}

		[Theory]
		[InlineData(new[] { 2, 3 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, 2)]
		[InlineData(new[] { 3, 4 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, 2)]
		[InlineData(new[] { 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, 4)]
		public void Slice(Int32[] expected, Int32[] initial, Int32 start, Int32 length) {
			Assert.Equal(expected, initial.Slice(start, length).ToArray());
			Assert.Equal(expected, initial.AsMemory().Slice(start, length).ToArray());
			Assert.Equal(expected, ((ReadOnlyMemory<Int32>)initial.AsMemory()).Slice(start, length).ToArray());
		}
	}
}
