using System;

namespace Stringier.Patterns.Debugging {
	/// <summary>
	/// Represents a <see cref="Trace"/> step; a snapshot of execution.
	/// </summary>
	internal class Step : IStep {
		public Error Error { get; }
		public String Text { get; }
		public Int32 Position { get; }

		internal Step(String text, Int32 position) {
			Text = text;
			Position = position;
		}

		internal Step(Error error, Int32 position) {
			Error = error;
			Position = position;
		}

		public override String ToString() {
			switch (Error) {
			case Error.None:
				return $"{Text}";
			default:
				return $"ERROR: {Error}";
			}
		}
	}
}
