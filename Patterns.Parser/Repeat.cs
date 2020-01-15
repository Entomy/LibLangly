using System;
using Stringier.Patterns;
using static Stringier.Patterns.Pattern;

namespace Stringier.Patterns.Parser {
	/// <summary>
	/// Represents a repeat combinator; the repetition of the lefthand pattern
	/// </summary>
	public sealed class Repeat : Combinator {
		/// <summary>
		/// The <see cref="Patterns.Pattern"/> which represents this type.
		/// </summary>
		new public static readonly Pattern Pattern = '×'.Or('x');

		/// <summary>
		/// Initialize a new <see cref="Repeat"/>.
		/// </summary>
		internal Repeat() : base("×") { }

		/// <summary>
		/// Attempt to consume a <see cref="Repeat"/> from the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <returns>A new <see cref="Repeat"/> instance if parsing succeeded; otherwise <see langword="null"/>.</returns>
		public static Repeat? Consume(ref Source source) {
			Result result = Pattern.Consume(ref source);
			return result ? Singleton.Instance : null;
		}

		private static class Singleton {
			static Singleton() { }

			internal static readonly Repeat Instance = new Repeat();
		}
	}
}
