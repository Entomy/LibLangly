using System;
using Stringier.Patterns.Errors;

namespace Stringier.Patterns.Debugging {
	/// <summary>
	/// Represents a <see cref="Trace"/> step; a snapshot of execution.
	/// </summary>
	internal class Step : IStep {
		public ErrorType ErrorType { get; }
		public String Text { get; }
		public Int32 Position { get; }

		internal Step(String text, Int32 position) {
			Text = text;
			Position = position;
		}

		internal Step(ErrorType errorType) {
			ErrorType = errorType;
		}
	}
}
