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
			ResultAssert.Fails(StringChecker.Consume("a"));
			ResultAssert.Fails(StringChecker.Consume("a "));
			ResultAssert.Fails(StringChecker.Consume("aa"));
			ResultAssert.Fails(StringChecker.Consume("aa "));
			ResultAssert.Fails(StringChecker.Consume("_a"));
			ResultAssert.Fails(StringChecker.Consume("_a "));
			ResultAssert.Fails(StringChecker.Consume("a_"));
			ResultAssert.Fails(StringChecker.Consume("a_ "));
			ResultAssert.Fails(StringChecker.Consume("1b"));
			ResultAssert.Fails(StringChecker.Consume("1b "));
			ResultAssert.Fails(StringChecker.Consume("a2"));
			ResultAssert.Fails(StringChecker.Consume("a2 "));
			ResultAssert.Fails(StringChecker.Consume("12"));
			ResultAssert.Fails(StringChecker.Consume("12 "));
			ResultAssert.Captures("abc", StringChecker.Consume("abc"));
			ResultAssert.Captures("abc", StringChecker.Consume("abc "));
			ResultAssert.Captures("_bc", StringChecker.Consume("_bc"));
			ResultAssert.Captures("_bc", StringChecker.Consume("_bc "));
			ResultAssert.Captures("a_c", StringChecker.Consume("a_c"));
			ResultAssert.Captures("a_c", StringChecker.Consume("a_c "));
			ResultAssert.Fails(StringChecker.Consume("ab_"));
			ResultAssert.Fails(StringChecker.Consume("ab_ "));
			ResultAssert.Fails(StringChecker.Consume("-bc"));
			ResultAssert.Fails(StringChecker.Consume("-bc "));
			ResultAssert.Captures("a-c", StringChecker.Consume("a-c"));
			ResultAssert.Captures("a-c", StringChecker.Consume("a-c "));
			ResultAssert.Fails(StringChecker.Consume("ab-"));
			ResultAssert.Fails(StringChecker.Consume("ab- "));
			ResultAssert.Fails(StringChecker.Consume("1bc"));
			ResultAssert.Fails(StringChecker.Consume("1bc "));
			ResultAssert.Captures("a2c", StringChecker.Consume("a2c"));
			ResultAssert.Captures("a2c", StringChecker.Consume("a2c "));
			ResultAssert.Captures("ab3", StringChecker.Consume("ab3"));
			ResultAssert.Captures("ab3", StringChecker.Consume("ab3 "));
			ResultAssert.Captures("a23", StringChecker.Consume("a23"));
			ResultAssert.Captures("a23", StringChecker.Consume("a23 "));
			ResultAssert.Fails(StringChecker.Consume("123"));
			ResultAssert.Fails(StringChecker.Consume("123 "));
			ResultAssert.Captures("a_cde", StringChecker.Consume("a_cde"));
			ResultAssert.Captures("a_cde", StringChecker.Consume("a_cde "));
			ResultAssert.Captures("ab_de", StringChecker.Consume("ab_de"));
			ResultAssert.Captures("ab_de", StringChecker.Consume("ab_de "));
			ResultAssert.Captures("abc_e", StringChecker.Consume("abc_e"));
			ResultAssert.Captures("abc_e", StringChecker.Consume("abc_e "));
			ResultAssert.Captures("a__de", StringChecker.Consume("a__de"));
			ResultAssert.Captures("a__de", StringChecker.Consume("a__de "));
			ResultAssert.Captures("ab__e", StringChecker.Consume("ab__e"));
			ResultAssert.Captures("ab__e", StringChecker.Consume("ab__e "));
			ResultAssert.Captures("a_c_e", StringChecker.Consume("a_c_e"));
			ResultAssert.Captures("a_c_e", StringChecker.Consume("a_c_e "));
			ResultAssert.Captures("a___e", StringChecker.Consume("a___e"));
			ResultAssert.Captures("a___e", StringChecker.Consume("a___e "));

			StringChecker = Pattern.Check(nameof(StringChecker),
				(Char) => Char.IsLetter() || Char == '_', false,
				(Char) => Char.IsLetterOrDigit() || Char == '_' || Char == '-', true,
				(Char) => Char.IsLetterOrDigit(), true);
			ResultAssert.Fails(StringChecker.Consume("a"));
			ResultAssert.Fails(StringChecker.Consume("a "));
			ResultAssert.Captures("aa", StringChecker.Consume("aa"));
			ResultAssert.Captures("aa", StringChecker.Consume("aa "));
			ResultAssert.Captures("_a", StringChecker.Consume("_a"));
			ResultAssert.Captures("_a", StringChecker.Consume("_a "));
			ResultAssert.Fails(StringChecker.Consume("a_"));
			ResultAssert.Fails(StringChecker.Consume("a_ "));
			ResultAssert.Captures("1b", StringChecker.Consume("1b"));
			ResultAssert.Captures("1b", StringChecker.Consume("1b "));
			ResultAssert.Captures("a2", StringChecker.Consume("a2"));
			ResultAssert.Captures("a2", StringChecker.Consume("a2 "));
			ResultAssert.Captures("12", StringChecker.Consume("12"));
			ResultAssert.Captures("12", StringChecker.Consume("12 "));
			ResultAssert.Captures("abc", StringChecker.Consume("abc"));
			ResultAssert.Captures("abc", StringChecker.Consume("abc "));
			ResultAssert.Captures("_bc", StringChecker.Consume("_bc"));
			ResultAssert.Captures("_bc", StringChecker.Consume("_bc "));
			ResultAssert.Captures("a_c", StringChecker.Consume("a_c"));
			ResultAssert.Captures("a_c", StringChecker.Consume("a_c "));
			ResultAssert.Fails(StringChecker.Consume("ab_"));
			ResultAssert.Fails(StringChecker.Consume("ab_ "));
			ResultAssert.Captures("-bc", StringChecker.Consume("-bc"));
			ResultAssert.Captures("-bc", StringChecker.Consume("-bc "));
			ResultAssert.Captures("a-c", StringChecker.Consume("a-c"));
			ResultAssert.Captures("a-c", StringChecker.Consume("a-c "));
			ResultAssert.Fails(StringChecker.Consume("ab-"));
			ResultAssert.Fails(StringChecker.Consume("ab- "));
			ResultAssert.Captures("1bc", StringChecker.Consume("1bc"));
			ResultAssert.Captures("1bc", StringChecker.Consume("1bc "));
			ResultAssert.Captures("a2c", StringChecker.Consume("a2c"));
			ResultAssert.Captures("a2c", StringChecker.Consume("a2c "));
			ResultAssert.Captures("ab3", StringChecker.Consume("ab3"));
			ResultAssert.Captures("ab3", StringChecker.Consume("ab3 "));
			ResultAssert.Captures("a23", StringChecker.Consume("a23"));
			ResultAssert.Captures("a23", StringChecker.Consume("a23 "));
			ResultAssert.Captures("123", StringChecker.Consume("123"));
			ResultAssert.Captures("123", StringChecker.Consume("123 "));
			ResultAssert.Captures("a_cde", StringChecker.Consume("a_cde"));
			ResultAssert.Captures("a_cde", StringChecker.Consume("a_cde "));
			ResultAssert.Captures("ab_de", StringChecker.Consume("ab_de"));
			ResultAssert.Captures("ab_de", StringChecker.Consume("ab_de "));
			ResultAssert.Captures("abc_e", StringChecker.Consume("abc_e"));
			ResultAssert.Captures("abc_e", StringChecker.Consume("abc_e "));
			ResultAssert.Captures("a__de", StringChecker.Consume("a__de"));
			ResultAssert.Captures("a__de", StringChecker.Consume("a__de "));
			ResultAssert.Captures("ab__e", StringChecker.Consume("ab__e"));
			ResultAssert.Captures("ab__e", StringChecker.Consume("ab__e "));
			ResultAssert.Captures("a_c_e", StringChecker.Consume("a_c_e"));
			ResultAssert.Captures("a_c_e", StringChecker.Consume("a_c_e "));
			ResultAssert.Captures("a___e", StringChecker.Consume("a___e"));
			ResultAssert.Captures("a___e", StringChecker.Consume("a___e "));

			StringChecker = Pattern.Check(nameof(StringChecker),
				(Char) => Char.IsLetter() || Char == '_', true,
				(Char) => Char.IsLetterOrDigit() || Char == '_' || Char == '-', false,
				(Char) => Char.IsLetterOrDigit(), true);
			ResultAssert.Fails(StringChecker.Consume("a"));
			ResultAssert.Fails(StringChecker.Consume("a "));
			ResultAssert.Captures("aa", StringChecker.Consume("aa"));
			ResultAssert.Captures("aa", StringChecker.Consume("aa "));
			ResultAssert.Captures("_a", StringChecker.Consume("_a"));
			ResultAssert.Captures("_a", StringChecker.Consume("_a "));
			ResultAssert.Fails(StringChecker.Consume("a_"));
			ResultAssert.Fails(StringChecker.Consume("a_ "));
			ResultAssert.Fails(StringChecker.Consume("1b"));
			ResultAssert.Fails(StringChecker.Consume("1b "));
			ResultAssert.Captures("a2", StringChecker.Consume("a2"));
			ResultAssert.Captures("a2", StringChecker.Consume("a2 "));
			ResultAssert.Fails(StringChecker.Consume("12"));
			ResultAssert.Fails(StringChecker.Consume("12 "));
			ResultAssert.Captures("abc", StringChecker.Consume("abc"));
			ResultAssert.Captures("abc", StringChecker.Consume("abc "));
			ResultAssert.Captures("_bc", StringChecker.Consume("_bc"));
			ResultAssert.Captures("_bc", StringChecker.Consume("_bc "));
			ResultAssert.Captures("a_c", StringChecker.Consume("a_c"));
			ResultAssert.Captures("a_c", StringChecker.Consume("a_c "));
			ResultAssert.Fails(StringChecker.Consume("ab_"));
			ResultAssert.Fails(StringChecker.Consume("ab_ "));
			ResultAssert.Fails(StringChecker.Consume("-bc"));
			ResultAssert.Fails(StringChecker.Consume("-bc "));
			ResultAssert.Captures("a-c", StringChecker.Consume("a-c"));
			ResultAssert.Captures("a-c", StringChecker.Consume("a-c "));
			ResultAssert.Fails(StringChecker.Consume("ab-"));
			ResultAssert.Fails(StringChecker.Consume("ab- "));
			ResultAssert.Fails(StringChecker.Consume("1bc"));
			ResultAssert.Fails(StringChecker.Consume("1bc "));
			ResultAssert.Captures("a2c", StringChecker.Consume("a2c"));
			ResultAssert.Captures("a2c", StringChecker.Consume("a2c "));
			ResultAssert.Captures("ab3", StringChecker.Consume("ab3"));
			ResultAssert.Captures("ab3", StringChecker.Consume("ab3 "));
			ResultAssert.Captures("a23", StringChecker.Consume("a23"));
			ResultAssert.Captures("a23", StringChecker.Consume("a23 "));
			ResultAssert.Fails(StringChecker.Consume("123"));
			ResultAssert.Fails(StringChecker.Consume("123 "));
			ResultAssert.Captures("a_cde", StringChecker.Consume("a_cde"));
			ResultAssert.Captures("a_cde", StringChecker.Consume("a_cde "));
			ResultAssert.Captures("ab_de", StringChecker.Consume("ab_de"));
			ResultAssert.Captures("ab_de", StringChecker.Consume("ab_de "));
			ResultAssert.Captures("abc_e", StringChecker.Consume("abc_e"));
			ResultAssert.Captures("abc_e", StringChecker.Consume("abc_e "));
			ResultAssert.Captures("a__de", StringChecker.Consume("a__de"));
			ResultAssert.Captures("a__de", StringChecker.Consume("a__de "));
			ResultAssert.Captures("ab__e", StringChecker.Consume("ab__e"));
			ResultAssert.Captures("ab__e", StringChecker.Consume("ab__e "));
			ResultAssert.Captures("a_c_e", StringChecker.Consume("a_c_e"));
			ResultAssert.Captures("a_c_e", StringChecker.Consume("a_c_e "));
			ResultAssert.Captures("a___e", StringChecker.Consume("a___e"));
			ResultAssert.Captures("a___e", StringChecker.Consume("a___e "));

			StringChecker = Pattern.Check(nameof(StringChecker),
				(Char) => Char.IsLetter() || Char == '_', true,
				(Char) => Char.IsLetterOrDigit() || Char == '_' || Char == '-', true,
				(Char) => Char.IsLetterOrDigit(), false);
			ResultAssert.Fails(StringChecker.Consume("a"));
			ResultAssert.Fails(StringChecker.Consume("a "));
			ResultAssert.Captures("aa", StringChecker.Consume("aa"));
			ResultAssert.Captures("aa", StringChecker.Consume("aa "));
			ResultAssert.Captures("_a", StringChecker.Consume("_a"));
			ResultAssert.Captures("_a", StringChecker.Consume("_a "));
			ResultAssert.Captures("a_", StringChecker.Consume("a_"));
			ResultAssert.Captures("a_", StringChecker.Consume("a_ "));
			ResultAssert.Fails(StringChecker.Consume("1b"));
			ResultAssert.Fails(StringChecker.Consume("1b "));
			ResultAssert.Captures("a2", StringChecker.Consume("a2"));
			ResultAssert.Captures("a2", StringChecker.Consume("a2 "));
			ResultAssert.Fails(StringChecker.Consume("12"));
			ResultAssert.Fails(StringChecker.Consume("12 "));
			ResultAssert.Captures("abc", StringChecker.Consume("abc"));
			ResultAssert.Captures("abc", StringChecker.Consume("abc "));
			ResultAssert.Captures("_bc", StringChecker.Consume("_bc"));
			ResultAssert.Captures("_bc", StringChecker.Consume("_bc "));
			ResultAssert.Captures("a_c", StringChecker.Consume("a_c"));
			ResultAssert.Captures("a_c", StringChecker.Consume("a_c "));
			ResultAssert.Captures("ab_", StringChecker.Consume("ab_"));
			ResultAssert.Captures("ab_", StringChecker.Consume("ab_ "));
			ResultAssert.Fails(StringChecker.Consume("-bc"));
			ResultAssert.Fails(StringChecker.Consume("-bc "));
			ResultAssert.Captures("a-c", StringChecker.Consume("a-c"));
			ResultAssert.Captures("a-c", StringChecker.Consume("a-c "));
			ResultAssert.Captures("ab-", StringChecker.Consume("ab-"));
			ResultAssert.Captures("ab-", StringChecker.Consume("ab- "));
			ResultAssert.Fails(StringChecker.Consume("1bc"));
			ResultAssert.Fails(StringChecker.Consume("1bc "));
			ResultAssert.Captures("a2c", StringChecker.Consume("a2c"));
			ResultAssert.Captures("a2c", StringChecker.Consume("a2c "));
			ResultAssert.Captures("ab3", StringChecker.Consume("ab3"));
			ResultAssert.Captures("ab3", StringChecker.Consume("ab3 "));
			ResultAssert.Captures("a23", StringChecker.Consume("a23"));
			ResultAssert.Captures("a23", StringChecker.Consume("a23 "));
			ResultAssert.Fails(StringChecker.Consume("123"));
			ResultAssert.Fails(StringChecker.Consume("123 "));
			ResultAssert.Captures("a_cde", StringChecker.Consume("a_cde"));
			ResultAssert.Captures("a_cde", StringChecker.Consume("a_cde "));
			ResultAssert.Captures("ab_de", StringChecker.Consume("ab_de"));
			ResultAssert.Captures("ab_de", StringChecker.Consume("ab_de "));
			ResultAssert.Captures("abc_e", StringChecker.Consume("abc_e"));
			ResultAssert.Captures("abc_e", StringChecker.Consume("abc_e "));
			ResultAssert.Captures("a__de", StringChecker.Consume("a__de"));
			ResultAssert.Captures("a__de", StringChecker.Consume("a__de "));
			ResultAssert.Captures("ab__e", StringChecker.Consume("ab__e"));
			ResultAssert.Captures("ab__e", StringChecker.Consume("ab__e "));
			ResultAssert.Captures("a_c_e", StringChecker.Consume("a_c_e"));
			ResultAssert.Captures("a_c_e", StringChecker.Consume("a_c_e "));
			ResultAssert.Captures("a___e", StringChecker.Consume("a___e"));
			ResultAssert.Captures("a___e", StringChecker.Consume("a___e "));

			StringChecker = Pattern.Check(nameof(StringChecker),
				(Char) => Char.IsLetter() || Char == '_', false,
				(Char) => Char.IsLetterOrDigit() || Char == '_' || Char == '-', false,
				(Char) => Char.IsLetterOrDigit(), true);
			ResultAssert.Captures("a", StringChecker.Consume("a"));
			ResultAssert.Captures("a", StringChecker.Consume("a "));
			ResultAssert.Captures("1", StringChecker.Consume("1"));
			ResultAssert.Captures("1", StringChecker.Consume("1 "));
			ResultAssert.Captures("aa", StringChecker.Consume("aa"));
			ResultAssert.Captures("aa", StringChecker.Consume("aa "));
			ResultAssert.Captures("_a", StringChecker.Consume("_a"));
			ResultAssert.Captures("_a", StringChecker.Consume("_a "));
			ResultAssert.Fails(StringChecker.Consume("a_"));
			ResultAssert.Fails(StringChecker.Consume("a_ "));
			ResultAssert.Captures("1b", StringChecker.Consume("1b"));
			ResultAssert.Captures("1b", StringChecker.Consume("1b "));
			ResultAssert.Captures("a2", StringChecker.Consume("a2"));
			ResultAssert.Captures("a2", StringChecker.Consume("a2 "));
			ResultAssert.Captures("12", StringChecker.Consume("12"));
			ResultAssert.Captures("12", StringChecker.Consume("12 "));
			ResultAssert.Captures("abc", StringChecker.Consume("abc"));
			ResultAssert.Captures("abc", StringChecker.Consume("abc "));
			ResultAssert.Captures("_bc", StringChecker.Consume("_bc"));
			ResultAssert.Captures("_bc", StringChecker.Consume("_bc "));
			ResultAssert.Captures("a_c", StringChecker.Consume("a_c"));
			ResultAssert.Captures("a_c", StringChecker.Consume("a_c "));
			ResultAssert.Fails(StringChecker.Consume("ab_"));
			ResultAssert.Fails(StringChecker.Consume("ab_ "));
			ResultAssert.Captures("-bc", StringChecker.Consume("-bc"));
			ResultAssert.Captures("-bc", StringChecker.Consume("-bc "));
			ResultAssert.Captures("a-c", StringChecker.Consume("a-c"));
			ResultAssert.Captures("a-c", StringChecker.Consume("a-c "));
			ResultAssert.Fails(StringChecker.Consume("ab-"));
			ResultAssert.Fails(StringChecker.Consume("ab- "));
			ResultAssert.Captures("1bc", StringChecker.Consume("1bc"));
			ResultAssert.Captures("1bc", StringChecker.Consume("1bc "));
			ResultAssert.Captures("a2c", StringChecker.Consume("a2c"));
			ResultAssert.Captures("a2c", StringChecker.Consume("a2c "));
			ResultAssert.Captures("ab3", StringChecker.Consume("ab3"));
			ResultAssert.Captures("ab3", StringChecker.Consume("ab3 "));
			ResultAssert.Captures("a23", StringChecker.Consume("a23"));
			ResultAssert.Captures("a23", StringChecker.Consume("a23 "));
			ResultAssert.Captures("123", StringChecker.Consume("123"));
			ResultAssert.Captures("123", StringChecker.Consume("123 "));
			ResultAssert.Captures("a_cde", StringChecker.Consume("a_cde"));
			ResultAssert.Captures("a_cde", StringChecker.Consume("a_cde "));
			ResultAssert.Captures("ab_de", StringChecker.Consume("ab_de"));
			ResultAssert.Captures("ab_de", StringChecker.Consume("ab_de "));
			ResultAssert.Captures("abc_e", StringChecker.Consume("abc_e"));
			ResultAssert.Captures("abc_e", StringChecker.Consume("abc_e "));
			ResultAssert.Captures("a__de", StringChecker.Consume("a__de"));
			ResultAssert.Captures("a__de", StringChecker.Consume("a__de "));
			ResultAssert.Captures("ab__e", StringChecker.Consume("ab__e"));
			ResultAssert.Captures("ab__e", StringChecker.Consume("ab__e "));
			ResultAssert.Captures("a_c_e", StringChecker.Consume("a_c_e"));
			ResultAssert.Captures("a_c_e", StringChecker.Consume("a_c_e "));
			ResultAssert.Captures("a___e", StringChecker.Consume("a___e"));
			ResultAssert.Captures("a___e", StringChecker.Consume("a___e "));

			StringChecker = Pattern.Check(nameof(StringChecker),
				(Char) => Char.IsLetter() || Char == '_', false,
				(Char) => Char.IsLetterOrDigit() || Char == '_' || Char == '-', true,
				(Char) => Char.IsLetterOrDigit(), false);
			ResultAssert.Captures("a", StringChecker.Consume("a"));
			ResultAssert.Captures("a", StringChecker.Consume("a "));
			ResultAssert.Captures("1", StringChecker.Consume("1"));
			ResultAssert.Captures("1", StringChecker.Consume("1 "));
			ResultAssert.Captures("aa", StringChecker.Consume("aa"));
			ResultAssert.Captures("aa", StringChecker.Consume("aa "));
			ResultAssert.Captures("_a", StringChecker.Consume("_a"));
			ResultAssert.Captures("_a", StringChecker.Consume("_a "));
			ResultAssert.Captures("a_", StringChecker.Consume("a_"));
			ResultAssert.Captures("a_", StringChecker.Consume("a_ "));
			ResultAssert.Captures("1b", StringChecker.Consume("1b"));
			ResultAssert.Captures("1b", StringChecker.Consume("1b "));
			ResultAssert.Captures("a2", StringChecker.Consume("a2"));
			ResultAssert.Captures("a2", StringChecker.Consume("a2 "));
			ResultAssert.Captures("12", StringChecker.Consume("12"));
			ResultAssert.Captures("12", StringChecker.Consume("12 "));
			ResultAssert.Captures("abc", StringChecker.Consume("abc"));
			ResultAssert.Captures("abc", StringChecker.Consume("abc "));
			ResultAssert.Captures("_bc", StringChecker.Consume("_bc"));
			ResultAssert.Captures("_bc", StringChecker.Consume("_bc "));
			ResultAssert.Captures("a_c", StringChecker.Consume("a_c"));
			ResultAssert.Captures("a_c", StringChecker.Consume("a_c "));
			ResultAssert.Captures("ab_", StringChecker.Consume("ab_"));
			ResultAssert.Captures("ab_", StringChecker.Consume("ab_ "));
			ResultAssert.Captures("-bc", StringChecker.Consume("-bc"));
			ResultAssert.Captures("-bc", StringChecker.Consume("-bc "));
			ResultAssert.Captures("a-c", StringChecker.Consume("a-c"));
			ResultAssert.Captures("a-c", StringChecker.Consume("a-c "));
			ResultAssert.Captures("ab-", StringChecker.Consume("ab-"));
			ResultAssert.Captures("ab-", StringChecker.Consume("ab- "));
			ResultAssert.Captures("1bc", StringChecker.Consume("1bc"));
			ResultAssert.Captures("1bc", StringChecker.Consume("1bc "));
			ResultAssert.Captures("a2c", StringChecker.Consume("a2c"));
			ResultAssert.Captures("a2c", StringChecker.Consume("a2c "));
			ResultAssert.Captures("ab3", StringChecker.Consume("ab3"));
			ResultAssert.Captures("ab3", StringChecker.Consume("ab3 "));
			ResultAssert.Captures("a23", StringChecker.Consume("a23"));
			ResultAssert.Captures("a23", StringChecker.Consume("a23 "));
			ResultAssert.Captures("123", StringChecker.Consume("123"));
			ResultAssert.Captures("123", StringChecker.Consume("123 "));
			ResultAssert.Captures("a_cde", StringChecker.Consume("a_cde"));
			ResultAssert.Captures("a_cde", StringChecker.Consume("a_cde "));
			ResultAssert.Captures("ab_de", StringChecker.Consume("ab_de"));
			ResultAssert.Captures("ab_de", StringChecker.Consume("ab_de "));
			ResultAssert.Captures("abc_e", StringChecker.Consume("abc_e"));
			ResultAssert.Captures("abc_e", StringChecker.Consume("abc_e "));
			ResultAssert.Captures("a__de", StringChecker.Consume("a__de"));
			ResultAssert.Captures("a__de", StringChecker.Consume("a__de "));
			ResultAssert.Captures("ab__e", StringChecker.Consume("ab__e"));
			ResultAssert.Captures("ab__e", StringChecker.Consume("ab__e "));
			ResultAssert.Captures("a_c_e", StringChecker.Consume("a_c_e"));
			ResultAssert.Captures("a_c_e", StringChecker.Consume("a_c_e "));
			ResultAssert.Captures("a___e", StringChecker.Consume("a___e"));
			ResultAssert.Captures("a___e", StringChecker.Consume("a___e "));

			StringChecker = Pattern.Check(nameof(StringChecker),
				(Char) => Char.IsLetter() || Char == '_', true,
				(Char) => Char.IsLetterOrDigit() || Char == '_' || Char == '-', false,
				(Char) => Char.IsLetterOrDigit(), false);
			ResultAssert.Captures("a", StringChecker.Consume("a"));
			ResultAssert.Captures("a", StringChecker.Consume("a "));
			ResultAssert.Fails(StringChecker.Consume("1"));
			ResultAssert.Fails(StringChecker.Consume("1 "));
			ResultAssert.Captures("aa", StringChecker.Consume("aa"));
			ResultAssert.Captures("aa", StringChecker.Consume("aa "));
			ResultAssert.Captures("_a", StringChecker.Consume("_a"));
			ResultAssert.Captures("_a", StringChecker.Consume("_a "));
			ResultAssert.Captures("a_", StringChecker.Consume("a_"));
			ResultAssert.Captures("a_", StringChecker.Consume("a_ "));
			ResultAssert.Fails(StringChecker.Consume("1b"));
			ResultAssert.Fails(StringChecker.Consume("1b "));
			ResultAssert.Captures("a2", StringChecker.Consume("a2"));
			ResultAssert.Captures("a2", StringChecker.Consume("a2 "));
			ResultAssert.Fails(StringChecker.Consume("12"));
			ResultAssert.Fails(StringChecker.Consume("12 "));
			ResultAssert.Captures("abc", StringChecker.Consume("abc"));
			ResultAssert.Captures("abc", StringChecker.Consume("abc "));
			ResultAssert.Captures("_bc", StringChecker.Consume("_bc"));
			ResultAssert.Captures("_bc", StringChecker.Consume("_bc "));
			ResultAssert.Captures("a_c", StringChecker.Consume("a_c"));
			ResultAssert.Captures("a_c", StringChecker.Consume("a_c "));
			ResultAssert.Captures("ab_", StringChecker.Consume("ab_"));
			ResultAssert.Captures("ab_", StringChecker.Consume("ab_ "));
			ResultAssert.Fails(StringChecker.Consume("-bc"));
			ResultAssert.Fails(StringChecker.Consume("-bc "));
			ResultAssert.Captures("a-c", StringChecker.Consume("a-c"));
			ResultAssert.Captures("a-c", StringChecker.Consume("a-c "));
			ResultAssert.Captures("ab-", StringChecker.Consume("ab-"));
			ResultAssert.Captures("ab-", StringChecker.Consume("ab- "));
			ResultAssert.Fails(StringChecker.Consume("1bc"));
			ResultAssert.Fails(StringChecker.Consume("1bc "));
			ResultAssert.Captures("a2c", StringChecker.Consume("a2c"));
			ResultAssert.Captures("a2c", StringChecker.Consume("a2c "));
			ResultAssert.Captures("ab3", StringChecker.Consume("ab3"));
			ResultAssert.Captures("ab3", StringChecker.Consume("ab3 "));
			ResultAssert.Captures("a23", StringChecker.Consume("a23"));
			ResultAssert.Captures("a23", StringChecker.Consume("a23 "));
			ResultAssert.Fails(StringChecker.Consume("123"));
			ResultAssert.Fails(StringChecker.Consume("123 "));
			ResultAssert.Captures("a_cde", StringChecker.Consume("a_cde"));
			ResultAssert.Captures("a_cde", StringChecker.Consume("a_cde "));
			ResultAssert.Captures("ab_de", StringChecker.Consume("ab_de"));
			ResultAssert.Captures("ab_de", StringChecker.Consume("ab_de "));
			ResultAssert.Captures("abc_e", StringChecker.Consume("abc_e"));
			ResultAssert.Captures("abc_e", StringChecker.Consume("abc_e "));
			ResultAssert.Captures("a__de", StringChecker.Consume("a__de"));
			ResultAssert.Captures("a__de", StringChecker.Consume("a__de "));
			ResultAssert.Captures("ab__e", StringChecker.Consume("ab__e"));
			ResultAssert.Captures("ab__e", StringChecker.Consume("ab__e "));
			ResultAssert.Captures("a_c_e", StringChecker.Consume("a_c_e"));
			ResultAssert.Captures("a_c_e", StringChecker.Consume("a_c_e "));
			ResultAssert.Captures("a___e", StringChecker.Consume("a___e"));
			ResultAssert.Captures("a___e", StringChecker.Consume("a___e "));

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
			ResultAssert.Captures("_", WordChecker.Consume("_"));
			ResultAssert.Captures("_", WordChecker.Consume("_ "));
			ResultAssert.Fails(WordChecker.Consume("b"));
			ResultAssert.Fails(WordChecker.Consume("b "));
			ResultAssert.Fails(WordChecker.Consume("3"));
			ResultAssert.Fails(WordChecker.Consume("3 "));
			ResultAssert.Captures("_3", WordChecker.Consume("_3"));
			ResultAssert.Captures("_3", WordChecker.Consume("_3 "));
			ResultAssert.Captures("_b3", WordChecker.Consume("_b3"));
			ResultAssert.Captures("_b3", WordChecker.Consume("_b3 "));
			ResultAssert.Captures("_example", WordChecker.Consume("_example"));
			ResultAssert.Captures("_example", WordChecker.Consume("_example "));
			ResultAssert.Captures("_example3", WordChecker.Consume("_example3"));
			ResultAssert.Captures("_example3", WordChecker.Consume("_example3 "));
			ResultAssert.Captures("_example", WordChecker.Consume("_example_"));
			ResultAssert.Captures("_example", WordChecker.Consume("_example_ "));

			WordChecker = Pattern.Check(nameof(WordChecker), Bias.Tail,
				(Char) => Char == '_',
				(Char) => Char.IsLetter(),
				(Char) => Char.IsLetterOrDigit());
			ResultAssert.Fails(WordChecker.Consume("_"));
			ResultAssert.Fails(WordChecker.Consume("_ "));
			ResultAssert.Captures("b", WordChecker.Consume("b"));
			ResultAssert.Captures("b", WordChecker.Consume("b "));
			ResultAssert.Captures("3", WordChecker.Consume("3"));
			ResultAssert.Captures("3", WordChecker.Consume("3 "));
			ResultAssert.Captures("_3", WordChecker.Consume("_3"));
			ResultAssert.Captures("_3", WordChecker.Consume("_3 "));
			ResultAssert.Captures("_b3", WordChecker.Consume("_b3"));
			ResultAssert.Captures("_b3", WordChecker.Consume("_b3 "));
			ResultAssert.Captures("_example", WordChecker.Consume("_example"));
			ResultAssert.Captures("_example", WordChecker.Consume("_example "));
			ResultAssert.Captures("_example3", WordChecker.Consume("_example3"));
			ResultAssert.Captures("_example3", WordChecker.Consume("_example3 "));
			ResultAssert.Captures("_example", WordChecker.Consume("_example_"));
			ResultAssert.Captures("_example", WordChecker.Consume("_example_ "));
		}
	}
}