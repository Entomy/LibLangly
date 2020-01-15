using System;
using Stringier.Patterns;
using static Stringier.Patterns.Pattern;

namespace Stringier.Patterns.Parser {
	/// <summary>
	/// Represents a many modifier; the spanning of the pattern
	/// </summary>
	public sealed class Many : Modifier {
		/// <summary>
		/// The <see cref="Patterns.Pattern"/> which represents this type.
		/// </summary>
		new public static readonly Pattern Pattern = '+';

		/// <summary>
		/// Initialize a new <see cref="Many"/>.
		/// </summary>
		internal Many() : base("+") { }

		/// <summary>
		/// Attempt to consume a <see cref="Many"/> from the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <returns>A new <see cref="Many"/> instance if parsing succeeded; otherwise <see langword="null"/>.</returns>
		public static Many? Consume(ref Source source) {
			Result result = Pattern.Consume(ref source);
			return result ? Singleton.Instance : null;
		}

		private static class Singleton {
			static Singleton() { }

			internal static readonly Many Instance = new Many();
		}
	}
}
