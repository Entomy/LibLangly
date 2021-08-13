using System;
using System.Traits.Concepts;
using System.Traits.Testing;
using Collectathon;
using Xunit;

namespace Numbersome {
	public class Stack_Tests : Tests {
		[Fact]
		public void Abs_Decimal() {
			IStack<Decimal> stack = new BoundedArray<Decimal>(1.0m, -1.0m);
			stack.Abs();
			Assert.That(stack.Pop()).Equals(1.0m);
			stack.Abs();
			Assert.That(stack.Pop()).Equals(1.0m);
		}

		[Fact]
		public void Abs_Double() {
			IStack<Double> stack = new BoundedArray<Double>(1.0, -1.0);
			stack.Abs();
			Assert.That(stack.Pop()).Equals(1.0);
			stack.Abs();
			Assert.That(stack.Pop()).Equals(1.0);
		}

		[Fact]
		public void Abs_Int16() {
			IStack<Int16> stack = new BoundedArray<Int16>(1, -1);
			stack.Abs();
			Assert.That(stack.Pop()).Equals(1);
			stack.Abs();
			Assert.That(stack.Pop()).Equals(1);
		}

		[Fact]
		public void Abs_Int32() {
			IStack<Int32> stack = new BoundedArray<Int32>(1, -1);
			stack.Abs();
			Assert.That(stack.Pop()).Equals(1);
			stack.Abs();
			Assert.That(stack.Pop()).Equals(1);
		}

		[Fact]
		public void Abs_Int64() {
			IStack<Int64> stack = new BoundedArray<Int64>(1, -1);
			stack.Abs();
			Assert.That(stack.Pop()).Equals(1);
			stack.Abs();
			Assert.That(stack.Pop()).Equals(1);
		}

		[Fact]
		public void Abs_SByte() {
			IStack<SByte> stack = new BoundedArray<SByte>(1, -1);
			stack.Abs();
			Assert.That(stack.Pop()).Equals(1);
			stack.Abs();
			Assert.That(stack.Pop()).Equals(1);
		}

		[Fact]
		public void Abs_Single() {
			IStack<Single> stack = new BoundedArray<Single>(1.0f, -1.0f);
			stack.Abs();
			Assert.That(stack.Pop()).Equals(1);
			stack.Abs();
			Assert.That(stack.Pop()).Equals(1);
		}

		[Fact]
		public void Add_nint() {
			IStack<nint> stack = new BoundedArray<nint>(1, 2);
			stack.Add();
			Assert.That(stack.Pop()).Equals(3);
		}

		[Fact]
		public void Add_nuint() {
			IStack<nuint> stack = new BoundedArray<nuint>(1, 2);
			stack.Add();
			Assert.That(stack.Pop()).Equals(3);
		}

		[Fact]
		public void Add_Int32() {
			IStack<Int32> stack = new BoundedArray<Int32>(1, 2);
			stack.Add();
			Assert.That(stack.Pop()).Equals(3);
		}

		[Fact]
		public void Add_UInt32() {
			IStack<UInt32> stack = new BoundedArray<UInt32>(1, 2);
			stack.Add();
			Assert.That(stack.Pop()).Equals(3);
		}

		[Fact]
		public void Add_Int64() {
			IStack<Int64> stack = new BoundedArray<Int64>(1, 2);
			stack.Add();
			Assert.That(stack.Pop()).Equals(3);
		}

		[Fact]
		public void Add_UInt64() {
			IStack<UInt64> stack = new BoundedArray<UInt64>(1, 2);
			stack.Add();
			Assert.That(stack.Pop()).Equals(3);
		}

		[Fact]
		public void Add_Single() {
			IStack<Single> stack = new BoundedArray<Single>(1.0f, 2.0f);
			stack.Add();
			Assert.That(stack.Pop()).Equals(3.0f);
		}

		[Fact]
		public void Add_Double() {
			IStack<Double> stack = new BoundedArray<Double>(1.0, 2.0);
			stack.Add();
			Assert.That(stack.Pop()).Equals(3.0);
		}

