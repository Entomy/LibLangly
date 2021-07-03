using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits.Testing;
using Stringier;
using Xunit;

namespace Stringier {
	public class Rope_Tests : Tests {
		[Theory]
		[InlineData(new Char[] { 'a', 'b' }, new Char[] { }, new Char[] { 'a', 'b' })]
		public void Add_Array([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, [DisallowNull] Char[] values) {
			Rope rope = initial;
			rope.Add(values);
			Assert(rope).Equals(expected);
		}

		[Theory]
		[InlineData(new Char[] { 'a' }, new Char[] { }, 'a')]
		[InlineData(new Char[] { 'a', 'b' }, new Char[] { 'a' }, 'b')]
		public void Add_Element([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, [DisallowNull] Char value) {
			Rope rope = initial;
			rope.Add(value);
			Assert(rope).Equals(expected);
		}

		[Theory]
		[InlineData(new Char[] { 'a', 'b' }, new Char[] { }, new Char[] { 'a', 'b' })]
		public void Add_Memory([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, [DisallowNull] Char[] values) {
			Rope rope = initial;
			rope.Add(values.AsMemory());
			Assert(rope).Equals(expected);
		}

		[Theory]
		[InlineData(new Char[] { 'a', 'b' }, new Char[] { }, new Char[] { 'a', 'b' })]
		public unsafe void Add_Pointer([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, [DisallowNull] Char[] values) {
			Rope rope = initial;
			fixed (Char* vals = values) {
				rope.Add(vals, values.Length);
			}
			Assert(rope).Equals(expected);
		}

		[Theory]
		[InlineData(new Char[] { 'a', 'b' }, new Char[] { }, new Char[] { 'a', 'b' })]
		public void Add_ReadOnlyMemory([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, [DisallowNull] Char[] values) {
			Rope rope = initial;
			rope.Add((ReadOnlyMemory<Char>)values.AsMemory());
			Assert(rope).Equals(expected);
		}

		[Theory]
		[InlineData(new Char[] { 'a', 'b' }, new Char[] { }, new Char[] { 'a', 'b' })]
		public void Add_ReadOnlySpan([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, [DisallowNull] Char[] values) {
			Rope rope = initial;
			rope.Add((ReadOnlySpan<Char>)values.AsSpan());
			Assert(rope).Equals(expected);
		}

		[Theory]
		[InlineData(new Char[] { 'a', 'b' }, new Char[] { }, new Char[] { 'a', 'b' })]
		public void Add_Span([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, [DisallowNull] Char[] values) {
			Rope rope = initial;
			rope.Add(values.AsSpan());
			Assert(rope).Equals(expected);
		}

		[Theory]
		[InlineData(new Char[] { })]
		[InlineData(new Char[] { 'a', 'b', 'c', 'd', 'e' })]
		public void Clear([DisallowNull] Char[] initial) {
			Rope rope = initial;
			rope.Clear();
			Assert(rope).Count(0);
		}

		[Theory]
		[InlineData(new Char[] { })]
		[InlineData(new Char[] { 'a', 'b', 'c', 'd', 'e' })]
		public void Equals([DisallowNull] Char[] values) {
			Rope val = values is not null ? new Rope(values) : null;
			Assert(val).Equals(values);
			Rope exp = values is not null ? new Rope(values) : null;
			Assert(val).Equals(exp);
			Rope dval = values is not null ? new Rope(values) : null;
			Assert(val).Equals(dval);
		}

		[Theory]
		[InlineData(new Char[] { 'a', 'b' }, new Char[] { }, 0, new Char[] { 'a', 'b' })]
		[InlineData(new Char[] { '0', '0', 'a', 'b', 'c', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 0, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', '0', '0', 'b', 'c', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 1, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', 'b', '0', '0', 'c', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 2, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', 'b', 'c', '0', '0', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 3, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', 'b', 'c', 'd', '0', '0', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 4, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', 'b', 'c', 'd', 'e', '0', '0' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 5, new Char[] { '0', '0' })]
		public void Insert_Array([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, Int32 index, [DisallowNull] Char[] elements) {
			Rope rope = initial;
			rope.Insert(index, elements);
			Assert(rope).Equals(expected);
		}

		[Theory]
		[InlineData(new Char[] { 'a' }, new Char[] { }, 0, 'a')]
		[InlineData(new Char[] { '0', 'a', 'b', 'c', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 0, '0')]
		[InlineData(new Char[] { 'a', '0', 'b', 'c', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 1, '0')]
		[InlineData(new Char[] { 'a', 'b', '0', 'c', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 2, '0')]
		[InlineData(new Char[] { 'a', 'b', 'c', '0', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 3, '0')]
		[InlineData(new Char[] { 'a', 'b', 'c', 'd', '0', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 4, '0')]
		[InlineData(new Char[] { 'a', 'b', 'c', 'd', 'e', '0' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 5, '0')]
		public void Insert_Element([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, Int32 index, Char element) {
			Rope rope = initial;
			rope.Insert(index, element);
			Assert(rope).Equals(expected);
		}

		[Theory]
		[InlineData(new Char[] { 'a', 'b' }, new Char[] { }, 0, new Char[] { 'a', 'b' })]
		[InlineData(new Char[] { '0', '0', 'a', 'b', 'c', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 0, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', '0', '0', 'b', 'c', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 1, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', 'b', '0', '0', 'c', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 2, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', 'b', 'c', '0', '0', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 3, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', 'b', 'c', 'd', '0', '0', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 4, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', 'b', 'c', 'd', 'e', '0', '0' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 5, new Char[] { '0', '0' })]
		public void Insert_Memory([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, Int32 index, [DisallowNull] Char[] values) {
			Rope rope = initial;
			rope.Insert(index, values.AsMemory());
			Assert(rope).Equals(expected);
		}

		[Theory]
		[InlineData(new Char[] { 'a', 'b' }, new Char[] { }, 0, new Char[] { 'a', 'b' })]
		[InlineData(new Char[] { '0', '0', 'a', 'b', 'c', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 0, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', '0', '0', 'b', 'c', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 1, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', 'b', '0', '0', 'c', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 2, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', 'b', 'c', '0', '0', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 3, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', 'b', 'c', 'd', '0', '0', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 4, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', 'b', 'c', 'd', 'e', '0', '0' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 5, new Char[] { '0', '0' })]
		public unsafe void Insert_Pointer([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, Int32 index, [DisallowNull] Char[] elements) {
			Rope rope = initial;
			fixed (Char* elmts = elements) {
				rope.Insert(index, elmts, elements.Length);
			}
			Assert(rope).Equals(expected);
		}

		[Theory]
		[InlineData(new Char[] { 'a', 'b' }, new Char[] { }, 0, new Char[] { 'a', 'b' })]
		[InlineData(new Char[] { '0', '0', 'a', 'b', 'c', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 0, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', '0', '0', 'b', 'c', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 1, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', 'b', '0', '0', 'c', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 2, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', 'b', 'c', '0', '0', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 3, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', 'b', 'c', 'd', '0', '0', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 4, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', 'b', 'c', 'd', 'e', '0', '0' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 5, new Char[] { '0', '0' })]
		public void Insert_ReadOnlyMemory([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, Int32 index, [DisallowNull] Char[] elements) {
			Rope rope = initial;
			rope.Insert(index, (ReadOnlyMemory<Char>)elements.AsMemory());
			Assert(rope).Equals(expected);
		}

		[Theory]
		[InlineData(new Char[] { 'a', 'b' }, new Char[] { }, 0, new Char[] { 'a', 'b' })]
		[InlineData(new Char[] { '0', '0', 'a', 'b', 'c', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 0, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', '0', '0', 'b', 'c', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 1, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', 'b', '0', '0', 'c', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 2, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', 'b', 'c', '0', '0', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 3, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', 'b', 'c', 'd', '0', '0', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 4, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', 'b', 'c', 'd', 'e', '0', '0' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 5, new Char[] { '0', '0' })]
		public void Insert_ReadOnlySpan([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, Int32 index, [DisallowNull] Char[] elements) {
			Rope rope = initial;
			rope.Insert(index, (ReadOnlySpan<Char>)elements.AsSpan());
			Assert(rope).Equals(expected);
		}

		[Theory]
		[InlineData(new Char[] { 'a', 'b' }, new Char[] { }, 0, new Char[] { 'a', 'b' })]
		[InlineData(new Char[] { '0', '0', 'a', 'b', 'c', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 0, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', '0', '0', 'b', 'c', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 1, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', 'b', '0', '0', 'c', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 2, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', 'b', 'c', '0', '0', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 3, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', 'b', 'c', 'd', '0', '0', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 4, new Char[] { '0', '0' })]
		[InlineData(new Char[] { 'a', 'b', 'c', 'd', 'e', '0', '0' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 5, new Char[] { '0', '0' })]
		public void Insert_Span([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, Int32 index, [DisallowNull] Char[] elements) {
			Rope rope = initial;
			rope.Insert(index, elements.AsSpan());
			Assert(rope).Equals(expected);
		}

		[Theory]
		[InlineData(new Char[] { }, new Char[] { }, new Char[] { })]
		[InlineData(new Char[] { 'a', 'b', 'c', 'd', 'e' }, new Char[] { 'a', 'b' }, new Char[] { 'c', 'd', 'e' })]
		public void Postpend_Array([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, [DisallowNull] Char[] elements) {
			Rope rope = initial;
			Assert(rope + elements).Equals(expected);
		}

		[Theory]
		[InlineData(new Char[] { 'a' }, new Char[] { }, 'a')]
		public void Postpend_Element([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, Char element) {
			Rope rope = initial;
			Assert(rope + element).Equals(expected);
		}

		[Theory]
		[InlineData(new Char[] { }, new Char[] { }, new Char[] { })]
		[InlineData(new Char[] { 'a', 'b', 'c', 'd', 'e' }, new Char[] { 'a', 'b' }, new Char[] { 'c', 'd', 'e' })]
		public void Postpend_Memory([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, [DisallowNull] Char[] elements) {
			Rope rope = initial;
			Assert(rope + elements.AsMemory()).Equals(expected);
		}

		[Theory]
		[InlineData(new Char[] { }, new Char[] { }, new Char[] { })]
		[InlineData(new Char[] { 'a', 'b', 'c', 'd', 'e' }, new Char[] { 'a', 'b' }, new Char[] { 'c', 'd', 'e' })]
		public unsafe void Postpend_Pointer([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, [DisallowNull] Char[] elements) {
			Rope rope = initial;
			fixed (Char* elmts = elements) {
				rope.Postpend(elmts, elements.Length);
			}
			Assert(rope).Equals(expected);
		}

		[Theory]
		[InlineData(new Char[] { }, new Char[] { }, new Char[] { })]
		[InlineData(new Char[] { 'a', 'b', 'c', 'd', 'e' }, new Char[] { 'a', 'b' }, new Char[] { 'c', 'd', 'e' })]
		public void Postpend_ReadOnlyMemory([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, [DisallowNull] Char[] elements) {
			Rope rope = initial;
			Assert(rope + (ReadOnlyMemory<Char>)elements.AsMemory()).Equals(expected);
		}

		[Theory]
		[InlineData(new Char[] { }, new Char[] { }, new Char[] { })]
		[InlineData(new Char[] { 'a', 'b', 'c', 'd', 'e' }, new Char[] { 'a', 'b' }, new Char[] { 'c', 'd', 'e' })]
		public void Postpend_ReadOnlySpan([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, [DisallowNull] Char[] elements) {
			Rope rope = initial;
			rope.Postpend((ReadOnlySpan<Char>)elements.AsSpan());
			Assert(rope).Equals(expected);
		}

		[Theory]
		[InlineData(new Char[] { }, new Char[] { }, new Char[] { })]
		[InlineData(new Char[] { 'a', 'b', 'c', 'd', 'e' }, new Char[] { 'a', 'b' }, new Char[] { 'c', 'd', 'e' })]
		public void Postpend_Span([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, [DisallowNull] Char[] elements) {
			Rope rope = initial;
			rope.Postpend(elements.AsSpan());
			Assert(rope).Equals(expected);
		}

		[Theory]
		[InlineData(new Char[] { }, new Char[] { }, new Char[] { })]
		[InlineData(new Char[] { 'c', 'd', 'e', 'a', 'b' }, new Char[] { 'a', 'b' }, new Char[] { 'c', 'd', 'e' })]
		public void Prepend_Array([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, [DisallowNull] Char[] elements) {
			Rope rope = initial;
			Assert(elements + rope).Equals(expected);
		}

		[Theory]
		[InlineData(new Char[] { 'a' }, new Char[] { }, 'a')]
		public void Prepend_Element([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, Char element) {
			Rope rope = initial;
			Assert(element + rope).Equals(expected);
		}

		[Theory]
		[InlineData(new Char[] { }, new Char[] { }, new Char[] { })]
		[InlineData(new Char[] { 'c', 'd', 'e', 'a', 'b' }, new Char[] { 'a', 'b' }, new Char[] { 'c', 'd', 'e' })]
		public void Prepend_Memory([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, [DisallowNull] Char[] elements) {
			Rope rope = initial;
			Assert(elements.AsMemory() + rope).Equals(expected);
		}

		[Theory]
		[InlineData(new Char[] { }, new Char[] { }, new Char[] { })]
		[InlineData(new Char[] { 'c', 'd', 'e', 'a', 'b' }, new Char[] { 'a', 'b' }, new Char[] { 'c', 'd', 'e' })]
		public unsafe void Prepend_Pointer([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, [DisallowNull] Char[] elements) {
			Rope rope = initial;
			fixed (Char* elmts = elements) {
				rope.Prepend(elmts, elements.Length);
			}
			Assert(rope).Equals(expected);
		}

		[Theory]
		[InlineData(new Char[] { }, new Char[] { }, new Char[] { })]
		[InlineData(new Char[] { 'c', 'd', 'e', 'a', 'b' }, new Char[] { 'a', 'b' }, new Char[] { 'c', 'd', 'e' })]
		public void Prepend_ReadOnlyMemory([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, [DisallowNull] Char[] elements) {
			Rope rope = initial;
			Assert((ReadOnlyMemory<Char>)elements.AsMemory() + rope).Equals(expected);
		}

		[Theory]
		[InlineData(new Char[] { }, new Char[] { }, new Char[] { })]
		[InlineData(new Char[] { 'c', 'd', 'e', 'a', 'b' }, new Char[] { 'a', 'b' }, new Char[] { 'c', 'd', 'e' })]
		public void Prepend_ReadOnlySpan([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, [DisallowNull] Char[] elements) {
			Rope rope = initial;
			rope.Prepend((ReadOnlySpan<Char>)elements.AsSpan());
			Assert(rope).Equals(expected);
		}

		[Theory]
		[InlineData(new Char[] { }, new Char[] { }, new Char[] { })]
		[InlineData(new Char[] { 'c', 'd', 'e', 'a', 'b' }, new Char[] { 'a', 'b' }, new Char[] { 'c', 'd', 'e' })]
		public void Prepend_Span([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, [DisallowNull] Char[] elements) {
			Rope rope = initial;
			rope.Prepend(elements.AsSpan());
			Assert(rope).Equals(expected);
		}

		[Theory]
		[InlineData(new Char[] { }, new Char[] { }, '0', '0')]
		[InlineData(new Char[] { 'a', 'b', 'c', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, '0', '0')]
		[InlineData(new Char[] { '0', 'b', 'c', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 'a', '0')]
		[InlineData(new Char[] { 'a', '0', 'c', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 'b', '0')]
		[InlineData(new Char[] { 'a', 'b', '0', 'd', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 'c', '0')]
		[InlineData(new Char[] { 'a', 'b', 'c', '0', 'e' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 'd', '0')]
		[InlineData(new Char[] { 'a', 'b', 'c', 'd', '0' }, new Char[] { 'a', 'b', 'c', 'd', 'e' }, 'e', '0')]
		[InlineData(new Char[] { '0', 'b', '0', 'b', '0' }, new Char[] { 'a', 'b', 'a', 'b', 'a' }, 'a', '0')]
		[InlineData(new Char[] { '0', '0', '0', '0', '0' }, new Char[] { 'a', 'a', 'a', 'a', 'a' }, 'a', '0')]
		public void Replace([DisallowNull] Char[] expected, [DisallowNull] Char[] initial, Char search, Char replace) {
			Rope rope = initial;
			rope.Replace(search, replace);
			Assert(rope).Equals(expected);
		}

		[Theory]
		[InlineData("", new Char[] { })]
		[InlineData("abcde", new Char[] { 'a', 'b', 'c', 'd', 'e' })]
		public void ToString([DisallowNull] String expected, [DisallowNull] Char[] values) {
			Rope rope = values;
			Assert(rope.ToString()).Equals(expected);
		}

		[Theory]
		[InlineData("", new Char[] { }, 0)]
		[InlineData("abc...", new Char[] { 'a', 'b', 'c', 'd', 'e' }, 3)]
		[InlineData("abcde", new Char[] { 'a', 'b', 'c', 'd', 'e' }, 5)]
		public void ToString_Amount([DisallowNull] String expected, [DisallowNull] Char[] values, Char amount) {
			Rope rope = values;
			Assert(rope.ToString(amount)).Equals(expected);
		}
	}
}
