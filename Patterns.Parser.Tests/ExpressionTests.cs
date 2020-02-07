using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Stringier.Patterns;
using Stringier.Patterns.Parser;

namespace Patterns.Parser {
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

		[TestMethod]
		public void SingleLiteral_Then_SingleLiteral() {
			Expression expression = Expression.Parse("\"he\" then \"llo\"");
			Pattern pattern = expression.Evaluate();
			ResultAssert.Captures("hello", pattern.Consume("hello"));
		}

		[TestMethod]
		public void SingleLiteralWithSingleModifer_Then_SingleLiteral() {
			Expression expression = Expression.Parse("\"de\"? then \"couple\"");
			Pattern pattern = expression.Evaluate();
			ResultAssert.Captures("decouple", pattern.Consume("decouple"));
			ResultAssert.Captures("couple", pattern.Consume("couple"));
		}

		[TestMethod]
		public void SingleLiteral_Then_SingleLiteralWithSingleModifier() {
			Expression expression = Expression.Parse("\"accept\" then \"able\"?");
			Pattern pattern = expression.Evaluate();
			ResultAssert.Captures("accept", pattern.Consume("accept"));
			ResultAssert.Captures("acceptable", pattern.Consume("acceptable"));
		}

		[TestMethod]
		public void SingleLiteral_Repeat_3() {
			Expression expression = Expression.Parse("\".\"x3");
			Pattern pattern = expression.Evaluate();
			ResultAssert.Captures("...", pattern.Consume("....."));
		}
	}
}