		[Fact]
		public void Add_Decimal() {
			IStack<Decimal> stack = new BoundedArray<Decimal>(1.0m, 2.0m);
			stack.Add();
			Assert.That(stack.Pop()).Equals(3.0m);
		}

		[Fact]
		public void BitDecrement_Double() {
			IStack<Double> stack = new BoundedArray<Double>(1.0);
			stack.BitDecrement();
			Assert.That(stack.Pop()).Equals(Math.BitDecrement(1.0));
		}

		[Fact]
		public void BitIncrement_Double() {
			IStack<Double> stack = new BoundedArray<Double>(1.0);
			stack.BitIncrement();
			Assert.That(stack.Pop()).Equals(Math.BitIncrement(1.0));
		}

		[Fact]
		public void Cbrt_Double() {
			IStack<Double> stack = new BoundedArray<Double>(1.0);
			stack.Cbrt();
			Assert.That(stack.Pop()).Equals(Math.Cbrt(1.0));
		}

		[Fact]
		public void Ceiling_Double() {
			IStack<Double> stack = new BoundedArray<Double>(0.5);
			stack.Ceiling();
			Assert.That(stack.Pop()).Equals(Math.Ceiling(0.5));
		}

		[Fact]
		public void CopySign_Double() {
			IStack<Double> stack = new BoundedArray<Double>(1.0, -1.0);
			stack.CopySign();
			Assert.That(stack.Pop()).Equals(Math.CopySign(1.0, -1.0));
		}

		[Fact]
		public void Divide_nint() {
			IStack<nint> stack = new BoundedArray<nint>(4, 2);
			stack.Divide();
			Assert.That(stack.Pop()).Equals(4 / 2);
		}

		[Fact]
		public void Divide_nuint() {
			IStack<nuint> stack = new BoundedArray<nuint>(4, 2);
			stack.Divide();
			Assert.That(stack.Pop()).Equals(4 / 2);
		}

		[Fact]
		public void Divide_Int32() {
			IStack<Int32> stack = new BoundedArray<Int32>(4, 2);
			stack.Divide();
			Assert.That(stack.Pop()).Equals(4 / 2);
		}

		[Fact]
		public void Divide_UInt32() {
			IStack<Int32> stack = new BoundedArray<Int32>(4, 2);
			stack.Divide();
			Assert.That(stack.Pop()).Equals(4 / 2);
		}

		[Fact]
		public void Divide_Int64() {
			IStack<Int64> stack = new BoundedArray<Int64>(4, 2);
			stack.Divide();
			Assert.That(stack.Pop()).Equals(4 / 2);
		}

		[Fact]
		public void Divide_UInt64() {
			IStack<UInt64> stack = new BoundedArray<UInt64>(4, 2);
			stack.Divide();
			Assert.That(stack.Pop()).Equals(4 / 2);
		}

		[Fact]
		public void Divide_Single() {
			IStack<Single> stack = new BoundedArray<Single>(4.0f, 2.0f);
			stack.Divide();
			Assert.That(stack.Pop()).Equals(4.0f / 2.0f);
		}

		[Fact]
		public void Divide_Double() {
			IStack<Double> stack = new BoundedArray<Double>(4.0, 2.0);
			stack.Divide();
			Assert.That(stack.Pop()).Equals(4.0 / 2.0);
		}

		[Fact]
		public void Divide_Decimal() {
			IStack<Decimal> stack = new BoundedArray<Decimal>(4.0m, 2.0m);
			stack.Divide();
			Assert.That(stack.Pop()).Equals(4.0m / 2.0m);
		}

		[Fact]
		public void Exp_Double() {
			IStack<Double> stack = new BoundedArray<Double>(2.0);
			stack.Exp();
			Assert.That(stack.Pop()).Equals(Math.Exp(2.0));
		}

		[Fact]
		public void Floor_Double() {
			IStack<Double> stack = new BoundedArray<Double>(0.5);
			stack.Floor();
			Assert.That(stack.Pop()).Equals(Math.Floor(0.5));
		}

