using System;
using System.Diagnostics.CodeAnalysis;
#if NETCOREAPP3_0_OR_GREATER
using System.Text;
#endif
using System.Traits;

namespace Stringier.Patterns {
	internal static class TraceExtensions {
		/// <summary>
		/// Adds a step to the <paramref name="trace"/>.
		/// </summary>
		/// <param name="trace">This trace collector.</param>
		/// <param name="text">The text captured at this step.</param>
		/// <param name="location">The location of this step.</param>
		internal static void Add([DisallowNull] this IAdd<Capture> trace, Char text, Int32 location) => throw new NotImplementedException();

#if NETCOREAPP3_0_OR_GREATER
		/// <summary>
		/// Adds a step to the <paramref name="trace"/>.
		/// </summary>
		/// <param name="trace">This trace collector.</param>
		/// <param name="text">The text captured at this step.</param>
		/// <param name="location">The location of this step.</param>
		internal static void Add([DisallowNull] this IAdd<Capture> trace, Rune text, Int32 location) => throw new NotImplementedException();
#endif

		/// <summary>
		/// Adds a step to the <paramref name="trace"/>.
		/// </summary>
		/// <param name="trace">This trace collector.</param>
		/// <param name="text">The text captured at this step.</param>
		/// <param name="location">The location of this step.</param>
		internal static void Add([DisallowNull] this IAdd<Capture> trace, [AllowNull] String text, Int32 location) => throw new NotImplementedException();

		/// <summary>
		/// Adds a step to the <paramref name="trace"/>.
		/// </summary>
		/// <param name="trace">This trace collector.</param>
		/// <param name="text">The text captured at this step.</param>
		/// <param name="location">The location of this step.</param>
		internal static void Add([DisallowNull] this IAdd<Capture> trace, [AllowNull] Char[] text, Int32 location) => throw new NotImplementedException();

		/// <summary>
		/// Adds a step to the <paramref name="trace"/>.
		/// </summary>
		/// <param name="trace">This trace collector.</param>
		/// <param name="text">The text captured at this step.</param>
		/// <param name="location">The location of this step.</param>
		internal static void Add([DisallowNull] this IAdd<Capture> trace, Memory<Char> text, Int32 location) => throw new NotImplementedException();

		/// <summary>
		/// Adds a step to the <paramref name="trace"/>.
		/// </summary>
		/// <param name="trace">This trace collector.</param>
		/// <param name="text">The text captured at this step.</param>
		/// <param name="location">The location of this step.</param>
		internal static void Add([DisallowNull] this IAdd<Capture> trace, ReadOnlyMemory<Char> text, Int32 location) => throw new NotImplementedException();

		/// <summary>
		/// Adds a step to the <paramref name="trace"/>.
		/// </summary>
		/// <param name="trace">This trace collector.</param>
		/// <param name="text">The text captured at this step.</param>
		/// <param name="location">The location of this step.</param>
		internal static void Add([DisallowNull] this IAdd<Capture> trace, Span<Char> text, Int32 location) => throw new NotImplementedException();

		/// <summary>
		/// Adds a step to the <paramref name="trace"/>.
		/// </summary>
		/// <param name="trace">This trace collector.</param>
		/// <param name="text">The text captured at this step.</param>
		/// <param name="location">The location of this step.</param>
		internal static void Add([DisallowNull] this IAdd<Capture> trace, ReadOnlySpan<Char> text, Int32 location) => throw new NotImplementedException();

		/// <summary>
		/// Adds a step to the <paramref name="trace"/>.
		/// </summary>
		/// <param name="trace">This trace collector.</param>
		/// <param name="exception">The exception that occurred at this step.</param>
		/// <param name="location">The location of this step.</param>
		internal static void Add([DisallowNull] this IAdd<Capture> trace, [DisallowNull] Exception exception, Int32 location) => throw new NotImplementedException();
	}
}
