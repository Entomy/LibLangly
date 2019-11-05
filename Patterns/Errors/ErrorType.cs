using System;

namespace Stringier.Patterns.Errors {
	internal enum ErrorType : Byte {
		None = 0,
		ConsumeFailed,
		NeglectFailed,
		EndOfSource,
	}
}
