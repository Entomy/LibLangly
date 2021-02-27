using System;
using Xunit;
using Langly.DataStructures.Lists;

namespace Langly {
	public class Numerics_Tests {
		[Theory]
		[MemberData(nameof(Numerics_Data.Max_nint), MemberType = typeof(Numerics_Data))]
		public void Max_nint(Double expected, nint[] values) {
			Chain<nint> chain = new Chain<nint>().Add(values);
			Assert.Equal(expected, chain.Max());
		}

		[Theory]
		[MemberData(nameof(Numerics_Data.Max_nuint), MemberType = typeof(Numerics_Data))]
		public void Max_nuint(Double expected, nuint[] values) {
			Chain<nuint> chain = new Chain<nuint>().Add(values);
			Assert.Equal(expected, chain.Max());
		}

		[Theory]
		[MemberData(nameof(Numerics_Data.Max_SByte), MemberType = typeof(Numerics_Data))]
		public void Max_SByte(Single expected, SByte[] values) {
			Chain<SByte> chain = new Chain<SByte>().Add(values);
			Assert.Equal(expected, chain.Max());
		}

		[Theory]
		[MemberData(nameof(Numerics_Data.Max_Byte), MemberType = typeof(Numerics_Data))]
		public void Max_Byte(Single expected, Byte[] values) {
			Chain<Byte> chain = new Chain<Byte>().Add(values);
			Assert.Equal(expected, chain.Max());
		}

		[Theory]
		[MemberData(nameof(Numerics_Data.Max_Int16), MemberType = typeof(Numerics_Data))]
		public void Max_Int16(Single expected, Int16[] values) {
			Chain<Int16> chain = new Chain<Int16>().Add(values);
			Assert.Equal(expected, chain.Max());
		}

		[Theory]
		[MemberData(nameof(Numerics_Data.Max_UInt16), MemberType = typeof(Numerics_Data))]
		public void Max_UInt16(Single expected, UInt16[] values) {
			Chain<UInt16> chain = new Chain<UInt16>().Add(values);
			Assert.Equal(expected, chain.Max());
		}

		[Theory]
		[MemberData(nameof(Numerics_Data.Max_Int32), MemberType = typeof(Numerics_Data))]
		public void Max_Int32(Double expected, Int32[] values) {
			Chain<Int32> chain = new Chain<Int32>().Add(values);
			Assert.Equal(expected, chain.Max());
		}

		[Theory]
		[MemberData(nameof(Numerics_Data.Max_UInt32), MemberType = typeof(Numerics_Data))]
		public void Max_UInt32(Double expected, UInt32[] values) {
			Chain<UInt32> chain = new Chain<UInt32>().Add(values);
			Assert.Equal(expected, chain.Max());
		}

		[Theory]
		[MemberData(nameof(Numerics_Data.Max_Int64), MemberType = typeof(Numerics_Data))]
		public void Max_Int64(Double expected, Int64[] values) {
			Chain<Int64> chain = new Chain<Int64>().Add(values);
			Assert.Equal(expected, chain.Max());
		}

		[Theory]
		[MemberData(nameof(Numerics_Data.Max_UInt64), MemberType = typeof(Numerics_Data))]
		public void Max_UInt64(Double expected, UInt64[] values) {
			Chain<UInt64> chain = new Chain<UInt64>().Add(values);
			Assert.Equal(expected, chain.Max());
		}

		[Theory]
		[MemberData(nameof(Numerics_Data.Max_Single), MemberType = typeof(Numerics_Data))]
		public void Max_Single(Single expected, Single[] values) {
			Chain<Single> chain = new Chain<Single>().Add(values);
			Assert.Equal(expected, chain.Max());
		}

		[Theory]
		[MemberData(nameof(Numerics_Data.Max_Double), MemberType = typeof(Numerics_Data))]
		public void Max_Double(Double expected, Double[] values) {
			Chain<Double> chain = new Chain<Double>().Add(values);
			Assert.Equal(expected, chain.Max());
		}

		[Theory]
		[MemberData(nameof(Numerics_Data.Max_Decimal), MemberType = typeof(Numerics_Data))]
		public void Max_Decimal(Decimal expected, Decimal[] values) {
			Chain<Decimal> chain = values is not null ? new Chain<Decimal>().Add(values) : null;
			if (chain is null) {
				Assert.Throws<Exceptions.ArgumentNullException>(() => chain.Max());
			} else if (chain.Count == 0) {
				Assert.Throws<Exceptions.ArgumentEmptyException>(() => chain.Max());
			} else {
				Assert.Equal(expected, chain.Max());
			}
		}

