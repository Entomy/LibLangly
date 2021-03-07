using System;
using Xunit;

namespace Langly {
	public class Generators_Tests {
		private readonly Generator Generator = new Generator();

		[Fact]
		public void Byte() {
			for (nint i = 0; i < 1_000_000; i++) {
				_ = Generator.Byte();
			}
		}

		[Fact]
		public void Char() {
			for (nint i = 0; i < 1_000_000; i++) {
				_ = Generator.Char();
			}
		}

		[Fact]
		public void Double() {
			for (nint i = 0; i < 1_000_000; i++) {
				_ = Generator.Double();
			}
		}

		[Fact]
		public void Int16() {
			for (nint i = 0; i < 1_000_000; i++) {
				_ = Generator.Int16();
			}
		}

		[Fact]
		public void Int32() {
			for (nint i = 0; i < 1_000_000; i++) {
				_ = Generator.Int32();
			}
		}

		[Fact]
		public void Int64() {
			for (nint i = 0; i < 1_000_000; i++) {
				_ = Generator.Int64();
			}
		}

		[Fact]
		public void IntPtr() {
			for (nint i = 0; i < 1_000_000; i++) {
				_ = Generator.IntPtr();
			}
		}

		[Fact]
		public void SByte() {
			for (nint i = 0; i < 1_000_000; i++) {
				_ = Generator.SByte();
			}
		}
		[Fact]
		public void Single() {
			for (nint i = 0; i < 1_000_000; i++) {
				_ = Generator.Single();
			}
		}

		[Fact]
		public void UInt16() {
			for (nint i = 0; i < 1_000_000; i++) {
				_ = Generator.UInt16();
			}
		}

		[Fact]
		public void UInt32() {
			for (nint i = 0; i < 1_000_000; i++) {
				_ = Generator.UInt32();
			}
		}

		[Fact]
		public void UInt64() {
			for (nint i = 0; i < 1_000_000; i++) {
				_ = Generator.UInt64();
			}
		}

		[Fact]
		public void UIntPtr() {
			for (nint i = 0; i < 1_000_000; i++) {
				_ = Generator.UIntPtr();
			}
		}
	}
}
