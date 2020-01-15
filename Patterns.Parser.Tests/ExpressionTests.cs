using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Stringier.Patterns.Parser;

namespace Patterns.Parser.Tests {
	[TestClass]
	public class ExpressionTests {
		[TestMethod]
		public void SingleLiteral() {
			Expression expression = Expression.Parse("\"hello\"");
			_ = Assert.ThrowsException<ExpressionParseException>(() => Expression.Parse("hello"));
		}
	}
}
