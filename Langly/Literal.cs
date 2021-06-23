using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Represents any literal.
	/// </summary>
	public abstract partial class Literal : Lexeme {
		/// <summary>
		/// The head node of the parser list.
		/// </summary>
		[AllowNull, MaybeNull]
		private static Parser Head;

		/// <summary>
		/// The tail node of the parser list.
		/// </summary>
		[AllowNull, MaybeNull]
		private static Parser Tail;

		/// <summary>
		/// Initializes a new <see cref="Literal"/>.
		/// </summary>
		/// <param name="location">The location in the source this literal was found.</param>
		/// <param name="length">The length of this lexeme in the source.</param>
		protected Literal(Int32 location, Int32 length) : base(location, length) { }

		/// <inheritdoc/>
		public sealed override Boolean Static => true;

		/// <summary>
		/// Registers the <paramref name="parser"/> as a specialization of a <see cref="Literal"/> <see cref="Parser"/>.
		/// </summary>
		/// <param name="parser">The <see cref="Parser"/> to register.</param>
		protected static void Register([DisallowNull] Parser parser) {
			if (Tail is not null) {
				Tail.Next = parser;
				Tail = (Parser)Tail.Next;
			} else {
				Head = parser;
				Tail = parser;
			}
		}
	}
}