		[Fact]
		public void IEEERemainder_Double() {
			IStack<Double> stack = new BoundedArray<Double>(4.0, 2.0);
			stack.IEEERemainder();
			Assert.That(stack.Pop()).Equals(Math.IEEERemainder(4.0, 2.0));
		}

		[Fact]
		public void ILogB_Double() {
			IStack<Double> stack = new BoundedArray<Double>(2.0);
			stack.ILogB();
			Assert.That(stack.Pop()).Equals(Math.ILogB(2.0));
		}

		[Fact]
		public void Log_Double() {
			IStack<Double> stack = new BoundedArray<Double>(2.0);
			stack.Log();
			Assert.That(stack.Pop()).Equals(Math.Log(2.0));
		}

		[Fact]
		public void Log10_Double() {
			IStack<Double> stack = new BoundedArray<Double>(2.0);
			stack.Log10();
			Assert.That(stack.Pop()).Equals(Math.Log10(2.0));
		}

		[Fact]
		public void Log2_Double() {
			IStack<Double> stack = new BoundedArray<Double>(2.0);
			stack.Log2();
			Assert.That(stack.Pop()).Equals(Math.Log2(2.0));
		}

		[Fact]
		public void Modulus_nint() {
			IStack<nint> stack = new BoundedArray<nint>(4, 2);
			stack.Modulus();
			Assert.That(stack.Pop()).Equals(4 % 2);
		}

		[Fact]
		public void Modulus_nuint() {
			IStack<nuint> stack = new BoundedArray<nuint>(4, 2);
			stack.Modulus();
			Assert.That(stack.Pop()).Equals(4 % 2);
		}

		[Fact]
		public void Modulus_Int32() {
			IStack<Int32> stack = new BoundedArray<Int32>(4, 2);
			stack.Modulus();
			Assert.That(stack.Pop()).Equals(4 % 2);
		}

		[Fact]
		public void Modulus_UInt32() {
			IStack<UInt32> stack = new BoundedArray<UInt32>(4, 2);
			stack.Modulus();
			Assert.That(stack.Pop()).Equals(4 % 2);
		}

		[Fact]
		public void Modulus_Int64() {
			IStack<Int64> stack = new BoundedArray<Int64>(4, 2);
			stack.Modulus();
			Assert.That(stack.Pop()).Equals(4 % 2);
		}

		[Fact]
		public void Modulus_UInt64() {
			IStack<UInt64> stack = new BoundedArray<UInt64>(4, 2);
			stack.Modulus();
			Assert.That(stack.Pop()).Equals(4 % 2);
		}

		[Fact]
		public void Modulus_Single() {
			IStack<Single> stack = new BoundedArray<Single>(4.0f, 2.0f);
			stack.Modulus();
			Assert.That(stack.Pop()).Equals(4.0f % 2.0f);
		}

		[Fact]
		public void Modulus_Double() {
			IStack<Double> stack = new BoundedArray<Double>(4.0, 2.0);
			stack.Modulus();
			Assert.That(stack.Pop()).Equals(4.0 % 2.0);
		}

		[Fact]
		public void Modulus_Decimal() {
			IStack<Decimal> stack = new BoundedArray<Decimal>(4.0m, 2.0m);
			stack.Modulus();
			Assert.That(stack.Pop()).Equals(4.0m % 2.0m);
		}

		[Fact]
		public void Multiply_nint() {
			IStack<nint> stack = new BoundedArray<nint>(4, 2);
			stack.Multiply();
			Assert.That(stack.Pop()).Equals(4 * 2);
		}

		[Fact]
		public void Multiply_nuint() {
			IStack<nuint> stack = new BoundedArray<nuint>(4, 2);
			stack.Multiply();
			Assert.That(stack.Pop()).Equals(4 * 2);
		}

		[Fact]
		public void Multiply_Int32() {
			IStack<Int32> stack = new BoundedArray<Int32>(4, 2);
			stack.Multiply();
			Assert.That(stack.Pop()).Equals(4 * 2);
		}

		[Fact]
		public void Multiply_UInt32() {
			IStack<UInt32> stack = new BoundedArray<UInt32>(4, 2);
			stack.Multiply();
			Assert.That(stack.Pop()).Equals(4 * 2);
		}

