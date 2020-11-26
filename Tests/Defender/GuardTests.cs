using System;
using Xunit;
using Langly;

namespace Defender {
	public class GuardTests {
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
		[InlineData(null, false)]
		[InlineData(1, true)]
		[InlineData(1.5, false)]
		[InlineData('a', false)]
		[InlineData("hi", false)]
		public void OfType_Int32(Object value, Boolean succeeds) {
			if (succeeds) {
				Guard.OfType<Int32>(value, nameof(value));
			} else {
				Assert.Throws<ArgumentNotTypeException>(() => Guard.OfType<Int32>(value, nameof(value)));
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
		public void NotNull_Object(Object value, Boolean succeeds) {
			if (succeeds) {
				Guard.NotNull(value, nameof(value));
			} else {
				Assert.Throws<Langly.ArgumentNullException>(() => Guard.NotNull(value, nameof(value)));
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
		public void Within_UInt32(UInt32 value, UInt32 lower, UInt32 upper, Boolean succeeds) {
			if (succeeds) {
				Guard.Within(value, nameof(value), lower, upper);
			} else {
				Assert.Throws<ArgumentNotWithinException>(() => Guard.Within(value, nameof(value), lower, upper));
			}
		}
	}
}
