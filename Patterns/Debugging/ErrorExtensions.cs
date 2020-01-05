using System;

namespace Stringier.Patterns.Debugging {
	internal static class ErrorExtensions {
		internal static void Throw(this Error error) {
			switch (error) {
			case Error.None:
				return;
			case Error.ConsumeFailed:
				throw new ConsumeFailedException($"Consume failed.");
			case Error.EndOfSource:
				throw new EndOfSourceException($"End of source has been reached before able to parse.");
			case Error.NeglectFailed:
				throw new NeglectFailedException($"Neglect failed.");
			default:
				throw new NotSupportedException($"{error} doesn't have a conversion.");
			}
		}
	}
}
