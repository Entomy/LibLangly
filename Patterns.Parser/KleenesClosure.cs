using static Stringier.Patterns.Pattern;

namespace Stringier.Patterns.Parser {
	/// <summary>
	/// Represents a Kleene's Closure modifier; the existance of one or more of the pattern
	/// </summary>
	internal sealed class KleenesClosure : Modifier {
		/// <summary>
		/// The <see cref="Patterns.Pattern"/> which represents this type.
		/// </summary>
		new internal static readonly Pattern Pattern = '*';

		/// <summary>
		/// Initialize a new <see cref="KleenesClosure"/>.
		/// </summary>
		internal KleenesClosure() : base("*") { }

		/// <summary>
		/// Attempt to consume a <see cref="KleenesClosure"/> from the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <returns>A new <see cref="KleenesClosure"/> instance if parsing succeeded; otherwise <see langword="null"/>.</returns>
		/// <exception cref="PatternUndefinedException">The pattern was attempted to be used before actually being defined.</exception>
		new internal static KleenesClosure? Consume(ref Source source) {
			Result result = Pattern.Consume(ref source);
			return result ? Singleton.Instance : null;
		}

		private static class Singleton {
			static Singleton() { }

			internal static readonly KleenesClosure Instance = new KleenesClosure();
		}
	}
}
