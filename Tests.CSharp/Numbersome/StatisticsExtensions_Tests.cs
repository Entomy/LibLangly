using System;
using Collectathon;
using Numbersome;
using Xunit;

namespace Numbersome {
	public class StatisticsExtensions_Tests {
		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Int32[] { })]
		[InlineData(5.0, new Int32[] { 1, 2, 3, 4, 5 })]
		[InlineData(5.0, new Int32[] { 5, 4, 3, 2, 1 })]
		public void Max_nint(Double expected, Int32[] values) {
			nint[] vals = null;
			if (values is not null) {
				vals = new nint[values.Length];
				for (nint i = 0; i < values.Length; i++) {
					vals[i] = (nint)values[i];
				}
			}
			BoundedArray<nint> array = values is not null ? new BoundedArray<nint>(vals) : null;
			Assert.Equal(expected, array.Max());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new UInt32[] { })]
		[InlineData(5.0, new UInt32[] { 1, 2, 3, 4, 5 })]
		[InlineData(5.0, new UInt32[] { 5, 4, 3, 2, 1 })]
		public void Max_nuint(Double expected, UInt32[] values) {
			nuint[] vals = null;
			if (values is not null) {
				vals = new nuint[values.Length];
				for (nint i = 0; i < values.Length; i++) {
					vals[i] = (nuint)values[i];
				}
			}
			BoundedArray<nuint> array = values is not null ? new BoundedArray<nuint>(vals) : null;
			Assert.Equal(expected, array.Max());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new SByte[] { })]
		[InlineData(5.0f, new SByte[] { 1, 2, 3, 4, 5 })]
		[InlineData(5.0f, new SByte[] { 5, 4, 3, 2, 1 })]
		public void Max_SByte(Single expected, SByte[] values) {
			BoundedArray<SByte> array = values is not null ? new BoundedArray<SByte>(values) : null;
			Assert.Equal(expected, array.Max());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new Byte[] { })]
		[InlineData(5.0f, new Byte[] { 1, 2, 3, 4, 5 })]
		[InlineData(5.0f, new Byte[] { 5, 4, 3, 2, 1 })]
		public void Max_Byte(Single expected, Byte[] values) {
			BoundedArray<Byte> array = values is not null ? new BoundedArray<Byte>(values) : null;
			Assert.Equal(expected, array.Max());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new Int16[] { })]
		[InlineData(5.0f, new Int16[] { 1, 2, 3, 4, 5 })]
		[InlineData(5.0f, new Int16[] { 5, 4, 3, 2, 1 })]
		public void Max_Int16(Single expected, Int16[] values) {
			BoundedArray<Int16> array = values is not null ? new BoundedArray<Int16>(values) : null;
			Assert.Equal(expected, array.Max());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new UInt16[] { })]
		[InlineData(5.0f, new UInt16[] { 1, 2, 3, 4, 5 })]
		[InlineData(5.0f, new UInt16[] { 5, 4, 3, 2, 1 })]
		public void Max_UInt16(Single expected, UInt16[] values) {
			BoundedArray<UInt16> array = values is not null ? new BoundedArray<UInt16>(values) : null;
			Assert.Equal(expected, array.Max());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Int32[] { })]
		[InlineData(5.0, new Int32[] { 1, 2, 3, 4, 5 })]
		[InlineData(5.0, new Int32[] { 5, 4, 3, 2, 1 })]
		public void Max_Int32(Double expected, Int32[] values) {
			BoundedArray<Int32> array = values is not null ? new BoundedArray<Int32>(values) : null;
			Assert.Equal(expected, array.Max());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new UInt32[] { })]
		[InlineData(5.0, new UInt32[] { 1, 2, 3, 4, 5 })]
		[InlineData(5.0, new UInt32[] { 5, 4, 3, 2, 1 })]
		public void Max_UInt32(Double expected, UInt32[] values) {
			BoundedArray<UInt32> array = values is not null ? new BoundedArray<UInt32>(values) : null;
			Assert.Equal(expected, array.Max());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Int64[] { })]
		[InlineData(5.0, new Int64[] { 1, 2, 3, 4, 5 })]
		[InlineData(5.0, new Int64[] { 5, 4, 3, 2, 1 })]
		public void Max_Int64(Double expected, Int64[] values) {
			BoundedArray<Int64> array = values is not null ? new BoundedArray<Int64>(values) : null;
			Assert.Equal(expected, array.Max());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new UInt64[] { })]
		[InlineData(5.0, new UInt64[] { 1, 2, 3, 4, 5 })]
		[InlineData(5.0, new UInt64[] { 5, 4, 3, 2, 1 })]
		public void Max_UInt64(Double expected, UInt64[] values) {
			BoundedArray<UInt64> array = values is not null ? new BoundedArray<UInt64>(values) : null;
			Assert.Equal(expected, array.Max());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new Single[] { })]
		[InlineData(5.0f, new Single[] { 1.0f, 2.0f, 3.0f, 4.0f, 5.0f })]
		[InlineData(5.0f, new Single[] { 5.0f, 4.0f, 3.0f, 2.0f, 1.0f })]
		public void Max_Single(Single expected, Single[] values) {
			BoundedArray<Single> array = values is not null ? new BoundedArray<Single>(values) : null;
			Assert.Equal(expected, array.Max());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Double[] { })]
		[InlineData(5.0, new Double[] { 1.0, 2.0, 3.0, 4.0, 5.0 })]
		[InlineData(5.0, new Double[] { 5.0, 4.0, 3.0, 2.0, 1.0 })]
		public void Max_Double(Double expected, Double[] values) {
			BoundedArray<Double> array = values is not null ? new BoundedArray<Double>(values) : null;
			Assert.Equal(expected, array.Max());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Int32[] { })]
		[InlineData(3.0, new Int32[] { 1, 2, 3, 4, 5 })]
		[InlineData(3.0, new Int32[] { 5, 4, 3, 2, 1 })]
		public void ArithmeticMean_nint(Double expected, Int32[] values) {
			nint[] vals = null;
			if (values is not null) {
				vals = new nint[values.Length];
				for (nint i = 0; i < values.Length; i++) {
					vals[i] = (nint)values[i];
				}
			}
			BoundedArray<nint> array = values is not null ? new BoundedArray<nint>(vals) : null;
			Assert.Equal(expected, array.ArithmeticMean());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new UInt32[] { })]
		[InlineData(3.0, new UInt32[] { 1, 2, 3, 4, 5 })]
		[InlineData(3.0, new UInt32[] { 5, 4, 3, 2, 1 })]
		public void ArithmeticMean_nuint(Double expected, UInt32[] values) {
			nuint[] vals = null;
			if (values is not null) {
				vals = new nuint[values.Length];
				for (nint i = 0; i < values.Length; i++) {
					vals[i] = (nuint)values[i];
				}
			}
			BoundedArray<nuint> array = values is not null ? new BoundedArray<nuint>(vals) : null;
			Assert.Equal(expected, array.ArithmeticMean());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Byte[] { })]
		[InlineData(3.0, new Byte[] { 1, 2, 3, 4, 5 })]
		[InlineData(3.0, new Byte[] { 5, 4, 3, 2, 1 })]
		public void ArithmeticMean_Byte(Double expected, Byte[] values) {
			BoundedArray<Byte> array = values is not null ? new BoundedArray<Byte>(values) : null;
			Assert.Equal(expected, array.ArithmeticMean());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new SByte[] { })]
		[InlineData(3.0, new SByte[] { 1, 2, 3, 4, 5 })]
		[InlineData(3.0, new SByte[] { 5, 4, 3, 2, 1 })]
		public void ArithmeticMean_SByte(Double expected, SByte[] values) {
			BoundedArray<SByte> array = values is not null ? new BoundedArray<SByte>(values) : null;
			Assert.Equal(expected, array.ArithmeticMean());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Int16[] { })]
		[InlineData(3.0, new Int16[] { 1, 2, 3, 4, 5 })]
		[InlineData(3.0, new Int16[] { 5, 4, 3, 2, 1 })]
		public void ArithmeticMean_Int16(Double expected, Int16[] values) {
			BoundedArray<Int16> array = values is not null ? new BoundedArray<Int16>(values) : null;
			Assert.Equal(expected, array.ArithmeticMean());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new UInt16[] { })]
		[InlineData(3.0, new UInt16[] { 1, 2, 3, 4, 5 })]
		[InlineData(3.0, new UInt16[] { 5, 4, 3, 2, 1 })]
		public void ArithmeticMean_UInt16(Double expected, UInt16[] values) {
			BoundedArray<UInt16> array = values is not null ? new BoundedArray<UInt16>(values) : null;
			Assert.Equal(expected, array.ArithmeticMean());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Int32[] { })]
		[InlineData(3.0, new Int32[] { 1, 2, 3, 4, 5 })]
		[InlineData(3.0, new Int32[] { 5, 4, 3, 2, 1 })]
		public void ArithmeticMean_Int32(Double expected, Int32[] values) {
			BoundedArray<Int32> array = values is not null ? new BoundedArray<Int32>(values) : null;
			Assert.Equal(expected, array.ArithmeticMean());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new UInt32[] { })]
		[InlineData(3.0, new UInt32[] { 1, 2, 3, 4, 5 })]
		[InlineData(3.0, new UInt32[] { 5, 4, 3, 2, 1 })]
		public void ArithmeticMean_UInt32(Double expected, UInt32[] values) {
			BoundedArray<UInt32> array = values is not null ? new BoundedArray<UInt32>(values) : null;
			Assert.Equal(expected, array.ArithmeticMean());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Int64[] { })]
		[InlineData(3.0, new Int64[] { 1, 2, 3, 4, 5 })]
		[InlineData(3.0, new Int64[] { 5, 4, 3, 2, 1 })]
		public void ArithmeticMean_Int64(Double expected, Int64[] values) {
			BoundedArray<Int64> array = values is not null ? new BoundedArray<Int64>(values) : null;
			Assert.Equal(expected, array.ArithmeticMean());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new UInt64[] { })]
		[InlineData(3.0, new UInt64[] { 1, 2, 3, 4, 5 })]
		[InlineData(3.0, new UInt64[] { 5, 4, 3, 2, 1 })]
		public void ArithmeticMean_UInt64(Double expected, UInt64[] values) {
			BoundedArray<UInt64> array = values is not null ? new BoundedArray<UInt64>(values) : null;
			Assert.Equal(expected, array.ArithmeticMean());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Single[] { })]
		[InlineData(3.0, new Single[] { 1.0f, 2.0f, 3.0f, 4.0f, 5.0f })]
		[InlineData(3.0, new Single[] { 5.0f, 4.0f, 3.0f, 2.0f, 1.0f })]
		public void ArithmeticMean_Single(Double expected, Single[] values) {
			BoundedArray<Single> array = values is not null ? new BoundedArray<Single>(values) : null;
			Assert.Equal(expected, array.ArithmeticMean());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Double[] { })]
		[InlineData(3.0, new Double[] { 1.0, 2.0, 3.0, 4.0, 5.0 })]
		[InlineData(3.0, new Double[] { 5.0, 4.0, 3.0, 2.0, 1.0 })]
		public void ArithmeticMean_Double(Double expected, Double[] values) {
			BoundedArray<Double> array = values is not null ? new BoundedArray<Double>(values) : null;
			Assert.Equal(expected, array.ArithmeticMean());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Int32[] { })]
		[InlineData(2.605171084697352, new Int32[] { 1, 2, 3, 4, 5 })]
		[InlineData(2.605171084697352, new Int32[] { 5, 4, 3, 2, 1 })]
		public void GeometricMean_nint(Double expected, Int32[] values) {
			nint[] vals = null;
			if (values is not null) {
				vals = new nint[values.Length];
				for (nint i = 0; i < values.Length; i++) {
					vals[i] = (nint)values[i];
				}
			}
			BoundedArray<nint> array = values is not null ? new BoundedArray<nint>(vals) : null;
			Assert.Equal(expected, array.GeometricMean());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new UInt32[] { })]
		[InlineData(2.605171084697352, new UInt32[] { 1, 2, 3, 4, 5 })]
		[InlineData(2.605171084697352, new UInt32[] { 5, 4, 3, 2, 1 })]
		public void GeometricMean_nuint(Double expected, UInt32[] values) {
			nuint[] vals = null;
			if (values is not null) {
				vals = new nuint[values.Length];
				for (nint i = 0; i < values.Length; i++) {
					vals[i] = (nuint)values[i];
				}
			}
			BoundedArray<nuint> array = values is not null ? new BoundedArray<nuint>(vals) : null;
			Assert.Equal(expected, array.GeometricMean());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Byte[] { })]
		[InlineData(2.605171084697352, new Byte[] { 1, 2, 3, 4, 5 })]
		[InlineData(2.605171084697352, new Byte[] { 5, 4, 3, 2, 1 })]
		public void GeometricMean_Byte(Double expected, Byte[] values) {
			BoundedArray<Byte> array = values is not null ? new BoundedArray<Byte>(values) : null;
			Assert.Equal(expected, array.GeometricMean());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new SByte[] { })]
		[InlineData(2.605171084697352, new SByte[] { 1, 2, 3, 4, 5 })]
		[InlineData(2.605171084697352, new SByte[] { 5, 4, 3, 2, 1 })]
		public void GeometricMean_SByte(Double expected, SByte[] values) {
			BoundedArray<SByte> array = values is not null ? new BoundedArray<SByte>(values) : null;
			Assert.Equal(expected, array.GeometricMean());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Int16[] { })]
		[InlineData(2.605171084697352, new Int16[] { 1, 2, 3, 4, 5 })]
		[InlineData(2.605171084697352, new Int16[] { 5, 4, 3, 2, 1 })]
		public void GeometricMean_Int16(Double expected, Int16[] values) {
			BoundedArray<Int16> array = values is not null ? new BoundedArray<Int16>(values) : null;
			Assert.Equal(expected, array.GeometricMean());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new UInt16[] { })]
		[InlineData(2.605171084697352, new UInt16[] { 1, 2, 3, 4, 5 })]
		[InlineData(2.605171084697352, new UInt16[] { 5, 4, 3, 2, 1 })]
		public void GeometricMean_UInt16(Double expected, UInt16[] values) {
			BoundedArray<UInt16> array = values is not null ? new BoundedArray<UInt16>(values) : null;
			Assert.Equal(expected, array.GeometricMean());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Int32[] { })]
		[InlineData(2.605171084697352, new Int32[] { 1, 2, 3, 4, 5 })]
		[InlineData(2.605171084697352, new Int32[] { 5, 4, 3, 2, 1 })]
		public void GeometricMean_Int32(Double expected, Int32[] values) {
			BoundedArray<Int32> array = values is not null ? new BoundedArray<Int32>(values) : null;
			Assert.Equal(expected, array.GeometricMean());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new UInt32[] { })]
		[InlineData(2.605171084697352, new UInt32[] { 1, 2, 3, 4, 5 })]
		[InlineData(2.605171084697352, new UInt32[] { 5, 4, 3, 2, 1 })]
		public void GeometricMean_UInt32(Double expected, UInt32[] values) {
			BoundedArray<UInt32> array = values is not null ? new BoundedArray<UInt32>(values) : null;
			Assert.Equal(expected, array.GeometricMean());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Int64[] { })]
		[InlineData(2.605171084697352, new Int64[] { 1, 2, 3, 4, 5 })]
		[InlineData(2.605171084697352, new Int64[] { 5, 4, 3, 2, 1 })]
		public void GeometricMean_Int64(Double expected, Int64[] values) {
			BoundedArray<Int64> array = values is not null ? new BoundedArray<Int64>(values) : null;
			Assert.Equal(expected, array.GeometricMean());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new UInt64[] { })]
		[InlineData(2.605171084697352, new UInt64[] { 1, 2, 3, 4, 5 })]
		[InlineData(2.605171084697352, new UInt64[] { 5, 4, 3, 2, 1 })]
		public void GeometricMean_UInt64(Double expected, UInt64[] values) {
			BoundedArray<UInt64> array = values is not null ? new BoundedArray<UInt64>(values) : null;
			Assert.Equal(expected, array.GeometricMean());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Single[] { })]
		[InlineData(2.605171084697352, new Single[] { 1.0f, 2.0f, 3.0f, 4.0f, 5.0f })]
		[InlineData(2.605171084697352, new Single[] { 5.0f, 4.0f, 3.0f, 2.0f, 1.0f })]
		public void GeometricMean_Single(Double expected, Single[] values) {
			BoundedArray<Single> array = values is not null ? new BoundedArray<Single>(values) : null;
			Assert.Equal(expected, array.GeometricMean());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Double[] { })]
		[InlineData(2.605171084697352, new Double[] { 1.0, 2.0, 3.0, 4.0, 5.0 })]
		[InlineData(2.605171084697352, new Double[] { 5.0, 4.0, 3.0, 2.0, 1.0 })]
		public void GeometricMean_Double(Double expected, Double[] values) {
			BoundedArray<Double> array = values is not null ? new BoundedArray<Double>(values) : null;
			Assert.Equal(expected, array.GeometricMean());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Int32[] { })]
		[InlineData(1, new Int32[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new Int32[] { 5, 4, 3, 2, 1 })]
		public void Min_nint(Double expected, Int32[] values) {
			nint[] vals = null;
			if (values is not null) {
				vals = new nint[values.Length];
				for (nint i = 0; i < values.Length; i++) {
					vals[i] = (nint)values[i];
				}
			}
			BoundedArray<nint> array = values is not null ? new BoundedArray<nint>(vals) : null;
			Assert.Equal(expected, array.Min());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new UInt32[] { })]
		[InlineData(1, new UInt32[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new UInt32[] { 5, 4, 3, 2, 1 })]
		public void Min_nuint(Double expected, UInt32[] values) {
			nuint[] vals = null;
			if (values is not null) {
				vals = new nuint[values.Length];
				for (nint i = 0; i < values.Length; i++) {
					vals[i] = (nuint)values[i];
				}
			}
			BoundedArray<nuint> array = values is not null ? new BoundedArray<nuint>(vals) : null;
			Assert.Equal(expected, array.Min());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new SByte[] { })]
		[InlineData(1, new SByte[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new SByte[] { 5, 4, 3, 2, 1 })]
		public void Min_SByte(Single expected, SByte[] values) {
			BoundedArray<SByte> array = values is not null ? new BoundedArray<SByte>(values) : null;
			Assert.Equal(expected, array.Min());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new Byte[] { })]
		[InlineData(1, new Byte[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new Byte[] { 5, 4, 3, 2, 1 })]
		public void Min_Byte(Single expected, Byte[] values) {
			BoundedArray<Byte> array = values is not null ? new BoundedArray<Byte>(values) : null;
			Assert.Equal(expected, array.Min());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new Int16[] { })]
		[InlineData(1, new Int16[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new Int16[] { 5, 4, 3, 2, 1 })]
		public void Min_Int16(Single expected, Int16[] values) {
			BoundedArray<Int16> array = values is not null ? new BoundedArray<Int16>(values) : null;
			Assert.Equal(expected, array.Min());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new UInt16[] { })]
		[InlineData(1, new UInt16[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new UInt16[] { 5, 4, 3, 2, 1 })]
		public void Min_UInt16(Single expected, UInt16[] values) {
			BoundedArray<UInt16> array = values is not null ? new BoundedArray<UInt16>(values) : null;
			Assert.Equal(expected, array.Min());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Int32[] { })]
		[InlineData(1, new Int32[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new Int32[] { 5, 4, 3, 2, 1 })]
		public void Min_Int32(Double expected, Int32[] values) {
			BoundedArray<Int32> array = values is not null ? new BoundedArray<Int32>(values) : null;
			Assert.Equal(expected, array.Min());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new UInt32[] { })]
		[InlineData(1, new UInt32[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new UInt32[] { 5, 4, 3, 2, 1 })]
		public void Min_UInt32(Double expected, UInt32[] values) {
			BoundedArray<UInt32> array = values is not null ? new BoundedArray<UInt32>(values) : null;
			Assert.Equal(expected, array.Min());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Int64[] { })]
		[InlineData(1, new Int64[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new Int64[] { 5, 4, 3, 2, 1 })]
		public void Min_Int64(Double expected, Int64[] values) {
			BoundedArray<Int64> array = values is not null ? new BoundedArray<Int64>(values) : null;
			Assert.Equal(expected, array.Min());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new UInt64[] { })]
		[InlineData(1, new UInt64[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new UInt64[] { 5, 4, 3, 2, 1 })]
		public void Min_UInt64(Double expected, UInt64[] values) {
			BoundedArray<UInt64> array = values is not null ? new BoundedArray<UInt64>(values) : null;
			Assert.Equal(expected, array.Min());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new Single[] { })]
		[InlineData(1, new Single[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new Single[] { 5, 4, 3, 2, 1 })]
		public void Min_Single(Single expected, Single[] values) {
			BoundedArray<Single> array = values is not null ? new BoundedArray<Single>(values) : null;
			Assert.Equal(expected, array.Min());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Double[] { })]
		[InlineData(1, new Double[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new Double[] { 5, 4, 3, 2, 1 })]
		public void Min_Double(Double expected, Double[] values) {
			BoundedArray<Double> array = values is not null ? new BoundedArray<Double>(values) : null;
			Assert.Equal(expected, array.Min());
		}

		[Theory]
		[InlineData('a', new Char[] { 'a' })]
		[InlineData('a', new Char[] { 'a', 'a', 'a', 'b', 'b', 'c' })]
		[InlineData('c', new Char[] { 'a', 'b', 'b', 'c', 'c', 'c' })]
		public void Mode(Char expected, Char[] values) {
			BoundedArray<Char> array = values is not null ? new BoundedArray<Char>(values) : null;
			Assert.Equal(expected, array.Mode());
		}
	}
}
