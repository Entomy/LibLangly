using System;
using Xunit;
using Langly.Exceptions;

namespace Langly {
	public class Guard_Tests {
		[Theory]
		[InlineData(null, '\0', false)]
		[InlineData(new Char[] { 'a', 'b', 'c' }, 'a', true)]
		[InlineData(new Char[] { 'a', 'b', 'c' }, 'c', true)]
		[InlineData(new Char[] { 'a', 'b', 'c' }, 'd', false)]
		public void Contains_Array_Char(Char[] collection, Char value, Boolean succeeds) {
			if (succeeds) {
				Guard.Contains(collection, nameof(collection), value);
			} else {
				Assert.Throws<ArgumentNotContainsException>(() => Guard.Contains(collection, nameof(collection), value));
			}
		}

		[Theory]
		[InlineData(null, '\0', false)]
		[InlineData(new Char[] { 'a', 'b', 'c' }, 'a', true)]
		[InlineData(new Char[] { 'a', 'b', 'c' }, 'c', true)]
		[InlineData(new Char[] { 'a', 'b', 'c' }, 'd', false)]
		public void Contains_GenericList_Char(Char[] values, Char value, Boolean succeeds) {
			System.Collections.Generic.IReadOnlyList<Char> collection = values is null ? null : new System.Collections.Generic.List<Char>(values);
			if (succeeds) {
				Guard.Contains(collection, nameof(collection), value);
			} else {
				Assert.Throws<ArgumentNotContainsException>(() => Guard.Contains(collection, nameof(collection), value));
			}
		}

		[Theory]
		[InlineData(null, '\0', false)]
		[InlineData(new Char[] { 'a', 'b', 'c' }, 'a', true)]
		[InlineData(new Char[] { 'a', 'b', 'c' }, 'c', true)]
		[InlineData(new Char[] { 'a', 'b', 'c' }, 'd', false)]
		public void Contains_WeakList_Char(Char[] values, Char value, Boolean succeeds) {
			System.Collections.ICollection collection = values is null ? null : new System.Collections.ArrayList(values);
			if (succeeds) {
				Guard.Contains(collection, nameof(collection), value);
			} else {
				Assert.Throws<ArgumentNotContainsException>(() => Guard.Contains(collection, nameof(collection), value));
			}
		}

		[Theory]
		[InlineData(ConsoleColor.Black, true)] //Valid colors ignore the boolean
		[InlineData(ConsoleColor.Red, true)]
		[InlineData((ConsoleColor)20, false)]
		public void Default(ConsoleColor color, Boolean unhandled) {
			switch (color) {
			case ConsoleColor.Black:
			case ConsoleColor.Blue:
			case ConsoleColor.Cyan:
			case ConsoleColor.Gray:
			case ConsoleColor.Green:
			case ConsoleColor.Magenta:
			case ConsoleColor.White:
				return;
			default:
				if (unhandled) {
					Assert.IsType<ArgumentUnhandledException>(Guard.Default(color, nameof(color)));
				} else {
					Assert.IsType<ArgumentNotValidException>(Guard.Default(color, nameof(color)));
				}
				break;
			}
		}

		[Theory]
		[InlineData(null, true)]
		[InlineData(new Int32[] { }, true)]
		[InlineData(new Int32[] { 1, 2, 3 }, false)]
		public void Empty_Array(Int32[] collection, Boolean succeeds) {
			if (succeeds) {
				Guard.Empty(collection, nameof(collection));
			} else {
				Assert.Throws<ArgumentNotEmptyException>(() => Guard.Empty(collection, nameof(collection)));
			}
		}

		[Theory]
		[InlineData(null, true)]
		[InlineData(new Int32[] { }, true)]
		[InlineData(new Int32[] { 1, 2, 3 }, false)]
		public void Empty_GenericList(Int32[] values, Boolean succeeds) {
			System.Collections.Generic.IReadOnlyList<Int32> collection = values is null ? null : new System.Collections.Generic.List<Int32>(values);
			if (succeeds) {
				Guard.Empty<Int32, System.Collections.Generic.IReadOnlyList<Int32>>(collection, nameof(collection));
			} else {
				Assert.Throws<ArgumentNotEmptyException>(() => Guard.Empty<Int32, System.Collections.Generic.IReadOnlyList<Int32>>(collection, nameof(collection)));
			}
		}

		[Theory]
		[InlineData(null, true)]
		[InlineData("", true)]
		[InlineData("hello", false)]
		public void Empty_String(String collection, Boolean succeeds) {
			if (succeeds) {
				Guard.Empty(collection, nameof(collection));
			} else {
				Assert.Throws<ArgumentNotEmptyException>(() => Guard.Empty(collection, nameof(collection)));
			}
		}

