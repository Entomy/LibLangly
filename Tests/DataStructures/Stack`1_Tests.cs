using System;
using Xunit;

namespace Langly.DataStructures {
	public class Stack1_Tests {
		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5, 4, 3, 2, 1 })]
		public void Stack(Int32[] expected, Int32[] values) {
			Stack<Int32> stack = new Stack<Int32>().Push(values);
			Assert.Equal(expected.Length, stack.Count);
			Assert.Equal(expected, stack);
			stack.Pop(expected.Length, out Int32[] vals);
			Assert.Equal(0, stack.Count);
			Assert.Equal(expected, vals);
		}
	}
}
