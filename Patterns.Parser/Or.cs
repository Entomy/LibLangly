using System;
using Stringier.Patterns;
using static Stringier.Patterns.Pattern;

namespace Stringier.Patterns.Parser {
	/// <summary>
	/// Represents an or combinator; the alternation of two patterns.
	/// </summary>
	public sealed class Or : Combinator {
		/// <summary>
		/// The <see cref="Patterns.Pattern"/> which represents this type.
		/// </summary>
		new public static readonly Pattern Pattern = "or".With(Compare.CaseInsensitive);

		/// <summary>
		/// Initialize a new <see cref="Or"/>.
		/// </summary>
		internal Or() : base("or") { }

		/// <summary>
		/// Attempt to consume a <see cref="Or"/> from the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <returns>A new <see cref="Or"/> instance if parsing succeeded; otherwise <see langword="null"/>.</returns>
		public static Or? Consume(ref Source source) {
			Result result = Pattern.Consume(ref source);
			return result ? Singleton.Instance : null;
		}

		private static class Singleton {
			static Singleton() { }

			internal static readonly Or Instance = new Or();
		}

	}
}
