using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a <see cref="Ranger"/> which supports escape sequences.
	/// </summary>
	/// <remarks>
	/// The escape sequence is intended to allow the <see cref="Ranger.To"/> node to exist inside of the range, it should be considered exactly like a string quote escape inside of a string.
	/// </remarks>
	internal sealed class EscapedRanger : Ranger {
		/// <summary>
		/// The <see cref="Pattern"/> representing the escape sequence.
		/// </summary>
		[DisallowNull, NotNull]
		internal readonly Pattern Escape;

		/// <summary>
		/// Initialize a new <see cref="EscapedRanger"/> with the given <paramref name="from"/>, <paramref name="to"/>, and <paramref name="escape"/> nodes.
		/// </summary>
		/// <param name="from">The <see cref="Pattern"/> to start from.</param>
		/// <param name="to">The <see cref="Pattern"/> to read to.</param>
		/// <param name="escape">The <see cref="Pattern"/> representing the escape sequence.</param>
		internal EscapedRanger([DisallowNull] Pattern from, [DisallowNull] Pattern to, [DisallowNull] Pattern escape) : base(from, to) => Escape = escape;

		/// <inheritdoc/>
		protected internal override void Consume(ReadOnlyMemory<Char> source, ref Int32 length) => throw new NotImplementedException();

		/// <inheritdoc/>
		protected internal override void Neglect(ReadOnlyMemory<Char> source, ref Int32 length) => throw new NotImplementedException();
	}
}
