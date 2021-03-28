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

		public static System.Collections.Generic.IEnumerable<object[]> Contains_Data(Int32 element, Boolean expected) {
			yield return new object[] { new Array<Int32>(1, 2, 3, 4, 5), element, expected };
			yield return new object[] { new BoundedArray<Int32>(8) { 1, 2, 3, 4, 5 }, element, expected };
			yield return new object[] { new DynamicArray<Int32>() { 1, 2, 3, 4, 5 }, element, expected };
			yield return new object[] { new BipartiteBuffer<Int32>() { 1, 2, 3, 4, 5 }, element, expected };
			yield return new object[] { new Chain<Int32>() { 1, 2, 3, 4, 5 }, element, expected };
			yield return new object[] { new Counter<Int32>() { 1, 2, 3, 4, 5 }, element, expected };
			yield return new object[] { new Stack<Int32>() { 1, 2, 3, 4, 5 }, element, expected };
		}

		[Theory]
		[MemberData(nameof(Contains_Data), 0, false)]
		[MemberData(nameof(Contains_Data), 1, true)]
		[MemberData(nameof(Contains_Data), 5, true)]
		[MemberData(nameof(Contains_Data), 6, false)]
		public void Contains<TElement, TCollection>(TCollection collection, TElement element, Boolean expected) where TCollection : IContains<TElement> => Assert.Equal(expected, TraitExtensions.Contains(collection, element));

		public static System.Collections.Generic.IEnumerable<object[]> ContainsAny_Data(Int32[] elements, Boolean expected) {
			yield return new object[] { new Array<Int32>(1, 2, 3, 4, 5), elements, expected };
			yield return new object[] { new BoundedArray<Int32>(8) { 1, 2, 3, 4, 5 }, elements, expected };
			yield return new object[] { new DynamicArray<Int32>() { 1, 2, 3, 4, 5 }, elements, expected };
			yield return new object[] { new BipartiteBuffer<Int32>() { 1, 2, 3, 4, 5 }, elements, expected };
			yield return new object[] { new Chain<Int32>() { 1, 2, 3, 4, 5 }, elements, expected };
			yield return new object[] { new Counter<Int32>() { 1, 2, 3, 4, 5 }, elements, expected };
			yield return new object[] { new Stack<Int32>() { 1, 2, 3, 4, 5 }, elements, expected };
		}

		[Theory]
		[MemberData(nameof(ContainsAny_Data), new Int32[] { 3, 4, 5 }, true)]
		[MemberData(nameof(ContainsAny_Data), new Int32[] { 4, 5, 6 }, true)]
		[MemberData(nameof(ContainsAny_Data), new Int32[] { 5, 6, 7 }, true)]
		[MemberData(nameof(ContainsAny_Data), new Int32[] { 6, 7, 8 }, false)]
		public void ContainsAny<TElement, TCollection>(TCollection collection, TElement[] elements, Boolean expected) where TCollection : IContains<TElement> => Assert.Equal(expected, TraitExtensions.ContainsAny(collection, elements));

		public static System.Collections.Generic.IEnumerable<object[]> ContainsAll_Data(Int32[] elements, Boolean expected) {
			yield return new object[] { new Array<Int32>(1, 2, 3, 4, 5), elements, expected };
			yield return new object[] { new BoundedArray<Int32>(8) { 1, 2, 3, 4, 5 }, elements, expected };
			yield return new object[] { new DynamicArray<Int32>() { 1, 2, 3, 4, 5 }, elements, expected };
			yield return new object[] { new BipartiteBuffer<Int32>() { 1, 2, 3, 4, 5 }, elements, expected };
			yield return new object[] { new Chain<Int32>() { 1, 2, 3, 4, 5 }, elements, expected };
			yield return new object[] { new Counter<Int32>() { 1, 2, 3, 4, 5 }, elements, expected };
			yield return new object[] { new Stack<Int32>() { 1, 2, 3, 4, 5 }, elements, expected };
		}

		[Theory]
		[MemberData(nameof(ContainsAll_Data), new Int32[] { 1, 3, 5 }, true)]
		[MemberData(nameof(ContainsAll_Data), new Int32[] { 2, 4 }, true)]
		[MemberData(nameof(ContainsAll_Data), new Int32[] { 1, 4, 7 }, false)]
		public void ContainsAll<TElement, TCollection>(TCollection collection, TElement[] elements, Boolean expected) where TCollection : IContains<TElement> => Assert.Equal(expected, TraitExtensions.ContainsAll(collection, elements));

		public static System.Collections.Generic.IEnumerable<object[]> Insert_Element_Data(Int32 index, Int32 element, Int32[] expected) {
			yield return new object[] { new Array<Int32>(1, 2, 3, 4, 5), index, element, expected };
			yield return new object[] { new BoundedArray<Int32>(8) { 1, 2, 3, 4, 5 }, index, element, expected };
			yield return new object[] { new DynamicArray<Int32>() { 1, 2, 3, 4, 5 }, index, element, expected };
			yield return new object[] { new Chain<Int32>() { 1, 2, 3, 4, 5 }, index, element, expected };
		}

		[Theory]
		[MemberData(nameof(Insert_Element_Data), 0, 0, new Int32[] { 0, 1, 2, 3, 4, 5 })]
		[MemberData(nameof(Insert_Element_Data), 1, 0, new Int32[] { 1, 0, 2, 3, 4, 5 })]
		[MemberData(nameof(Insert_Element_Data), 2, 0, new Int32[] { 1, 2, 0, 3, 4, 5 })]
		[MemberData(nameof(Insert_Element_Data), 3, 0, new Int32[] { 1, 2, 3, 0, 4, 5 })]
		[MemberData(nameof(Insert_Element_Data), 4, 0, new Int32[] { 1, 2, 3, 4, 0, 5 })]
		[MemberData(nameof(Insert_Element_Data), 5, 0, new Int32[] { 1, 2, 3, 4, 5, 0 })]
		public void Insert_Element<TElement, TCollection>(TCollection collection, Int32 index, TElement element, TElement[] expected) where TCollection : IInsert<TElement, TCollection>, System.Collections.Generic.IEnumerable<TElement> {
			collection = TraitExtensions.Insert(collection, index, element);
			Assert.Equal(expected, collection);
		}

		public static System.Collections.Generic.IEnumerable<object[]> Insert_Array_Data(Int32 index, Int32[] elements, Int32[] expected) {
			yield return new object[] { new Array<Int32>(1, 2, 3, 4, 5), index, elements, expected };
			yield return new object[] { new BoundedArray<Int32>(8) { 1, 2, 3, 4, 5 }, index, elements, expected };
			yield return new object[] { new DynamicArray<Int32>() { 1, 2, 3, 4, 5 }, index, elements, expected };
			yield return new object[] { new Chain<Int32>() { 1, 2, 3, 4, 5 }, index, elements, expected };
		}

		[Theory]
		[MemberData(nameof(Insert_Array_Data), 0, new Int32[] { 0, 0 }, new Int32[] { 0, 0, 1, 2, 3, 4, 5 })]
		[MemberData(nameof(Insert_Array_Data), 1, new Int32[] { 0, 0 }, new Int32[] { 1, 0, 0, 2, 3, 4, 5 })]
		[MemberData(nameof(Insert_Array_Data), 2, new Int32[] { 0, 0 }, new Int32[] { 1, 2, 0, 0, 3, 4, 5 })]
		[MemberData(nameof(Insert_Array_Data), 3, new Int32[] { 0, 0 }, new Int32[] { 1, 2, 3, 0, 0, 4, 5 })]
		[MemberData(nameof(Insert_Array_Data), 4, new Int32[] { 0, 0 }, new Int32[] { 1, 2, 3, 4, 0, 0, 5 })]
		[MemberData(nameof(Insert_Array_Data), 5, new Int32[] { 0, 0 }, new Int32[] { 1, 2, 3, 4, 5, 0, 0 })]
		public void Insert_Array<TElement, TCollection>(TCollection collection, Int32 index, TElement[] elements, TElement[] expected) where TCollection : IInsert<TElement, TCollection>, System.Collections.Generic.IEnumerable<TElement> {
			collection = TraitExtensions.Insert(collection, index, elements);
			Assert.Equal(expected, collection);
		}

		public static System.Collections.Generic.IEnumerable<object[]> Replace_Element_Data(Int32 search, Int32 replace, Int32[] expected) {
			yield return new object[] { new Array<Int32>(1, 2, 1, 2, 1), search, replace, expected };
			yield return new object[] { new BoundedArray<Int32>(8) { 1, 2, 1, 2, 1 }, search, replace, expected };
			yield return new object[] { new DynamicArray<Int32>() { 1, 2, 1, 2, 1 }, search, replace, expected };
			yield return new object[] { new Chain<Int32>() { 1, 2, 1, 2, 1 }, search, replace, expected };
		}

		[Theory]
		[MemberData(nameof(Replace_Element_Data), 0, 0, new Int32[] { 1, 2, 1, 2, 1 })]
		[MemberData(nameof(Replace_Element_Data), 1, 0, new Int32[] { 0, 2, 0, 2, 0 })]
		[MemberData(nameof(Replace_Element_Data), 2, 0, new Int32[] { 1, 0, 1, 0, 1 })]
		public void Replace_Element<TElement, TCollection>(TCollection collection, TElement search, TElement replace, TElement[] expected) where TCollection : IReplace<TElement, TCollection>, System.Collections.Generic.IEnumerable<TElement> {
			collection = collection.Replace(search, replace);
			Assert.Equal(expected, collection);
		}
	}
}
