using System;

namespace Stringier.Patterns.Debugging {
	/// <summary>
	/// Represents a <see cref="ITrace"/> step; a snapshot of execution.
	/// </summary>
	public interface IStep {
		public Error Error { get; }

		public Int32 Position { get; }

		public String Text { get; }
	}
}
