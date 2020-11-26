using Stringier.Linguistics;

namespace Langly {
	/// <summary>
	/// Indicates the type has casing.
	/// </summary>
	public interface ICased<out TSelf> where TSelf : ICased<TSelf> {
		/// <summary>
		/// Converts the text to its lowercase form, invariant of orthograhy.
		/// </summary>
		/// <returns></returns>
		TSelf ToLower();

		/// <summary>
		/// Converts the text to its lowercase form using the rules of the <paramref name="orthography"/>.
		/// </summary>
		/// <param name="orthography">The <see cref="Orthography"/> instance describing the rules of the orthography.</param>
		/// <returns></returns>
		/// <remarks>
		/// If <paramref name="orthography"/> is <see langword="null"/>, then the invariant should be used.
		/// </remarks>
		TSelf ToLower(Orthography orthography);

		/// <summary>
		/// Converts the text to its titlecase form, invariant of orthograhy.
		/// </summary>
		/// <returns></returns>
		TSelf ToTitle();

		/// <summary>
		/// Converts the text to its titlecase form using the rules of the <paramref name="orthography"/>.
		/// </summary>
		/// <param name="orthography">The <see cref="Orthography"/> instance describing the rules of the orthography.</param>
		/// /// <returns></returns>
		/// <remarks>
		/// If <paramref name="orthography"/> is <see langword="null"/>, then the invariant should be used.
		/// </remarks>
		TSelf ToTitle(Orthography orthography);

		/// <summary>
		/// Converts the text to its uppercase form, invariant of orthograhy.
		/// </summary>
		/// <returns></returns>
		TSelf ToUpper();

		/// <summary>
		/// Converts the text to its uppercase form using the rules of the <paramref name="orthography"/>.
		/// </summary>
		/// <param name="orthography">The <see cref="Orthography"/> instance describing the rules of the orthography.</param>
		/// <returns></returns>
		/// <remarks>
		/// If <paramref name="orthography"/> is <see langword="null"/>, then the invariant should be used.
		/// </remarks>
		TSelf ToUpper(Orthography orthography);
	}
}
