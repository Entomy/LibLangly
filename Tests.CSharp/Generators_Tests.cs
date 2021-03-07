using System.Text;
using Xunit;

namespace Langly {
	public class Generators_Tests {
		private readonly Generator Generator = new Generator();

		[Fact]
		public void Boolean() => Generator.Boolean(1_000_000);

		[Fact]
		public void Byte() => Generator.Byte(1_000_000);

		[Fact]
		public void Char() => Generator.Char(1_000_000);

		[Fact]
		public void Decimal() => Generator.Decimal(1_000_000);

		[Fact]
		public void Double() => Generator.Double(1_000_000);

		[Fact]
		public void Int16() => Generator.Int16(1_000_000);

		[Fact]
		public void Int32() => Generator.Int32(1_000_000);

		[Fact]
		public void Int64() => Generator.Int64(1_000_000);

		[Fact]
		public void IntPtr() => Generator.IntPtr(1_000_000);

		[Fact]
		public void Rune() => Generator.Rune(1_000_000);

		[Fact]
		public void SByte() => Generator.SByte(1_000_000);

		[Fact]
		public void Single() => Generator.Single(1_000_000);

		[Fact]
		public void UInt16() => Generator.UInt16(1_000_000);

		[Fact]
		public void UInt32() => Generator.UInt32(1_000_000);

		[Fact]
		public void UInt64() => Generator.UInt64(1_000_000);

		[Fact]
		public void UIntPtr() => Generator.UIntPtr(1_000_000);
	}
}
