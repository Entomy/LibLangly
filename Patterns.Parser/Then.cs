using System;
using Stringier.Patterns;
using static Stringier.Patterns.Pattern;

namespace Stringier.Patterns.Parser {
	/// <summary>
	/// Represents a then combinator; the concatenation of two patterns.
	/// </summary>
	internal sealed class Then : Combinator {
		/// <summary>
		/// The <see cref="Patterns.Pattern"/> which represents this type.
		/// </summary>
		new public static readonly Pattern Pattern = "then".With(Compare.CaseInsensitive);

		/// <summary>
		/// Initialize a new <see cref="Then"/>.
		/// </summary>
		internal Then() : base("then") { }

		/// <summary>
		/// Attempt to consume a <see cref="Then"/> from the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <returns>A new <see cref="Then"/> instance if parsing succeeded; otherwise <see langword="null"/>.</returns>
		new internal static Then? Consume(ref Source source) {
			Result result = Pattern.Consume(ref source);
			return result ? Singleton.Instance : null;
		}

		private static class Singleton {
			static Singleton() { }

			internal static readonly Then Instance = new Then();
		}
	}
}
