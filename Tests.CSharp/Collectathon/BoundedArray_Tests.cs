using System;
using System.Diagnostics.CodeAnalysis;
using Collectathon.Arrays;
using Xunit;

namespace Collectathon {
	public class BoundedArray_Tests {
		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, new Int32[] { 0, 0 })]
		public void Add_Array([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			BoundedArray<Int32> array = initial;
			if (array.Count + elements.Length <= array.Capacity) {
				array.Add(elements);
				Assert.Equal(expected, array);
			} else {
				Assert.Throws<InvalidOperationException>(() => array.Add(elements));
			}
		}

		[Theory]
		[InlineData(new Int32[] { 0 }, new Int32[] { }, 0)]
		[InlineData(new Int32[] { 1, 2, }, new Int32[] { 1 }, 2)]
		public void Add_Element([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32 value) {
			BoundedArray<Int32> array = initial;
			if (array.Count < array.Capacity) {
				array.Add(value);
				Assert.Equal(expected, array);
			} else {
				Assert.Throws<InvalidOperationException>(() => array.Add(value));
			}
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, new Int32[] { 0, 0 })]
		public void Add_Memory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			BoundedArray<Int32> array = initial;
			if (array.Count + elements.Length <= array.Capacity) {
				array.Add(elements.AsMemory());
				Assert.Equal(expected, array);
			} else {
				Assert.Throws<InvalidOperationException>(() => array.Add(elements));
			}
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, new Int32[] { 0, 0 })]
		public void Add_ReadOnlyMemory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			BoundedArray<Int32> array = initial;
			if (array.Count + elements.Length <= array.Capacity) {
				array.Add((ReadOnlyMemory<Int32>)elements.AsMemory());
				Assert.Equal(expected, array);
			} else {
				Assert.Throws<InvalidOperationException>(() => array.Add((ReadOnlyMemory<Int32>)elements.AsMemory()));
			}
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, new Int32[] { 0, 0 })]
		public void Add_ReadOnlySpan([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			BoundedArray<Int32> array = initial;
			if (array.Count + elements.Length <= array.Capacity) {
				array.Add((ReadOnlySpan<Int32>)elements.AsSpan());
				Assert.Equal(expected, array);
			} else {
				Assert.Throws<InvalidOperationException>(() => array.Add((ReadOnlySpan<Int32>)elements.AsSpan()));
			}
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, new Int32[] { 0, 0 })]
		public void Add_Span([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			BoundedArray<Int32> array = initial;
			if (array.Count + elements.Length <= array.Capacity) {
				array.Add(elements.AsSpan());
				Assert.Equal(expected, array);
			} else {
				Assert.Throws<InvalidOperationException>(() => array.Add(elements.AsSpan()));
			}
		}

		[Theory]
		[InlineData(new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 })]
		public void Clear([DisallowNull] Int32[] initial) {
			BoundedArray<Int32> array = initial;
			array.Clear();
			Assert.Empty(array);
		}

		[Theory]
		[InlineData(new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 })]

		public void Equals([DisallowNull] Int32[] elements) {
			BoundedArray<Int32> val = elements is not null ? new BoundedArray<Int32>(elements) : null;
			Assert.Equal(elements, val);
			Assert.True(val.Equals(elements));
			BoundedArray<Int32> exp = elements is not null ? new BoundedArray<Int32>(elements) : null;
			Assert.Equal(exp, val);
			Assert.Equal<Int32>(exp, val);
			Assert.True(val.Equals(exp));
			BoundedArray<Int32> dval = elements is not null ? new BoundedArray<Int32>(elements) : null;
			BoundedArray<Int32> dexp = elements is not null ? new BoundedArray<Int32>(elements) : null;
			Assert.True(val.Equals(dval));
			Assert.True(dval.Equals(val));
		}

		[Theory]
		[InlineData(0, new Int32[] { })]
		[InlineData(15, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Fold(Int32 expected, [DisallowNull] Int32[] elements) {
			BoundedArray<Int32> array = elements;
			Assert.Equal(expected, array.Fold((a, b) => a + b, 0));
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
			BoundedArray<Int32> array = initial;
			if (array.Count + elements.Length <= array.Capacity) {
				array.Insert(index, elements);
				Assert.Equal(expected, array);
			} else {
				Assert.Throws<InvalidOperationException>(() => array.Insert(index, elements));
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
		public void Insert_Element([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 index, Int32 element) {
			BoundedArray<Int32> array = initial;
			if (array.Count < array.Capacity) {
				array.Insert(index, element);
				Assert.Equal(expected, array);
			} else {
				Assert.Throws<InvalidOperationException>(() => array.Insert(index, element));
			}
		}

		[Theory]
		[InlineData(new Int32[] { 0, 0 }, new Int32[] { }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 0, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 0, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 0, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 3, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 0, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 4, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 5, new Int32[] { 0, 0 })]
		public void Insert_Memory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 index, [DisallowNull] Int32[] elements) {
			BoundedArray<Int32> array = initial;
			if (array.Count + elements.Length <= array.Capacity) {
				array.Insert(index, elements.AsMemory());
				Assert.Equal(expected, array);
			} else {
				Assert.Throws<InvalidOperationException>(() => array.Insert(index, elements.AsMemory()));
			}
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
			BoundedArray<Int32> array = initial;
			if (array.Count + elements.Length <= array.Capacity) {
				array.Insert(index, (ReadOnlyMemory<Int32>)elements.AsMemory());
				Assert.Equal(expected, array);
			} else {
				Assert.Throws<InvalidOperationException>(() => array.Insert(index, (ReadOnlyMemory<Int32>)elements.AsMemory()));
			}
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
			BoundedArray<Int32> array = initial;
			if (array.Count + elements.Length <= array.Capacity) {
				array.Insert(index, (ReadOnlySpan<Int32>)elements.AsSpan());
				Assert.Equal(expected, array);
			} else {
				Assert.Throws<InvalidOperationException>(() => array.Insert(index, (ReadOnlySpan<Int32>)elements.AsSpan()));
			}
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
			BoundedArray<Int32> array = initial;
			if (array.Count + elements.Length <= array.Capacity) {
				array.Insert(index, elements.AsSpan());
				Assert.Equal(expected, array);
			} else {
				Assert.Throws<InvalidOperationException>(() => array.Insert(index, elements.AsSpan()));
			}
		}

		[Theory]
		[InlineData(0, new Int32[] { 1, 2, 3, 4, 5 }, 0)]
		[InlineData(3, new Int32[] { 1, 2, 1, 2, 1 }, 1)]
		[InlineData(2, new Int32[] { 1, 2, 1, 2, 1 }, 2)]
		public void Occurrences_Element(Int32 expected, [DisallowNull] Int32[] elements, Int32 element) {
			BoundedArray<Int32> array = elements;
			Assert.Equal(expected, array.Occurrences(element));
		}

		[Theory]
		[InlineData(0, new Int32[] { })]
		[InlineData(0, new Int32[] { 1 })]
		[InlineData(0, new Int32[] { 1, 1, 1, 1, 1 })]
		[InlineData(2, new Int32[] { 1, 2, 1, 2, 1 })]
		[InlineData(3, new Int32[] { 2, 1, 2, 1, 2 })]
		public void Occurrences_Predicate(Int32 expected, [DisallowNull] Int32[] elements) {
			BoundedArray<Int32> array = elements;
			Assert.Equal(expected, array.Occurrences((x) => x % 2 == 0));
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Postpend_Array([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			BoundedArray<Int32> array = initial;
			if (array.Count + elements.Length <= array.Capacity) {
				array.Postpend(elements);
				Assert.Equal(expected, array);
			} else {
				Assert.Throws<InvalidOperationException>(() => array.Postpend(elements));
			}
		}

		[Theory]
		[InlineData(new Int32[] { 0 }, new Int32[] { }, 0)]
		public void Postpend_Element([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 element) {
			BoundedArray<Int32> array = initial;
			if (array.Count < array.Capacity) {
				array.Postpend(element);
				Assert.Equal(expected, array);
			} else {
				Assert.Throws<InvalidOperationException>(() => array.Postpend(element));
			}
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Postpend_Memory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			BoundedArray<Int32> array = initial;
			if (array.Count + elements.Length <= array.Capacity) {
				array.Postpend(elements.AsMemory());
				Assert.Equal(expected, array);
			} else {
				Assert.Throws<InvalidOperationException>(() => array.Postpend(elements.AsMemory()));
			}
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Postpend_ReadOnlyMemory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			BoundedArray<Int32> array = initial;
			if (array.Count + elements.Length <= array.Capacity) {
				array.Postpend((ReadOnlyMemory<Int32>)elements.AsMemory());
				Assert.Equal(expected, array);
			} else {
				Assert.Throws<InvalidOperationException>(() => array.Postpend((ReadOnlyMemory<Int32>)elements.AsMemory()));
			}
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Postpend_ReadOnlySpan([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			BoundedArray<Int32> array = initial;
			if (array.Count + elements.Length <= array.Capacity) {
				array.Postpend((ReadOnlySpan<Int32>)elements.AsSpan());
				Assert.Equal(expected, array);
			} else {
				Assert.Throws<InvalidOperationException>(() => array.Postpend((ReadOnlySpan<Int32>)elements.AsSpan()));
			}
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Postpend_Span([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			BoundedArray<Int32> array = initial;
			if (array.Count + elements.Length <= array.Capacity) {
				array.Postpend(elements.AsSpan());
				Assert.Equal(expected, array);
			} else {
				Assert.Throws<InvalidOperationException>(() => array.Postpend(elements.AsSpan()));
			}
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Prepend_Array([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			BoundedArray<Int32> array = initial;
			if (array.Count + elements.Length <= array.Capacity) {
				array.Prepend(elements);
				Assert.Equal(expected, array);
			} else {
				Assert.Throws<InvalidOperationException>(() => array.Prepend(elements));
			}
		}

		[Theory]
		[InlineData(new Int32[] { 0 }, new Int32[] { }, 0)]
		public void Prepend_Element([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 element) {
			BoundedArray<Int32> array = initial;
			if (array.Count < array.Capacity) {
				array.Prepend(element);
				Assert.Equal(expected, array);
			} else {
				Assert.Throws<InvalidOperationException>(() => array.Prepend(element));
			}
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Prepend_Memory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			BoundedArray<Int32> array = initial;
			if (array.Count + elements.Length <= array.Capacity) {
				array.Prepend(elements.AsMemory());
				Assert.Equal(expected, array);
			} else {
				Assert.Throws<InvalidOperationException>(() => array.Prepend(elements.AsMemory()));
			}
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Prepend_ReadOnlyMemory([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			BoundedArray<Int32> array = initial;
			if (array.Count + elements.Length <= array.Capacity) {
				array.Prepend((ReadOnlyMemory<Int32>)elements.AsMemory());
				Assert.Equal(expected, array);
			} else {
				Assert.Throws<InvalidOperationException>(() => array.Prepend((ReadOnlyMemory<Int32>)elements.AsMemory()));
			}
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Prepend_ReadOnlySpan([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			BoundedArray<Int32> array = initial;
			if (array.Count + elements.Length <= array.Capacity) {
				array.Prepend((ReadOnlySpan<Int32>)elements.AsSpan());
				Assert.Equal(expected, array);
			} else {
				Assert.Throws<InvalidOperationException>(() => array.Prepend((ReadOnlySpan<Int32>)elements.AsSpan()));
			}
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 3, 4, 5, 1, 2 }, new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 })]
		public void Prepend_Span([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, [DisallowNull] Int32[] elements) {
			BoundedArray<Int32> array = initial;
			if (array.Count + elements.Length <= array.Capacity) {
				array.Prepend(elements.AsSpan());
				Assert.Equal(expected, array);
			} else {
				Assert.Throws<InvalidOperationException>(() => array.Prepend(elements.AsSpan()));
			}
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
			BoundedArray<Int32> array = initial;
			array.Replace(search, replace);
			Assert.Equal(expected, array);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 })]
		public void ShiftLeft([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial) {
			BoundedArray<Int32> array = initial;
			array.ShiftLeft();
			Assert.Equal(expected, array);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, 1)]
		[InlineData(new Int32[] { 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 1)]
		[InlineData(new Int32[] { 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 2)]
		public void ShiftLeftBy([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 amount) {
			BoundedArray<Int32> array = initial;
			array.ShiftLeft(amount);
			Assert.Equal(expected, array);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, 1)]
		[InlineData(new Int32[] { 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 1)]
		[InlineData(new Int32[] { 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 2)]
		public void ShiftLeftOp([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 amount) {
			BoundedArray<Int32> array = initial;
			Assert.Equal(expected, array << amount);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 0, 1, 2, 3, 4 }, new Int32[] { 1, 2, 3, 4, 5 })]
		public void ShiftRight([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial) {
			BoundedArray<Int32> array = initial;
			array.ShiftRight();
			Assert.Equal(expected, array);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, 1)]
		[InlineData(new Int32[] { 0, 1, 2, 3, 4 }, new Int32[] { 1, 2, 3, 4, 5 }, 1)]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3 }, new Int32[] { 1, 2, 3, 4, 5 }, 2)]
		public void ShiftRightBy([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 amount) {
			BoundedArray<Int32> array = initial;
			array.ShiftRight(amount);
			Assert.Equal(expected, array);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, 1)]
		[InlineData(new Int32[] { 0, 1, 2, 3, 4 }, new Int32[] { 1, 2, 3, 4, 5 }, 1)]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3 }, new Int32[] { 1, 2, 3, 4, 5 }, 2)]
		public void ShiftRightOp([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 amount) {
			BoundedArray<Int32> array = initial;
			Assert.Equal(expected, array >> amount);
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Slice([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial) {
			BoundedArray<Int32> array = initial;
			Memory<Int32> slice = array.Slice();
			Assert.Equal(expected, slice.ToArray());
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { }, 0, 0)]
		[InlineData(new Int32[] { }, new Int32[] { 1, 2, 3, 4, 5 }, 0, 0)]
		[InlineData(new Int32[] { 2, 3 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, 3)]
		[InlineData(new Int32[] { 3, 4 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, 4)]
		[InlineData(new Int32[] { 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, 5)]
		public void Slice_Range([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 start, Int32 end) {
			BoundedArray<Int32> array = initial;
			Memory<Int32> slice = array[start..end];
			Assert.Equal(expected, slice.ToArray());
		}

		[Theory]
		[InlineData(new Int32[] { 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1)]
		[InlineData(new Int32[] { 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 2)]
		public void Slice_Start([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 start) {
			BoundedArray<Int32> array = initial;
			Memory<Int32> slice = array.Slice(start);
			Assert.Equal(expected, slice.ToArray());
		}

		[Theory]
		[InlineData(new Int32[] { 2, 3 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, 2)]
		[InlineData(new Int32[] { 3, 4 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, 2)]
		[InlineData(new Int32[] { 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, 4)]
		public void Slice_Start_Length([DisallowNull] Int32[] expected, [DisallowNull] Int32[] initial, Int32 start, Int32 length) {
			BoundedArray<Int32> array = initial;
			Memory<Int32> slice = array.Slice(start, length);
			Assert.Equal(expected, slice.ToArray());
		}

		[Theory]
		[InlineData(new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 })]
		public void ToArray([DisallowNull] Int32[] elements) {
			BoundedArray<Int32> array = elements;
			Assert.Equal(elements, array.ToArray());
		}

		[Theory]
		[InlineData("[]", new Int32[] { }, 0)]
		[InlineData("[1, 2, 3...]", new Int32[] { 1, 2, 3, 4, 5 }, 3)]
		[InlineData("[1, 2, 3, 4, 5]", new Int32[] { 1, 2, 3, 4, 5 }, 5)]
		public void ToString([DisallowNull] String expected, [DisallowNull] Int32[] elements, Int32 amount) {
			BoundedArray<Int32> array = elements;
			Assert.Equal(expected, array.ToString(amount));
		}
	}
}
