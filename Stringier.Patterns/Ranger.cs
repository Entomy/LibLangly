using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a <see cref="Ranger"/>, a "range" of text between two <see cref="Pattern"/>.
	/// </summary>
	internal class Ranger : Combinator {
		/// <summary>
		/// The <see cref="Pattern"/> to start from.
		/// </summary>
		[DisallowNull, NotNull]
		protected readonly Pattern From;

		/// <summary>
		/// The <see cref="Pattern"/> to read to.
		/// </summary>
		[DisallowNull, NotNull]
		protected readonly Pattern To;

		/// <summary>
		/// Initialize a new <see cref="Ranger"/> with the given <paramref name="from"/> and <paramref name="to"/> nodes.
		/// </summary>
		/// <param name="from">The <see cref="Pattern"/> to start from.</param>
		/// <param name="to">The <see cref="Pattern"/> to read to.</param>
		internal protected Ranger([DisallowNull] Pattern from, [DisallowNull] Pattern to) {
			From = from;
			To = to;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override Pattern Not() => throw new InvalidOperationException("Ranges can not be negated, as there is no valid concept to describe this behavior");

		/// <inheritdoc/>
		protected internal override void Consume(ReadOnlyMemory<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			Int32 start = location;
			From.Consume(source, ref location, out exception, trace);
			if (exception is not null) return;
			To.Consume(source, ref location, out exception, trace);
			while (exception is not null) {
				if (++location == source.Length) break;
				if (To.IsConsumeHeader(source, location)) {
					To.Consume(source, ref location, out exception, trace);
				}
			}
			if (exception is not null) {
				location = start;
				exception = AtEnd;
			}
		}

		/// <inheritdoc/>
		protected internal override unsafe void Consume([DisallowNull] Char* source, Int32 length, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			Int32 start = location;
			From.Consume(source, length, ref location, out exception, trace);
			if (exception is not null) return;
			To.Consume(source, length, ref location, out exception, trace);
			while (exception is not null) {
				if (++location == length) break;
				if (To.IsConsumeHeader(source, location)) {
					To.Consume(source, length, ref location, out exception, trace);
				}
			}
			if (exception is not null) {
				location = start;
				exception = AtEnd;
			}
		}

		/// <inheritdoc/>
		protected internal sealed override Boolean IsConsumeHeader(ReadOnlySpan<Char> source, Int32 location) => From.IsConsumeHeader(source, location);

		/// <inheritdoc/>
		protected internal sealed override Boolean IsNeglectHeader(ReadOnlySpan<Char> source, Int32 location) => From.IsConsumeHeader(source, location);

		/// <inheritdoc/>
		protected internal sealed override void Neglect(ReadOnlyMemory<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => throw new InvalidOperationException("Ranges can not be negated, as there is no valid concept to describe this behavior");

		/// <inheritdoc/>
		protected internal sealed override unsafe void Neglect([DisallowNull] Char* source, Int32 length, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => throw new InvalidOperationException("Ranges can not be negated, as there is no valid concept to describe this behavior");
	}
}
