using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Represents any possible lexical element.
	/// </summary>
	public abstract partial class Lexeme {
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
		/// Initializes a new <see cref="Lexeme"/>.
		/// </summary>
		/// <param name="location">The location in the source this lexeme was found.</param>
		/// <param name="length">The length of this lexeme in the source.</param>
		protected Lexeme(Int32 location, Int32 length) {
			Location = location;
			Length = length;
		}

		/// <summary>
		/// The length of this lexeme in the source.
		/// </summary>
		public Int32 Length { get; }

		/// <summary>
		/// The location in the source this lexeme was found.
		/// </summary>
		public Int32 Location { get; }

		/// <summary>
		/// Can this lexeme be statically evaluated?
		/// </summary>
		public abstract Boolean Static { get; }

		/// <summary>
		/// Registers the <paramref name="parser"/> as a specialization of a <see cref="Lexeme"/> <see cref="Parser"/>.
		/// </summary>
		/// <param name="parser">The <see cref="Parser"/> to register.</param>
		protected static void Register([DisallowNull] Parser parser) {
			if (Tail is not null) {
				Tail.Next = parser;
				Tail = Tail.Next;
			} else {
				Head = parser;
				Tail = parser;
			}
		}
	}
}
