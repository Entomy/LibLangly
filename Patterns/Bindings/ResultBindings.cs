using System;

namespace Stringier.Patterns.Bindings {
	/// <summary>
	/// Holds useful definitions for creating bindings to <see cref="Result"/>
	/// </summary>
	/// <remarks>
	/// The entire point of this is to make it easy to declare bindings to this library from another language which does not map directly, such as F#.
	/// </remarks>
	public static class ResultBindings {
		public static Boolean Success(Result Result) => (Boolean)Result;

		public static String Text(Result Result) => (String)Result;
	}
}
