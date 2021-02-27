using System;
using System.Collections.Generic;

namespace Langly {
	public static class Numerics_Data {
		public static IEnumerable<object[]> Max_nint() {
			yield return new object[] { Double.NaN, null };
			yield return new object[] { Double.NaN, new nint[] { } };
			yield return new object[] { 5, new nint[] { 1, 2, 3, 4, 5 } };
			yield return new object[] { 5, new nint[] { 5, 4, 3, 2, 1 } };
		}

		public static IEnumerable<object[]> Max_nuint() {
			yield return new object[] { Double.NaN, null };
			yield return new object[] { Double.NaN, new nuint[] { } };
			yield return new object[] { 5, new nuint[] { 1, 2, 3, 4, 5 } };
			yield return new object[] { 5, new nuint[] { 5, 4, 3, 2, 1 } };
		}

		public static IEnumerable<object[]> Max_SByte() {
			yield return new object[] { Single.NaN, null };
			yield return new object[] { Single.NaN, new SByte[] { } };
			yield return new object[] { 5, new SByte[] { 1, 2, 3, 4, 5 } };
			yield return new object[] { 5, new SByte[] { 5, 4, 3, 2, 1 } };
		}

		public static IEnumerable<object[]> Max_Byte() {
			yield return new object[] { Single.NaN, null };
			yield return new object[] { Single.NaN, new Byte[] { } };
			yield return new object[] { 5, new Byte[] { 1, 2, 3, 4, 5 } };
			yield return new object[] { 5, new Byte[] { 5, 4, 3, 2, 1 } };
		}

		public static IEnumerable<object[]> Max_Int16() {
			yield return new object[] { Single.NaN, null };
			yield return new object[] { Single.NaN, new Int16[] { } };
			yield return new object[] { 5, new Int16[] { 1, 2, 3, 4, 5 } };
			yield return new object[] { 5, new Int16[] { 5, 4, 3, 2, 1 } };
		}

		public static IEnumerable<object[]> Max_UInt16() {
			yield return new object[] { Single.NaN, null };
			yield return new object[] { Single.NaN, new UInt16[] { } };
			yield return new object[] { 5, new UInt16[] { 1, 2, 3, 4, 5 } };
			yield return new object[] { 5, new UInt16[] { 5, 4, 3, 2, 1 } };
		}

		public static IEnumerable<object[]> Max_Int32() {
			yield return new object[] { Double.NaN, null };
			yield return new object[] { Double.NaN, new Int32[] { } };
			yield return new object[] { 5, new Int32[] { 1, 2, 3, 4, 5 } };
			yield return new object[] { 5, new Int32[] { 5, 4, 3, 2, 1 } };
		}

		public static IEnumerable<object[]> Max_UInt32() {
			yield return new object[] { Double.NaN, null };
			yield return new object[] { Double.NaN, new UInt32[] { } };
			yield return new object[] { 5, new Int32[] { 1, 2, 3, 4, 5 } };
			yield return new object[] { 5, new Int32[] { 5, 4, 3, 2, 1 } };
		}

		public static IEnumerable<object[]> Max_Int64() {
			yield return new object[] { Double.NaN, null };
			yield return new object[] { Double.NaN, new Int64[] { } };
			yield return new object[] { 5, new Int64[] { 1, 2, 3, 4, 5 } };
			yield return new object[] { 5, new Int64[] { 5, 4, 3, 2, 1 } };
		}

		public static IEnumerable<object[]> Max_UInt64() {
			yield return new object[] { Double.NaN, null };
			yield return new object[] { Double.NaN, new UInt64[] { } };
			yield return new object[] { 5, new UInt64[] { 1, 2, 3, 4, 5 } };
			yield return new object[] { 5, new UInt64[] { 5, 4, 3, 2, 1 } };
		}

		public static IEnumerable<object[]> Max_Single() {
			yield return new object[] { Single.NaN, null };
			yield return new object[] { Single.NaN, new Single[] { } };
			yield return new object[] { 5.0F, new Single[] { 1.0F, 2.0F, 3.0F, 4.0F, 5.0F } };
			yield return new object[] { 5.0F, new Single[] { 5.0F, 4.0F, 3.0F, 2.0F, 1.0F } };
		}

