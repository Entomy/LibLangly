using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class CharTests {
		[TestMethod]
		public void Join() {
			Assert.AreEqual("hello", new Char[]{ 'h', 'e', 'l', 'l', 'o' }.Join());
			Assert.AreEqual("h e l l o", new Char[] { 'h', 'e', 'l', 'l', 'o' }.Join(' '));
		}

		[DataTestMethod]
		[DataRow(1, '1')]
		[DataRow(2, '2')]
		[DataRow(3, '3')]
		[DataRow(4, '4')]
		[DataRow(5, '5')]
		[DataRow(6, '6')]
		[DataRow(7, '7')]
		[DataRow(8, '8')]
		[DataRow(9, '9')]
		public void ParseInt32(Int32 Expected, Char Char) {
			Assert.AreEqual(Expected, Char.ParseInt32());
		}

		[DataTestMethod]
		[DataRow(0x1, '1')]
		[DataRow(0x2, '2')]
		[DataRow(0x3, '3')]
		[DataRow(0x4, '4')]
		[DataRow(0x5, '5')]
		[DataRow(0x6, '6')]
		[DataRow(0x7, '7')]
		[DataRow(0x8, '8')]
		[DataRow(0x9, '9')]
		[DataRow(0xA, 'A')]
		[DataRow(0xB, 'B')]
		[DataRow(0xC, 'C')]
		[DataRow(0xD, 'D')]
		[DataRow(0xE, 'E')]
		[DataRow(0xF, 'F')]
		public void ParseInt32Hex(Int32 Expected, Char Char) {
			Assert.AreEqual(Expected, Char.ParseInt32(NumberStyles.HexNumber));
		}
	}
}