		[Theory]
		[MemberData(nameof(Numerics_Data.Mean_nint), MemberType = typeof(Numerics_Data))]
		public void Mean_nint(Double expected, nint[] values, Mean mean) {
			Chain<nint> chain = values is not null ? new Chain<nint>().Add(values) : null;
			Assert.Equal(expected, chain.Mean(mean));
		}

		[Theory]
		[MemberData(nameof(Numerics_Data.Mean_nuint), MemberType = typeof(Numerics_Data))]
		public void Mean_nuint(Double expected, nuint[] values, Mean mean) {
			Chain<nuint> chain = values is not null ? new Chain<nuint>().Add(values) : null;
			Assert.Equal(expected, chain.Mean(mean));
		}

		[Theory]
		[MemberData(nameof(Numerics_Data.Mean_Byte), MemberType = typeof(Numerics_Data))]
		public void Mean_Byte(Double expected, Byte[] values, Mean mean) {
			Chain<Byte> chain = values is not null ? new Chain<Byte>().Add(values) : null;
			Assert.Equal(expected, chain.Mean(mean));
		}

		[Theory]
		[MemberData(nameof(Numerics_Data.Mean_SByte), MemberType = typeof(Numerics_Data))]
		public void Mean_SByte(Double expected, SByte[] values, Mean mean) {
			Chain<SByte> chain = values is not null ? new Chain<SByte>().Add(values) : null;
			Assert.Equal(expected, chain.Mean(mean));
		}

		[Theory]
		[MemberData(nameof(Numerics_Data.Mean_Int16), MemberType = typeof(Numerics_Data))]
		public void Mean_Int16(Double expected, Int16[] values, Mean mean) {
			Chain<Int16> chain = values is not null ? new Chain<Int16>().Add(values) : null;
			Assert.Equal(expected, chain.Mean(mean));
		}

		[Theory]
		[MemberData(nameof(Numerics_Data.Mean_UInt16), MemberType = typeof(Numerics_Data))]
		public void Mean_UInt16(Double expected, UInt16[] values, Mean mean) {
			Chain<UInt16> chain = values is not null ? new Chain<UInt16>().Add(values) : null;
			Assert.Equal(expected, chain.Mean(mean));
		}

		[Theory]
		[MemberData(nameof(Numerics_Data.Mean_Int32), MemberType = typeof(Numerics_Data))]
		public void Mean_Int32(Double expected, Int32[] values, Mean mean) {
			Chain<Int32> chain = values is not null ? new Chain<Int32>().Add(values) : null;
			Assert.Equal(expected, chain.Mean(mean));
		}

		[Theory]
		[MemberData(nameof(Numerics_Data.Mean_UInt32), MemberType = typeof(Numerics_Data))]
		public void Mean_UInt32(Double expected, UInt32[] values, Mean mean) {
			Chain<UInt32> chain = values is not null ? new Chain<UInt32>().Add(values) : null;
			Assert.Equal(expected, chain.Mean(mean));
		}

		[Theory]
		[MemberData(nameof(Numerics_Data.Mean_Int64), MemberType = typeof(Numerics_Data))]
		public void Mean_Int64(Double expected, Int64[] values, Mean mean) {
			Chain<Int64> chain = values is not null ? new Chain<Int64>().Add(values) : null;
			Assert.Equal(expected, chain.Mean(mean));
		}

		[Theory]
		[MemberData(nameof(Numerics_Data.Mean_UInt64), MemberType = typeof(Numerics_Data))]
		public void Mean_UInt64(Double expected, UInt64[] values, Mean mean) {
			Chain<UInt64> chain = values is not null ? new Chain<UInt64>().Add(values) : null;
			Assert.Equal(expected, chain.Mean(mean));
		}

		[Theory]
		[MemberData(nameof(Numerics_Data.Mean_Single), MemberType = typeof(Numerics_Data))]
		public void Mean_Single(Double expected, Single[] values, Mean mean) {
			Chain<Single> chain = values is not null ? new Chain<Single>().Add(values) : null;
			Assert.Equal(expected, chain.Mean(mean));
		}