		public static IEnumerable<object[]> Max_Double() {
			yield return new object[] { Double.NaN, null };
			yield return new object[] { Double.NaN, new Double[] { } };
			yield return new object[] { 5.0, new Double[] { 1.0, 2.0, 3.0, 4.0, 5.0 } };
			yield return new object[] { 5.0, new Double[] { 5.0, 4.0, 3.0, 2.0, 1.0 } };
		}

		public static IEnumerable<object[]> Max_Decimal() {
			yield return new object[] { 0.0M, null };
			yield return new object[] { 0.0M, new Decimal[] { } };
			yield return new object[] { 5.0M, new Decimal[] { 1.0M, 2.0M, 3.0M, 4.0M, 5.0M } };
			yield return new object[] { 5.0M, new Decimal[] { 5.0M, 4.0M, 3.0M, 2.0M, 1.0M } };
		}

		public static IEnumerable<object[]> Mean_nint() {
			yield return new object[] { Double.NaN, null, Mean.Arithmetic };
			yield return new object[] { Double.NaN, new nint[] { }, Mean.Arithmetic };
			yield return new object[] { 3.0, new nint[] { 1, 2, 3, 4, 5 }, Mean.Arithmetic };
			yield return new object[] { 3.0, new nint[] { 5, 4, 3, 2, 1 }, Mean.Arithmetic };
			yield return new object[] { Double.NaN, null, Mean.Geometric };
			yield return new object[] { Double.NaN, new nint[] { }, Mean.Geometric };
			yield return new object[] { 2.605171084697352, new nint[] { 1, 2, 3, 4, 5 }, Mean.Geometric };
			yield return new object[] { 2.605171084697352, new nint[] { 5, 4, 3, 2, 1 }, Mean.Geometric };
		}

		public static IEnumerable<object[]> Mean_nuint() {
			yield return new object[] { Double.NaN, null, Mean.Arithmetic };
			yield return new object[] { Double.NaN, new nuint[] { }, Mean.Arithmetic };
			yield return new object[] { 3.0, new nuint[] { 1, 2, 3, 4, 5 }, Mean.Arithmetic };
			yield return new object[] { 3.0, new nuint[] { 5, 4, 3, 2, 1 }, Mean.Arithmetic };
			yield return new object[] { Double.NaN, null, Mean.Geometric };
			yield return new object[] { Double.NaN, new nuint[] { }, Mean.Geometric };
			yield return new object[] { 2.605171084697352, new nuint[] { 1, 2, 3, 4, 5 }, Mean.Geometric };
			yield return new object[] { 2.605171084697352, new nuint[] { 5, 4, 3, 2, 1 }, Mean.Geometric };
		}

		public static IEnumerable<object[]> Mean_Byte() {
			yield return new object[] { Double.NaN, null, Mean.Arithmetic };
			yield return new object[] { Double.NaN, new Byte[] { }, Mean.Arithmetic };
			yield return new object[] { 3.0, new Byte[] { 1, 2, 3, 4, 5 }, Mean.Arithmetic };
			yield return new object[] { 3.0, new Byte[] { 5, 4, 3, 2, 1 }, Mean.Arithmetic };
			yield return new object[] { Double.NaN, null, Mean.Geometric };
			yield return new object[] { Double.NaN, new Byte[] { }, Mean.Geometric };
			yield return new object[] { 2.605171084697352, new Byte[] { 1, 2, 3, 4, 5 }, Mean.Geometric };
			yield return new object[] { 2.605171084697352, new Byte[] { 5, 4, 3, 2, 1 }, Mean.Geometric };
		}

