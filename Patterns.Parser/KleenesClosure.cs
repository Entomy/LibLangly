using System;
using Stringier.Patterns;
using static Stringier.Patterns.Pattern;

namespace Stringier.Patterns.Parser {
	/// <summary>
	/// Represents a Kleene's Closure modifier; the existance of one or more of the pattern
	/// </summary>
	public sealed class KleeneClosure : Modifier {
		/// <summary>
		/// The <see cref="Patterns.Pattern"/> which represents this type.
		/// </summary>
		new public static readonly Pattern Pattern = '*';

		/// <summary>
		/// Initialize a new <see cref="KleeneClosure"/>.
		/// </summary>
		internal KleeneClosure() : base("*") { }

		/// <summary>
		/// Attempt to consume a <see cref="KleeneClosure"/> from the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <returns>A new <see cref="KleeneClosure"/> instance if parsing succeeded; otherwise <see langword="null"/>.</returns>
		public static KleeneClosure? Consume(ref Source source) {
			Result result = Pattern.Consume(ref source);
			return result ? Singleton.Instance : null;
		}

		private static class Singleton {
			static Singleton() { }

			internal static readonly KleeneClosure Instance = new KleeneClosure();
		}
	}
}
