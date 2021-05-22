using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a rune literal, a pattern matching this exact rune.
	/// </summary>
	/// <remarks>
	/// This exists to box <see cref="System.Text.Rune"/> into something that we can treat as part of a pattern.
	/// </remarks>
	internal sealed class RuneLiteral : Literal {
		/// <summary>
		/// The <see cref="System.Text.Rune"/> being matched.
		/// </summary>
		internal readonly Rune Rune;

		/// <summary>
		/// Initialize a new <see cref="RuneLiteral"/> with the given <paramref name="rune"/>.
		/// </summary>
		/// <param name="rune"></param>
		internal RuneLiteral(Rune rune) : this(rune, default) { }

		/// <summary>
		/// Initialize a new <see cref="RuneLiteral"/> with the given <paramref name="rune"/>.
		/// </summary>
		/// <param name="rune">The <see cref="System.Text.Rune"/> to parse.</param>
		/// <param name="casing">The <see cref="Case"/> to use when parsing.</param>
		internal RuneLiteral(Rune rune, Case casing) : base(casing) => Rune = rune;

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Rune.ToString();

		/// <inheritdoc/>
		protected internal override void Consume(ReadOnlyMemory<Char> source, ref Int32 length) => throw new NotImplementedException();

		/// <inheritdoc/>
		protected internal override void Neglect(ReadOnlyMemory<Char> source, ref Int32 length) => throw new NotImplementedException();
	}
}
