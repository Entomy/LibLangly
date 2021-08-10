using System;
using Collectathon;
using Numbersome;
using Xunit;

namespace Numbersome {
	public class ArithmeticExtensions_Tests {
		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Int32[] { })]
		[InlineData(120, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Product_nint(Double expected, Int32[] values) {
			nint[] vals = null;
			if (values is not null) {
				vals = new nint[values.Length];
				for (nint i = 0; i < values.Length; i++) {
					vals[i] = (nint)values[i];
				}
			}
			DynamicArray<nint> array = values is not null ? new DynamicArray<nint>(vals) : null;
			Assert.Equal(expected, array.Product());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new UInt32[] { })]
		[InlineData(120, new UInt32[] { 1, 2, 3, 4, 5 })]
		public void Product_nuint(Double expected, UInt32[] values) {
			nuint[] vals = null;
			if (values is not null) {
				vals = new nuint[values.Length];
				for (nint i = 0; i < values.Length; i++) {
					vals[i] = (nuint)values[i];
				}
			}
			DynamicArray<nuint> array = values is not null ? new DynamicArray<nuint>(vals) : null;
			Assert.Equal(expected, array.Product());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new SByte[] { })]
		[InlineData(120, new SByte[] { 1, 2, 3, 4, 5 })]
		public void Product_SByte(Single expected, SByte[] values) {
			DynamicArray<SByte> array = values is not null ? new DynamicArray<SByte>(values) : null;
			Assert.Equal(expected, array.Product());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new Byte[] { })]
		[InlineData(120, new Byte[] { 1, 2, 3, 4, 5 })]
		public void Product_Byte(Single expected, Byte[] values) {
			DynamicArray<Byte> array = values is not null ? new DynamicArray<Byte>(values) : null;
			Assert.Equal(expected, array.Product());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new Int16[] { })]
		[InlineData(120, new Int16[] { 1, 2, 3, 4, 5 })]
		public void Product_Int16(Single expected, Int16[] values) {
			DynamicArray<Int16> array = values is not null ? new DynamicArray<Int16>(values) : null;
			Assert.Equal(expected, array.Product());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new UInt16[] { })]
		[InlineData(120, new UInt16[] { 1, 2, 3, 4, 5 })]
		public void Product_UInt16(Single expected, UInt16[] values) {
			DynamicArray<UInt16> array = values is not null ? new DynamicArray<UInt16>(values) : null;
			Assert.Equal(expected, array.Product());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Int32[] { })]
		[InlineData(120, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Product_Int32(Double expected, Int32[] values) {
			DynamicArray<Int32> array = values is not null ? new DynamicArray<Int32>(values) : null;
			Assert.Equal(expected, array.Product());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new UInt32[] { })]
		[InlineData(120, new UInt32[] { 1, 2, 3, 4, 5 })]
		public void Product_UInt32(Double expected, UInt32[] values) {
			DynamicArray<UInt32> array = values is not null ? new DynamicArray<UInt32>(values) : null;
			Assert.Equal(expected, array.Product());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Int64[] { })]
		[InlineData(120, new Int64[] { 1, 2, 3, 4, 5 })]
		public void Product_Int64(Double expected, Int64[] values) {
			DynamicArray<Int64> array = values is not null ? new DynamicArray<Int64>(values) : null;
			Assert.Equal(expected, array.Product());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new UInt64[] { })]
		[InlineData(120, new UInt64[] { 1, 2, 3, 4, 5 })]
		public void Product_UInt64(Double expected, UInt64[] values) {
			DynamicArray<UInt64> array = values is not null ? new DynamicArray<UInt64>(values) : null;
			Assert.Equal(expected, array.Product());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new Single[] { })]
		[InlineData(120, new Single[] { 1, 2, 3, 4, 5 })]
		public void Product_Single(Single expected, Single[] values) {
			DynamicArray<Single> array = values is not null ? new DynamicArray<Single>(values) : null;
			Assert.Equal(expected, array.Product());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Double[] { })]
		[InlineData(120, new Double[] { 1, 2, 3, 4, 5 })]
		public void Product_Double(Double expected, Double[] values) {
			DynamicArray<Double> array = values is not null ? new DynamicArray<Double>(values) : null;
			Assert.Equal(expected, array.Product());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Int32[] { })]
		[InlineData(15, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Sum_nint(Double expected, Int32[] values) {
			nint[] vals = null;
			if (values is not null) {
				vals = new nint[values.Length];
				for (nint i = 0; i < values.Length; i++) {
					vals[i] = (nint)values[i];
				}
			}
			DynamicArray<nint> array = values is not null ? new DynamicArray<nint>(vals) : null;
			Assert.Equal(expected, array.Sum());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new UInt32[] { })]
		[InlineData(15, new UInt32[] { 1, 2, 3, 4, 5 })]
		public void Sum_nuint(Double expected, UInt32[] values) {
			nuint[] vals = null;
			if (values is not null) {
				vals = new nuint[values.Length];
				for (nint i = 0; i < values.Length; i++) {
					vals[i] = (nuint)values[i];
				}
			}
			DynamicArray<nuint> array = values is not null ? new DynamicArray<nuint>(vals) : null;
			Assert.Equal(expected, array.Sum());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new SByte[] { })]
		[InlineData(15, new SByte[] { 1, 2, 3, 4, 5 })]
		public void Sum_SByte(Single expected, SByte[] values) {
			DynamicArray<SByte> array = values is not null ? new DynamicArray<SByte>(values) : null;
			Assert.Equal(expected, array.Sum());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new Byte[] { })]
		[InlineData(15, new Byte[] { 1, 2, 3, 4, 5 })]
		public void Sum_Byte(Single expected, Byte[] values) {
			DynamicArray<Byte> array = values is not null ? new DynamicArray<Byte>(values) : null;
			Assert.Equal(expected, array.Sum());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new Int16[] { })]
		[InlineData(15, new Int16[] { 1, 2, 3, 4, 5 })]
		public void Sum_Int16(Single expected, Int16[] values) {
			DynamicArray<Int16> array = values is not null ? new DynamicArray<Int16>(values) : null;
			Assert.Equal(expected, array.Sum());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new UInt16[] { })]
		[InlineData(15, new UInt16[] { 1, 2, 3, 4, 5 })]
		public void Sum_UInt16(Single expected, UInt16[] values) {
			DynamicArray<UInt16> array = values is not null ? new DynamicArray<UInt16>(values) : null;
			Assert.Equal(expected, array.Sum());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Int32[] { })]
		[InlineData(15, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Sum_Int32(Double expected, Int32[] values) {
			DynamicArray<Int32> array = values is not null ? new DynamicArray<Int32>(values) : null;
			Assert.Equal(expected, array.Sum());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new UInt32[] { })]
		[InlineData(15, new UInt32[] { 1, 2, 3, 4, 5 })]
		public void Sum_UInt32(Double expected, UInt32[] values) {
			DynamicArray<UInt32> array = values is not null ? new DynamicArray<UInt32>(values) : null;
			Assert.Equal(expected, array.Sum());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Int64[] { })]
		[InlineData(15, new Int64[] { 1, 2, 3, 4, 5 })]
		public void Sum_Int64(Double expected, Int64[] values) {
			DynamicArray<Int64> array = values is not null ? new DynamicArray<Int64>(values) : null;
			Assert.Equal(expected, array.Sum());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new UInt64[] { })]
		[InlineData(15, new UInt64[] { 1, 2, 3, 4, 5 })]
		public void Sum_UInt64(Double expected, UInt64[] values) {
			DynamicArray<UInt64> array = values is not null ? new DynamicArray<UInt64>(values) : null;
			Assert.Equal(expected, array.Sum());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new Single[] { })]
		[InlineData(15, new Single[] { 1, 2, 3, 4, 5 })]
		public void Sum_Single(Single expected, Single[] values) {
			DynamicArray<Single> array = values is not null ? new DynamicArray<Single>(values) : null;
			Assert.Equal(expected, array.Sum());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Double[] { })]
		[InlineData(15, new Double[] { 1, 2, 3, 4, 5 })]
		public void Sum_Double(Double expected, Double[] values) {
			DynamicArray<Double> array = values is not null ? new DynamicArray<Double>(values) : null;
			Assert.Equal(expected, array.Sum());
		}
	}
}