		[Theory]
		[MemberData(nameof(Numerics_Data.Mean_Double), MemberType = typeof(Numerics_Data))]
		public void Mean_Double(Double expected, Double[] values, Mean mean) {
			Chain<Double> chain = values is not null ? new Chain<Double>().Add(values) : null;
			Assert.Equal(expected, chain.Mean(mean));
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
			Chain<nint> chain = values is not null ? new Chain<nint>().Add(vals) : null;
			Assert.Equal(expected, chain.Min());
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
			Chain<nuint> chain = values is not null ? new Chain<nuint>().Add(vals) : null;
			Assert.Equal(expected, chain.Min());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new SByte[] { })]
		[InlineData(1, new SByte[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new SByte[] { 5, 4, 3, 2, 1 })]
		public void Min_SByte(Single expected, SByte[] values) {
			Chain<SByte> chain = values is not null ? new Chain<SByte>().Add(values) : null;
			Assert.Equal(expected, chain.Min());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new Byte[] { })]
		[InlineData(1, new Byte[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new Byte[] { 5, 4, 3, 2, 1 })]
		public void Min_Byte(Single expected, Byte[] values) {
			Chain<Byte> chain = values is not null ? new Chain<Byte>().Add(values) : null;
			Assert.Equal(expected, chain.Min());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new Int16[] { })]
		[InlineData(1, new Int16[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new Int16[] { 5, 4, 3, 2, 1 })]
		public void Min_Int16(Single expected, Int16[] values) {
			Chain<Int16> chain = values is not null ? new Chain<Int16>().Add(values) : null;
			Assert.Equal(expected, chain.Min());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new UInt16[] { })]
		[InlineData(1, new UInt16[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new UInt16[] { 5, 4, 3, 2, 1 })]
		public void Min_UInt16(Single expected, UInt16[] values) {
			Chain<UInt16> chain = values is not null ? new Chain<UInt16>().Add(values) : null;
			Assert.Equal(expected, chain.Min());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Int32[] { })]
		[InlineData(1, new Int32[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new Int32[] { 5, 4, 3, 2, 1 })]
		public void Min_Int32(Double expected, Int32[] values) {
			Chain<Int32> chain = values is not null ? new Chain<Int32>().Add(values) : null;
			Assert.Equal(expected, chain.Min());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new UInt32[] { })]
		[InlineData(1, new UInt32[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new UInt32[] { 5, 4, 3, 2, 1 })]
		public void Min_UInt32(Double expected, UInt32[] values) {
			Chain<UInt32> chain = values is not null ? new Chain<UInt32>().Add(values) : null;
			Assert.Equal(expected, chain.Min());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Int64[] { })]
		[InlineData(1, new Int64[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new Int64[] { 5, 4, 3, 2, 1 })]
		public void Min_Int64(Double expected, Int64[] values) {
			Chain<Int64> chain = values is not null ? new Chain<Int64>().Add(values) : null;
			Assert.Equal(expected, chain.Min());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new UInt64[] { })]
		[InlineData(1, new UInt64[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new UInt64[] { 5, 4, 3, 2, 1 })]
		public void Min_UInt64(Double expected, UInt64[] values) {
			Chain<UInt64> chain = values is not null ? new Chain<UInt64>().Add(values) : null;
			Assert.Equal(expected, chain.Min());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new Single[] { })]
		[InlineData(1, new Single[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new Single[] { 5, 4, 3, 2, 1 })]
		public void Min_Single(Single expected, Single[] values) {
			Chain<Single> chain = values is not null ? new Chain<Single>().Add(values) : null;
			Assert.Equal(expected, chain.Min());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Double[] { })]
		[InlineData(1, new Double[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new Double[] { 5, 4, 3, 2, 1 })]
		public void Min_Double(Double expected, Double[] values) {
			Chain<Double> chain = values is not null ? new Chain<Double>().Add(values) : null;
			Assert.Equal(expected, chain.Min());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new Int32[] { })]
		[InlineData(1, new Int32[] { 1, 2, 3, 4, 5 })]
		[InlineData(1, new Int32[] { 5, 4, 3, 2, 1 })]
		public void Min_Decimal(Decimal expected, Int32[] values) {
			Decimal[] vals = null;
			if (values is not null) {
				vals = new Decimal[values.Length];
				for (nint i = 0; i < values.Length; i++) {
					vals[i] = values[i];
				}
			}
			Chain<Decimal> chain = values is not null ? new Chain<Decimal>().Add(vals) : null;
			if (chain is null) {
				Assert.Throws<Exceptions.ArgumentNullException>(() => chain.Min());
			} else if (chain.Count == 0) {
				Assert.Throws<Exceptions.ArgumentEmptyException>(() => chain.Min());
			} else {
				Assert.Equal(expected, chain.Min());
			}
		}