		public static IEnumerable<object[]> Mean_SByte() {
			yield return new object[] { Double.NaN, null, Mean.Arithmetic };
			yield return new object[] { Double.NaN, new SByte[] { }, Mean.Arithmetic };
			yield return new object[] { 3.0, new SByte[] { 1, 2, 3, 4, 5 }, Mean.Arithmetic };
			yield return new object[] { 3.0, new SByte[] { 5, 4, 3, 2, 1 }, Mean.Arithmetic };
			yield return new object[] { Double.NaN, null, Mean.Geometric };
			yield return new object[] { Double.NaN, new SByte[] { }, Mean.Geometric };
			yield return new object[] { 2.605171084697352, new SByte[] { 1, 2, 3, 4, 5 }, Mean.Geometric };
			yield return new object[] { 2.605171084697352, new SByte[] { 5, 4, 3, 2, 1 }, Mean.Geometric };
		}

		public static IEnumerable<object[]> Mean_Int16() {
			yield return new object[] { Double.NaN, null, Mean.Arithmetic };
			yield return new object[] { Double.NaN, new Int16[] { }, Mean.Arithmetic };
			yield return new object[] { 3.0, new Int16[] { 1, 2, 3, 4, 5 }, Mean.Arithmetic };
			yield return new object[] { 3.0, new Int16[] { 5, 4, 3, 2, 1 }, Mean.Arithmetic };
			yield return new object[] { Double.NaN, null, Mean.Geometric };
			yield return new object[] { Double.NaN, new Int16[] { }, Mean.Geometric };
			yield return new object[] { 2.605171084697352, new Int16[] { 1, 2, 3, 4, 5 }, Mean.Geometric };
			yield return new object[] { 2.605171084697352, new Int16[] { 5, 4, 3, 2, 1 }, Mean.Geometric };
		}

		public static IEnumerable<object[]> Mean_UInt16() {
			yield return new object[] { Double.NaN, null, Mean.Arithmetic };
			yield return new object[] { Double.NaN, new UInt16[] { }, Mean.Arithmetic };
			yield return new object[] { 3.0, new UInt16[] { 1, 2, 3, 4, 5 }, Mean.Arithmetic };
			yield return new object[] { 3.0, new UInt16[] { 5, 4, 3, 2, 1 }, Mean.Arithmetic };
			yield return new object[] { Double.NaN, null, Mean.Geometric };
			yield return new object[] { Double.NaN, new UInt16[] { }, Mean.Geometric };
			yield return new object[] { 2.605171084697352, new UInt16[] { 1, 2, 3, 4, 5 }, Mean.Geometric };
			yield return new object[] { 2.605171084697352, new UInt16[] { 5, 4, 3, 2, 1 }, Mean.Geometric };
		}

		public static IEnumerable<object[]> Mean_Int32() {
			yield return new object[] { Double.NaN, null, Mean.Arithmetic };
			yield return new object[] { Double.NaN, new Int32[] { }, Mean.Arithmetic };
			yield return new object[] { 3.0, new Int32[] { 1, 2, 3, 4, 5 }, Mean.Arithmetic };
			yield return new object[] { 3.0, new Int32[] { 5, 4, 3, 2, 1 }, Mean.Arithmetic };
			yield return new object[] { Double.NaN, null, Mean.Geometric };
			yield return new object[] { Double.NaN, new Int32[] { }, Mean.Geometric };
			yield return new object[] { 2.605171084697352, new Int32[] { 1, 2, 3, 4, 5 }, Mean.Geometric };
			yield return new object[] { 2.605171084697352, new Int32[] { 5, 4, 3, 2, 1 }, Mean.Geometric };
		}

		public static IEnumerable<object[]> Mean_UInt32() {
			yield return new object[] { Double.NaN, null, Mean.Arithmetic };
			yield return new object[] { Double.NaN, new UInt32[] { }, Mean.Arithmetic };
			yield return new object[] { 3.0, new UInt32[] { 1, 2, 3, 4, 5 }, Mean.Arithmetic };
			yield return new object[] { 3.0, new UInt32[] { 5, 4, 3, 2, 1 }, Mean.Arithmetic };
			yield return new object[] { Double.NaN, null, Mean.Geometric };
			yield return new object[] { Double.NaN, new UInt32[] { }, Mean.Geometric };
			yield return new object[] { 2.605171084697352, new UInt32[] { 1, 2, 3, 4, 5 }, Mean.Geometric };
			yield return new object[] { 2.605171084697352, new UInt32[] { 5, 4, 3, 2, 1 }, Mean.Geometric };
		}

