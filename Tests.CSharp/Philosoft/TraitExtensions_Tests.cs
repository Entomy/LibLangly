using System;
using System.Diagnostics.CodeAnalysis;
using Collectathon;
using Defender;
using Xunit;

namespace Philosoft {
	public class TraitExtensions_Tests : Tests {
		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, new Int32[] { 0, 0 })]
		public void Add_Array([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] values) {
			SinglyLinkedList<Int32> list = new(initial);
			System.TraitExtensions.Add(list, values);
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, new Int32[] { 0, 0 })]
		public void Add_Memory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] values) {
			SinglyLinkedList<Int32> list = new(initial);
			System.TraitExtensions.Add(list, values.AsMemory());
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, new Int32[] { 0, 0 })]
		public unsafe void Add_Pointer([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] values) {
			SinglyLinkedList<Int32> list = new(initial);
			fixed (Int32* vals = values) {
				System.TraitExtensions.Add(list, vals, values.Length);
			}
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, new Int32[] { 0, 0 })]
		public void Add_ReadOnlyMemory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] values) {
			SinglyLinkedList<Int32> list = new(initial);
			System.TraitExtensions.Add(list, (ReadOnlyMemory<Int32>)values.AsMemory());
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, new Int32[] { 0, 0 })]
		public void Add_ReadOnlySpan([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] values) {
			SinglyLinkedList<Int32> list = new(initial);
			System.TraitExtensions.Add(list, (ReadOnlySpan<Int32>)values.AsSpan());
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, new Int32[] { 0, 0 })]
		public void Add_Span([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] values) {
			SinglyLinkedList<Int32> list = new(initial);
			System.TraitExtensions.Add(list, values.AsSpan());
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(0, new Int32[] { })]
		[InlineData(15, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Fold(Int32 expected, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(elements);
			Int32 actual = System.TraitExtensions.Fold(list, (a, b) => a + b, 0);
			Assert.That(actual).Equals(expected);
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
			System.TraitExtensions.Insert(list, index, elements);
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
			System.TraitExtensions.Insert(list, index, values.AsMemory());
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
				System.TraitExtensions.Insert(list, index, elmts, elements.Length);
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
			System.TraitExtensions.Insert(list, index, (ReadOnlyMemory<Int32>)elements.AsMemory());
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
			System.TraitExtensions.Insert(list, index, (ReadOnlySpan<Int32>)elements.AsSpan());
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
			System.TraitExtensions.Insert(list, index, elements.AsSpan());
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(0, new Int32[] { 1, 2, 3, 4, 5 }, 0)]
		[InlineData(3, new Int32[] { 1, 2, 1, 2, 1 }, 1)]
		[InlineData(2, new Int32[] { 1, 2, 1, 2, 1 }, 2)]
		public void Occurrences_Element(Int32 expected, [DisallowNull] Int32[] elements, Int32 element) {
			SinglyLinkedList<Int32> list = new(elements);
			Assert.That(System.TraitExtensions.Occurrences(list, element)).Equals(expected);
		}

		[Theory]
		[InlineData(0, new Int32[] { })]
		[InlineData(0, new Int32[] { 1 })]
		[InlineData(0, new Int32[] { 1, 1, 1, 1, 1 })]
		[InlineData(2, new Int32[] { 1, 2, 1, 2, 1 })]
		[InlineData(3, new Int32[] { 2, 1, 2, 1, 2 })]
		public void Occurrences_Predicate(Int32 expected, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(elements);
			Assert.That(System.TraitExtensions.Occurrences(list, (x) => x % 2 == 0)).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Postpend_Array([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			System.TraitExtensions.Postpend(list, elements);
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Postpend_Memory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			System.TraitExtensions.Postpend(list, elements.AsMemory());
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public unsafe void Postpend_Pointer([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			fixed (Int32* elmts = elements) {
				System.TraitExtensions.Postpend(list, elmts, elements.Length);
			}
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Postpend_ReadOnlyMemory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			System.TraitExtensions.Postpend(list, (ReadOnlyMemory<Int32>)elements.AsMemory());
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Postpend_ReadOnlySpan([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			System.TraitExtensions.Postpend(list, (ReadOnlySpan<Int32>)elements.AsSpan());
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Postpend_Span([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			System.TraitExtensions.Postpend(list, elements.AsSpan());
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Prepend_Array([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			System.TraitExtensions.Prepend(list, elements);
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Prepend_Memory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			System.TraitExtensions.Prepend(list, elements.AsMemory());
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public unsafe void Prepend_Pointer([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			fixed (Int32* elmts = elements) {
				System.TraitExtensions.Prepend(list, elmts, elements.Length);
			}
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Prepend_ReadOnlyMemory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			System.TraitExtensions.Prepend(list, (ReadOnlyMemory<Int32>)elements.AsMemory());
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Prepend_ReadOnlySpan([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			System.TraitExtensions.Prepend(list, (ReadOnlySpan<Int32>)elements.AsSpan());
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Prepend_Span([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			System.TraitExtensions.Prepend(list, elements.AsSpan());
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 5, 4, 3, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Push_Array([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			System.TraitExtensions.Push(list, elements);
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 5, 4, 3, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Push_Memory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			System.TraitExtensions.Push(list, elements.AsMemory());
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 5, 4, 3, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Push_ReadOnlyMemory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			System.TraitExtensions.Push(list, (ReadOnlyMemory<Int32>)elements.AsMemory());
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 5, 4, 3, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public unsafe void Push_Pointer([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			fixed (Int32* elmts = elements) {
				System.TraitExtensions.Push(list, elmts, elements.Length);
			}
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 5, 4, 3, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Push_Span([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			System.TraitExtensions.Push(list, elements.AsSpan());
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 5, 4, 3, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Push_ReadOnlySpan([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(initial);
			System.TraitExtensions.Push(list, (ReadOnlySpan<Int32>)elements.AsSpan());
			Assert.That(list).Equals(expected);
		}

		[Theory]
		[InlineData(new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 })]
		public void ToArray([DisallowNull] Int32[] elements) {
			SinglyLinkedList<Int32> list = new(elements);
			Assert.That(System.TraitExtensions.ToArray(list)).Equals(elements);
		}
	}
}
