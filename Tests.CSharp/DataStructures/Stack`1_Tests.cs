using System;
using Xunit;

namespace Langly.DataStructures {
	public class Stack1_Tests {
		[Theory]
		[MemberData(nameof(Stack1_Data.Stack), MemberType = typeof(Stack1_Data))]
		public void Stack(Int32[] expected, Int32[] values) {
			Stack<Int32> stack = new Stack<Int32>().Write(values);
			Assert.Equal(expected.Length, stack.Count);
			Assert.Equal(expected, stack);
			stack.Read(expected.Length, out ReadOnlyMemory<Int32> vals);
			Assert.Equal(0, stack.Count);
			Assert.Equal(expected, vals.ToArray());
		}
	}
}
