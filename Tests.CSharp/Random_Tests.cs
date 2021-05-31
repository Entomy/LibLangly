using System;
using System.Text;
using Numbersome;
using Xunit;

namespace Langly {
	public class Random_Tests {
		private readonly Numbersome.Random Random = new();

		[Fact]
		public void NextBooleans() {
			foreach (Boolean value in Random.NextBooleans(1_000)) { }
		}

		[Fact]
		public void NextBytes() {
			foreach (Byte value in Random.NextBytes(1_000)) { }
		}

		[Fact]
		public void NextBytes_Range() {
			Byte min = 0;
			Byte max = Byte.MaxValue;
			foreach (Byte value in Random.NextBytes(1_000, min, max)) {
				Assert.True(min <= value && value <= max);
			}
		}

		[Fact]
		public void NextChars() {
			foreach (Char value in Random.NextChars(1_000)) { }
		}

		[Fact]
		public void NextChars_Range() {
			Char min = 'a';
			Char max = 'z';
			foreach (Char value in Random.NextChars(1_000, min, max)) {
				Assert.True(min <= value && value <= max);
			}
		}

		[Fact]
		public void NextDecimals() {
			foreach (Decimal value in Random.NextDecimals(1_000)) { }
		}

		[Fact]
		public void NextDecimals_Range() {
			Decimal min = 0m;
			Decimal max = Decimal.MaxValue;
			foreach (Decimal value in Random.NextDecimals(1_000, min, max)) {
				Assert.True(min <= value && value <= max);
			}
		}

		[Fact]
		public void NextDoubles() {
			foreach (Double value in Random.NextDouble(1_000)) { }
		}

		[Fact]
		public void NextDoubles_Range() {
			Double min = 0.0;
			Double max = Double.MaxValue;
			foreach (Double value in Random.NextDoubles(1_000, min, max)) {
				Assert.True(min <= value && value <= max);
			}
		}

		[Fact]
		public void NextInt16s() {
			foreach (Int16 value in Random.NextInt16s(1_000)) { }
		}

		[Fact]
		public void NextInt16s_Range() {
			Int16 min = 0;
			Int16 max = Int16.MaxValue;
			foreach (Int16 value in Random.NextInt16s(1_000, min, max)) {
				Assert.True(min <= value && value <= max);
			}
		}

		[Fact]
		public void NextInt32s() {
			foreach (Int32 value in Random.NextInt32s(1_000)) { }
		}

		[Fact]
		public void NextInt32s_Range() {
			Int32 min = 0;
			Int32 max = Int32.MaxValue;
			foreach (Int32 value in Random.NextInt32s(1_000, min, max)) {
				Assert.True(min <= value && value <= max);
			}
		}

		[Fact]
		public void NextInt64s() {
			foreach (Int64 value in Random.NextInt64s(1_000)) { }
		}

		[Fact]
		public void NextInt64s_Range() {
			Int64 min = 0;
			Int64 max = Int64.MaxValue;
			foreach (Int64 value in Random.NextInt64s(1_000, min, max)) {
				Assert.True(min <= value && value <= max);
			}
		}

		[Fact]
		public void NextRunes() {
			foreach (Rune value in Random.NextRunes(1_000)) { }
		}

		[Fact]
		public void NextRunes_Range() {
			Rune min = new Rune('a'); // Latin-A
			Rune max = new Rune(0x1D11E); // 𝄞 G-Clef
			foreach (Rune value in Random.NextRunes(1_000, min, max)) {
				Assert.True(min <= value && value <= max);
			}
		}

		[Fact]
		public void NextSBytes() {
			foreach (SByte value in Random.NextSBytes(1_000)) { }
		}

		[Fact]
		public void NextSBytes_Range() {
			SByte min = 0;
			SByte max = SByte.MaxValue;
			foreach (SByte value in Random.NextSBytes(1_000, min, max)) {
				Assert.True(min <= value && value <= max);
			}
		}
		[Fact]
		public void NextSingles() {
			foreach (Single value in Random.NextSingles(1_000)) { }
		}

		[Fact]
		public void NextSingles_Range() {
			Single min = 0.0f;
			Single max = Single.MaxValue;
			foreach (Single value in Random.NextSingles(1_000, min, max)) {
				Assert.True(min <= value && value <= max);
			}
		}

		[Fact]
		public void NextUInt16s() {
			foreach (UInt16 value in Random.NextUInt16s(1_000)) { }
		}

		[Fact]
		public void NextUInt16s_Range() {
			UInt16 min = 0;
			UInt16 max = UInt16.MaxValue / 2;
			foreach (UInt16 value in Random.NextUInt16s(1_000, min, max)) {
				Assert.True(min <= value && value <= max);
			}
		}

		[Fact]
		public void NextUInt32s() {
			foreach (UInt32 value in Random.NextUInt32s(1_000)) { }
		}

		[Fact]
		public void NextUInt32s_Range() {
			UInt32 min = 0;
			UInt32 max = UInt32.MaxValue / 2;
			foreach (UInt32 value in Random.NextUInt32s(1_000, min, max)) {
				Assert.True(min <= value && value <= max);
			}
		}

		[Fact]
		public void NextUInt64s() {
			foreach (UInt64 value in Random.NextUInt64s(1_000)) { }
		}

		[Fact]
		public void NextUInt64s_Range() {
			UInt64 min = 0;
			UInt64 max = UInt64.MaxValue / 2;
			foreach (UInt64 value in Random.NextUInt64s(1_000, min, max)) {
				Assert.True(min <= value && value <= max);
			}
		}
	}
}
