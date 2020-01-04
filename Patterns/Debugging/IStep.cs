using System;
using Stringier.Patterns.Errors;

namespace Stringier.Patterns.Debugging {
	/// <summary>
	/// Represents a <see cref="ITrace"/> step; a snapshot of execution.
	/// </summary>
	public interface IStep {
		public ErrorType ErrorType { get; }
		
		public Int32 Position { get; }
		
		public String Text { get; }
	}
}
