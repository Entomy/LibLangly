using System;

namespace Stringier.Patterns.Debugging {
	/// <summary>
	/// A collection of extensions for <see cref="ITrace"/> to make collecting easier without requiring additional implementations by downstream.
	/// </summary>
	internal static class TraceExtensions {
		/// <summary>
		/// Collects the parameters as a trace step.
		/// </summary>
		/// <param name="text"></param>
		/// <param name="position"></param>
		internal static void Collect(this ITrace trace, Char text, Int32 position) => trace.Collect(text.ToString(), position);

		/// <summary>
		/// Collects the parameters as a trace step.
		/// </summary>
		/// <param name="text">A <see cref="ReadOnlySpan{T}"/> of the text to collect.</param>
		/// <param name="position">The position in the <see cref="Source"/> to collect.</param>
		internal static void Collect(this ITrace trace, ReadOnlySpan<Char> text, Int32 position) => trace.Collect(text.ToString(), position);
	}
}