		[Theory]
		[InlineData(null, true)]
		[InlineData(new Int32[] { }, true)]
		[InlineData(new Int32[] { 1, 2, 3 }, false)]
		public void Empty_WeakList(Int32[] values, Boolean succeeds) {
			System.Collections.IList collection = values is null ? null : new System.Collections.ArrayList(values);
			if (succeeds) {
				Guard.Empty(collection, nameof(collection));
			} else {
				Assert.Throws<ArgumentNotEmptyException>(() => Guard.Empty(collection, nameof(collection)));
			}
		}

		[Theory]
		[InlineData('a', 'a', true)]
		[InlineData('a', 'b', false)]
		[InlineData('b', 'a', false)]
		public void Equal_Char(Char value, Char other, Boolean succeeds) {
			if (succeeds) {
				Guard.Equal(value, nameof(value), other);
			} else {
				Assert.Throws<ArgumentNotEqualException>(() => Guard.Equal(value, nameof(value), other));
			}
		}

		[Theory]
		[InlineData(1, 1, true)]
		[InlineData(1, 2, false)]
		[InlineData(2, 1, false)]
		public void Equal_Int32(Int32 value, Int32 other, Boolean succeeds) {
			if (succeeds) {
				Guard.Equal(value, nameof(value), other);
			} else {
				Assert.Throws<ArgumentNotEqualException>(() => Guard.Equal(value, nameof(value), other));
			}
		}

		[Theory]
		[InlineData("hi", "hi", true)]
		[InlineData("hi", "no", false)]
		[InlineData("no", "hi", false)]
		public void Equal_String(String value, String other, Boolean succeeds) {
			if (succeeds) {
				Guard.Equal(value, nameof(value), other);
			} else {
				Assert.Throws<ArgumentNotEqualException>(() => Guard.Equal(value, nameof(value), other));
			}
		}

		[Theory]
		[InlineData(0, 1, false)]
		[InlineData(1, 1, false)]
		[InlineData(2, 1, true)]
		public void GreaterThan_Int32(Int32 value, Int32 lower, Boolean succeeds) {
			if (succeeds) {
				Guard.GreaterThan(value, nameof(value), lower);
			} else if (value == lower) {
				Assert.Throws<ArgumentEqualException>(() => Guard.GreaterThan(value, nameof(value), lower));
			} else {
				Assert.Throws<ArgumentLesserThanException>(() => Guard.GreaterThan(value, nameof(value), lower));
			}
		}

		[Theory]
		[InlineData(0, 1, false)]
		[InlineData(1, 1, true)]
		[InlineData(2, 1, true)]
		public void GreaterThanOrEqual_Int32(Int32 value, Int32 lower, Boolean succeeds) {
			if (succeeds) {
				Guard.GreaterThanOrEqual(value, nameof(value), lower);
			} else {
				Assert.Throws<ArgumentLesserThanException>(() => Guard.GreaterThanOrEqual(value, nameof(value), lower));
			}
		}

		[Theory]
		[InlineData(0, 1, true)]
		[InlineData(1, 1, false)]
		[InlineData(2, 1, false)]
		public void LesserThan_Int32(Int32 value, Int32 upper, Boolean succeeds) {
			if (succeeds) {
				Guard.LesserThan(value, nameof(value), upper);
			} else if (value == upper) {
				Assert.Throws<ArgumentEqualException>(() => Guard.LesserThan(value, nameof(value), upper));
			} else {
				Assert.Throws<ArgumentGreaterThanException>(() => Guard.LesserThan(value, nameof(value), upper));
			}
		}

		[Theory]
		[InlineData(0, 1, true)]
		[InlineData(1, 1, true)]
		[InlineData(2, 1, false)]
		public void LesserThanOrEqual_Int32(Int32 value, Int32 upper, Boolean succeeds) {
			if (succeeds) {
				Guard.LesserThanOrEqual(value, nameof(value), upper);
			} else {
				Assert.Throws<ArgumentGreaterThanException>(() => Guard.LesserThanOrEqual(value, nameof(value), upper));
			}
		}

		[Theory]
		[InlineData(new Int32[] { }, false)]
		[InlineData(new Int32[] { 1, 2, 3 }, true)]
		public void NotEmpty_Array(Int32[] value, Boolean succeeds) {
			if (succeeds) {
				Guard.NotEmpty(value, nameof(value));
			} else {
				Assert.Throws<ArgumentEmptyException>(() => Guard.NotEmpty(value, nameof(value)));
			}
		}

		[Theory]
		[InlineData(null, false)]
		[InlineData("", true)]
		public void NotNull_Object(System.Object value, Boolean succeeds) {
			if (succeeds) {
				Guard.NotNull(value, nameof(value));
			} else {
				Assert.Throws<Langly.Exceptions.ArgumentNullException>(() => Guard.NotNull(value, nameof(value)));
			}
		}

