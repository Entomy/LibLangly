using System;
using System.Collections.Generic;
using System.Text;

namespace Core {
	public class RuneEnumeratorData {
		public Char[] Chars;
		public Int32[] Expected;

		public RuneEnumeratorData(Char[] chars, Int32[] expected) {
			Chars = chars;
			Expected = expected;
		}
	}
}
