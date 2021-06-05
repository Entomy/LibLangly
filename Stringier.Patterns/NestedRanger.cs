using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a <see cref="Ranger"/> which supports nesting of the range.
	/// </summary>
	internal sealed class NestedRanger : Ranger {
		/// <summary>
		/// The current nesting level.
		/// </summary>
		private Int32 Level;

		/// <summary>
		/// Initialize a new <see cref="NestedRanger"/> with the given <paramref name="from"/> and <paramref name="to"/>
		/// </summary>
		/// <param name="from">The <see cref="Pattern"/> to start from.</param>
		/// <param name="to">The <see cref="Pattern"/> to read to.</param>
		internal NestedRanger([DisallowNull] Pattern from, [DisallowNull] Pattern to) : base(from, to) => Level = 0;

		/// <inheritdoc/>
		protected internal override void Consume(ReadOnlySpan<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			Int32 start = location;
			From.Consume(source, ref location, out exception, trace);
			if (exception is null) {
				Level++;
			} else {
				exception = NoMatch;
				return;
			}
			while (Level > 0) {
				if (location == source.Length) break;
				if (From.IsConsumeHeader(source, location)) {
					From.Consume(source, ref location, out exception, trace);
					if (exception is null) {
						Level++;
					}
				}
				if (location == source.Length) break;
				if (To.IsConsumeHeader(source, location)) {
					To.Consume(source, ref location, out exception, trace);
					if (exception is null) {
						Level--;
					}
				} else {
					location++;
				}
			}
			if (Level != 0) {
				exception = NoMatch;
			}
			if (exception is not null) {
				location = start;
			}
		}
	}
}