		[Theory]
		[InlineData(null, false)]
		[InlineData(1, true)]
		[InlineData(1.5, false)]
		[InlineData('a', false)]
		[InlineData("hi", false)]
		public void OfType_Int32(System.Object value, Boolean succeeds) {
			if (succeeds) {
				Guard.OfType<Int32>(value, nameof(value));
			} else {
				Assert.Throws<ArgumentNotTypeException>(() => Guard.OfType<Int32>(value, nameof(value)));
			}
		}

		[Theory]
		[InlineData(-1, false)]
		[InlineData(0, true)]
		[InlineData(1, true)]
		[InlineData(15, true)]
		[InlineData(16, false)]
		public void Valid_ConsoleColor(Int32 value, Boolean succeeds) {
			if (succeeds) {
				Guard.Valid((ConsoleColor)value, nameof(value));
			} else {
				Assert.Throws<ArgumentNotValidException>(() => Guard.Valid((ConsoleColor)value, nameof(value)));
			}
		}

		[Theory]
		[InlineData(0, 1, 5, false)]
		[InlineData(1, 1, 5, true)]
		[InlineData(2, 1, 5, true)]
		[InlineData(3, 1, 5, true)]
		[InlineData(4, 1, 5, true)]
		[InlineData(5, 1, 5, true)]
		[InlineData(6, 1, 5, false)]
		public void Within_Byte(Byte value, Byte lower, Byte upper, Boolean succeeds) {
			if (succeeds) {
				Guard.Within(value, nameof(value), lower, upper);
			} else {
				Assert.Throws<ArgumentNotWithinException>(() => Guard.Within(value, nameof(value), lower, upper));
			}
		}

		[Theory]
		[InlineData(0, 1, 5, false)]
		[InlineData(1, 1, 5, true)]
		[InlineData(2, 1, 5, true)]
		[InlineData(3, 1, 5, true)]
		[InlineData(4, 1, 5, true)]
		[InlineData(5, 1, 5, true)]
		[InlineData(6, 1, 5, false)]
		public void Within_Double(Double value, Double lower, Double upper, Boolean succeeds) {
			if (succeeds) {
				Guard.Within(value, nameof(value), lower, upper);
			} else {
				Assert.Throws<ArgumentNotWithinException>(() => Guard.Within(value, nameof(value), lower, upper));
			}
		}

		[Theory]
		[InlineData(0, 1, 5, false)]
		[InlineData(1, 1, 5, true)]
		[InlineData(2, 1, 5, true)]
		[InlineData(3, 1, 5, true)]
		[InlineData(4, 1, 5, true)]
		[InlineData(5, 1, 5, true)]
		[InlineData(6, 1, 5, false)]
		public void Within_Int16(Int16 value, Int16 lower, Int16 upper, Boolean succeeds) {
			if (succeeds) {
				Guard.Within(value, nameof(value), lower, upper);
			} else {
				Assert.Throws<ArgumentNotWithinException>(() => Guard.Within(value, nameof(value), lower, upper));
			}
		}

		[Theory]
		[InlineData(0, 1, 5, false)]
		[InlineData(1, 1, 5, true)]
		[InlineData(2, 1, 5, true)]
		[InlineData(3, 1, 5, true)]
		[InlineData(4, 1, 5, true)]
		[InlineData(5, 1, 5, true)]
		[InlineData(6, 1, 5, false)]
		public void Within_Int32(Int32 value, Int32 lower, Int32 upper, Boolean succeeds) {
			if (succeeds) {
				Guard.Within(value, nameof(value), lower, upper);
			} else {
				Assert.Throws<ArgumentNotWithinException>(() => Guard.Within(value, nameof(value), lower, upper));
			}
		}

		[Theory]
		[InlineData(0, 1, 5, false)]
		[InlineData(1, 1, 5, true)]
		[InlineData(2, 1, 5, true)]
		[InlineData(3, 1, 5, true)]
		[InlineData(4, 1, 5, true)]
		[InlineData(5, 1, 5, true)]
		[InlineData(6, 1, 5, false)]
		public void Within_Int64(Int64 value, Int64 lower, Int64 upper, Boolean succeeds) {
			if (succeeds) {
				Guard.Within(value, nameof(value), lower, upper);
			} else {
				Assert.Throws<ArgumentNotWithinException>(() => Guard.Within(value, nameof(value), lower, upper));
			}
		}

