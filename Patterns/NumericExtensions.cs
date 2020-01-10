using System;
using Stringier.Patterns.Nodes;

namespace Stringier.Patterns {
	public static class NumericExtensions {
		public static Pattern AsPattern(this Byte value) {
			switch (value) {
			case 0:
				return new CharLiteral('0');
			case 1:
				return new CharLiteral('1');
			case 2:
				return new CharLiteral('2');
			case 3:
				return new CharLiteral('3');
			case 4:
				return new CharLiteral('4');
			case 5:
				return new CharLiteral('5');
			case 6:
				return new CharLiteral('6');
			case 7:
				return new CharLiteral('7');
			case 8:
				return new CharLiteral('8');
			case 9:
				return new CharLiteral('9');
			default:
				return new StringLiteral(value.ToString());
			}
		}

		[CLSCompliant(false)]
		public static Pattern AsPattern(this SByte value) {
			switch (value) {
			case 0:
				return new CharLiteral('0');
			case 1:
				return new CharLiteral('1');
			case 2:
				return new CharLiteral('2');
			case 3:
				return new CharLiteral('3');
			case 4:
				return new CharLiteral('4');
			case 5:
				return new CharLiteral('5');
			case 6:
				return new CharLiteral('6');
			case 7:
				return new CharLiteral('7');
			case 8:
				return new CharLiteral('8');
			case 9:
				return new CharLiteral('9');
			default:
				return new StringLiteral(value.ToString());
			}
		}

		[CLSCompliant(false)]
		public static Pattern AsPattern(this UInt16 value) {
			switch (value) {
			case 0:
				return new CharLiteral('0');
			case 1:
				return new CharLiteral('1');
			case 2:
				return new CharLiteral('2');
			case 3:
				return new CharLiteral('3');
			case 4:
				return new CharLiteral('4');
			case 5:
				return new CharLiteral('5');
			case 6:
				return new CharLiteral('6');
			case 7:
				return new CharLiteral('7');
			case 8:
				return new CharLiteral('8');
			case 9:
				return new CharLiteral('9');
			default:
				return new StringLiteral(value.ToString());
			}
		}

		public static Pattern AsPattern(this Int16 value) {
			switch (value) {
			case 0:
				return new CharLiteral('0');
			case 1:
				return new CharLiteral('1');
			case 2:
				return new CharLiteral('2');
			case 3:
				return new CharLiteral('3');
			case 4:
				return new CharLiteral('4');
			case 5:
				return new CharLiteral('5');
			case 6:
				return new CharLiteral('6');
			case 7:
				return new CharLiteral('7');
			case 8:
				return new CharLiteral('8');
			case 9:
				return new CharLiteral('9');
			default:
				return new StringLiteral(value.ToString());
			}
		}

		[CLSCompliant(false)]
		public static Pattern AsPattern(this UInt32 value) {
			switch (value) {
			case 0:
				return new CharLiteral('0');
			case 1:
				return new CharLiteral('1');
			case 2:
				return new CharLiteral('2');
			case 3:
				return new CharLiteral('3');
			case 4:
				return new CharLiteral('4');
			case 5:
				return new CharLiteral('5');
			case 6:
				return new CharLiteral('6');
			case 7:
				return new CharLiteral('7');
			case 8:
				return new CharLiteral('8');
			case 9:
				return new CharLiteral('9');
			default:
				return new StringLiteral(value.ToString());
			}
		}

		public static Pattern AsPattern(this Int32 value) {
			switch (value) {
			case 0:
				return new CharLiteral('0');
			case 1:
				return new CharLiteral('1');
			case 2:
				return new CharLiteral('2');
			case 3:
				return new CharLiteral('3');
			case 4:
				return new CharLiteral('4');
			case 5:
				return new CharLiteral('5');
			case 6:
				return new CharLiteral('6');
			case 7:
				return new CharLiteral('7');
			case 8:
				return new CharLiteral('8');
			case 9:
				return new CharLiteral('9');
			default:
				return new StringLiteral(value.ToString());
			}
		}

		[CLSCompliant(false)]
		public static Pattern AsPattern(this UInt64 value) {
			switch (value) {
			case 0:
				return new CharLiteral('0');
			case 1:
				return new CharLiteral('1');
			case 2:
				return new CharLiteral('2');
			case 3:
				return new CharLiteral('3');
			case 4:
				return new CharLiteral('4');
			case 5:
				return new CharLiteral('5');
			case 6:
				return new CharLiteral('6');
			case 7:
				return new CharLiteral('7');
			case 8:
				return new CharLiteral('8');
			case 9:
				return new CharLiteral('9');
			default:
				return new StringLiteral(value.ToString());
			}
		}

		public static Pattern AsPattern(this Int64 value) {
			switch (value) {
			case 0:
				return new CharLiteral('0');
			case 1:
				return new CharLiteral('1');
			case 2:
				return new CharLiteral('2');
			case 3:
				return new CharLiteral('3');
			case 4:
				return new CharLiteral('4');
			case 5:
				return new CharLiteral('5');
			case 6:
				return new CharLiteral('6');
			case 7:
				return new CharLiteral('7');
			case 8:
				return new CharLiteral('8');
			case 9:
				return new CharLiteral('9');
			default:
				return new StringLiteral(value.ToString());
			}
		}
	}
}
