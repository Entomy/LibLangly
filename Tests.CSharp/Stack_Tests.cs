using System;
using Collectathon.Stacks;
using Xunit;

namespace Langly {
	public class Stack_Tests {
		[Fact]
		public void Abs_Int32() {
			Stack<Int32> stack = new Stack<Int32>(-1);
			stack.Abs();
			stack.Read(out Int32 result);
			Assert.Equal(1, result);
		}

		[Fact]
		public void Abs_Int64() {
			Stack<Int64> stack = new Stack<Int64>(-1);
			stack.Abs();
			stack.Read(out Int64 result);
			Assert.Equal(1, result);
		}

		[Fact]
		public void Add_Int32() {
			Stack<Int32> stack = new Stack<Int32>(1, 2);
			stack.Add();
			stack.Read(out Int32 result);
			Assert.Equal(3, result);
		}

		[Fact]
		public void Add_Int64() {
			Stack<Int64> stack = new Stack<Int64>(1, 2);
			stack.Add();
			stack.Read(out Int64 result);
			Assert.Equal(3, result);
		}

		[Fact]
		public void Div_Int32() {
			Stack<Int32> stack = new Stack<Int32>(1, 2);
			stack.Div();
			stack.Read(out Int32 result);
			Assert.Equal(0, result);
		}

		[Fact]
		public void Div_Int64() {
			Stack<Int64> stack = new Stack<Int64>(1, 2);
			stack.Div();
			stack.Read(out Int64 result);
			Assert.Equal(0, result);
		}

		[Fact]
		public void Max_Int32() {
			Stack<Int32> stack = new Stack<Int32>(1, 2);
			stack.Max();
			stack.Read(out Int32 result);
			Assert.Equal(2, result);
		}

		[Fact]
		public void Max_Int64() {
			Stack<Int64> stack = new Stack<Int64>(1, 2);
			stack.Max();
			stack.Read(out Int64 result);
			Assert.Equal(2, result);
		}

		[Fact]
		public void Min_Int32() {
			Stack<Int32> stack = new Stack<Int32>(1, 2);
			stack.Min();
			stack.Read(out Int32 result);
			Assert.Equal(1, result);
		}

		[Fact]
		public void Min_Int64() {
			Stack<Int64> stack = new Stack<Int64>(1, 2);
			stack.Min();
			stack.Read(out Int64 result);
			Assert.Equal(1, result);
		}

		[Fact]
		public void Mod_Int32() {
			Stack<Int32> stack = new Stack<Int32>(1, 2);
			stack.Mod();
			stack.Read(out Int32 result);
			Assert.Equal(1, result);
		}

		[Fact]
		public void Mod_Int64() {
			Stack<Int64> stack = new Stack<Int64>(1, 2);
			stack.Mod();
			stack.Read(out Int64 result);
			Assert.Equal(1, result);
		}

		[Fact]
		public void Mul_Int32() {
			Stack<Int32> stack = new Stack<Int32>(1, 2);
			stack.Mul();
			stack.Read(out Int32 result);
			Assert.Equal(2, result);
		}

		[Fact]
		public void Mul_Int64() {
			Stack<Int64> stack = new Stack<Int64>(1, 2);
			stack.Mul();
			stack.Read(out Int64 result);
			Assert.Equal(2, result);
		}

		[Fact]
		public void Sub_Int32() {
			Stack<Int32> stack = new Stack<Int32>(1, 2);
			stack.Sub();
			stack.Read(out Int32 result);
			Assert.Equal(-1, result);
		}

		[Fact]
		public void Sub_Int64() {
			Stack<Int64> stack = new Stack<Int64>(1, 2);
			stack.Sub();
			stack.Read(out Int64 result);
			Assert.Equal(-1, result);
		}
	}
}
