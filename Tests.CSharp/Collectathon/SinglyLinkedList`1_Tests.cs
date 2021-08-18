using System;
using System.Diagnostics.CodeAnalysis;
using Collectathon;
using Defender;
using Defender.Contracts;
using Xunit;

namespace Collectathon {
	public class SinglyLinkedList1_Tests : Tests, IAddContract, IClearContract, IPostpendContract, IReplaceContract {
		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(AddContractData.Add_Elements), MemberType = typeof(AddContractData))]
		public void Add_Array<TElement>(TElement[] initial, TElement[] elements, TElement[] expected) {
			SinglyLinkedList<TElement> list = new(initial);
			list.Add(elements);
			Assert.That(list).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(AddContractData.Add_Element), MemberType = typeof(AddContractData))]
		public void Add_Element<TElement>(TElement[] initial, TElement element, TElement[] expected) {
			SinglyLinkedList<TElement> list = new(initial);
			list.Add(element);
			Assert.That(list).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(AddContractData.Add_Elements), MemberType = typeof(AddContractData))]
		public void Add_Memory<TElement>(TElement[] initial, TElement[] elements, TElement[] expected) {
			SinglyLinkedList<TElement> list = new(initial);
			list.Add(elements.AsMemory());
			Assert.That(list).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(AddContractData.Add_Elements), MemberType = typeof(AddContractData))]
		public void Add_ReadOnlyMemory<TElement>(TElement[] initial, TElement[] elements, TElement[] expected) {
			SinglyLinkedList<TElement> list = new(initial);
			list.Add((ReadOnlyMemory<TElement>)elements.AsMemory());
			Assert.That(list).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(AddContractData.Add_Elements), MemberType = typeof(AddContractData))]
		public void Add_ReadOnlySpan<TElement>(TElement[] initial, TElement[] elements, TElement[] expected) {
			SinglyLinkedList<TElement> list = new(initial);
			list.Add((ReadOnlySpan<TElement>)elements.AsSpan());
			Assert.That(list).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(AddContractData.Add_Elements), MemberType = typeof(AddContractData))]
		public void Add_Segment<TElement>(TElement[] initial, TElement[] elements, TElement[] expected) {
			SinglyLinkedList<TElement> list = new(initial);
			list.Add(new ArraySegment<TElement>(elements));
			Assert.That(list).Equals(expected);

		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(AddContractData.Add_Elements), MemberType = typeof(AddContractData))]
		public void Add_Span<TElement>(TElement[] initial, TElement[] elements, TElement[] expected) {
			SinglyLinkedList<TElement> list = new(initial);
			list.Add(elements.AsSpan());
			Assert.That(list).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(ClearContractData.Clear), MemberType = typeof(ClearContractData))]
		public void Clear<TElement>(TElement[] initial) {
			SinglyLinkedList<TElement> list = new(initial);
			list.Clear();
			Assert.That(list).Count(0);
		}

		[Theory]
		[InlineData(new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 })]
		public void Equals([DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> val = elements is not null ? new SinglyLinkedList<Int32>(elements) : null;
			Assert.That(val).Equals(elements);
			SinglyLinkedList<Int32> exp = elements is not null ? new SinglyLinkedList<Int32>(elements) : null;
			Assert.That(val).Equals(exp);
			SinglyLinkedList<Int32> dval = elements is not null ? new SinglyLinkedList<Int32>(elements) : null;
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
			SinglyLinkedList<Int32> list = new(initial);
			list.Insert(index, elements);
			Assert.That(list).Equals(expected);
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
			SinglyLinkedList<Int32> list = new(initial);
			list.Insert(index, element);
			Assert.That(list).Equals(expected);
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
			SinglyLinkedList<Int32> list = new(initial);
			list.Insert(index, values.AsMemory());
			Assert.That(list).Equals(expected);
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
			SinglyLinkedList<Int32> list = new(initial);
			fixed (Int32* elmts = elements) {
				list.Insert(index, elmts, elements.Length);
			}
			Assert.That(list).Equals(expected);
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
			SinglyLinkedList<Int32> list = new(initial);
			list.Insert(index, (ReadOnlyMemory<Int32>)elements.AsMemory());
			Assert.That(list).Equals(expected);
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
			SinglyLinkedList<Int32> list = new(initial);
			list.Insert(index, (ReadOnlySpan<Int32>)elements.AsSpan());
			Assert.That(list).Equals(expected);
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
			SinglyLinkedList<Int32> list = new(initial);
			list.Insert(index, elements.AsSpan());
			Assert.That(list).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(PostpendContractData.Postpend_Elements), MemberType = typeof(PostpendContractData))]
		public void Postpend_Array<TElement>(TElement[] initial, TElement[] elements, TElement[] expected) {
			SinglyLinkedList<TElement> list = new(initial);
			list.Postpend(elements);
			Assert.That(list).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(PostpendContractData.Postpend_Element), MemberType = typeof(PostpendContractData))]
		public void Postpend_Element<TElement>(TElement[] initial, TElement element, TElement[] expected) {
			SinglyLinkedList<TElement> list = new(initial);
			list.Postpend(element);
			Assert.That(list).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(PostpendContractData.Postpend_Elements), MemberType = typeof(PostpendContractData))]
		public void Postpend_Memory<TElement>(TElement[] initial, TElement[] elements, TElement[] expected) {
			SinglyLinkedList<TElement> list = new(initial);
			list.Postpend(elements.AsMemory());
			Assert.That(list).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(PostpendContractData.Postpend_Elements), MemberType = typeof(PostpendContractData))]
		public void Postpend_ReadOnlyMemory<TElement>(TElement[] initial, TElement[] elements, TElement[] expected) {
			SinglyLinkedList<TElement> list = new(initial);
			list.Postpend((ReadOnlyMemory<TElement>)elements.AsMemory());
			Assert.That(list).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(PostpendContractData.Postpend_Elements), MemberType = typeof(PostpendContractData))]
		public void Postpend_ReadOnlySpan<TElement>(TElement[] initial, TElement[] elements, TElement[] expected) {
			SinglyLinkedList<TElement> list = new(initial);
			list.Postpend((ReadOnlySpan<TElement>)elements.AsSpan());
			Assert.That(list).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(PostpendContractData.Postpend_Elements), MemberType = typeof(PostpendContractData))]
		public void Postpend_Segment<TElement>(TElement[] initial, TElement[] elements, TElement[] expected) {
			SinglyLinkedList<TElement> list = new(initial);
			list.Postpend(elements.AsSpan());
			Assert.That(list).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(PostpendContractData.Postpend_Elements), MemberType = typeof(PostpendContractData))]
		public void Postpend_Span<TElement>(TElement[] initial, TElement[] elements, TElement[] expected) {
			SinglyLinkedList<TElement> list = new(initial);
			list.Postpend(elements.AsSpan());
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Prepend_Array([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			list.Prepend(elements);
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { 0 }, new Int32[] { }, 0)]
		public void Prepend_Element([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 element) {
			SinglyLinkedList<Int32> list = new(initial);
			list.Prepend(element);
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Prepend_Memory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			list.Prepend(elements.AsMemory());
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public unsafe void Prepend_Pointer([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			fixed (Int32* elmts = elements) {
				list.Prepend(elmts, elements.Length);
			}
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Prepend_ReadOnlyMemory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			list.Prepend((ReadOnlyMemory<Int32>)elements.AsMemory());
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Prepend_ReadOnlySpan([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			list.Prepend((ReadOnlySpan<Int32>)elements.AsSpan());
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Prepend_Span([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			list.Prepend(elements.AsSpan());
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 5, 4, 3, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Push_Array([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			list.Push(elements);
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { 0 }, new Int32[] { }, 0)]
		[InlineData(new Int32[] { 2, 1 }, new Int32[] { 1 }, 2)]
		public void Push_Element([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32 value) {
			SinglyLinkedList<Int32> list = new(initial);
			list.Push(value);
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 5, 4, 3, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Push_Memory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			list.Push(elements.AsMemory());
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 5, 4, 3, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Push_ReadOnlyMemory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			list.Push((ReadOnlyMemory<Int32>)elements.AsMemory());
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 5, 4, 3, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public unsafe void Push_Pointer([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			fixed (Int32* elmts = elements) {
				list.Push(elmts, elements.Length);
			}
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 5, 4, 3, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Push_Span([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			list.Push(elements.AsSpan());
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 5, 4, 3, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Push_ReadOnlySpan([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			list.Push((ReadOnlySpan<Int32>)elements.AsSpan());
			Assert.That(list).Equals(expected);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(ReplaceContractData.Replace_Simple), MemberType = typeof(ReplaceContractData))]
		public void Replace_Simple<TElement>(TElement[] initial, TElement search, TElement replace, TElement[] expected) {
			SinglyLinkedList<TElement> array = new(initial);
			array.Replace(search, replace);
			Assert.That(array).Equals(expected);
		}

		/// <inheritdoc/>
		public void Replace_Complex<TElement, TSearch, TReplace>(TElement[] initial, TSearch search, TReplace replace, TElement[] expected) => throw new NotImplementedException();

		[Theory]
		[InlineData(new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 })]
		public void ToArray([DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(elements);
			Assert.That(list.ToArray()).Equals(elements);
		}

		[Theory]
		[InlineData("[]", new Int32[] { }, 0)]
		[InlineData("[1, 2, 3...]", new Int32[] { 1, 2, 3, 4, 5 }, 3)]
		[InlineData("[1, 2, 3, 4, 5]", new Int32[] { 1, 2, 3, 4, 5 }, 5)]
		public void ToString([DisallowNull] String expected, [DisallowNull] Int32[] elements, Int32 amount) {
			SinglyLinkedList<Int32> list = new(elements);
			Assert.That(list.ToString(amount)).Equals(expected);
		}
	}
}
