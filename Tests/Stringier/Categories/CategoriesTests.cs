using System;
using Xunit;
using Philosoft;

namespace Stringier.Categories {
	public class CategoriesTests {
		[Theory]
		[InlineData('\u24FF', false)]
		[InlineData('\u2500', true)]
		[InlineData('\u257F', true)]
		[InlineData('\u2580', false)]
		public void BoxDrawing(Char value, Boolean expected) => Assert.Equal(expected, Category.BoxDrawing.Contains(value));

		[Theory]
		[InlineData('\u0000', true)]
		[InlineData('\u001F', true)]
		[InlineData('\u0020', false)]
		public void Control(Char value, Boolean expected) => Assert.Equal(expected, Category.Control.Contains(value));

		[Theory]
		[InlineData('\u00AD', true)]
		[InlineData('\u0600', true)]
		public void Format(Char value, Boolean expected) => Assert.Equal(expected, Category.Format.Contains(value));

		[Theory]
		[InlineData('\u0009', true)]
		[InlineData('\u0020', true)]
		[InlineData('\u00A0', true)]
		[InlineData('\u2029', true)]
		public void WhiteSpace(Char value, Boolean expected) => Assert.Equal(expected, Category.WhiteSpace.Contains(value));

		[Fact]
		public void Difference() {
			Category difference = Category.CasedLetter - Category.UppercaseLetter;
			Assert.True(difference.Contains('a'));
			Assert.False(difference.Contains('A'));
			Assert.True(difference.Contains('ǆ'));
			Assert.True(difference.Contains('ǅ'));
			Assert.False(difference.Contains('Ǆ'));
		}

		[Fact]
		public void Disjunction() {
			Category disjunction = Category.Control ^ Category.WhiteSpace;
			Assert.True(disjunction.Contains('\u0008'));
			Assert.False(disjunction.Contains('\u0009'));
			Assert.True(disjunction.Contains('\u0020'));
			Assert.False(disjunction.Contains('\u0085'));
		}

		[Fact]
		public void Intersection() {
			Category intersection = Category.CasedLetter & Category.HexadecimalNumber;
			Assert.True(intersection.Contains('a'));
			Assert.True(intersection.Contains('A'));
			Assert.True(intersection.Contains('f'));
			Assert.True(intersection.Contains('F'));
			Assert.False(intersection.Contains('1'));
			Assert.False(intersection.Contains('g'));
			Assert.False(intersection.Contains('G'));
		}

		[Fact]
		public void Union() {
			Category union = Category.Letter | Category.Number;
			Assert.True(union.Contains('a'));
			Assert.True(union.Contains('A'));
			Assert.True(union.Contains('1'));
			Assert.False(union.Contains('.'));
		}
	}
}
