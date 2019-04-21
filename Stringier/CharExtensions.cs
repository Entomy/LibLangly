using System;
using System.Collections.Generic;
using System.Text;

namespace System {
	public static class CharExtensions {

		public static String Join(this Char[] Chars) => new String(Chars);

		public static String Join(this Char[] Chars, Char Separator) {
			Char[] Result = new Char[Chars.Length * 2 - 1];
			for (int i = 0; i < Chars.Length * 2 - 1; i++) {
				if (i % 2 == 0) {
					Result[i] = Chars[i / 2];
				} else {
					Result[i] = Separator;
				}
			}
			return Result.Join();
		}

	}
}
