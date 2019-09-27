using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class CheckerTests {
		[TestMethod]
		public void StringCheckerConsume() {
			//!This is a sophisticated, therefore fragile, pattern type. It needs to be exhaustively tested against a very large battery. Do not remove these no matter how redundant they may seem, for they are not.

			Pattern StringChecker = Pattern.Check(nameof(StringChecker),
				(Char) => Char.IsLetter() || Char == '_', true,
				(Char) => Char.IsLetterOrDigit() || Char == '_' || Char == '-', true,
				(Char) => Char.IsLetterOrDigit(), true);
			Assert.That.Fails(StringChecker.Consume("a"));
			Assert.That.Fails(StringChecker.Consume("a "));
			Assert.That.Fails(StringChecker.Consume("aa"));
			Assert.That.Fails(StringChecker.Consume("aa "));
			Assert.That.Fails(StringChecker.Consume("_a"));
			Assert.That.Fails(StringChecker.Consume("_a "));
			Assert.That.Fails(StringChecker.Consume("a_"));
			Assert.That.Fails(StringChecker.Consume("a_ "));
			Assert.That.Fails(StringChecker.Consume("1b"));
			Assert.That.Fails(StringChecker.Consume("1b "));
			Assert.That.Fails(StringChecker.Consume("a2"));
			Assert.That.Fails(StringChecker.Consume("a2 "));
			Assert.That.Fails(StringChecker.Consume("12"));
			Assert.That.Fails(StringChecker.Consume("12 "));
			Assert.That.Captures("abc", StringChecker.Consume("abc"));
			Assert.That.Captures("abc", StringChecker.Consume("abc "));
			Assert.That.Captures("_bc", StringChecker.Consume("_bc"));
			Assert.That.Captures("_bc", StringChecker.Consume("_bc "));
			Assert.That.Captures("a_c", StringChecker.Consume("a_c"));
			Assert.That.Captures("a_c", StringChecker.Consume("a_c "));
			Assert.That.Fails(StringChecker.Consume("ab_"));
			Assert.That.Fails(StringChecker.Consume("ab_ "));
			Assert.That.Fails(StringChecker.Consume("-bc"));
			Assert.That.Fails(StringChecker.Consume("-bc "));
			Assert.That.Captures("a-c", StringChecker.Consume("a-c"));
			Assert.That.Captures("a-c", StringChecker.Consume("a-c "));
			Assert.That.Fails(StringChecker.Consume("ab-"));
			Assert.That.Fails(StringChecker.Consume("ab- "));
			Assert.That.Fails(StringChecker.Consume("1bc"));
			Assert.That.Fails(StringChecker.Consume("1bc "));
			Assert.That.Captures("a2c", StringChecker.Consume("a2c"));
			Assert.That.Captures("a2c", StringChecker.Consume("a2c "));
			Assert.That.Captures("ab3", StringChecker.Consume("ab3"));
			Assert.That.Captures("ab3", StringChecker.Consume("ab3 "));
			Assert.That.Captures("a23", StringChecker.Consume("a23"));
			Assert.That.Captures("a23", StringChecker.Consume("a23 "));
			Assert.That.Fails(StringChecker.Consume("123"));
			Assert.That.Fails(StringChecker.Consume("123 "));
			Assert.That.Captures("a_cde", StringChecker.Consume("a_cde"));
			Assert.That.Captures("a_cde", StringChecker.Consume("a_cde "));
			Assert.That.Captures("ab_de", StringChecker.Consume("ab_de"));
			Assert.That.Captures("ab_de", StringChecker.Consume("ab_de "));
			Assert.That.Captures("abc_e", StringChecker.Consume("abc_e"));
			Assert.That.Captures("abc_e", StringChecker.Consume("abc_e "));
			Assert.That.Captures("a__de", StringChecker.Consume("a__de"));
			Assert.That.Captures("a__de", StringChecker.Consume("a__de "));
			Assert.That.Captures("ab__e", StringChecker.Consume("ab__e"));
			Assert.That.Captures("ab__e", StringChecker.Consume("ab__e "));
			Assert.That.Captures("a_c_e", StringChecker.Consume("a_c_e"));
			Assert.That.Captures("a_c_e", StringChecker.Consume("a_c_e "));
			Assert.That.Captures("a___e", StringChecker.Consume("a___e"));
			Assert.That.Captures("a___e", StringChecker.Consume("a___e "));

			StringChecker = Pattern.Check(nameof(StringChecker),
				(Char) => Char.IsLetter() || Char == '_', false,
				(Char) => Char.IsLetterOrDigit() || Char == '_' || Char == '-', true,
				(Char) => Char.IsLetterOrDigit(), true);
			Assert.That.Fails(StringChecker.Consume("a"));
			Assert.That.Fails(StringChecker.Consume("a "));
			Assert.That.Captures("aa", StringChecker.Consume("aa"));
			Assert.That.Captures("aa", StringChecker.Consume("aa "));
			Assert.That.Captures("_a", StringChecker.Consume("_a"));
			Assert.That.Captures("_a", StringChecker.Consume("_a "));
			Assert.That.Fails(StringChecker.Consume("a_"));
			Assert.That.Fails(StringChecker.Consume("a_ "));
			Assert.That.Captures("1b", StringChecker.Consume("1b"));
			Assert.That.Captures("1b", StringChecker.Consume("1b "));
			Assert.That.Captures("a2", StringChecker.Consume("a2"));
			Assert.That.Captures("a2", StringChecker.Consume("a2 "));
			Assert.That.Captures("12", StringChecker.Consume("12"));
			Assert.That.Captures("12", StringChecker.Consume("12 "));
			Assert.That.Captures("abc", StringChecker.Consume("abc"));
			Assert.That.Captures("abc", StringChecker.Consume("abc "));
			Assert.That.Captures("_bc", StringChecker.Consume("_bc"));
			Assert.That.Captures("_bc", StringChecker.Consume("_bc "));
			Assert.That.Captures("a_c", StringChecker.Consume("a_c"));
			Assert.That.Captures("a_c", StringChecker.Consume("a_c "));
			Assert.That.Fails(StringChecker.Consume("ab_"));
			Assert.That.Fails(StringChecker.Consume("ab_ "));
			Assert.That.Captures("-bc", StringChecker.Consume("-bc"));
			Assert.That.Captures("-bc", StringChecker.Consume("-bc "));
			Assert.That.Captures("a-c", StringChecker.Consume("a-c"));
			Assert.That.Captures("a-c", StringChecker.Consume("a-c "));
			Assert.That.Fails(StringChecker.Consume("ab-"));
			Assert.That.Fails(StringChecker.Consume("ab- "));
			Assert.That.Captures("1bc", StringChecker.Consume("1bc"));
			Assert.That.Captures("1bc", StringChecker.Consume("1bc "));
			Assert.That.Captures("a2c", StringChecker.Consume("a2c"));
			Assert.That.Captures("a2c", StringChecker.Consume("a2c "));
			Assert.That.Captures("ab3", StringChecker.Consume("ab3"));
			Assert.That.Captures("ab3", StringChecker.Consume("ab3 "));
			Assert.That.Captures("a23", StringChecker.Consume("a23"));
			Assert.That.Captures("a23", StringChecker.Consume("a23 "));
			Assert.That.Captures("123", StringChecker.Consume("123"));
			Assert.That.Captures("123", StringChecker.Consume("123 "));
			Assert.That.Captures("a_cde", StringChecker.Consume("a_cde"));
			Assert.That.Captures("a_cde", StringChecker.Consume("a_cde "));
			Assert.That.Captures("ab_de", StringChecker.Consume("ab_de"));
			Assert.That.Captures("ab_de", StringChecker.Consume("ab_de "));
			Assert.That.Captures("abc_e", StringChecker.Consume("abc_e"));
			Assert.That.Captures("abc_e", StringChecker.Consume("abc_e "));
			Assert.That.Captures("a__de", StringChecker.Consume("a__de"));
			Assert.That.Captures("a__de", StringChecker.Consume("a__de "));
			Assert.That.Captures("ab__e", StringChecker.Consume("ab__e"));
			Assert.That.Captures("ab__e", StringChecker.Consume("ab__e "));
			Assert.That.Captures("a_c_e", StringChecker.Consume("a_c_e"));
			Assert.That.Captures("a_c_e", StringChecker.Consume("a_c_e "));
			Assert.That.Captures("a___e", StringChecker.Consume("a___e"));
			Assert.That.Captures("a___e", StringChecker.Consume("a___e "));

			StringChecker = Pattern.Check(nameof(StringChecker),
				(Char) => Char.IsLetter() || Char == '_', true,
				(Char) => Char.IsLetterOrDigit() || Char == '_' || Char == '-', false,
				(Char) => Char.IsLetterOrDigit(), true);
			Assert.That.Fails(StringChecker.Consume("a"));
			Assert.That.Fails(StringChecker.Consume("a "));
			Assert.That.Captures("aa", StringChecker.Consume("aa"));
			Assert.That.Captures("aa", StringChecker.Consume("aa "));
			Assert.That.Captures("_a", StringChecker.Consume("_a"));
			Assert.That.Captures("_a", StringChecker.Consume("_a "));
			Assert.That.Fails(StringChecker.Consume("a_"));
			Assert.That.Fails(StringChecker.Consume("a_ "));
			Assert.That.Fails(StringChecker.Consume("1b"));
			Assert.That.Fails(StringChecker.Consume("1b "));
			Assert.That.Captures("a2", StringChecker.Consume("a2"));
			Assert.That.Captures("a2", StringChecker.Consume("a2 "));
			Assert.That.Fails(StringChecker.Consume("12"));
			Assert.That.Fails(StringChecker.Consume("12 "));
			Assert.That.Captures("abc", StringChecker.Consume("abc"));
			Assert.That.Captures("abc", StringChecker.Consume("abc "));
			Assert.That.Captures("_bc", StringChecker.Consume("_bc"));
			Assert.That.Captures("_bc", StringChecker.Consume("_bc "));
			Assert.That.Captures("a_c", StringChecker.Consume("a_c"));
			Assert.That.Captures("a_c", StringChecker.Consume("a_c "));
			Assert.That.Fails(StringChecker.Consume("ab_"));
			Assert.That.Fails(StringChecker.Consume("ab_ "));
			Assert.That.Fails(StringChecker.Consume("-bc"));
			Assert.That.Fails(StringChecker.Consume("-bc "));
			Assert.That.Captures("a-c", StringChecker.Consume("a-c"));
			Assert.That.Captures("a-c", StringChecker.Consume("a-c "));
			Assert.That.Fails(StringChecker.Consume("ab-"));
			Assert.That.Fails(StringChecker.Consume("ab- "));
			Assert.That.Fails(StringChecker.Consume("1bc"));
			Assert.That.Fails(StringChecker.Consume("1bc "));
			Assert.That.Captures("a2c", StringChecker.Consume("a2c"));
			Assert.That.Captures("a2c", StringChecker.Consume("a2c "));
			Assert.That.Captures("ab3", StringChecker.Consume("ab3"));
			Assert.That.Captures("ab3", StringChecker.Consume("ab3 "));
			Assert.That.Captures("a23", StringChecker.Consume("a23"));
			Assert.That.Captures("a23", StringChecker.Consume("a23 "));
			Assert.That.Fails(StringChecker.Consume("123"));
			Assert.That.Fails(StringChecker.Consume("123 "));
			Assert.That.Captures("a_cde", StringChecker.Consume("a_cde"));
			Assert.That.Captures("a_cde", StringChecker.Consume("a_cde "));
			Assert.That.Captures("ab_de", StringChecker.Consume("ab_de"));
			Assert.That.Captures("ab_de", StringChecker.Consume("ab_de "));
			Assert.That.Captures("abc_e", StringChecker.Consume("abc_e"));
			Assert.That.Captures("abc_e", StringChecker.Consume("abc_e "));
			Assert.That.Captures("a__de", StringChecker.Consume("a__de"));
			Assert.That.Captures("a__de", StringChecker.Consume("a__de "));
			Assert.That.Captures("ab__e", StringChecker.Consume("ab__e"));
			Assert.That.Captures("ab__e", StringChecker.Consume("ab__e "));
			Assert.That.Captures("a_c_e", StringChecker.Consume("a_c_e"));
			Assert.That.Captures("a_c_e", StringChecker.Consume("a_c_e "));
			Assert.That.Captures("a___e", StringChecker.Consume("a___e"));
			Assert.That.Captures("a___e", StringChecker.Consume("a___e "));

			StringChecker = Pattern.Check(nameof(StringChecker),
				(Char) => Char.IsLetter() || Char == '_', true,
				(Char) => Char.IsLetterOrDigit() || Char == '_' || Char == '-', true,
				(Char) => Char.IsLetterOrDigit(), false);
			Assert.That.Fails(StringChecker.Consume("a"));
			Assert.That.Fails(StringChecker.Consume("a "));
			Assert.That.Captures("aa", StringChecker.Consume("aa"));
			Assert.That.Captures("aa", StringChecker.Consume("aa "));
			Assert.That.Captures("_a", StringChecker.Consume("_a"));
			Assert.That.Captures("_a", StringChecker.Consume("_a "));
			Assert.That.Captures("a_", StringChecker.Consume("a_"));
			Assert.That.Captures("a_", StringChecker.Consume("a_ "));
			Assert.That.Fails(StringChecker.Consume("1b"));
			Assert.That.Fails(StringChecker.Consume("1b "));
			Assert.That.Captures("a2", StringChecker.Consume("a2"));
			Assert.That.Captures("a2", StringChecker.Consume("a2 "));
			Assert.That.Fails(StringChecker.Consume("12"));
			Assert.That.Fails(StringChecker.Consume("12 "));
			Assert.That.Captures("abc", StringChecker.Consume("abc"));
			Assert.That.Captures("abc", StringChecker.Consume("abc "));
			Assert.That.Captures("_bc", StringChecker.Consume("_bc"));
			Assert.That.Captures("_bc", StringChecker.Consume("_bc "));
			Assert.That.Captures("a_c", StringChecker.Consume("a_c"));
			Assert.That.Captures("a_c", StringChecker.Consume("a_c "));
			Assert.That.Captures("ab_", StringChecker.Consume("ab_"));
			Assert.That.Captures("ab_", StringChecker.Consume("ab_ "));
			Assert.That.Fails(StringChecker.Consume("-bc"));
			Assert.That.Fails(StringChecker.Consume("-bc "));
			Assert.That.Captures("a-c", StringChecker.Consume("a-c"));
			Assert.That.Captures("a-c", StringChecker.Consume("a-c "));
			Assert.That.Captures("ab-", StringChecker.Consume("ab-"));
			Assert.That.Captures("ab-", StringChecker.Consume("ab- "));
			Assert.That.Fails(StringChecker.Consume("1bc"));
			Assert.That.Fails(StringChecker.Consume("1bc "));
			Assert.That.Captures("a2c", StringChecker.Consume("a2c"));
			Assert.That.Captures("a2c", StringChecker.Consume("a2c "));
			Assert.That.Captures("ab3", StringChecker.Consume("ab3"));
			Assert.That.Captures("ab3", StringChecker.Consume("ab3 "));
			Assert.That.Captures("a23", StringChecker.Consume("a23"));
			Assert.That.Captures("a23", StringChecker.Consume("a23 "));
			Assert.That.Fails(StringChecker.Consume("123"));
			Assert.That.Fails(StringChecker.Consume("123 "));
			Assert.That.Captures("a_cde", StringChecker.Consume("a_cde"));
			Assert.That.Captures("a_cde", StringChecker.Consume("a_cde "));
			Assert.That.Captures("ab_de", StringChecker.Consume("ab_de"));
			Assert.That.Captures("ab_de", StringChecker.Consume("ab_de "));
			Assert.That.Captures("abc_e", StringChecker.Consume("abc_e"));
			Assert.That.Captures("abc_e", StringChecker.Consume("abc_e "));
			Assert.That.Captures("a__de", StringChecker.Consume("a__de"));
			Assert.That.Captures("a__de", StringChecker.Consume("a__de "));
			Assert.That.Captures("ab__e", StringChecker.Consume("ab__e"));
			Assert.That.Captures("ab__e", StringChecker.Consume("ab__e "));
			Assert.That.Captures("a_c_e", StringChecker.Consume("a_c_e"));
			Assert.That.Captures("a_c_e", StringChecker.Consume("a_c_e "));
			Assert.That.Captures("a___e", StringChecker.Consume("a___e"));
			Assert.That.Captures("a___e", StringChecker.Consume("a___e "));

			StringChecker = Pattern.Check(nameof(StringChecker),
				(Char) => Char.IsLetter() || Char == '_', false,
				(Char) => Char.IsLetterOrDigit() || Char == '_' || Char == '-', false,
				(Char) => Char.IsLetterOrDigit(), true);
			Assert.That.Captures("a", StringChecker.Consume("a"));
			Assert.That.Captures("a", StringChecker.Consume("a "));
			Assert.That.Captures("1", StringChecker.Consume("1"));
			Assert.That.Captures("1", StringChecker.Consume("1 "));
			Assert.That.Captures("aa", StringChecker.Consume("aa"));
			Assert.That.Captures("aa", StringChecker.Consume("aa "));
			Assert.That.Captures("_a", StringChecker.Consume("_a"));
			Assert.That.Captures("_a", StringChecker.Consume("_a "));
			Assert.That.Fails(StringChecker.Consume("a_"));
			Assert.That.Fails(StringChecker.Consume("a_ "));
			Assert.That.Captures("1b", StringChecker.Consume("1b"));
			Assert.That.Captures("1b", StringChecker.Consume("1b "));
			Assert.That.Captures("a2", StringChecker.Consume("a2"));
			Assert.That.Captures("a2", StringChecker.Consume("a2 "));
			Assert.That.Captures("12", StringChecker.Consume("12"));
			Assert.That.Captures("12", StringChecker.Consume("12 "));
			Assert.That.Captures("abc", StringChecker.Consume("abc"));
			Assert.That.Captures("abc", StringChecker.Consume("abc "));
			Assert.That.Captures("_bc", StringChecker.Consume("_bc"));
			Assert.That.Captures("_bc", StringChecker.Consume("_bc "));
			Assert.That.Captures("a_c", StringChecker.Consume("a_c"));
			Assert.That.Captures("a_c", StringChecker.Consume("a_c "));
			Assert.That.Fails(StringChecker.Consume("ab_"));
			Assert.That.Fails(StringChecker.Consume("ab_ "));
			Assert.That.Captures("-bc", StringChecker.Consume("-bc"));
			Assert.That.Captures("-bc", StringChecker.Consume("-bc "));
			Assert.That.Captures("a-c", StringChecker.Consume("a-c"));
			Assert.That.Captures("a-c", StringChecker.Consume("a-c "));
			Assert.That.Fails(StringChecker.Consume("ab-"));
			Assert.That.Fails(StringChecker.Consume("ab- "));
			Assert.That.Captures("1bc", StringChecker.Consume("1bc"));
			Assert.That.Captures("1bc", StringChecker.Consume("1bc "));
			Assert.That.Captures("a2c", StringChecker.Consume("a2c"));
			Assert.That.Captures("a2c", StringChecker.Consume("a2c "));
			Assert.That.Captures("ab3", StringChecker.Consume("ab3"));
			Assert.That.Captures("ab3", StringChecker.Consume("ab3 "));
			Assert.That.Captures("a23", StringChecker.Consume("a23"));
			Assert.That.Captures("a23", StringChecker.Consume("a23 "));
			Assert.That.Captures("123", StringChecker.Consume("123"));
			Assert.That.Captures("123", StringChecker.Consume("123 "));
			Assert.That.Captures("a_cde", StringChecker.Consume("a_cde"));
			Assert.That.Captures("a_cde", StringChecker.Consume("a_cde "));
			Assert.That.Captures("ab_de", StringChecker.Consume("ab_de"));
			Assert.That.Captures("ab_de", StringChecker.Consume("ab_de "));
			Assert.That.Captures("abc_e", StringChecker.Consume("abc_e"));
			Assert.That.Captures("abc_e", StringChecker.Consume("abc_e "));
			Assert.That.Captures("a__de", StringChecker.Consume("a__de"));
			Assert.That.Captures("a__de", StringChecker.Consume("a__de "));
			Assert.That.Captures("ab__e", StringChecker.Consume("ab__e"));
			Assert.That.Captures("ab__e", StringChecker.Consume("ab__e "));
			Assert.That.Captures("a_c_e", StringChecker.Consume("a_c_e"));
			Assert.That.Captures("a_c_e", StringChecker.Consume("a_c_e "));
			Assert.That.Captures("a___e", StringChecker.Consume("a___e"));
			Assert.That.Captures("a___e", StringChecker.Consume("a___e "));

			StringChecker = Pattern.Check(nameof(StringChecker),
				(Char) => Char.IsLetter() || Char == '_', false,
				(Char) => Char.IsLetterOrDigit() || Char == '_' || Char == '-', true,
				(Char) => Char.IsLetterOrDigit(), false);
			Assert.That.Captures("a", StringChecker.Consume("a"));
			Assert.That.Captures("a", StringChecker.Consume("a "));
			Assert.That.Captures("1", StringChecker.Consume("1"));
			Assert.That.Captures("1", StringChecker.Consume("1 "));
			Assert.That.Captures("aa", StringChecker.Consume("aa"));
			Assert.That.Captures("aa", StringChecker.Consume("aa "));
			Assert.That.Captures("_a", StringChecker.Consume("_a"));
			Assert.That.Captures("_a", StringChecker.Consume("_a "));
			Assert.That.Captures("a_", StringChecker.Consume("a_"));
			Assert.That.Captures("a_", StringChecker.Consume("a_ "));
			Assert.That.Captures("1b", StringChecker.Consume("1b"));
			Assert.That.Captures("1b", StringChecker.Consume("1b "));
			Assert.That.Captures("a2", StringChecker.Consume("a2"));
			Assert.That.Captures("a2", StringChecker.Consume("a2 "));
			Assert.That.Captures("12", StringChecker.Consume("12"));
			Assert.That.Captures("12", StringChecker.Consume("12 "));
			Assert.That.Captures("abc", StringChecker.Consume("abc"));
			Assert.That.Captures("abc", StringChecker.Consume("abc "));
			Assert.That.Captures("_bc", StringChecker.Consume("_bc"));
			Assert.That.Captures("_bc", StringChecker.Consume("_bc "));
			Assert.That.Captures("a_c", StringChecker.Consume("a_c"));
			Assert.That.Captures("a_c", StringChecker.Consume("a_c "));
			Assert.That.Captures("ab_", StringChecker.Consume("ab_"));
			Assert.That.Captures("ab_", StringChecker.Consume("ab_ "));
			Assert.That.Captures("-bc", StringChecker.Consume("-bc"));
			Assert.That.Captures("-bc", StringChecker.Consume("-bc "));
			Assert.That.Captures("a-c", StringChecker.Consume("a-c"));
			Assert.That.Captures("a-c", StringChecker.Consume("a-c "));
			Assert.That.Captures("ab-", StringChecker.Consume("ab-"));
			Assert.That.Captures("ab-", StringChecker.Consume("ab- "));
			Assert.That.Captures("1bc", StringChecker.Consume("1bc"));
			Assert.That.Captures("1bc", StringChecker.Consume("1bc "));
			Assert.That.Captures("a2c", StringChecker.Consume("a2c"));
			Assert.That.Captures("a2c", StringChecker.Consume("a2c "));
			Assert.That.Captures("ab3", StringChecker.Consume("ab3"));
			Assert.That.Captures("ab3", StringChecker.Consume("ab3 "));
			Assert.That.Captures("a23", StringChecker.Consume("a23"));
			Assert.That.Captures("a23", StringChecker.Consume("a23 "));
			Assert.That.Captures("123", StringChecker.Consume("123"));
			Assert.That.Captures("123", StringChecker.Consume("123 "));
			Assert.That.Captures("a_cde", StringChecker.Consume("a_cde"));
			Assert.That.Captures("a_cde", StringChecker.Consume("a_cde "));
			Assert.That.Captures("ab_de", StringChecker.Consume("ab_de"));
			Assert.That.Captures("ab_de", StringChecker.Consume("ab_de "));
			Assert.That.Captures("abc_e", StringChecker.Consume("abc_e"));
			Assert.That.Captures("abc_e", StringChecker.Consume("abc_e "));
			Assert.That.Captures("a__de", StringChecker.Consume("a__de"));
			Assert.That.Captures("a__de", StringChecker.Consume("a__de "));
			Assert.That.Captures("ab__e", StringChecker.Consume("ab__e"));
			Assert.That.Captures("ab__e", StringChecker.Consume("ab__e "));
			Assert.That.Captures("a_c_e", StringChecker.Consume("a_c_e"));
			Assert.That.Captures("a_c_e", StringChecker.Consume("a_c_e "));
			Assert.That.Captures("a___e", StringChecker.Consume("a___e"));
			Assert.That.Captures("a___e", StringChecker.Consume("a___e "));

			StringChecker = Pattern.Check(nameof(StringChecker),
				(Char) => Char.IsLetter() || Char == '_', true,
				(Char) => Char.IsLetterOrDigit() || Char == '_' || Char == '-', false,
				(Char) => Char.IsLetterOrDigit(), false);
			Assert.That.Captures("a", StringChecker.Consume("a"));
			Assert.That.Captures("a", StringChecker.Consume("a "));
			Assert.That.Fails(StringChecker.Consume("1"));
			Assert.That.Fails(StringChecker.Consume("1 "));
			Assert.That.Captures("aa", StringChecker.Consume("aa"));
			Assert.That.Captures("aa", StringChecker.Consume("aa "));
			Assert.That.Captures("_a", StringChecker.Consume("_a"));
			Assert.That.Captures("_a", StringChecker.Consume("_a "));
			Assert.That.Captures("a_", StringChecker.Consume("a_"));
			Assert.That.Captures("a_", StringChecker.Consume("a_ "));
			Assert.That.Fails(StringChecker.Consume("1b"));
			Assert.That.Fails(StringChecker.Consume("1b "));
			Assert.That.Captures("a2", StringChecker.Consume("a2"));
			Assert.That.Captures("a2", StringChecker.Consume("a2 "));
			Assert.That.Fails(StringChecker.Consume("12"));
			Assert.That.Fails(StringChecker.Consume("12 "));
			Assert.That.Captures("abc", StringChecker.Consume("abc"));
			Assert.That.Captures("abc", StringChecker.Consume("abc "));
			Assert.That.Captures("_bc", StringChecker.Consume("_bc"));
			Assert.That.Captures("_bc", StringChecker.Consume("_bc "));
			Assert.That.Captures("a_c", StringChecker.Consume("a_c"));
			Assert.That.Captures("a_c", StringChecker.Consume("a_c "));
			Assert.That.Captures("ab_", StringChecker.Consume("ab_"));
			Assert.That.Captures("ab_", StringChecker.Consume("ab_ "));
			Assert.That.Fails(StringChecker.Consume("-bc"));
			Assert.That.Fails(StringChecker.Consume("-bc "));
			Assert.That.Captures("a-c", StringChecker.Consume("a-c"));
			Assert.That.Captures("a-c", StringChecker.Consume("a-c "));
			Assert.That.Captures("ab-", StringChecker.Consume("ab-"));
			Assert.That.Captures("ab-", StringChecker.Consume("ab- "));
			Assert.That.Fails(StringChecker.Consume("1bc"));
			Assert.That.Fails(StringChecker.Consume("1bc "));
			Assert.That.Captures("a2c", StringChecker.Consume("a2c"));
			Assert.That.Captures("a2c", StringChecker.Consume("a2c "));
			Assert.That.Captures("ab3", StringChecker.Consume("ab3"));
			Assert.That.Captures("ab3", StringChecker.Consume("ab3 "));
			Assert.That.Captures("a23", StringChecker.Consume("a23"));
			Assert.That.Captures("a23", StringChecker.Consume("a23 "));
			Assert.That.Fails(StringChecker.Consume("123"));
			Assert.That.Fails(StringChecker.Consume("123 "));
			Assert.That.Captures("a_cde", StringChecker.Consume("a_cde"));
			Assert.That.Captures("a_cde", StringChecker.Consume("a_cde "));
			Assert.That.Captures("ab_de", StringChecker.Consume("ab_de"));
			Assert.That.Captures("ab_de", StringChecker.Consume("ab_de "));
			Assert.That.Captures("abc_e", StringChecker.Consume("abc_e"));
			Assert.That.Captures("abc_e", StringChecker.Consume("abc_e "));
			Assert.That.Captures("a__de", StringChecker.Consume("a__de"));
			Assert.That.Captures("a__de", StringChecker.Consume("a__de "));
			Assert.That.Captures("ab__e", StringChecker.Consume("ab__e"));
			Assert.That.Captures("ab__e", StringChecker.Consume("ab__e "));
			Assert.That.Captures("a_c_e", StringChecker.Consume("a_c_e"));
			Assert.That.Captures("a_c_e", StringChecker.Consume("a_c_e "));
			Assert.That.Captures("a___e", StringChecker.Consume("a___e"));
			Assert.That.Captures("a___e", StringChecker.Consume("a___e "));

			Assert.ThrowsException<PatternConstructionException>(() => Pattern.Check(nameof(StringChecker),
				(Char) => Char.IsLetter() || Char == '_', false,
				(Char) => Char.IsLetterOrDigit() || Char == '_' || Char == '-', false,
				(Char) => Char.IsLetterOrDigit(), false));
		}

		[TestMethod]
		public void CharCheckerEqual() {
			Pattern CharChecker = Pattern.Check(nameof(CharChecker), (Char) => Char == 'a' || Char == '1');
			Assert.IsTrue(CharChecker.Equals("a"));
			Assert.IsTrue(CharChecker.Equals("1"));
			Assert.IsFalse(CharChecker.Equals("b"));
			Assert.IsFalse(CharChecker.Equals("a1"));
		}

		[TestMethod]
		public void WordCheckerConsume() {
			Pattern WordChecker = Pattern.Check(nameof(WordChecker), Bias.Head,
				(Char) => Char == '_',
				(Char) => Char.IsLetter(),
				(Char) => Char.IsLetterOrDigit());
			Assert.That.Captures("_", WordChecker.Consume("_"));
			Assert.That.Fails(WordChecker.Consume("b"));
			Assert.That.Fails(WordChecker.Consume("3"));
			Assert.That.Captures("_3", WordChecker.Consume("_3"));
			Assert.That.Captures("_b3", WordChecker.Consume("_b3"));
			Assert.That.Captures("_example", WordChecker.Consume("_example"));

			WordChecker = Pattern.Check(nameof(WordChecker), Bias.Tail,
				(Char) => Char == '_',
				(Char) => Char.IsLetter(),
				(Char) => Char.IsLetterOrDigit());
			Assert.That.Fails(WordChecker.Consume("_"));
			Assert.That.Captures("b", WordChecker.Consume("b"));
			Assert.That.Captures("3", WordChecker.Consume("3"));
			Assert.That.Captures("_3", WordChecker.Consume("_3"));
			Assert.That.Captures("_b3", WordChecker.Consume("_b3"));
			Assert.That.Captures("_example", WordChecker.Consume("_example"));
		}
	}
}


