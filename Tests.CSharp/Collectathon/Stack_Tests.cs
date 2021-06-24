using System;
using Collectathon.Stacks;
using Xunit;

namespace Collectathon {
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
		public void Cbrt_Double() {
			Stack<Double> stack = new Stack<Double>(2.0);
			stack.Cbrt();
			stack.Read(out Double result);
			Assert.Equal(Math.Cbrt(2.0), result);
		}

		[Fact]
		public void Ceiling_Double() {
			Stack<Double> stack = new Stack<Double>(1.5);
			stack.Ceiling();
			stack.Read(out Double result);
			Assert.Equal(Math.Ceiling(1.5), result);
		}

		[Fact]
		public void Cos_Double() {
			Stack<Double> stack = new Stack<Double>(Math.PI / 2);
			stack.Cos();
			stack.Read(out Double result);
			Assert.Equal(Math.Cos(Math.PI / 2), result);
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

		[Theory]
		[InlineData(new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48 })]
		public void Enumerator(Int32[] elements) {
			Stack<Int32> stack = new Stack<Int32>() { elements };
			Int32 i = elements.Length;
			foreach (Int32 item in stack) {
				Assert.Equal(elements[--i], item);
			}
		}

		[Fact]
		public void Exp_Double() {
			Stack<Double> stack = new Stack<Double>(2.0);
			stack.Exp();
			stack.Read(out Double result);
			Assert.Equal(Math.Exp(2.0), result);
		}

		[Fact]
		public void Floor_Double() {
			Stack<Double> stack = new Stack<Double>(1.5);
			stack.Floor();
			stack.Read(out Double result);
			Assert.Equal(Math.Floor(1.5), result);
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
		public void Pow_Double() {
			Stack<Double> stack = new Stack<Double>(1.0, 2.0);
			stack.Pow();
			stack.Read(out Double result);
			Assert.Equal(Math.Pow(1.0, 2.0), result);
		}

		[Fact]
		public void Sin_Double() {
			Stack<Double> stack = new Stack<Double>(Math.PI / 2);
			stack.Sin();
			stack.Read(out Double result);
			Assert.Equal(Math.Sin(Math.PI / 2), result);
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

		[Fact]
		public void Tan_Double() {
			Stack<Double> stack = new Stack<Double>(Math.PI / 2);
			stack.Tan();
			stack.Read(out Double result);
			Assert.Equal(Math.Tan(Math.PI / 2), result);
		}

		[Fact]
		public void Truncate_Double() {
			Stack<Double> stack = new Stack<Double>(1.5);
			stack.Truncate();
			stack.Read(out Double result);
			Assert.Equal(Math.Truncate(1.5), result);
		}
	}
}
