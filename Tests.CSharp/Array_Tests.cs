using System;
using Xunit;

namespace Langly {
	public class Array_Tests {
		[Theory]
		[InlineData(null, null, null)]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1 }, new Int32[] { 1 }, new Int32[] { })]
		[InlineData(new Int32[] { 1 }, new Int32[] { }, new Int32[] { 1 })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { 1, 2, 3 }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { }, new Int32[] { 1, 2, 3 })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { 1 }, new Int32[] { 2, 3 })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { 1, 2 }, new Int32[] { 3 })]
		public void Add_Array(Int32[] expected, Int32[] initial, Int32[] values) {
			var arr = PhilosoftExtensions.Add(initial, values);
			var mem = PhilosoftExtensions.Add(initial.AsMemory(), values);
			var rom = PhilosoftExtensions.Add((ReadOnlyMemory<Int32>)initial.AsMemory(), values);
			var spn = PhilosoftExtensions.Add(initial.AsSpan(), values);
			var ros = PhilosoftExtensions.Add((ReadOnlySpan<Int32>)initial.AsSpan(), values);
			if (expected is not null) {
				foreach (Int32 exp in expected) {
					Assert.Contains(exp, arr.ToArray());
					Assert.Contains(exp, mem.ToArray());
					Assert.Contains(exp, rom.ToArray());
					Assert.Contains(exp, spn.ToArray());
					Assert.Contains(exp, ros.ToArray());
				}
			} else {
				Assert.True(arr.Length == 0);
				Assert.True(mem.Length == 0);
				Assert.True(rom.Length == 0);
				Assert.True(spn.Length == 0);
				Assert.True(ros.Length == 0);
			}
		}

		[Theory]
		[InlineData(new Int32[] { 1 }, new Int32[] { }, 1)]
		[InlineData(new Int32[] { 1, 2 }, new Int32[] { 1 }, 2)]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { 1, 2 }, 3)]
		public void Add_Element(Int32[] expected, Int32[] initial, Int32 value) {
			var arr = PhilosoftExtensions.Add(initial, value);
			var mem = PhilosoftExtensions.Add(initial.AsMemory(), value);
			var rom = PhilosoftExtensions.Add((ReadOnlyMemory<Int32>)initial.AsMemory(), value);
			var spn = PhilosoftExtensions.Add(initial.AsSpan(), value);
			var ros = PhilosoftExtensions.Add((ReadOnlySpan<Int32>)initial.AsSpan(), value);
			if (expected is not null) {
				foreach (Int32 exp in expected) {
					Assert.Contains(exp, arr.ToArray());
					Assert.Contains(exp, mem.ToArray());
					Assert.Contains(exp, rom.ToArray());
					Assert.Contains(exp, spn.ToArray());
					Assert.Contains(exp, ros.ToArray());
				}
			} else {
				Assert.True(arr.Length == 0);
				Assert.True(mem.Length == 0);
				Assert.True(rom.Length == 0);
				Assert.True(spn.Length == 0);
				Assert.True(ros.Length == 0);
			}
		}

		[Theory]
		[InlineData(null, null, null)]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1 }, new Int32[] { 1 }, new Int32[] { })]
		[InlineData(new Int32[] { 1 }, new Int32[] { }, new Int32[] { 1 })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { 1, 2, 3 }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { }, new Int32[] { 1, 2, 3 })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { 1 }, new Int32[] { 2, 3 })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { 1, 2 }, new Int32[] { 3 })]
		public void Add_Memory(Int32[] expected, Int32[] initial, Int32[] values) {
			var arr = PhilosoftExtensions.Add(initial, values.AsMemory());
			var mem = PhilosoftExtensions.Add(initial.AsMemory(), values.AsMemory());
			var rom = PhilosoftExtensions.Add((ReadOnlyMemory<Int32>)initial.AsMemory(), values.AsMemory());
			var spn = PhilosoftExtensions.Add(initial.AsSpan(), values.AsMemory());
			var ros = PhilosoftExtensions.Add((ReadOnlySpan<Int32>)initial.AsSpan(), values.AsMemory());
			if (expected is not null) {
				foreach (Int32 exp in expected) {
					Assert.Contains(exp, arr.ToArray());
					Assert.Contains(exp, mem.ToArray());
					Assert.Contains(exp, rom.ToArray());
					Assert.Contains(exp, spn.ToArray());
					Assert.Contains(exp, ros.ToArray());
				}
			} else {
				Assert.True(arr.Length == 0);
				Assert.True(mem.Length == 0);
				Assert.True(rom.Length == 0);
				Assert.True(spn.Length == 0);
				Assert.True(ros.Length == 0);
			}
		}

		[Theory]
		[InlineData(null, null, new Int32[] { })]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1 }, new Int32[] { 1 }, new Int32[] { })]
		[InlineData(new Int32[] { 1 }, new Int32[] { }, new Int32[] { 1 })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { 1, 2, 3 }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { }, new Int32[] { 1, 2, 3 })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { 1 }, new Int32[] { 2, 3 })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { 1, 2 }, new Int32[] { 3 })]
		public unsafe void Add_Pointer(Int32[] expected, Int32[] initial, Int32[] values) {
			fixed (Int32* val = values) {
				var arr = PhilosoftExtensions.Add(initial, val, values.Length);
				var mem = PhilosoftExtensions.Add(initial.AsMemory(), val, values.Length);
				var rom = PhilosoftExtensions.Add((ReadOnlyMemory<Int32>)initial.AsMemory(), val, values.Length);
				var spn = PhilosoftExtensions.Add(initial.AsSpan(), val, values.Length);
				var ros = PhilosoftExtensions.Add((ReadOnlySpan<Int32>)initial.AsSpan(), val, values.Length);
				if (expected is not null) {
					foreach (Int32 exp in expected) {
						Assert.Contains(exp, arr.ToArray());
						Assert.Contains(exp, mem.ToArray());
						Assert.Contains(exp, rom.ToArray());
						Assert.Contains(exp, spn.ToArray());
						Assert.Contains(exp, ros.ToArray());
					}
				} else {
					Assert.True(arr.Length == 0);
					Assert.True(mem.Length == 0);
					Assert.True(rom.Length == 0);
					Assert.True(spn.Length == 0);
					Assert.True(ros.Length == 0);
				}
			}
		}

		[Theory]
		[InlineData(null, null, new Int32[] { })]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1 }, new Int32[] { 1 }, new Int32[] { })]
		[InlineData(new Int32[] { 1 }, new Int32[] { }, new Int32[] { 1 })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { 1, 2, 3 }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { }, new Int32[] { 1, 2, 3 })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { 1 }, new Int32[] { 2, 3 })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { 1, 2 }, new Int32[] { 3 })]
		public void Add_ReadOnlyMemory(Int32[] expected, Int32[] initial, Int32[] values) {
			var arr = PhilosoftExtensions.Add(initial, (ReadOnlyMemory<Int32>)values.AsMemory());
			var mem = PhilosoftExtensions.Add(initial.AsMemory(), (ReadOnlyMemory<Int32>)values.AsMemory());
			var rom = PhilosoftExtensions.Add((ReadOnlyMemory<Int32>)initial.AsMemory(), (ReadOnlyMemory<Int32>)values.AsMemory());
			var spn = PhilosoftExtensions.Add(initial.AsSpan(), (ReadOnlyMemory<Int32>)values.AsMemory());
			var ros = PhilosoftExtensions.Add((ReadOnlySpan<Int32>)initial.AsSpan(), (ReadOnlyMemory<Int32>)values.AsMemory());
			if (expected is not null) {
				foreach (Int32 exp in expected) {
					Assert.Contains(exp, arr.ToArray());
					Assert.Contains(exp, mem.ToArray());
					Assert.Contains(exp, rom.ToArray());
					Assert.Contains(exp, spn.ToArray());
					Assert.Contains(exp, ros.ToArray());
				}
			} else {
				Assert.True(arr.Length == 0);
				Assert.True(mem.Length == 0);
				Assert.True(rom.Length == 0);
				Assert.True(spn.Length == 0);
				Assert.True(ros.Length == 0);
			}
		}

		[Theory]
		[InlineData(null, null, new Int32[] { })]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1 }, new Int32[] { 1 }, new Int32[] { })]
		[InlineData(new Int32[] { 1 }, new Int32[] { }, new Int32[] { 1 })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { 1, 2, 3 }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { }, new Int32[] { 1, 2, 3 })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { 1 }, new Int32[] { 2, 3 })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { 1, 2 }, new Int32[] { 3 })]
		public void Add_ReadOnlySpan(Int32[] expected, Int32[] initial, Int32[] values) {
			var arr = PhilosoftExtensions.Add(initial, (ReadOnlySpan<Int32>)values.AsSpan());
			var mem = PhilosoftExtensions.Add(initial.AsMemory(), (ReadOnlySpan<Int32>)values.AsSpan());
			var rom = PhilosoftExtensions.Add((ReadOnlyMemory<Int32>)initial.AsMemory(), (ReadOnlySpan<Int32>)values.AsSpan());
			var spn = PhilosoftExtensions.Add(initial.AsSpan(), (ReadOnlySpan<Int32>)values.AsSpan());
			var ros = PhilosoftExtensions.Add((ReadOnlySpan<Int32>)initial.AsSpan(), (ReadOnlySpan<Int32>)values.AsSpan());
			if (expected is not null) {
				foreach (Int32 exp in expected) {
					Assert.Contains(exp, arr.ToArray());
					Assert.Contains(exp, mem.ToArray());
					Assert.Contains(exp, rom.ToArray());
					Assert.Contains(exp, spn.ToArray());
					Assert.Contains(exp, ros.ToArray());
				}
			} else {
				Assert.True(arr.Length == 0);
				Assert.True(mem.Length == 0);
				Assert.True(rom.Length == 0);
				Assert.True(spn.Length == 0);
				Assert.True(ros.Length == 0);
			}
		}

		[Theory]
		[InlineData(null, null, new Int32[] { })]
		[InlineData(new Int32[] { }, new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1 }, new Int32[] { 1 }, new Int32[] { })]
		[InlineData(new Int32[] { 1 }, new Int32[] { }, new Int32[] { 1 })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { 1, 2, 3 }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { }, new Int32[] { 1, 2, 3 })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { 1 }, new Int32[] { 2, 3 })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { 1, 2 }, new Int32[] { 3 })]
		public void Add_Span(Int32[] expected, Int32[] initial, Int32[] values) {
			var arr = PhilosoftExtensions.Add(initial, values.AsSpan());
			var mem = PhilosoftExtensions.Add(initial.AsMemory(), values.AsSpan());
			var rom = PhilosoftExtensions.Add((ReadOnlyMemory<Int32>)initial.AsMemory(), values.AsSpan());
			var spn = PhilosoftExtensions.Add(initial.AsSpan(), values.AsSpan());
			var ros = PhilosoftExtensions.Add((ReadOnlySpan<Int32>)initial.AsSpan(), values.AsSpan());
			if (expected is not null) {
				foreach (Int32 exp in expected) {
					Assert.Contains(exp, arr.ToArray());
					Assert.Contains(exp, mem.ToArray());
					Assert.Contains(exp, rom.ToArray());
					Assert.Contains(exp, spn.ToArray());
					Assert.Contains(exp, ros.ToArray());
				}
			} else {
				Assert.True(arr.Length == 0);
				Assert.True(mem.Length == 0);
				Assert.True(rom.Length == 0);
				Assert.True(spn.Length == 0);
				Assert.True(ros.Length == 0);
			}
		}

		[Theory]
		[InlineData(false, new Int32[] { 1, 2, 3 }, 0)]
		[InlineData(true, new Int32[] { 1, 2, 3 }, 1)]
		[InlineData(true, new Int32[] { 1, 2, 3 }, 2)]
		[InlineData(true, new Int32[] { 1, 2, 3 }, 3)]
		[InlineData(false, new Int32[] { 1, 2, 3 }, 4)]
		public void Contains_Element(Boolean expected, Int32[] values, Int32 element) {
			Assert.Equal(expected, PhilosoftExtensions.Contains(values, element));
			Assert.Equal(expected, PhilosoftExtensions.Contains(values.AsMemory(), element));
			Assert.Equal(expected, PhilosoftExtensions.Contains((ReadOnlyMemory<Int32>)values.AsMemory(), element));
			Assert.Equal(expected, PhilosoftExtensions.Contains(values.AsSpan(), element));
			Assert.Equal(expected, PhilosoftExtensions.Contains((ReadOnlySpan<Int32>)values.AsSpan(), element));
		}

		[Theory]
		[InlineData(true, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3 })]
		[InlineData(true, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 3, 4 })]
		[InlineData(true, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 3, 4, 5 })]
		[InlineData(false, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 4, 5, 6 })]
		public void ContainsAll(Boolean expected, Int32[] values, Int32[] elements) {
			Assert.Equal(expected, PhilosoftExtensions.ContainsAll(values, elements));
			Assert.Equal(expected, PhilosoftExtensions.ContainsAll(values.AsMemory(), elements));
			Assert.Equal(expected, PhilosoftExtensions.ContainsAll((ReadOnlyMemory<Int32>)values.AsMemory(), elements));
			Assert.Equal(expected, PhilosoftExtensions.ContainsAll(values.AsSpan(), elements));
			Assert.Equal(expected, PhilosoftExtensions.ContainsAll((ReadOnlySpan<Int32>)values.AsSpan(), elements));
		}

		[Theory]
		[InlineData(true, new Int32[] { 1, 2, 3 }, new Int32[] { 1, 2, 3 })]
		[InlineData(true, new Int32[] { 1, 2, 3 }, new Int32[] { 2, 3, 4 })]
		[InlineData(true, new Int32[] { 1, 2, 3 }, new Int32[] { 3, 4, 5 })]
		[InlineData(false, new Int32[] { 1, 2, 3 }, new Int32[] { 4, 5, 6 })]
		public void ContainsAny(Boolean expected, Int32[] values, Int32[] elements) {
			Assert.Equal(expected, PhilosoftExtensions.ContainsAny(values, elements));
			Assert.Equal(expected, PhilosoftExtensions.ContainsAny(values.AsMemory(), elements));
			Assert.Equal(expected, PhilosoftExtensions.ContainsAny((ReadOnlyMemory<Int32>)values.AsMemory(), elements));
			Assert.Equal(expected, PhilosoftExtensions.ContainsAny(values.AsSpan(), elements));
			Assert.Equal(expected, PhilosoftExtensions.ContainsAny((ReadOnlySpan<Int32>)values.AsSpan(), elements));
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new Int32[] { })]
		[InlineData(15, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Fold(Int32 expected, Int32[] values) {
			Assert.Equal(expected, PhilosoftExtensions.Fold(values, (x, y) => x + y, 0));
			Assert.Equal(expected, PhilosoftExtensions.Fold(values.AsMemory(), (x, y) => x + y, 0));
			Assert.Equal(expected, PhilosoftExtensions.Fold((ReadOnlyMemory<Int32>)values.AsMemory(), (x, y) => x + y, 0));
			Assert.Equal(expected, PhilosoftExtensions.Fold(values.AsSpan(), (x, y) => x + y, 0));
			Assert.Equal(expected, PhilosoftExtensions.Fold((ReadOnlySpan<Int32>)values.AsSpan(), (x, y) => x + y, 0));
		}

		[Theory]
		[InlineData(new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 })]
		public void Grow(Int32[] values) {
			var arr = PhilosoftExtensions.Grow(values);
			var mem = PhilosoftExtensions.Grow(values.AsMemory());
			var spn = PhilosoftExtensions.Grow(values.AsSpan());
			Assert.True(arr.Length > values.Length);
			Assert.True(mem.Length > values.Length);
			Assert.True(spn.Length > values.Length);
			foreach (Int32 value in values) {
				Assert.Contains(value, arr);
				Assert.Contains(value, mem.ToArray());
				Assert.Contains(value, spn.ToArray());
			}
		}

		[Theory]
		[InlineData(-1, null, 1)]
		[InlineData(-1, new Int32[] { }, 1)]
		[InlineData(0, new Int32[] { 1, 2, 3 }, 1)]
		[InlineData(1, new Int32[] { 1, 2, 3 }, 2)]
		[InlineData(2, new Int32[] { 1, 2, 3 }, 3)]
		[InlineData(0, new Int32[] { 1, 2, 3, 1, 2, 3 }, 1)]
		[InlineData(1, new Int32[] { 1, 2, 3, 1, 2, 3 }, 2)]
		[InlineData(2, new Int32[] { 1, 2, 3, 1, 2, 3 }, 3)]
		[InlineData(-1, new Int32[] { 1, 2, 3 }, 4)]
		public void IndexOfFirst(Int32 expected, Int32[] values, Int32 element) {
			Assert.Equal(expected, PhilosoftExtensions.IndexOfFirst(values, element));
			Assert.Equal(expected, PhilosoftExtensions.IndexOfFirst(values.AsMemory(), element));
			Assert.Equal(expected, PhilosoftExtensions.IndexOfFirst((ReadOnlyMemory<Int32>)values.AsMemory(), element));
			Assert.Equal(expected, PhilosoftExtensions.IndexOfFirst(values.AsSpan(), element));
			Assert.Equal(expected, PhilosoftExtensions.IndexOfFirst((ReadOnlySpan<Int32>)values.AsSpan(), element));
		}

		[Theory]
		[InlineData(-1, null, 1)]
		[InlineData(-1, new Int32[] { }, 1)]
		[InlineData(0, new Int32[] { 1, 2, 3 }, 1)]
		[InlineData(1, new Int32[] { 1, 2, 3 }, 2)]
		[InlineData(2, new Int32[] { 1, 2, 3 }, 3)]
		[InlineData(3, new Int32[] { 1, 2, 3, 1, 2, 3 }, 1)]
		[InlineData(4, new Int32[] { 1, 2, 3, 1, 2, 3 }, 2)]
		[InlineData(5, new Int32[] { 1, 2, 3, 1, 2, 3 }, 3)]
		[InlineData(-1, new Int32[] { 1, 2, 3 }, 4)]
		public void IndexOfLast(Int32 expected, Int32[] values, Int32 element) {
			Assert.Equal(expected, PhilosoftExtensions.IndexOfLast(values, element));
			Assert.Equal(expected, PhilosoftExtensions.IndexOfLast(values.AsMemory(), element));
			Assert.Equal(expected, PhilosoftExtensions.IndexOfLast((ReadOnlyMemory<Int32>)values.AsMemory(), element));
			Assert.Equal(expected, PhilosoftExtensions.IndexOfLast(values.AsSpan(), element));
			Assert.Equal(expected, PhilosoftExtensions.IndexOfLast((ReadOnlySpan<Int32>)values.AsSpan(), element));
		}

		[Theory]
		[InlineData(new Int32[] { 1, 2, 3 }, null, 0, new Int32[] { 1, 2, 3 })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { }, 0, new Int32[] { 1, 2, 3 })]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3 }, new Int32[] { 1, 2, 3 }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 0, 0, 2, 3 }, new Int32[] { 1, 2, 3 }, 1, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 0, 0, 3 }, new Int32[] { 1, 2, 3 }, 2, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 0, 0 }, new Int32[] { 1, 2, 3 }, 3, new Int32[] { 0, 0 })]
		public void Insert_Array(Int32[] expected, Int32[] initial, Int32 index, Int32[] values) {
			var arr = PhilosoftExtensions.Insert(initial, index, values);
			var mem = PhilosoftExtensions.Insert(initial.AsMemory(), index, values);
			var rom = PhilosoftExtensions.Insert((ReadOnlyMemory<Int32>)initial.AsMemory(), index, values);
			var spn = PhilosoftExtensions.Insert(initial.AsSpan(), index, values);
			var ros = PhilosoftExtensions.Insert((ReadOnlySpan<Int32>)initial.AsSpan(), index, values);
			if (expected is not null) {
				Assert.Equal(expected, arr.ToArray());
				Assert.Equal(expected, mem.ToArray());
				Assert.Equal(expected, rom.ToArray());
				Assert.Equal(expected, spn.ToArray());
				Assert.Equal(expected, ros.ToArray());
			} else {
				Assert.True(arr.Length == 0);
				Assert.True(mem.Length == 0);
				Assert.True(rom.Length == 0);
				Assert.True(spn.Length == 0);
				Assert.True(ros.Length == 0);
			}
		}

		[Theory]
		[InlineData(new Int32[] { 1 }, null, 0, 1)]
		[InlineData(new Int32[] { 1 }, new Int32[] { }, 0, 1)]
		[InlineData(new Int32[] { 0, 1, 2, 3 }, new Int32[] { 1, 2, 3 }, 0, 0)]
		[InlineData(new Int32[] { 1, 0, 2, 3 }, new Int32[] { 1, 2, 3 }, 1, 0)]
		[InlineData(new Int32[] { 1, 2, 0, 3 }, new Int32[] { 1, 2, 3 }, 2, 0)]
		[InlineData(new Int32[] { 1, 2, 3, 0 }, new Int32[] { 1, 2, 3 }, 3, 0)]
		public void Insert_Element(Int32[] expected, Int32[] initial, Int32 index, Int32 value) {
			var arr = PhilosoftExtensions.Insert(initial, index, value);
			var mem = PhilosoftExtensions.Insert(initial.AsMemory(), index, value);
			var rom = PhilosoftExtensions.Insert((ReadOnlyMemory<Int32>)initial.AsMemory(), index, value);
			var spn = PhilosoftExtensions.Insert(initial.AsSpan(), index, value);
			var ros = PhilosoftExtensions.Insert((ReadOnlySpan<Int32>)initial.AsSpan(), index, value);
			if (expected is not null) {
				Assert.Equal(expected, arr.ToArray());
				Assert.Equal(expected, mem.ToArray());
				Assert.Equal(expected, rom.ToArray());
				Assert.Equal(expected, spn.ToArray());
				Assert.Equal(expected, ros.ToArray());
			} else {
				Assert.True(arr.Length == 0);
				Assert.True(mem.Length == 0);
				Assert.True(rom.Length == 0);
				Assert.True(spn.Length == 0);
				Assert.True(ros.Length == 0);
			}
		}

		[Theory]
		[InlineData(new Int32[] { 1, 2, 3 }, null, 0, new Int32[] { 1, 2, 3 })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { }, 0, new Int32[] { 1, 2, 3 })]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3 }, new Int32[] { 1, 2, 3 }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 0, 0, 2, 3 }, new Int32[] { 1, 2, 3 }, 1, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 0, 0, 3 }, new Int32[] { 1, 2, 3 }, 2, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 0, 0 }, new Int32[] { 1, 2, 3 }, 3, new Int32[] { 0, 0 })]
		public void Insert_Memory(Int32[] expected, Int32[] initial, Int32 index, Int32[] values) {
			var arr = PhilosoftExtensions.Insert(initial, index, values.AsMemory());
			var mem = PhilosoftExtensions.Insert(initial.AsMemory(), index, values.AsMemory());
			var rom = PhilosoftExtensions.Insert((ReadOnlyMemory<Int32>)initial.AsMemory(), index, values.AsMemory());
			var spn = PhilosoftExtensions.Insert(initial.AsSpan(), index, values.AsMemory());
			var ros = PhilosoftExtensions.Insert((ReadOnlySpan<Int32>)initial.AsSpan(), index, values.AsMemory());
			if (expected is not null) {
				Assert.Equal(expected, arr.ToArray());
				Assert.Equal(expected, mem.ToArray());
				Assert.Equal(expected, rom.ToArray());
				Assert.Equal(expected, spn.ToArray());
				Assert.Equal(expected, ros.ToArray());
			} else {
				Assert.True(arr.Length == 0);
				Assert.True(mem.Length == 0);
				Assert.True(rom.Length == 0);
				Assert.True(spn.Length == 0);
				Assert.True(ros.Length == 0);
			}
		}

		[Theory]
		[InlineData(new Int32[] { 1, 2, 3 }, null, 0, new Int32[] { 1, 2, 3 })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { }, 0, new Int32[] { 1, 2, 3 })]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3 }, new Int32[] { 1, 2, 3 }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 0, 0, 2, 3 }, new Int32[] { 1, 2, 3 }, 1, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 0, 0, 3 }, new Int32[] { 1, 2, 3 }, 2, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 0, 0 }, new Int32[] { 1, 2, 3 }, 3, new Int32[] { 0, 0 })]
		public unsafe void Insert_Pointer(Int32[] expected, Int32[] initial, Int32 index, Int32[] values) {
			fixed (Int32* vals = values) {
				var arr = PhilosoftExtensions.Insert(initial, index, vals, values.Length);
				var mem = PhilosoftExtensions.Insert(initial.AsMemory(), index, vals, values.Length);
				var rom = PhilosoftExtensions.Insert((ReadOnlyMemory<Int32>)initial.AsMemory(), index, vals, values.Length);
				var spn = PhilosoftExtensions.Insert(initial.AsSpan(), index, vals, values.Length);
				var ros = PhilosoftExtensions.Insert((ReadOnlySpan<Int32>)initial.AsSpan(), index, vals, values.Length);
				if (expected is not null) {
					Assert.Equal(expected, arr.ToArray());
					Assert.Equal(expected, mem.ToArray());
					Assert.Equal(expected, rom.ToArray());
					Assert.Equal(expected, spn.ToArray());
					Assert.Equal(expected, ros.ToArray());
				} else {
					Assert.True(arr.Length == 0);
					Assert.True(mem.Length == 0);
					Assert.True(rom.Length == 0);
					Assert.True(spn.Length == 0);
					Assert.True(ros.Length == 0);
				}
			}
		}

		[Theory]
		[InlineData(new Int32[] { 1, 2, 3 }, null, 0, new Int32[] { 1, 2, 3 })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { }, 0, new Int32[] { 1, 2, 3 })]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3 }, new Int32[] { 1, 2, 3 }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 0, 0, 2, 3 }, new Int32[] { 1, 2, 3 }, 1, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 0, 0, 3 }, new Int32[] { 1, 2, 3 }, 2, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 0, 0 }, new Int32[] { 1, 2, 3 }, 3, new Int32[] { 0, 0 })]
		public void Insert_ReadOnlyMemory(Int32[] expected, Int32[] initial, Int32 index, Int32[] values) {
			var arr = PhilosoftExtensions.Insert(initial, index, (ReadOnlyMemory<Int32>)values.AsMemory());
			var mem = PhilosoftExtensions.Insert(initial.AsMemory(), index, (ReadOnlyMemory<Int32>)values.AsMemory());
			var rom = PhilosoftExtensions.Insert((ReadOnlyMemory<Int32>)initial.AsMemory(), index, (ReadOnlyMemory<Int32>)values.AsMemory());
			var spn = PhilosoftExtensions.Insert(initial.AsSpan(), index, (ReadOnlyMemory<Int32>)values.AsMemory());
			var ros = PhilosoftExtensions.Insert((ReadOnlySpan<Int32>)initial.AsSpan(), index, (ReadOnlyMemory<Int32>)values.AsMemory());
			if (expected is not null) {
				Assert.Equal(expected, arr.ToArray());
				Assert.Equal(expected, mem.ToArray());
				Assert.Equal(expected, rom.ToArray());
				Assert.Equal(expected, spn.ToArray());
				Assert.Equal(expected, ros.ToArray());
			} else {
				Assert.True(arr.Length == 0);
				Assert.True(mem.Length == 0);
				Assert.True(rom.Length == 0);
				Assert.True(spn.Length == 0);
				Assert.True(ros.Length == 0);
			}
		}
		[Theory]
		[InlineData(new Int32[] { 1, 2, 3 }, null, 0, new Int32[] { 1, 2, 3 })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { }, 0, new Int32[] { 1, 2, 3 })]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3 }, new Int32[] { 1, 2, 3 }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 0, 0, 2, 3 }, new Int32[] { 1, 2, 3 }, 1, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 0, 0, 3 }, new Int32[] { 1, 2, 3 }, 2, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 0, 0 }, new Int32[] { 1, 2, 3 }, 3, new Int32[] { 0, 0 })]
		public void Insert_ReadOnlySpan(Int32[] expected, Int32[] initial, Int32 index, Int32[] values) {
			var arr = PhilosoftExtensions.Insert(initial, index, (ReadOnlySpan<Int32>)values.AsSpan());
			var mem = PhilosoftExtensions.Insert(initial.AsMemory(), index, values.AsSpan());
			var rom = PhilosoftExtensions.Insert((ReadOnlyMemory<Int32>)initial.AsMemory(), index, values.AsSpan());
			var spn = PhilosoftExtensions.Insert(initial.AsSpan(), index, values.AsSpan());
			var ros = PhilosoftExtensions.Insert((ReadOnlySpan<Int32>)initial.AsSpan(), index, values.AsSpan());
			if (expected is not null) {
				Assert.Equal(expected, arr.ToArray());
				Assert.Equal(expected, mem.ToArray());
				Assert.Equal(expected, rom.ToArray());
				Assert.Equal(expected, spn.ToArray());
				Assert.Equal(expected, ros.ToArray());
			} else {
				Assert.True(arr.Length == 0);
				Assert.True(mem.Length == 0);
				Assert.True(rom.Length == 0);
				Assert.True(spn.Length == 0);
				Assert.True(ros.Length == 0);
			}
		}

		[Theory]
		[InlineData(new Int32[] { 1, 2, 3 }, null, 0, new Int32[] { 1, 2, 3 })]
		[InlineData(new Int32[] { 1, 2, 3 }, new Int32[] { }, 0, new Int32[] { 1, 2, 3 })]
		[InlineData(new Int32[] { 0, 0, 1, 2, 3 }, new Int32[] { 1, 2, 3 }, 0, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 0, 0, 2, 3 }, new Int32[] { 1, 2, 3 }, 1, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 0, 0, 3 }, new Int32[] { 1, 2, 3 }, 2, new Int32[] { 0, 0 })]
		[InlineData(new Int32[] { 1, 2, 3, 0, 0 }, new Int32[] { 1, 2, 3 }, 3, new Int32[] { 0, 0 })]
		public void Insert_Span(Int32[] expected, Int32[] initial, Int32 index, Int32[] values) {
			var arr = PhilosoftExtensions.Insert(initial, index, values.AsSpan());
			var mem = PhilosoftExtensions.Insert(initial.AsMemory(), index, values.AsSpan());
			var rom = PhilosoftExtensions.Insert((ReadOnlyMemory<Int32>)initial.AsMemory(), index, values.AsSpan());
			var spn = PhilosoftExtensions.Insert(initial.AsSpan(), index, values.AsSpan());
			var ros = PhilosoftExtensions.Insert((ReadOnlySpan<Int32>)initial.AsSpan(), index, values.AsSpan());
			if (expected is not null) {
				Assert.Equal(expected, arr.ToArray());
				Assert.Equal(expected, mem.ToArray());
				Assert.Equal(expected, rom.ToArray());
				Assert.Equal(expected, spn.ToArray());
				Assert.Equal(expected, ros.ToArray());
			} else {
				Assert.True(arr.Length == 0);
				Assert.True(mem.Length == 0);
				Assert.True(rom.Length == 0);
				Assert.True(spn.Length == 0);
				Assert.True(ros.Length == 0);
			}
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 2, 4, 6, 8, 10 }, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Map(Int32[] expected, Int32[] values) {
			Assert.Equal(expected, PhilosoftExtensions.Map(values, (x) => x * 2).ToArray());
			Assert.Equal(expected, PhilosoftExtensions.Map(values.AsMemory(), (x) => x * 2).ToArray());
			Assert.Equal(expected, PhilosoftExtensions.Map((ReadOnlyMemory<Int32>)values.AsMemory(), (x) => x * 2).ToArray());
			Assert.Equal(expected, PhilosoftExtensions.Map(values.AsSpan(), (x) => x * 2).ToArray());
			Assert.Equal(expected, PhilosoftExtensions.Map((ReadOnlySpan<Int32>)values.AsSpan(), (x) => x * 2).ToArray());
		}

		[Theory]
		[InlineData(0, null, 0)]
		[InlineData(0, new Int32[] { }, 0)]
		[InlineData(0, new Int32[] { 1 }, 0)]
		[InlineData(1, new Int32[] { 0 }, 0)]
		[InlineData(0, new Int32[] { 1, 1, 1 }, 0)]
		[InlineData(3, new Int32[] { 0, 0, 0 }, 0)]
		[InlineData(0, new Int32[] { 1, 2, 1, 2, 1 }, 0)]
		[InlineData(3, new Int32[] { 0, 2, 0, 2, 0 }, 0)]
		[InlineData(2, new Int32[] { 1, 0, 1, 0, 1 }, 0)]
		public void Occurrences_Element(Int32 expected, Int32[] values, Int32 element) {
			Assert.Equal(expected, PhilosoftExtensions.Occurrences(values, element));
			Assert.Equal(expected, PhilosoftExtensions.Occurrences(values.AsMemory(), element));
			Assert.Equal(expected, PhilosoftExtensions.Occurrences((ReadOnlyMemory<Int32>)values.AsMemory(), element));
			Assert.Equal(expected, PhilosoftExtensions.Occurrences(values.AsSpan(), element));
			Assert.Equal(expected, PhilosoftExtensions.Occurrences((ReadOnlySpan<Int32>)values.AsSpan(), element));
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new Int32[] { })]
		[InlineData(0, new Int32[] { 1 })]
		[InlineData(1, new Int32[] { 2 })]
		[InlineData(0, new Int32[] { 1, 1, 1 })]
		[InlineData(3, new Int32[] { 2, 2, 2 })]
		[InlineData(3, new Int32[] { 2, 4, 6 })]
		[InlineData(2, new Int32[] { 1, 2, 1, 2, 1 })]
		[InlineData(3, new Int32[] { 2, 1, 2, 1, 2 })]
		public void Occurrences_Predicate(Int32 expected, Int32[] values) {
			Assert.Equal(expected, PhilosoftExtensions.Occurrences(values, (x) => x % 2 == 0));
			Assert.Equal(expected, PhilosoftExtensions.Occurrences(values.AsMemory(), (x) => x % 2 == 0));
			Assert.Equal(expected, PhilosoftExtensions.Occurrences((ReadOnlyMemory<Int32>)values.AsMemory(), (x) => x % 2 == 0));
			Assert.Equal(expected, PhilosoftExtensions.Occurrences(values.AsSpan(), (x) => x % 2 == 0));
			Assert.Equal(expected, PhilosoftExtensions.Occurrences((ReadOnlySpan<Int32>)values.AsSpan(), (x) => x % 2 == 0));
		}
	}
}
