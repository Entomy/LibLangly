using System;
using System.Collections.Generic;

namespace Langly {
	public static class Console_Data {
		public static IEnumerable<object[]> Write_String() {
			yield return new object[] { null };
			yield return new object[] { "Hello" };
		}

		public static IEnumerable<object[]> Write_Array() {
			yield return new object[] { null };
			yield return new object[] { new Char[] { 'H', 'e', 'l', 'l', 'o' } };
		}

		public static IEnumerable<object[]> Write_Object() {
			yield return new object[] { null };
			yield return new object[] { 1 };
			yield return new object[] { 1.0 };
		}
	}
}
