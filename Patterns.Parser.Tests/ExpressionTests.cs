using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Stringier.Patterns;
using Stringier.Patterns.Parser;

namespace Patterns.Parser.Tests {
	[TestClass]
	public class ExpressionTests {
		[TestMethod]
		public void SingleLiteral() {
			Expression expression = Expression.Parse("\"hello\"");
			_ = Assert.ThrowsException<ExpressionParseException>(() => Expression.Parse("hello"));
			Pattern pattern = expression.Evaluate();
			ResultAssert.Captures("hello", pattern.Consume("hello"));
		}

		[TestMethod]
		public void SingleLiteralWithSingleModifier() {
			Expression expression = Expression.Parse("\"hi!\"+");
			Pattern pattern = expression.Evaluate();
			ResultAssert.Captures("hi!", pattern.Consume("hi!"));
			ResultAssert.Captures("hi!hi!", pattern.Consume("hi!hi!"));
		}

		[TestMethod]
		public void SingleLiteralWithMultipleModifiers() {
			Expression expression = Expression.Parse("\"hi!\"-+");
			Pattern pattern = expression.Evaluate();
			ResultAssert.Captures("no?", pattern.Consume("no?"));
			ResultAssert.Captures("no?no!", pattern.Consume("no?no!"));
			ResultAssert.Captures("oh!", pattern.Consume("oh!hi!"));
		}
	}
}
