using System;
using System.Collections.Generic;

namespace Langly {
	public static class Collection1_Data {
		public static IEnumerable<object[]> Add_Int32_Single() {
			yield return new object[] { new Int32[] { } };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 5 } };
		}

		public static IEnumerable<object[]> Add_Int32_Group() {
			yield return new object[] { new Int32[] { }, new Int32[] { } };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 } };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 } };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 } };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 } };
		}

		public static IEnumerable<object[]> Insert_Int32_Single_Single() {
			yield return new object[] { new Int32[] { 0 }, new Int32[] { }, 0, 0 };
			yield return new object[] { new Int32[] { 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0, 0 };
			yield return new object[] { new Int32[] { 1, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, 0 };
			yield return new object[] { new Int32[] { 1, 2, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 3, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 4, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 5, 0 };
		}

		public static IEnumerable<object[]> Insert_Int32_Single_Group() {
			yield return new object[] { new Int32[] { 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 0, 0 };
			yield return new object[] { new Int32[] { 1, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 1, 0 };
			yield return new object[] { new Int32[] { 1, 2, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 2, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 3, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 4, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 5, 0 };
			yield return new object[] { new Int32[] { 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 0, 0 };
			yield return new object[] { new Int32[] { 1, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 1, 0 };
			yield return new object[] { new Int32[] { 1, 2, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 2, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 3, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 4, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 5, 0 };
			yield return new object[] { new Int32[] { 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 0, 0 };
			yield return new object[] { new Int32[] { 1, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 1, 0 };
			yield return new object[] { new Int32[] { 1, 2, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 2, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 3, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 4, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 5, 0 };
			yield return new object[] { new Int32[] { 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 0, 0 };
			yield return new object[] { new Int32[] { 1, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 1, 0 };
			yield return new object[] { new Int32[] { 1, 2, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 2, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 3, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 4, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 5, 0 };
		}

		public static IEnumerable<object[]> Insert_Int32_Group_Single() {
			yield return new object[] { new Int32[] { 0, 0 }, new Int32[] { }, 0, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 1, 0, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 1, 2, 0, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 1, 2, 3, 0, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 3, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 0, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 4, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 5, new Int32[] { 0, 0 } };
		}

		public static IEnumerable<object[]> Insert_Int32_Group_Group() {
			yield return new object[] { new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 0, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 1, 0, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 1, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 1, 2, 0, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 2, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 1, 2, 3, 0, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 3, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 0, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 4, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 5, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 0, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 1, 0, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 1, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 1, 2, 0, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 2, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 1, 2, 3, 0, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 3, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 0, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 4, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 5, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 0, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 1, 0, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 1, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 1, 2, 0, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 2, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 1, 2, 3, 0, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 3, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 0, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 4, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 5, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 0, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 1, 0, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 1, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 1, 2, 0, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 2, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 1, 2, 3, 0, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 3, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 0, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 4, new Int32[] { 0, 0 } };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 5, new Int32[] { 0, 0 } };
		}

		public static IEnumerable<object[]> Replace_Single() {
			yield return new object[] { new Int32[] { }, new Int32[] { }, 0, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0, 0 };
			yield return new object[] { new Int32[] { 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, 0 };
			yield return new object[] { new Int32[] { 1, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, 0 };
			yield return new object[] { new Int32[] { 1, 2, 0, 4, 5, }, new Int32[] { 1, 2, 3, 4, 5 }, 3, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 4, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 5, 0 };
			yield return new object[] { new Int32[] { 0, 2, 0, 2, 0 }, new Int32[] { 1, 2, 1, 2, 1 }, 1, 0 };
			yield return new object[] { new Int32[] { 0, 0, 0, 0, 0 }, new Int32[] { 1, 1, 1, 1, 1 }, 1, 0 };
		}

		public static IEnumerable<object[]> Replace_Group() {
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 0, 0 };
			yield return new object[] { new Int32[] { 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 1, 0 };
			yield return new object[] { new Int32[] { 1, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 2, 0 };
			yield return new object[] { new Int32[] { 1, 2, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 3, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 4, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5 }, 5, 0 };
			yield return new object[] { new Int32[] { 0, 2, 0, 2, 0 }, new Int32[] { 1, 2, 1, 2, 1 }, new Int32[] { 5 }, 1, 0 };
			yield return new object[] { new Int32[] { 0, 0, 0, 0, 0 }, new Int32[] { 1, 1, 1, 1, 1 }, new Int32[] { 5 }, 1, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 0, 0 };
			yield return new object[] { new Int32[] { 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 1, 0 };
			yield return new object[] { new Int32[] { 1, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 2, 0 };
			yield return new object[] { new Int32[] { 1, 2, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 3, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 4, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 5 }, 5, 0 };
			yield return new object[] { new Int32[] { 0, 2, 0, 2, 0 }, new Int32[] { 1, 2, 1, 2, 1 }, new Int32[] { 2, 5 }, 1, 0 };
			yield return new object[] { new Int32[] { 0, 0, 0, 0, 0 }, new Int32[] { 1, 1, 1, 1, 1 }, new Int32[] { 2, 5 }, 1, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 0, 0 };
			yield return new object[] { new Int32[] { 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 1, 0 };
			yield return new object[] { new Int32[] { 1, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 2, 0 };
			yield return new object[] { new Int32[] { 1, 2, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 3, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 4, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 2, 4, 5 }, 5, 0 };
			yield return new object[] { new Int32[] { 0, 2, 0, 2, 0 }, new Int32[] { 1, 2, 1, 2, 1 }, new Int32[] { 2, 4, 5 }, 1, 0 };
			yield return new object[] { new Int32[] { 0, 0, 0, 0, 0 }, new Int32[] { 1, 1, 1, 1, 1 }, new Int32[] { 2, 4, 5 }, 1, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 0, 0 };
			yield return new object[] { new Int32[] { 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 1, 0 };
			yield return new object[] { new Int32[] { 1, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 2, 0 };
			yield return new object[] { new Int32[] { 1, 2, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 3, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 4, 0 };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 5 }, 5, 0 };
			yield return new object[] { new Int32[] { 0, 2, 0, 2, 0 }, new Int32[] { 1, 2, 1, 2, 1 }, new Int32[] { 1, 5 }, 1, 0 };
			yield return new object[] { new Int32[] { 0, 0, 0, 0, 0 }, new Int32[] { 1, 1, 1, 1, 1 }, new Int32[] { 1, 5 }, 1, 0 };
		}

		public static IEnumerable<object[]> Sparse() {
			yield return new object[] { 0, new Int32[] { 1, 2, 3, 4, 5 }, -1 };
			yield return new object[] { 1, new Int32[] { 1, 2, 3, 4, 5 }, 0 };
			yield return new object[] { 2, new Int32[] { 1, 2, 3, 4, 5 }, 1 };
			yield return new object[] { 3, new Int32[] { 1, 2, 3, 4, 5 }, 2 };
			yield return new object[] { 4, new Int32[] { 1, 2, 3, 4, 5 }, 3 };
			yield return new object[] { 5, new Int32[] { 1, 2, 3, 4, 5 }, 4 };
			yield return new object[] { 0, new Int32[] { 1, 2, 3, 4, 5 }, 5 };
		}

		public static IEnumerable<object[]> ToString() {
			yield return new object[] { "[]", null };
			yield return new object[] { "[]", new Int32[] { } };
			yield return new object[] { "[1, 2, 3, 4, 5]", new Int32[] { 1, 2, 3, 4, 5 } };
		}

		public static IEnumerable<object[]> ToString_Amount() {
			yield return new object[] { "[]", null, 5 };
			yield return new object[] { "[]", null, 3 };
			yield return new object[] { "[]", new Int32[] { }, 5 };
			yield return new object[] { "[]", new Int32[] { }, 3 };
			yield return new object[] { "[1, 2, 3, 4, 5]", new Int32[] { 1, 2, 3, 4, 5 }, 5 };
			yield return new object[] { "[1, 2, 3...]", new Int32[] { 1, 2, 3, 4, 5 }, 3 };
		}
	}
}
