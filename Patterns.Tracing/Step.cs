using System;
using System.Runtime.InteropServices;
using Stringier.Patterns.Errors;

namespace Stringier.Patterns.Debugging {
	/// <summary>
	/// Represents a <see cref="Trace"/> step; a snapshot of execution.
	/// </summary>
	internal class Step : IStep {
		public ErrorType ErrorType { get; }
		public Pattern NodeType { get; }
		public String Text { get; }
		public Int32 Position { get; }

		internal Step(String text, Int32 position, Pattern nodeType, ErrorType errorType) {
			Text = text;
			Position = position;
			NodeType = nodeType;
			ErrorType = errorType;
		}
	}
}
