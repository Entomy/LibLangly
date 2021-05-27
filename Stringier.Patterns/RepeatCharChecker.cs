using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents the repetition of <see cref="CharChecker"/>.
	/// </summary>
	/// <remarks>
	/// This is an optimization, and doesn't do anything that normal repeater wouldn't be able to do.
	/// </remarks>
	internal sealed class RepeatCharChecker : Checker {
		/// <summary>
		/// A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/>.
		/// </summary>
		[NotNull, DisallowNull]
		internal readonly Func<Char, Boolean> Check;

		/// <summary>
		/// The amount of times to repeat.
		/// </summary>
		internal readonly Int32 Count;

		/// <summary>
		/// Initialize a new <see cref="RepeatCharChecker"/> from the specified <paramref name="check"/> and <paramref name="count"/>.
		/// </summary>
		/// <param name="check">A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/>.
		/// </param>
		/// <param name="count">The amount of times to repeat.</param>
		internal RepeatCharChecker([DisallowNull] Func<Char, Boolean> check, Int32 count) {
			Check = check;
			Count = count;
		}

		/// <inheritdoc/>
		protected internal override void Consume(ReadOnlyMemory<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => Consume(source.Span, ref location, out exception, trace);

		/// <inheritdoc/>
		protected internal override unsafe void Consume([DisallowNull] Char* source, Int32 length, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => Consume(new ReadOnlySpan<Char>(source, length), ref location, out exception, trace);

		/// <inheritdoc/>
		protected internal override Boolean IsConsumeHeader(ReadOnlySpan<Char> source, Int32 location) => throw new NotImplementedException();

		/// <inheritdoc/>
		protected internal override Boolean IsNeglectHeader(ReadOnlySpan<Char> source, Int32 location) => throw new NotImplementedException();

		/// <inheritdoc/>
		protected internal override void Neglect(ReadOnlyMemory<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => Neglect(source.Span, ref location, out exception, trace);

		/// <inheritdoc/>
		protected internal override unsafe void Neglect([DisallowNull] Char* source, Int32 length, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => Neglect(new ReadOnlySpan<Char>(source, length), ref location, out exception, trace);

		private void Consume(ReadOnlySpan<Char> source, ref Int32 length, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => throw new NotImplementedException();

		private void Neglect(ReadOnlySpan<Char> source, ref Int32 length, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => throw new NotImplementedException();
	}
}
