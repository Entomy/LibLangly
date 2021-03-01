using System;
using System.Collections.Generic;

namespace Langly {
	public class Collection2_Data {
		public static IEnumerable<object[]> Insert() {
			yield return new object[] { new Char[] { }, new String[] { } };
			yield return new object[] { new Char[] { 'a' }, new String[] { "alpha" } };
			yield return new object[] { new Char[] { 'a', 'b', 'c' }, new String[] { "alpha", "bravo", "charlie" } };
		}
	}
}
