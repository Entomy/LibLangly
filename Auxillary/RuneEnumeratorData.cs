// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the THIRD_PARTY_NOTICES file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace Tests {
	public class RuneEnumeratorData {
		public Char[] Chars;
		public Int32[] Expected;

		public RuneEnumeratorData(Char[] chars, Int32[] expected) {
			Chars = chars;
			Expected = expected;
		}
	}
}
