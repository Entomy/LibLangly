using System;
using Xunit;
using Langly.DataStructures;
using Langly.DataStructures.Arrays;
using Langly.DataStructures.Buffers;
using Langly.DataStructures.Lists;

namespace Langly {
	public class Trait_Tests {
		public static System.Collections.Generic.IEnumerable<object[]> Add_Element_Data(Int32[] expected) {
			yield return new object[] { new Array<Int32>(), expected };
			yield return new object[] { new BoundedArray<Int32>(8), expected };
			yield return new object[] { new DynamicArray<Int32>(), expected };
			yield return new object[] { new BipartiteBuffer<Int32>(), expected };
			yield return new object[] { new Chain<Int32>(), expected };
			yield return new object[] { new Counter<Int32>(), expected };
			yield return new object[] { new Stack<Int32>(), expected };
		}

		[Theory]
		[MemberData(nameof(Add_Element_Data), new Int32[] { })]
		[MemberData(nameof(Add_Element_Data), new Int32[] { 1 })]
		[MemberData(nameof(Add_Element_Data), new Int32[] { 1, 2, 3, 4, 5 })]
		public void Add_Element<TElement, TCollection>(TCollection collection, TElement[] expected) where TCollection : IAdd<TElement, TCollection>, System.Collections.Generic.IEnumerable<TElement> {
			foreach (TElement item in expected) {
				collection = TraitExtensions.Add(collection, item);
			}
			foreach (TElement item in expected) {
				Assert.Contains(item, collection);
			}
		}

		public static System.Collections.Generic.IEnumerable<object[]> Add_Array_Data(Int32[] expected, Int32[] slicePoints) {
			yield return new object[] { new Array<Int32>(), expected, slicePoints };
			yield return new object[] { new BoundedArray<Int32>(8), expected, slicePoints };
			yield return new object[] { new DynamicArray<Int32>(), expected, slicePoints };
			yield return new object[] { new BipartiteBuffer<Int32>(), expected, slicePoints };
			yield return new object[] { new Chain<Int32>(), expected, slicePoints };
			yield return new object[] { new Counter<Int32>(), expected, slicePoints };
			yield return new object[] { new Stack<Int32>(), expected, slicePoints };
		}

		[Theory]
		[MemberData(nameof(Add_Array_Data), new Int32[] { }, new Int32[] { })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Add_Array<TElement, TCollection>(TCollection collection, TElement[] expected, Int32[] slicePoints) where TCollection : IAdd<TElement, TCollection>, System.Collections.Generic.IEnumerable<TElement> {
			Int32 i = 0;
			foreach (Int32 sp in slicePoints) {
				collection = TraitExtensions.Add(collection, expected[i..sp]);
				i = sp;
			}
			foreach (TElement item in expected) {
				Assert.Contains(item, collection);
			}
		}

		[Theory]
		[MemberData(nameof(Add_Array_Data), new Int32[] { }, new Int32[] { })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Add_Memory<TElement, TCollection>(TCollection collection, TElement[] expected, Int32[] slicePoints) where TCollection : IAdd<TElement, TCollection>, System.Collections.Generic.IEnumerable<TElement> {
			Int32 i = 0;
			foreach (Int32 sp in slicePoints) {
				collection = TraitExtensions.Add(collection, expected.AsMemory()[i..sp]);
				i = sp;
			}
			foreach (TElement item in expected) {
				Assert.Contains(item, collection);
			}
		}

		[Theory]
		[MemberData(nameof(Add_Array_Data), new Int32[] { }, new Int32[] { })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Add_ReadOnlyMemory<TElement, TCollection>(TCollection collection, TElement[] expected, Int32[] slicePoints) where TCollection : IAdd<TElement, TCollection>, System.Collections.Generic.IEnumerable<TElement> {
			Int32 i = 0;
			foreach (Int32 sp in slicePoints) {
				collection = TraitExtensions.Add(collection, (ReadOnlyMemory<TElement>)expected.AsMemory()[i..sp]);
				i = sp;
			}
			foreach (TElement item in expected) {
				Assert.Contains(item, collection);
			}
		}

		[Theory]
		[MemberData(nameof(Add_Array_Data), new Int32[] { }, new Int32[] { })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Add_Span<TElement, TCollection>(TCollection collection, TElement[] expected, Int32[] slicePoints) where TCollection : IAdd<TElement, TCollection>, System.Collections.Generic.IEnumerable<TElement> {
			Int32 i = 0;
			foreach (Int32 sp in slicePoints) {
				collection = TraitExtensions.Add(collection, expected.AsSpan()[i..sp]);
				i = sp;
			}
			foreach (TElement item in expected) {
				Assert.Contains(item, collection);
			}
		}

		[Theory]
		[MemberData(nameof(Add_Array_Data), new Int32[] { }, new Int32[] { })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Add_ReadOnlySpan<TElement, TCollection>(TCollection collection, TElement[] expected, Int32[] slicePoints) where TCollection : IAdd<TElement, TCollection>, System.Collections.Generic.IEnumerable<TElement> {
			Int32 i = 0;
			foreach (Int32 sp in slicePoints) {
				collection = TraitExtensions.Add(collection, (ReadOnlySpan<TElement>)expected.AsSpan()[i..sp]);
				i = sp;
			}
			foreach (TElement item in expected) {
				Assert.Contains(item, collection);
			}
		}

		[Theory]
		[MemberData(nameof(Add_Array_Data), new Int32[] { }, new Int32[] { })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 })]
		[MemberData(nameof(Add_Array_Data), new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Add_Sequence<TElement, TCollection>(TCollection collection, TElement[] expected, Int32[] slicePoints) where TCollection : IAdd<TElement, TCollection>, System.Collections.Generic.IEnumerable<TElement> {
			Array<TElement> expct = expected;
			Int32 i = 0;
			foreach (Int32 sp in slicePoints) {
				collection = TraitExtensions.Add(collection, expct[i..sp]);
				i = sp;
			}
			foreach (TElement item in expected) {
				Assert.Contains(item, collection);
			}
		}
	}
}