		[Theory]
		[InlineData('a', new Char[] { 'a' })]
		[InlineData('a', new Char[] { 'a', 'a', 'a', 'b', 'b', 'c' })]
		[InlineData('c', new Char[] { 'a', 'b', 'b', 'c', 'c', 'c' })]
		public void Mode(Char expected, Char[] values) {
			Chain<Char> chain = new Chain<Char>().Add(values);
			Assert.Equal(expected, chain.Mode());
		}

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
			Chain<nint> chain = values is not null ? new Chain<nint>().Add(vals) : null;
			Assert.Equal(expected, chain.Product());
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
			Chain<nuint> chain = values is not null ? new Chain<nuint>().Add(vals) : null;
			Assert.Equal(expected, chain.Product());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new SByte[] { })]
		[InlineData(120, new SByte[] { 1, 2, 3, 4, 5 })]
		public void Product_SByte(Single expected, SByte[] values) {
			Chain<SByte> chain = values is not null ? new Chain<SByte>().Add(values) : null;
			Assert.Equal(expected, chain.Product());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new Byte[] { })]
		[InlineData(120, new Byte[] { 1, 2, 3, 4, 5 })]
		public void Product_Byte(Single expected, Byte[] values) {
			Chain<Byte> chain = values is not null ? new Chain<Byte>().Add(values) : null;
			Assert.Equal(expected, chain.Product());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new Int16[] { })]
		[InlineData(120, new Int16[] { 1, 2, 3, 4, 5 })]
		public void Product_Int16(Single expected, Int16[] values) {
			Chain<Int16> chain = values is not null ? new Chain<Int16>().Add(values) : null;
			Assert.Equal(expected, chain.Product());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new UInt16[] { })]
		[InlineData(120, new UInt16[] { 1, 2, 3, 4, 5 })]
		public void Product_UInt16(Single expected, UInt16[] values) {
			Chain<UInt16> chain = values is not null ? new Chain<UInt16>().Add(values) : null;
			Assert.Equal(expected, chain.Product());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Int32[] { })]
		[InlineData(120, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Product_Int32(Double expected, Int32[] values) {
			Chain<Int32> chain = values is not null ? new Chain<Int32>().Add(values) : null;
			Assert.Equal(expected, chain.Product());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new UInt32[] { })]
		[InlineData(120, new UInt32[] { 1, 2, 3, 4, 5 })]
		public void Product_UInt32(Double expected, UInt32[] values) {
			Chain<UInt32> chain = values is not null ? new Chain<UInt32>().Add(values) : null;
			Assert.Equal(expected, chain.Product());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Int64[] { })]
		[InlineData(120, new Int64[] { 1, 2, 3, 4, 5 })]
		public void Product_Int64(Double expected, Int64[] values) {
			Chain<Int64> chain = values is not null ? new Chain<Int64>().Add(values) : null;
			Assert.Equal(expected, chain.Product());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new UInt64[] { })]
		[InlineData(120, new UInt64[] { 1, 2, 3, 4, 5 })]
		public void Product_UInt64(Double expected, UInt64[] values) {
			Chain<UInt64> chain = values is not null ? new Chain<UInt64>().Add(values) : null;
			Assert.Equal(expected, chain.Product());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new Single[] { })]
		[InlineData(120, new Single[] { 1, 2, 3, 4, 5 })]
		public void Product_Single(Single expected, Single[] values) {
			Chain<Single> chain = values is not null ? new Chain<Single>().Add(values) : null;
			Assert.Equal(expected, chain.Product());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Double[] { })]
		[InlineData(120, new Double[] { 1, 2, 3, 4, 5 })]
		public void Product_Double(Double expected, Double[] values) {
			Chain<Double> chain = values is not null ? new Chain<Double>().Add(values) : null;
			Assert.Equal(expected, chain.Product());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new Int32[] { })]
		[InlineData(120, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Product_Decimal(Decimal expected, Int32[] values) {
			Decimal[] vals = null;
			if (values is not null) {
				vals = new Decimal[values.Length];
				for (nint i = 0; i < values.Length; i++) {
					vals[i] = values[i];
				}
			}
			Chain<Decimal> chain = values is not null ? new Chain<Decimal>().Add(vals) : null;
			if (chain is null) {
				Assert.Throws<Exceptions.ArgumentNullException>(() => chain.Product());
			} else if (chain.Count == 0) {
				Assert.Throws<Exceptions.ArgumentEmptyException>(() => chain.Product());
			} else {
				Assert.Equal(expected, chain.Product());
			}
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
			Chain<nint> chain = values is not null ? new Chain<nint>().Add(vals) : null;
			Assert.Equal(expected, chain.Sum());
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
			Chain<nuint> chain = values is not null ? new Chain<nuint>().Add(vals) : null;
			Assert.Equal(expected, chain.Sum());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new SByte[] { })]
		[InlineData(15, new SByte[] { 1, 2, 3, 4, 5 })]
		public void Sum_SByte(Single expected, SByte[] values) {
			Chain<SByte> chain = values is not null ? new Chain<SByte>().Add(values) : null;
			Assert.Equal(expected, chain.Sum());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new Byte[] { })]
		[InlineData(15, new Byte[] { 1, 2, 3, 4, 5 })]
		public void Sum_Byte(Single expected, Byte[] values) {
			Chain<Byte> chain = values is not null ? new Chain<Byte>().Add(values) : null;
			Assert.Equal(expected, chain.Sum());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new Int16[] { })]
		[InlineData(15, new Int16[] { 1, 2, 3, 4, 5 })]
		public void Sum_Int16(Single expected, Int16[] values) {
			Chain<Int16> chain = values is not null ? new Chain<Int16>().Add(values) : null;
			Assert.Equal(expected, chain.Sum());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new UInt16[] { })]
		[InlineData(15, new UInt16[] { 1, 2, 3, 4, 5 })]
		public void Sum_UInt16(Single expected, UInt16[] values) {
			Chain<UInt16> chain = values is not null ? new Chain<UInt16>().Add(values) : null;
			Assert.Equal(expected, chain.Sum());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Int32[] { })]
		[InlineData(15, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Sum_Int32(Double expected, Int32[] values) {
			Chain<Int32> chain = values is not null ? new Chain<Int32>().Add(values) : null;
			Assert.Equal(expected, chain.Sum());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new UInt32[] { })]
		[InlineData(15, new UInt32[] { 1, 2, 3, 4, 5 })]
		public void Sum_UInt32(Double expected, UInt32[] values) {
			Chain<UInt32> chain = values is not null ? new Chain<UInt32>().Add(values) : null;
			Assert.Equal(expected, chain.Sum());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Int64[] { })]
		[InlineData(15, new Int64[] { 1, 2, 3, 4, 5 })]
		public void Sum_Int64(Double expected, Int64[] values) {
			Chain<Int64> chain = values is not null ? new Chain<Int64>().Add(values) : null;
			Assert.Equal(expected, chain.Sum());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new UInt64[] { })]
		[InlineData(15, new UInt64[] { 1, 2, 3, 4, 5 })]
		public void Sum_UInt64(Double expected, UInt64[] values) {
			Chain<UInt64> chain = values is not null ? new Chain<UInt64>().Add(values) : null;
			Assert.Equal(expected, chain.Sum());
		}

		[Theory]
		[InlineData(Single.NaN, null)]
		[InlineData(Single.NaN, new Single[] { })]
		[InlineData(15, new Single[] { 1, 2, 3, 4, 5 })]
		public void Sum_Single(Single expected, Single[] values) {
			Chain<Single> chain = values is not null ? new Chain<Single>().Add(values) : null;
			Assert.Equal(expected, chain.Sum());
		}

		[Theory]
		[InlineData(Double.NaN, null)]
		[InlineData(Double.NaN, new Double[] { })]
		[InlineData(15, new Double[] { 1, 2, 3, 4, 5 })]
		public void Sum_Double(Double expected, Double[] values) {
			Chain<Double> chain = values is not null ? new Chain<Double>().Add(values) : null;
			Assert.Equal(expected, chain.Sum());
		}

		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new Int32[] { })]
		[InlineData(15, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Sum_Decimal(Decimal expected, Int32[] values) {
			Decimal[] vals = null;
			if (values is not null) {
				vals = new Decimal[values.Length];
				for (nint i = 0; i < values.Length; i++) {
					vals[i] = values[i];
				}
			}
			Chain<Decimal> chain = values is not null ? new Chain<Decimal>().Add(vals) : null;
			if (chain is null) {
				Assert.Throws<Exceptions.ArgumentNullException>(() => chain.Sum());
			} else if (chain.Count == 0) {
				Assert.Throws<Exceptions.ArgumentEmptyException>(() => chain.Sum());
			} else {
				Assert.Equal(expected, chain.Sum());
			}
		}
	}
}