		public static IEnumerable<object[]> Mean_Int64() {
			yield return new object[] { Double.NaN, null, Mean.Arithmetic };
			yield return new object[] { Double.NaN, new Int64[] { }, Mean.Arithmetic };
			yield return new object[] { 3.0, new Int64[] { 1, 2, 3, 4, 5 }, Mean.Arithmetic };
			yield return new object[] { 3.0, new Int64[] { 5, 4, 3, 2, 1 }, Mean.Arithmetic };
			yield return new object[] { Double.NaN, null, Mean.Geometric };
			yield return new object[] { Double.NaN, new Int64[] { }, Mean.Geometric };
			yield return new object[] { 2.605171084697352, new Int64[] { 1, 2, 3, 4, 5 }, Mean.Geometric };
			yield return new object[] { 2.605171084697352, new Int64[] { 5, 4, 3, 2, 1 }, Mean.Geometric };
		}

		public static IEnumerable<object[]> Mean_UInt64() {
			yield return new object[] { Double.NaN, null, Mean.Arithmetic };
			yield return new object[] { Double.NaN, new UInt64[] { }, Mean.Arithmetic };
			yield return new object[] { 3.0, new UInt64[] { 1, 2, 3, 4, 5 }, Mean.Arithmetic };
			yield return new object[] { 3.0, new UInt64[] { 5, 4, 3, 2, 1 }, Mean.Arithmetic };
			yield return new object[] { Double.NaN, null, Mean.Geometric };
			yield return new object[] { Double.NaN, new UInt64[] { }, Mean.Geometric };
			yield return new object[] { 2.605171084697352, new UInt64[] { 1, 2, 3, 4, 5 }, Mean.Geometric };
			yield return new object[] { 2.605171084697352, new UInt64[] { 5, 4, 3, 2, 1 }, Mean.Geometric };
		}

		public static IEnumerable<object[]> Mean_Single() {
			yield return new object[] { Double.NaN, null, Mean.Arithmetic };
			yield return new object[] { Double.NaN, new Single[] { }, Mean.Arithmetic };
			yield return new object[] { 3.0, new Single[] { 1.0F, 2.0F, 3.0F, 4.0F, 5.0F }, Mean.Arithmetic };
			yield return new object[] { 3.0, new Single[] { 5.0F, 4.0F, 3.0F, 2.0F, 1.0F }, Mean.Arithmetic };
			yield return new object[] { Double.NaN, null, Mean.Geometric };
			yield return new object[] { Double.NaN, new Single[] { }, Mean.Geometric };
			yield return new object[] { 2.605171084697352, new Single[] { 1.0F, 2.0F, 3.0F, 4.0F, 5.0F }, Mean.Geometric };
			yield return new object[] { 2.605171084697352, new Single[] { 5.0F, 4.0F, 3.0F, 2.0F, 1.0F }, Mean.Geometric };
		}

		public static IEnumerable<object[]> Mean_Double() {
			yield return new object[] { Double.NaN, null, Mean.Arithmetic };
			yield return new object[] { Double.NaN, new Double[] { }, Mean.Arithmetic };
			yield return new object[] { 3.0, new Double[] { 1.0, 2.0, 3.0, 4.0, 5.0 }, Mean.Arithmetic };
			yield return new object[] { 3.0, new Double[] { 5.0, 4.0, 3.0, 2.0, 1.0 }, Mean.Arithmetic };
			yield return new object[] { Double.NaN, null, Mean.Geometric };
			yield return new object[] { Double.NaN, new Double[] { }, Mean.Geometric };
			yield return new object[] { 2.605171084697352, new Double[] { 1.0, 2.0, 3.0, 4.0, 5.0 }, Mean.Geometric };
			yield return new object[] { 2.605171084697352, new Double[] { 5.0, 4.0, 3.0, 2.0, 1.0 }, Mean.Geometric };
		}
	}
}
