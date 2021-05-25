using System.Diagnostics.CodeAnalysis;

namespace Stringier.Patterns {
	public partial class Pattern {
		/// <summary>
		/// Marks the <paramref name="pattern"/> as optional.
		/// </summary>
		/// <param name="pattern">The <see cref="Pattern"/> to make optional.</param>
		/// <returns>A new <see cref="Pattern"/> which may or may not be present in order to match.</returns>
		[return: MaybeNull, NotNullIfNotNull("pattern")]
		public static Pattern operator -([AllowNull] Pattern pattern) => pattern?.Maybe();

		/// <summary>
		/// Marks this <see cref="Pattern"/> as optional.
		/// </summary>
		/// <returns>A new <see cref="Pattern"/> which may or may not be present in order to match.</returns>
		[return: NotNull]
		public virtual Pattern Maybe() => new Optor(this);

		/// <summary>
		/// Marks the <paramref name="pattern"/> as optional.
		/// </summary>
		/// <param name="pattern">The <see cref="Pattern"/> to make optional.</param>
		/// <returns>A new <see cref="Pattern"/> which may or may not be present in order to match.</returns>
		[return: MaybeNull, NotNullIfNotNull("pattern")]
		public static Pattern Maybe([AllowNull] Pattern pattern) => pattern?.Maybe();
	}
}
