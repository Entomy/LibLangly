using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents the concatenation of two <see cref="Pattern"/>. That is, one <see cref="Pattern"/> directly after another.
	/// </summary>
	internal sealed class Concatenator : Combinator {
		/// <summary>
		/// The lefthand <see cref="Pattern"/>; the first.
		/// </summary>
		[DisallowNull, NotNull]
		private readonly Pattern Left;

		/// <summary>
		/// The righthand <see cref="Pattern"/>; the last.
		/// </summary>
		[DisallowNull, NotNull]
		private readonly Pattern Right;

		/// <summary>
		/// Initialize a new <see cref="Concatenator"/> with the <paramref name="left"/> and <paramref name="right"/> <see cref="Pattern"/>.
		/// </summary>
		/// <param name="left">The lefthand <see cref="Pattern"/>; the first.</param>
		/// <param name="right">The righthand <see cref="Pattern"/>; the last.</param>
		internal Concatenator([DisallowNull] Pattern left, [DisallowNull] Pattern right) {
			Left = left;
			Right = right;
		}

		/// <inheritdoc/>
		protected internal override void Consume(ReadOnlyMemory<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			Left.Consume(source, ref location, out exception, trace);
			if (exception is not null) return;
			Right.Consume(source, ref location, out exception, trace);
		}

		/// <inheritdoc/>
		protected internal override unsafe void Consume([DisallowNull] Char* source, Int32 length, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			Left.Consume(source, length, ref location, out exception, trace);
			if (exception is not null) return;
			Right.Consume(source, length, ref location, out exception, trace);
		}

		/// <inheritdoc/>
		protected internal override Boolean IsConsumeHeader(ReadOnlySpan<Char> source, Int32 location) => Left.IsConsumeHeader(source, location);

		/// <inheritdoc/>
		protected internal override Boolean IsNeglectHeader(ReadOnlySpan<Char> source, Int32 location) => Left.IsNeglectHeader(source, location);

		/// <inheritdoc/>
		protected internal override void Neglect(ReadOnlyMemory<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			Left.Neglect(source, ref location, out exception, trace);
			if (exception is null) return;
			Right.Neglect(source, ref location, out exception, trace);
		}

		/// <inheritdoc/>
		protected internal override unsafe void Neglect([DisallowNull] Char* source, Int32 length, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			Left.Neglect(source, length, ref location, out exception, trace);
			if (exception is null) return;
			Right.Neglect(source, length, ref location, out exception, trace);
		}
	}
}
