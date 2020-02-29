// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the THIRD_PARTY_NOTICES file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace Tests {
	public class GeneralTestData {
		public String __DebugDisplay => $"U+{ScalarValue:X4}";

		public Int32 ScalarValue;
		public Boolean IsAscii;
		public Boolean IsBmp;
		public Int32 Plane;
		public Char[] Utf16Sequence;
		public Byte[] Utf8Sequence;

		public GeneralTestData(Int32 scalarValue, Boolean isAscii, Boolean isBmp, Int32 plane, Char[] utf16Sequence, Byte[] utf8Sequence) {
			ScalarValue = scalarValue;
			IsAscii = isAscii;
			IsBmp = isBmp;
			Plane = plane;
			Utf16Sequence = utf16Sequence;
			Utf8Sequence = utf8Sequence;
		}
	}
}