		[Theory]
		[InlineData(0, 1, 5, false)]
		[InlineData(1, 1, 5, true)]
		[InlineData(2, 1, 5, true)]
		[InlineData(3, 1, 5, true)]
		[InlineData(4, 1, 5, true)]
		[InlineData(5, 1, 5, true)]
		[InlineData(6, 1, 5, false)]
		public void Within_nint(Int32 value, Int32 lower, Int32 upper, Boolean succeeds) {
			if (succeeds) {
				Guard.Within((nint)value, nameof(value), (nint)lower, (nint)upper);
			} else {
				Assert.Throws<ArgumentNotWithinException>(() => Guard.Within(value, nameof(value), lower, upper));
			}
		}

		[Theory]
		[InlineData(0, 1, 5, false)]
		[InlineData(1, 1, 5, true)]
		[InlineData(2, 1, 5, true)]
		[InlineData(3, 1, 5, true)]
		[InlineData(4, 1, 5, true)]
		[InlineData(5, 1, 5, true)]
		[InlineData(6, 1, 5, false)]
		public void Within_nuint(UInt32 value, UInt32 lower, UInt32 upper, Boolean succeeds) {
			if (succeeds) {
				Guard.Within((nuint)value, nameof(value), (nuint)lower, (nuint)upper);
			} else {
				Assert.Throws<ArgumentNotWithinException>(() => Guard.Within(value, nameof(value), lower, upper));
			}
		}

		[Theory]
		[InlineData(0, 1, 5, false)]
		[InlineData(1, 1, 5, true)]
		[InlineData(2, 1, 5, true)]
		[InlineData(3, 1, 5, true)]
		[InlineData(4, 1, 5, true)]
		[InlineData(5, 1, 5, true)]
		[InlineData(6, 1, 5, false)]
		public void Within_SByte(SByte value, SByte lower, SByte upper, Boolean succeeds) {
			if (succeeds) {
				Guard.Within(value, nameof(value), lower, upper);
			} else {
				Assert.Throws<ArgumentNotWithinException>(() => Guard.Within(value, nameof(value), lower, upper));
			}
		}

		[Theory]
		[InlineData(0, 1, 5, false)]
		[InlineData(1, 1, 5, true)]
		[InlineData(2, 1, 5, true)]
		[InlineData(3, 1, 5, true)]
		[InlineData(4, 1, 5, true)]
		[InlineData(5, 1, 5, true)]
		[InlineData(6, 1, 5, false)]
		public void Within_Single(Single value, Single lower, Single upper, Boolean succeeds) {
			if (succeeds) {
				Guard.Within(value, nameof(value), lower, upper);
			} else {
				Assert.Throws<ArgumentNotWithinException>(() => Guard.Within(value, nameof(value), lower, upper));
			}
		}

		[Theory]
		[InlineData(0, 1, 5, false)]
		[InlineData(1, 1, 5, true)]
		[InlineData(2, 1, 5, true)]
		[InlineData(3, 1, 5, true)]
		[InlineData(4, 1, 5, true)]
		[InlineData(5, 1, 5, true)]
		[InlineData(6, 1, 5, false)]
		public void Within_UInt16(UInt16 value, UInt16 lower, UInt16 upper, Boolean succeeds) {
			if (succeeds) {
				Guard.Within(value, nameof(value), lower, upper);
			} else {
				Assert.Throws<ArgumentNotWithinException>(() => Guard.Within(value, nameof(value), lower, upper));
			}
		}

		[Theory]
		[InlineData(0, 1, 5, false)]
		[InlineData(1, 1, 5, true)]
		[InlineData(2, 1, 5, true)]
		[InlineData(3, 1, 5, true)]
		[InlineData(4, 1, 5, true)]
		[InlineData(5, 1, 5, true)]
		[InlineData(6, 1, 5, false)]
		public void Within_UInt32(UInt32 value, UInt32 lower, UInt32 upper, Boolean succeeds) {
			if (succeeds) {
				Guard.Within(value, nameof(value), lower, upper);
			} else {
				Assert.Throws<ArgumentNotWithinException>(() => Guard.Within(value, nameof(value), lower, upper));
			}
		}

		[Theory]
		[InlineData(0, 1, 5, false)]
		[InlineData(1, 1, 5, true)]
		[InlineData(2, 1, 5, true)]
		[InlineData(3, 1, 5, true)]
		[InlineData(4, 1, 5, true)]
		[InlineData(5, 1, 5, true)]
		[InlineData(6, 1, 5, false)]
		public void Within_UInt64(UInt64 value, UInt64 lower, UInt64 upper, Boolean succeeds) {
			if (succeeds) {
				Guard.Within(value, nameof(value), lower, upper);
			} else {
				Assert.Throws<ArgumentNotWithinException>(() => Guard.Within(value, nameof(value), lower, upper));
			}
		}
	}
}
