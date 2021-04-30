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
		public void Abs_Single() {
			Stack<Single> stack = new Stack<Single>(-1.0f);
			stack.Abs();
			stack.Read(out Single result);
			Assert.Equal(1.0f, result);
		}

		[Fact]
		public void Abs_Double() {
			Stack<Double> stack = new Stack<Double>(-1.0);
			stack.Abs();
			stack.Read(out Double result);
			Assert.Equal(1.0, result);
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
		public void Add_Single() {
			Stack<Single> stack = new Stack<Single>(1.0f, 2.0f);
			stack.Add();
			stack.Read(out Single result);
			Assert.Equal(3.0f, result);
		}

		[Fact]
		public void Add_Double() {
			Stack<Double> stack = new Stack<Double>(1.0, 2.0);
			stack.Add();
			stack.Read(out Double result);
			Assert.Equal(3.0, result);
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
		public void Div_Single() {
			Stack<Single> stack = new Stack<Single>(1.0f, 2.0f);
			stack.Div();
			stack.Read(out Single result);
			Assert.Equal(0.5f, result);
		}

		[Fact]
		public void Div_Double() {
			Stack<Double> stack = new Stack<Double>(1.0, 2.0);
			stack.Div();
			stack.Read(out Double result);
			Assert.Equal(0.5, result);
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
		public void Max_Single() {
			Stack<Single> stack = new Stack<Single>(1.0f, 2.0f);
			stack.Max();
			stack.Read(out Single result);
			Assert.Equal(2.0f, result);
		}

		[Fact]
		public void Max_Double() {
			Stack<Double> stack = new Stack<Double>(1.0, 2.0);
			stack.Max();
			stack.Read(out Double result);
			Assert.Equal(2.0, result);
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
		public void Min_Single() {
			Stack<Single> stack = new Stack<Single>(1.0f, 2.0f);
			stack.Min();
			stack.Read(out Single result);
			Assert.Equal(1.0f, result);
		}

		[Fact]
		public void Min_Double() {
			Stack<Double> stack = new Stack<Double>(1.0, 2.0);
			stack.Min();
			stack.Read(out Double result);
			Assert.Equal(1.0, result);
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
		public void Mod_Single() {
			Stack<Single> stack = new Stack<Single>(1.0f, 2.0f);
			stack.Mod();
			stack.Read(out Single result);
			Assert.Equal(1.0f, result);
		}

		[Fact]
		public void Mod_Double() {
			Stack<Double> stack = new Stack<Double>(1.0, 2.0);
			stack.Mod();
			stack.Read(out Double result);
			Assert.Equal(1.0, result);
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
		public void Mul_Single() {
			Stack<Single> stack = new Stack<Single>(1.0f, 2.0f);
			stack.Mul();
			stack.Read(out Single result);
			Assert.Equal(2.0f, result);
		}

		[Fact]
		public void Mul_Double() {
			Stack<Double> stack = new Stack<Double>(1.0, 2.0);
			stack.Mul();
			stack.Read(out Double result);
			Assert.Equal(2.0, result);
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

		[Fact]
		public void Sub_Single() {
			Stack<Single> stack = new Stack<Single>(1.0f, 2.0f);
			stack.Sub();
			stack.Read(out Single result);
			Assert.Equal(-1.0f, result);
		}

		[Fact]
		public void Sub_Double() {
			Stack<Double> stack = new Stack<Double>(1.0, 2.0);
			stack.Sub();
			stack.Read(out Double result);
			Assert.Equal(-1.0, result);
		}
	}
}
