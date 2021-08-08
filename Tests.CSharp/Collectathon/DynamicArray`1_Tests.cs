using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits.Testing;
using System.Traits.Testing.Contracts;
using Collectathon.Arrays;
using Xunit;

namespace Collectathon {
	public class DynamicArray1_Tests : Tests, IAddContract, IClearContract, IPostpendContract, IReplaceContract {
		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(AddContractData.Add_Elements), MemberType = typeof(AddContractData))]
		public void Add_Array<TElement>(TElement[] initial, TElement[] elements, TElement[] expected) {
			DynamicArray<TElement> array = new(initial);
			array.Add(elements);
			Assert.That(array).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(AddContractData.Add_Element), MemberType = typeof(AddContractData))]
		public void Add_Element<TElement>(TElement[] initial, TElement element, TElement[] expected) {
			DynamicArray<TElement> array = new(initial);
			array.Add(element);
			Assert.That(array).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(AddContractData.Add_Elements), MemberType = typeof(AddContractData))]
		public void Add_Memory<TElement>(TElement[] initial, TElement[] elements, TElement[] expected) {
			DynamicArray<TElement> array = new(initial);
			array.Add(elements.AsMemory());
			Assert.That(array).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(AddContractData.Add_Elements), MemberType = typeof(AddContractData))]
		public void Add_ReadOnlyMemory<TElement>(TElement[] initial, TElement[] elements, TElement[] expected) {
			DynamicArray<TElement> array = new(initial);
			array.Add((ReadOnlyMemory<TElement>)elements.AsMemory());
			Assert.That(array).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(AddContractData.Add_Elements), MemberType = typeof(AddContractData))]
		public void Add_ReadOnlySpan<TElement>(TElement[] initial, TElement[] elements, TElement[] expected) {
			DynamicArray<TElement> array = new(initial);
			array.Add((ReadOnlySpan<TElement>)elements.AsSpan());
			Assert.That(array).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(AddContractData.Add_Elements), MemberType = typeof(AddContractData))]
		public void Add_Segment<TElement>(TElement[] initial, TElement[] elements, TElement[] expected) {
			DynamicArray<TElement> array = new(initial);
			array.Add(new ArraySegment<TElement>(elements));
			Assert.That(array).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(AddContractData.Add_Elements), MemberType = typeof(AddContractData))]
		public void Add_Span<TElement>(TElement[] initial, TElement[] elements, TElement[] expected) {
			DynamicArray<TElement> array = new(initial);
			array.Add(elements.AsSpan());
			Assert.That(array).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(ClearContractData.Clear), MemberType = typeof(ClearContractData))]
		public void Clear<TElement>(TElement[] initial) {
			DynamicArray<TElement> array = new(initial);
			array.Clear();
			Assert.That(array).Count(0);
		}

		[Theory]
		[InlineData(new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 })]

		public void Equals([DisallowNull] Int32[] elements) {
			DynamicArray<Int32> val = elements is not null ? new DynamicArray<Int32>(elements) : null;
			Assert.That(val).Equals(elements);
			DynamicArray<Int32> exp = elements is not null ? new DynamicArray<Int32>(elements) : null;
			Assert.That(val).Equals(exp);
			DynamicArray<Int32> dval = elements is not null ? new DynamicArray<Int32>(elements) : null;
			Assert.That(val).Equals(dval);
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
			DynamicArray<Int32> array = new(initial);
			array.Insert(index, elements);
			Assert.That(array).Equals(expected);
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
			DynamicArray<Int32> array = new(initial);
			array.Insert(index, element);
			Assert.That(array).Equals(expected);
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
			DynamicArray<Int32> array = new(initial);
			array.Insert(index, values.AsMemory());
			Assert.That(array).Equals(expected);
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
			DynamicArray<Int32> array = new(initial);
			fixed (Int32* elmts = elements) {
				array.Insert(index, elmts, elements.Length);
			}
			Assert.That(array).Equals(expected);
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
			DynamicArray<Int32> array = new(initial);
			array.Insert(index, (ReadOnlyMemory<Int32>)elements.AsMemory());
			Assert.That(array).Equals(expected);
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
			DynamicArray<Int32> array = new(initial);
			array.Insert(index, (ReadOnlySpan<Int32>)elements.AsSpan());
			Assert.That(array).Equals(expected);
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
			DynamicArray<Int32> array = new(initial);
			array.Insert(index, elements.AsSpan());
			Assert.That(array).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(PostpendContractData.Postpend_Elements), MemberType = typeof(PostpendContractData))]
		public void Postpend_Array<TElement>(TElement[] initial, TElement[] elements, TElement[] expected) {
			DynamicArray<TElement> array = new(initial);
			array.Postpend(elements);
			Assert.That(array).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(PostpendContractData.Postpend_Element), MemberType = typeof(PostpendContractData))]
		public void Postpend_Element<TElement>(TElement[] initial, TElement element, TElement[] expected) {
			DynamicArray<TElement> array = new(initial);
			array.Postpend(element);
			Assert.That(array).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(PostpendContractData.Postpend_Elements), MemberType = typeof(PostpendContractData))]
		public void Postpend_Memory<TElement>(TElement[] initial, TElement[] elements, TElement[] expected) {
			DynamicArray<TElement> array = new(initial);
			array.Postpend(elements.AsMemory());
			Assert.That(array).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(PostpendContractData.Postpend_Elements), MemberType = typeof(PostpendContractData))]
		public void Postpend_ReadOnlyMemory<TElement>(TElement[] initial, TElement[] elements, TElement[] expected) {
			DynamicArray<TElement> array = new(initial);
			array.Postpend((ReadOnlyMemory<TElement>)elements.AsMemory());
			Assert.That(array).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(PostpendContractData.Postpend_Elements), MemberType = typeof(PostpendContractData))]
		public void Postpend_ReadOnlySpan<TElement>(TElement[] initial, TElement[] elements, TElement[] expected) {
			DynamicArray<TElement> array = new(initial);
			array.Postpend((ReadOnlySpan<TElement>)elements.AsSpan());
			Assert.That(array).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(PostpendContractData.Postpend_Elements), MemberType = typeof(PostpendContractData))]
		public void Postpend_Segment<TElement>(TElement[] initial, TElement[] elements, TElement[] expected) {
			DynamicArray<TElement> array = new(initial);
			array.Postpend(new ArraySegment<TElement>(elements));
			Assert.That(array).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(PostpendContractData.Postpend_Elements), MemberType = typeof(PostpendContractData))]
		public void Postpend_Span<TElement>(TElement[] initial, TElement[] elements, TElement[] expected) {
			DynamicArray<TElement> array = new(initial);
			array.Postpend(elements.AsSpan());
			Assert.That(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Prepend_Array([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			DynamicArray<Int32> array = new(initial);
			array.Prepend(elements);
			Assert.That(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { 0 }, new Int32[] { }, 0)]
		public void Prepend_Element([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 element) {
			DynamicArray<Int32> array = new(initial);
			array.Prepend(element);
			Assert.That(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Prepend_Memory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			DynamicArray<Int32> array = new(initial);
			array.Prepend(elements.AsMemory());
			Assert.That(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public unsafe void Prepend_Pointer([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			DynamicArray<Int32> array = new(initial);
			fixed (Int32* elmts = elements) {
				array.Prepend(elmts, elements.Length);
			}
			Assert.That(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Prepend_ReadOnlyMemory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			DynamicArray<Int32> array = new(initial);
			array.Prepend((ReadOnlyMemory<Int32>)elements.AsMemory());
			Assert.That(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Prepend_ReadOnlySpan([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			DynamicArray<Int32> array = new(initial);
			array.Prepend((ReadOnlySpan<Int32>)elements.AsSpan());
			Assert.That(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Prepend_Span([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			DynamicArray<Int32> array = new(initial);
			array.Prepend(elements.AsSpan());
			Assert.That(array).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(ReplaceContractData.Replace_Simple), MemberType = typeof(ReplaceContractData))]
		public void Replace_Simple<TElement>(TElement[] initial, TElement search, TElement replace, TElement[] expected) {
			DynamicArray<TElement> array = new(initial);
			array.Replace(search, replace);
			Assert.That(array).Equals(expected);
		}

		/// <inheritdoc/>
		public void Replace_Complex<TElement, TSearch, TReplace>(TElement[] initial, TSearch search, TReplace replace, TElement[] expected) => throw new NotImplementedException();

		[Theory]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 5)]
		public void Resize([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 capacity) {
			DynamicArray<Int32> array = new(initial);
			array.Resize(capacity);
			Assert.That(array.Capacity).Equals(capacity);
			Assert.That(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 })]
		public void ShiftLeft([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial) {
			DynamicArray<Int32> array = new(initial);
			array.ShiftLeft();
			Assert.That(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, 1)]
		[InlineData(new Int32[] { 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 1)]
		[InlineData(new Int32[] { 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 2)]
		public void ShiftLeftBy([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 amount) {
			DynamicArray<Int32> array = new(initial);
			array.ShiftLeft(amount);
			Assert.That(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, 1)]
		[InlineData(new Int32[] { 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 1)]
		[InlineData(new Int32[] { 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 2)]
		public void ShiftLeftOp([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 amount) {
			DynamicArray<Int32> array = new(initial);
			Assert.That(array << amount).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 0, 1, 2, 3, 4 }, new Int32[] { 1, 2, 3, 4, 5 })]
		public void ShiftRight([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial) {
			DynamicArray<Int32> array = new(initial);
			array.ShiftRight();
			Assert.That(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, 1)]
		[InlineData(new Int32[] { 0, 1, 2, 3, 4 }, new Int32[] { 1, 2, 3, 4, 5 }, 1)]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3 }, new Int32[] { 1, 2, 3, 4, 5 }, 2)]
		public void ShiftRightBy([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 amount) {
			DynamicArray<Int32> array = new(initial);
			array.ShiftRight(amount);
			Assert.That(array).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, 1)]
		[InlineData(new Int32[] { 0, 1, 2, 3, 4 }, new Int32[] { 1, 2, 3, 4, 5 }, 1)]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3 }, new Int32[] { 1, 2, 3, 4, 5 }, 2)]
		public void ShiftRightOp([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 amount) {
			DynamicArray<Int32> array = new(initial);
			Assert.That(array >> amount).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Slice([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial) {
			DynamicArray<Int32> array = new(initial);
			Span<Int32> slice = array.Slice();
			Assert.That(slice).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, 0, 0)]
		[InlineData(new Int32[] { }, new Int32[] { 1, 2, 3, 4, 5 }, 0, 0)]
		[InlineData(new Int32[] { 2, 3 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, 3)]
		[InlineData(new Int32[] { 3, 4 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, 4)]
		[InlineData(new Int32[] { 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, 5)]
		public void Slice_Range([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 start, Int32 end) {
			DynamicArray<Int32> array = new(initial);
			Span<Int32> slice = array[start..end];
			Assert.That(slice).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1)]
		[InlineData(new Int32[] { 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 2)]
		public void Slice_Start([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 start) {
			DynamicArray<Int32> array = new(initial);
			Span<Int32> slice = array.Slice(start);
			Assert.That(slice).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { 2, 3 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, 2)]
		[InlineData(new Int32[] { 3, 4 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, 2)]
		[InlineData(new Int32[] { 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, 4)]
		public void Slice_Start_Length([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 start, Int32 length) {
			DynamicArray<Int32> array = new(initial);
			Span<Int32> slice = array.Slice(start, length);
			Assert.That(slice).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 })]
		public void ToArray([DisallowNull] Int32[] elements) {
			DynamicArray<Int32> array = new(elements);
			Assert.That(array.ToArray()).Equals(elements);
		}

		[Theory]
		[InlineData("[]", new Int32[] { }, 0)]
		[InlineData("[1, 2, 3...]", new Int32[] { 1, 2, 3, 4, 5 }, 3)]
		[InlineData("[1, 2, 3, 4, 5]", new Int32[] { 1, 2, 3, 4, 5 }, 5)]
		public void ToString([DisallowNull] String expected, [DisallowNull] Int32[] elements, Int32 amount) {
			DynamicArray<Int32> array = new(elements);
			Assert.That(array.ToString(amount)).Equals(expected);
		}
	}
}
