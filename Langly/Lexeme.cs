using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Represents any possible lexical element.
	/// </summary>
	public abstract partial class Lexeme {
		/// <summary>
		/// The location in the source this lexeme was found.
		/// </summary>
		private readonly Int32 Location;

		/// <summary>
		/// Initializes a new <see cref="Lexeme"/>.
		/// </summary>
		/// <param name="location">The location in the source this lexeme was found.</param>
		protected Lexeme(Int32 location) => Location = location;

		/// <summary>
		/// Can this lexeme be statically evaluated?
		/// </summary>
		public abstract Boolean Static { get; }

		/// <inheritdoc/>
		[return: NotNull]
		public abstract override String ToString();
	}
}