		[Fact]
		public void Multiply_Int64() {
			IStack<Int64> stack = new BoundedArray<Int64>(4, 2);
			stack.Multiply();
			Assert.That(stack.Pop()).Equals(4 * 2);
		}

		[Fact]
		public void Multiply_UInt64() {
			IStack<UInt64> stack = new BoundedArray<UInt64>(4, 2);
			stack.Multiply();
			Assert.That(stack.Pop()).Equals(4 * 2);
		}

		[Fact]
		public void Multiply_Single() {
			IStack<Single> stack = new BoundedArray<Single>(4.0f, 2.0f);
			stack.Multiply();
			Assert.That(stack.Pop()).Equals(4.0f * 2.0f);
		}

		[Fact]
		public void Multiply_Double() {
			IStack<Double> stack = new BoundedArray<Double>(4.0, 2.0);
			stack.Multiply();
			Assert.That(stack.Pop()).Equals(4.0 * 2.0);
		}

		[Fact]
		public void Multiply_Decimal() {
			IStack<Decimal> stack = new BoundedArray<Decimal>(4.0m, 2.0m);
			stack.Multiply();
			Assert.That(stack.Pop()).Equals(4.0m * 2.0m);
		}

		[Fact]
		public void Pow_Double() {
			IStack<Double> stack = new BoundedArray<Double>(1.0, 2.0);
			stack.Pow();
			Assert.That(stack.Pop()).Equals(Math.Pow(1.0, 2.0));
		}

		[Fact]
		public void Sqrt_Double() {
			IStack<Double> stack = new BoundedArray<Double>(1.0);
			stack.Sqrt();
			Assert.That(stack.Pop()).Equals(Math.Sqrt(1.0));
		}

		[Fact]
		public void Subtract_nint() {
			IStack<nint> stack = new BoundedArray<nint>(4, 2);
			stack.Subtract();
			Assert.That(stack.Pop()).Equals(4 - 2);
		}

		[Fact]
		public void Subtract_nuint() {
			IStack<nuint> stack = new BoundedArray<nuint>(4, 2);
			stack.Subtract();
			Assert.That(stack.Pop()).Equals(4 - 2);
		}

		[Fact]
		public void Subtract_Int32() {
			IStack<Int32> stack = new BoundedArray<Int32>(4, 2);
			stack.Subtract();
			Assert.That(stack.Pop()).Equals(4 - 2);
		}

		[Fact]
		public void Subtract_UInt32() {
			IStack<UInt32> stack = new BoundedArray<UInt32>(4, 2);
			stack.Subtract();
			Assert.That(stack.Pop()).Equals(4 - 2);
		}

		[Fact]
		public void Subtract_Int64() {
			IStack<Int64> stack = new BoundedArray<Int64>(4, 2);
			stack.Subtract();
			Assert.That(stack.Pop()).Equals(4 - 2);
		}

		[Fact]
		public void Subtract_UInt64() {
			IStack<UInt64> stack = new BoundedArray<UInt64>(4, 2);
			stack.Subtract();
			Assert.That(stack.Pop()).Equals(4 - 2);
		}

		[Fact]
		public void Subtract_Single() {
			IStack<Single> stack = new BoundedArray<Single>(4.0f, 2.0f);
			stack.Subtract();
			Assert.That(stack.Pop()).Equals(4.0f - 2.0f);
		}

		[Fact]
		public void Subtract_Double() {
			IStack<Double> stack = new BoundedArray<Double>(4.0, 2.0);
			stack.Subtract();
			Assert.That(stack.Pop()).Equals(4.0 - 2.0);
		}

		[Fact]
		public void Subtract_Decimal() {
			IStack<Decimal> stack = new BoundedArray<Decimal>(4.0m, 2.0m);
			stack.Subtract();
			Assert.That(stack.Pop()).Equals(4.0m - 2.0m);
		}

		[Fact]
		public void Truncate_Double() {
			IStack<Double> stack = new BoundedArray<Double>(0.5);
			stack.Truncate();
			Assert.That(stack.Pop()).Equals(Math.Truncate(0.5));
		}
	}
}
