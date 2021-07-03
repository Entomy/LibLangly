using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits.Testing;
using Collectathon.Arrays;
using Xunit;

namespace Collectathon {
	public class DynamicArray_Tests : Tests {
		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, new Int32[] { 0, 0 })]
		public void Add_Array([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] values) {
			DynamicArray<Int32> array = initial;
			array.Add(values);
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { 0 }, new Int32[] { }, 0)]
		[InlineData(new Int32[] { 1, 2, }, new Int32[] { 1 }, 2)]
		public void Add_Element([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32 value) {
			DynamicArray<Int32> array = initial;
			array.Add(value);
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, new Int32[] { 0, 0 })]
		public void Add_Memory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] values) {
			DynamicArray<Int32> array = initial;
			array.Add(values.AsMemory());
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, new Int32[] { 0, 0 })]
		public unsafe void Add_Pointer([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] values) {
			DynamicArray<Int32> array = initial;
			fixed (Int32* vals = values) {
				array.Add(vals, values.Length);
			}
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, new Int32[] { 0, 0 })]
		public void Add_ReadOnlyMemory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] values) {
			DynamicArray<Int32> array = initial;
			array.Add((ReadOnlyMemory<Int32>)values.AsMemory());
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, new Int32[] { 0, 0 })]
		public void Add_ReadOnlySpan([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] values) {
			DynamicArray<Int32> array = initial;
			array.Add((ReadOnlySpan<Int32>)values.AsSpan());
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, new Int32[] { 0, 0 })]
		public void Add_Span([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] values) {
			DynamicArray<Int32> array = initial;
			array.Add(values.AsSpan());
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 })]
		public void Clear([DisallowNull] Int32[] initial) {
			DynamicArray<Int32> array = initial;
			array.Clear();
			Assert(array).Count(0);
		}

		[Theory]
		[InlineData(new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 })]

		public void Equals([DisallowNull] Int32[] elements) {
			DynamicArray<Int32> val = elements is not null ? new DynamicArray<Int32>(elements) : null;
			Assert(val).Equals(elements);
			DynamicArray<Int32> exp = elements is not null ? new DynamicArray<Int32>(elements) : null;
			Assert(val).Equals(exp);
			DynamicArray<Int32> dval = elements is not null ? new DynamicArray<Int32>(elements) : null;
			Assert(val).Equals(dval);
		}

		[Theory]
		[InlineData(0, new Int32[] { })]
		[InlineData(15, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Fold(Int32 expected, [DisallowNull] Int32[] values) {
			DynamicArray<Int32> array = values;
			Assert(array.Fold((a, b) => a + b, 0)).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 0, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 0, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 0, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 3, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 4, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 5, new Int32[] { 0, 0 })]
		public void Insert_Array([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 index, [DisallowNull] Int32[] elements) {
			DynamicArray<Int32> array = initial;
			array.Insert(index, elements);
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { 0 }, new Int32[] { }, 0, 0)]
		[InlineData(new Int32[] { 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0, 0)]
		[InlineData(new Int32[] { 1, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, 0)]
		[InlineData(new Int32[] { 1, 2, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 3, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 4, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 5, 0)]
		public void Insert_Element([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 index, Int32 element) {
			DynamicArray<Int32> array = initial;
			array.Insert(index, element);
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 0, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 0, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 0, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 3, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 4, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 5, new Int32[] { 0, 0 })]
		public void Insert_Memory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 index, [DisallowNull] Int32[] values) {
			DynamicArray<Int32> array = initial;
			array.Insert(index, values.AsMemory());
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 0, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 0, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 0, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 3, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 4, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 5, new Int32[] { 0, 0 })]
		public unsafe void Insert_Pointer([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 index, [DisallowNull] Int32[] elements) {
			DynamicArray<Int32> array = initial;
			fixed (Int32* elmts = elements) {
				array.Insert(index, elmts, elements.Length);
			}
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 0, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 0, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 0, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 3, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 4, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 5, new Int32[] { 0, 0 })]
		public void Insert_ReadOnlyMemory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 index, [DisallowNull] Int32[] elements) {
			DynamicArray<Int32> array = initial;
			array.Insert(index, (ReadOnlyMemory<Int32>)elements.AsMemory());
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 0, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 0, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 0, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 3, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 4, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 5, new Int32[] { 0, 0 })]
		public void Insert_ReadOnlySpan([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 index, [DisallowNull] Int32[] elements) {
			DynamicArray<Int32> array = initial;
			array.Insert(index, (ReadOnlySpan<Int32>)elements.AsSpan());
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 0, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 0, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 0, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 3, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 4, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 5, new Int32[] { 0, 0 })]
		public void Insert_Span([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 index, [DisallowNull] Int32[] elements) {
			DynamicArray<Int32> array = initial;
			array.Insert(index, elements.AsSpan());
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(0, new Int32[] { 1, 2, 3, 4, 5 }, 0)]
		[InlineData(3, new Int32[] { 1, 2, 1, 2, 1 }, 1)]
		[InlineData(2, new Int32[] { 1, 2, 1, 2, 1 }, 2)]
		public void Occurrences_Element(Int32 expected, [DisallowNull] Int32[] values, Int32 element) {
			DynamicArray<Int32> array = values;
			Assert(array.Occurrences(element)).Equals(expected);
		}

		[Theory]
		[InlineData(0, new Int32[] { })]
		[InlineData(0, new Int32[] { 1 })]
		[InlineData(0, new Int32[] { 1, 1, 1, 1, 1 })]
		[InlineData(2, new Int32[] { 1, 2, 1, 2, 1 })]
		[InlineData(3, new Int32[] { 2, 1, 2, 1, 2 })]
		public void Occurrences_Predicate(Int32 expected, [DisallowNull] Int32[] values) {
			DynamicArray<Int32> array = values;
			Assert(array.Occurrences((x) => x % 2 == 0)).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Postpend_Array([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			DynamicArray<Int32> array = initial;
			array.Postpend(elements);
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { 0 }, new Int32[] { }, 0)]
		public void Postpend_Element([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 element) {
			DynamicArray<Int32> array = initial;
			array.Postpend(element);
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Postpend_Memory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			DynamicArray<Int32> array = initial;
			array.Postpend(elements.AsMemory());
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public unsafe void Postpend_Pointer([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			DynamicArray<Int32> array = initial;
			fixed (Int32* elmts = elements) {
				array.Postpend(elmts, elements.Length);
			}
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Postpend_ReadOnlyMemory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			DynamicArray<Int32> array = initial;
			array.Postpend((ReadOnlyMemory<Int32>)elements.AsMemory());
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Postpend_ReadOnlySpan([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			DynamicArray<Int32> array = initial;
			array.Postpend((ReadOnlySpan<Int32>)elements.AsSpan());
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Postpend_Span([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			DynamicArray<Int32> array = initial;
			array.Postpend(elements.AsSpan());
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Prepend_Array([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			DynamicArray<Int32> array = initial;
			array.Prepend(elements);
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { 0 }, new Int32[] { }, 0)]
		public void Prepend_Element([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 element) {
			DynamicArray<Int32> array = initial;
			array.Prepend(element);
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Prepend_Memory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			DynamicArray<Int32> array = initial;
			array.Prepend(elements.AsMemory());
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public unsafe void Prepend_Pointer([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			DynamicArray<Int32> array = initial;
			fixed (Int32* elmts = elements) {
				array.Prepend(elmts, elements.Length);
			}
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Prepend_ReadOnlyMemory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			DynamicArray<Int32> array = initial;
			array.Prepend((ReadOnlyMemory<Int32>)elements.AsMemory());
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Prepend_ReadOnlySpan([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			DynamicArray<Int32> array = initial;
			array.Prepend((ReadOnlySpan<Int32>)elements.AsSpan());
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Prepend_Span([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			DynamicArray<Int32> array = initial;
			array.Prepend(elements.AsSpan());
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, 0, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0, 0)]
		[InlineData(new Int32[] { 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, 0)]
		[InlineData(new Int32[] { 1, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, 0)]
		[InlineData(new Int32[] { 1, 2, 0, 4, 5, }, new Int32[] { 1, 2, 3, 4, 5 }, 3, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 4, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 5, 0)]
		[InlineData(new Int32[] { 0, 2, 0, 2, 0 }, new Int32[] { 1, 2, 1, 2, 1 }, 1, 0)]
		[InlineData(new Int32[] { 0, 0, 0, 0, 0 }, new Int32[] { 1, 1, 1, 1, 1 }, 1, 0)]
		public void Replace([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 search, Int32 replace) {
			DynamicArray<Int32> array = initial;
			array.Replace(search, replace);
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 5)]
		public void Resize([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 capacity) {
			DynamicArray<Int32> array = initial;
			array.Resize(capacity);
			Assert(array.Capacity).Equals(capacity);
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 })]
		public void ShiftLeft([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial) {
			DynamicArray<Int32> array = initial;
			array.ShiftLeft();
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, 1)]
		[InlineData(new Int32[] { 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 1)]
		[InlineData(new Int32[] { 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 2)]
		public void ShiftLeftBy([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 amount) {
			DynamicArray<Int32> array = initial;
			array.ShiftLeft(amount);
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, 1)]
		[InlineData(new Int32[] { 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 1)]
		[InlineData(new Int32[] { 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 2)]
		public void ShiftLeftOp([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 amount) {
			DynamicArray<Int32> array = initial;
			Assert(array << amount).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 0, 1, 2, 3, 4 }, new Int32[] { 1, 2, 3, 4, 5 })]
		public void ShiftRight([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial) {
			DynamicArray<Int32> array = initial;
			array.ShiftRight();
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, 1)]
		[InlineData(new Int32[] { 0, 1, 2, 3, 4 }, new Int32[] { 1, 2, 3, 4, 5 }, 1)]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3 }, new Int32[] { 1, 2, 3, 4, 5 }, 2)]
		public void ShiftRightBy([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 amount) {
			DynamicArray<Int32> array = initial;
			array.ShiftRight(amount);
			Assert(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, 1)]
		[InlineData(new Int32[] { 0, 1, 2, 3, 4 }, new Int32[] { 1, 2, 3, 4, 5 }, 1)]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3 }, new Int32[] { 1, 2, 3, 4, 5 }, 2)]
		public void ShiftRightOp([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 amount) {
			DynamicArray<Int32> array = initial;
			Assert(array >> amount).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Slice([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial) {
			DynamicArray<Int32> array = initial;
			Span<Int32> slice = array.Slice();
			Assert(slice).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, 0, 0)]
		[InlineData(new Int32[] { }, new Int32[] { 1, 2, 3, 4, 5 }, 0, 0)]
		[InlineData(new Int32[] { 2, 3 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, 3)]
		[InlineData(new Int32[] { 3, 4 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, 4)]
		[InlineData(new Int32[] { 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, 5)]
		public void Slice_Range([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 start, Int32 end) {
			DynamicArray<Int32> array = initial;
			Span<Int32> slice = array[start..end];
			Assert(slice).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1)]
		[InlineData(new Int32[] { 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 2)]
		public void Slice_Start([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 start) {
			DynamicArray<Int32> array = initial;
			Span<Int32> slice = array.Slice(start);
			Assert(slice).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { 2, 3 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, 2)]
		[InlineData(new Int32[] { 3, 4 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, 2)]
		[InlineData(new Int32[] { 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, 4)]
		public void Slice_Start_Length([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 start, Int32 length) {
			DynamicArray<Int32> array = initial;
			Span<Int32> slice = array.Slice(start, length);
			Assert(slice).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 })]
		public void ToArray([DisallowNull] Int32[] values) {
			DynamicArray<Int32> array = values;
			Assert(array.ToArray()).Equals(values);
		}

		[Theory]
		[InlineData("[]", new Int32[] { }, 0)]
		[InlineData("[1, 2, 3...]", new Int32[] { 1, 2, 3, 4, 5 }, 3)]
		[InlineData("[1, 2, 3, 4, 5]", new Int32[] { 1, 2, 3, 4, 5 }, 5)]
		public void ToString([DisallowNull] String expected, [DisallowNull] Int32[] values, Int32 amount) {
			DynamicArray<Int32> array = values;
			Assert(array.ToString(amount)).Equals(expected);
		}
	}
}
