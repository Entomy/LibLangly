using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Traits;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents the alternation of two <see cref="Pattern"/>. That is, one <see cref="Pattern"/> or the other.
	/// </summary>
	internal sealed class Alternator : Combinator {
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
		internal Alternator([DisallowNull] Pattern left, [DisallowNull] Pattern right) {
			Left = left;
			Right = right;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override Pattern Many() {
			if (Left is Optor || Right is Optor) {
				throw new InvalidOperationException("One or more of the components of this alternator are optional, and the alternator is marked as spanning. Options can not span, as it creates an infinite loop. While this potentially could succeed, this is absolutely an error.");
			} else {
				return base.Many();
			}
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override Pattern Or([AllowNull] Pattern other) => other is not null ? new ChainAlternator(Left, Right, other) : this;

		/// <inheritdoc/>
		[return: NotNull]
		public override Pattern Or(Char other) => new ChainAlternator(Left, Right, new CharLiteral(other));

		/// <inheritdoc/>
		[return: NotNull]
		public override Pattern Or(Rune other) => new ChainAlternator(Left, Right, new RuneLiteral(other));

		/// <inheritdoc/>
		[return: NotNull]
		public override Pattern Or([AllowNull] String other) => other is not null ? new ChainAlternator(Left, Right, new StringLiteral(other)) : this;
		/// <inheritdoc/>
		protected internal override void Consume(ReadOnlyMemory<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			Left.Consume(source, ref location, out exception, trace);
			if (exception is not null) {
				Exception last = exception; // Store the exception
				Right.Consume(source, ref location, out exception, trace);
				if (exception is not null) {
					exception = last; // Reassign the first error, since both failed and we want to be clear of that
				}
			}
		}

		/// <inheritdoc/>
		protected internal override unsafe void Consume([DisallowNull] Char* source, Int32 length, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			Left.Consume(source, length, ref location, out exception, trace);
			if (exception is not null) {
				Exception last = exception; // Store the exception
				Right.Consume(source, length, ref location, out exception, trace);
				if (exception is not null) {
					exception = last; // Reassign the first error, since both failed and we want to be clear of that
				}
			}
		}

		/// <inheritdoc/>
		protected internal override Boolean IsConsumeHeader(ReadOnlySpan<Char> source, Int32 location) => Left.IsConsumeHeader(source, location) || Right.IsConsumeHeader(source, location);

		/// <inheritdoc/>
		protected internal override Boolean IsNeglectHeader(ReadOnlySpan<Char> source, Int32 location) => Left.IsNeglectHeader(source, location) || Right.IsNeglectHeader(source, location);

		/// <inheritdoc/>
		protected internal override void Neglect(ReadOnlyMemory<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			Int32 start = location;
			Right.Neglect(source, ref location, out exception, trace);
			if (exception is not null) {
				location = start;
				Left.Neglect(source, ref location, out exception, trace);
			}
		}

		/// <inheritdoc/>
		protected internal override unsafe void Neglect([DisallowNull] Char* source, Int32 length, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			Int32 start = location;
			Right.Neglect(source, length, ref location, out exception, trace);
			if (exception is not null) {
				location = start;
				Left.Neglect(source, length, ref location, out exception, trace);
			}
		}
	}
}
