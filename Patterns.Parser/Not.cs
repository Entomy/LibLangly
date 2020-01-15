using System;
using Stringier.Patterns;
using static Stringier.Patterns.Pattern;

namespace Stringier.Patterns.Parser {
	/// <summary>
	/// Represents a not modifier; the negation of the pattern
	/// </summary>
	internal sealed class Not : Modifier {
		/// <summary>
		/// The <see cref="Patterns.Pattern"/> which represents this type.
		/// </summary>
		new public static readonly Pattern Pattern = '-';

		/// <summary>
		/// Initialize a new <see cref="Not"/>.
		/// </summary>
		internal Not() : base("-") { }

		/// <summary>
		/// Attempt to consume a <see cref="Not"/> from the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <returns>A new <see cref="Not"/> instance if parsing succeeded; otherwise <see langword="null"/>.</returns>
		new internal static Not? Consume(ref Source source) {
			Result result = Pattern.Consume(ref source);
			return result ? Singleton.Instance : null;
		}

		private static class Singleton {
			static Singleton() { }

			internal static readonly Not Instance = new Not();
		}
	}
}
