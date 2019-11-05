using System;

namespace Stringier.Patterns.Errors {
	internal enum ErrorData : Byte {
		None = 0,
		Char,
		Node,
		Pattern,
		String,
	}
}
