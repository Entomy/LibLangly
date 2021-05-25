using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier.Patterns {
	public partial class Pattern {
		/// <summary>
		/// Marks the <paramref name="pattern"/> as repeating <paramref name="count"/> times.
		/// </summary>
		/// <param name="pattern">The <see cref="Pattern"/> to repeat.</param>
		/// <param name="count">The amount of times to repeat.</param>
		/// <returns>A new <see cref="Pattern"/> repeated <paramref name="count"/> times.</returns>
		[return: MaybeNull, NotNullIfNotNull("pattern")]
		public static Pattern operator *([AllowNull] Pattern pattern, Int32 count) => pattern?.Repeat(count);

		/// <summary>
		/// Marks this <see cref="Pattern"/> as repeating <paramref name="count"/> times.
		/// </summary>
		/// <param name="count">The amount of times to repeat.</param>
		/// <returns>A new <see cref="Pattern"/> repeated <paramref name="count"/> times.</returns>
		[return: NotNull]
		public virtual Pattern Repeat(Int32 count) => new Repeater(this, count);

		/// <summary>
		/// Marks the <paramref name="pattern"/> as repeating <paramref name="count"/> times.
		/// </summary>
		/// <param name="pattern">The <see cref="Pattern"/> to repeat.</param>
		/// <param name="count">The amount of times to repeat.</param>
		/// <returns>A new <see cref="Pattern"/> repeated <paramref name="count"/> times.</returns>
		[return: MaybeNull, NotNullIfNotNull("pattern")]
		public static Pattern Repeat([AllowNull] Pattern pattern, Int32 count) => pattern?.Repeat(count);
	}
}
