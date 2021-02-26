using System;
using System.Collections.Generic;

namespace Langly.DataStructures {
	public static class Stack1_Data {
		public static IEnumerable<object[]> Stack() {
			yield return new object[] { new Int32[] { }, new Int32[] { } };
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5, 4, 3, 2, 1 } };
		}
	}
}
