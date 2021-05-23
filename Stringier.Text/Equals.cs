using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace Stringier {
	public static partial class Text {
		#region Equals(Text, Char)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Char first, Char second) => first.Equals(second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Rune first, Char second) => first == new Rune(second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this Rope first, Char second) => first?.Equals(second) ?? false;

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this String first, Char second) => EqualsKernel(first.AsSpan(), second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this Char[] first, Char second) => EqualsKernel(first, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Memory<Char> first, Char second) => EqualsKernel(first.Span, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlyMemory<Char> first, Char second) => EqualsKernel(first.Span, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Span<Char> first, Char second) => EqualsKernel(first, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlySpan<Char> first, Char second) => EqualsKernel(first, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* first, Int32 length, Char second) => EqualsKernel(new ReadOnlySpan<Char>(first, length), second);
		#endregion

		#region Equals(Text, Char, Case)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Char first, Char second, Case casing) {
			switch (casing) {
			case Case.Insensitive:
				return Char.ToUpper(first) == Char.ToUpper(second);
			case Case.Sensitive:
				return first == second;
			default:
				throw new ArgumentException();
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Rune first, Char second, Case casing) {
			switch (casing) {
			case Case.Insensitive:
				return Rune.ToUpper(first, CultureInfo.CurrentCulture) == Rune.ToUpper(new Rune(second), CultureInfo.CurrentCulture);
			case Case.Sensitive:
				return first == new Rune(second);
			default:
				throw new ArgumentException();
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this Rope first, Char second, Case casing) => first?.Equals(second, casing) ?? false;

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this String first, Char second, Case casing) => EqualsKernel(first.AsSpan(), second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this Char[] first, Char second, Case casing) => EqualsKernel(first, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Memory<Char> first, Char second, Case casing) => EqualsKernel(first.Span, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlyMemory<Char> first, Char second, Case casing) => EqualsKernel(first.Span, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Span<Char> first, Char second, Case casing) => EqualsKernel(first, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlySpan<Char> first, Char second, Case casing) => EqualsKernel(first, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* first, Int32 length, Char second, Case casing) => EqualsKernel(new ReadOnlySpan<Char>(first, length), second, casing);
		#endregion

		#region Equals(Text, Rune)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Char first, Rune second) => new Rune(first) == second;

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Rune first, Rune second) => first == second;

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this Rope first, Rune second) => first?.Equals(second) ?? false;

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this String first, Rune second) => EqualsKernel(first.AsSpan(), second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this Char[] first, Rune second) => EqualsKernel(first, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Memory<Char> first, Rune second) => EqualsKernel(first.Span, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlyMemory<Char> first, Rune second) => EqualsKernel(first.Span, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Span<Char> first, Rune second) => EqualsKernel(first, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlySpan<Char> first, Rune second) => EqualsKernel(first, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* first, Int32 length, Rune second) => EqualsKernel(new ReadOnlySpan<Char>(first, length), second);
		#endregion

		#region Equals(Text, Rune, Case)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Char first, Rune second, Case casing) {
			switch (casing) {
			case Case.Insensitive:
				return Rune.ToUpper(new Rune(first), CultureInfo.CurrentCulture) == Rune.ToUpper(second, CultureInfo.CurrentCulture);
			case Case.Sensitive:
				return new Rune(first) == second;
			default:
				throw new ArgumentException();
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Rune first, Rune second, Case casing) {
			switch (casing) {
			case Case.Insensitive:
				return Rune.ToUpper(first, CultureInfo.CurrentCulture) == Rune.ToUpper(second, CultureInfo.CurrentCulture);
			case Case.Sensitive:
				return first == second;
			default:
				throw new ArgumentException();
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this Rope first, Rune second, Case casing) => first?.Equals(second, casing) ?? false;

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this String first, Rune second, Case casing) => EqualsKernel(first.AsSpan(), second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this Char[] first, Rune second, Case casing) => EqualsKernel(first, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Memory<Char> first, Rune second, Case casing) => EqualsKernel(first.Span, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlyMemory<Char> first, Rune second, Case casing) => EqualsKernel(first.Span, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Span<Char> first, Rune second, Case casing) => EqualsKernel(first, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlySpan<Char> first, Rune second, Case casing) => EqualsKernel(first, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* first, Int32 length, Rune second, Case casing) => EqualsKernel(new ReadOnlySpan<Char>(first, length), second, casing);
		#endregion

		#region Equals(Text, Rope)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Char first, [AllowNull] Rope second) => second?.Equals(first) ?? false;

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Rune first, [AllowNull] Rope second) => second?.Equals(first) ?? false;

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this Rope first, [AllowNull] Rope second) => first?.Equals(second) ?? (second is null || second.Count <= 0);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this String first, [AllowNull] Rope second) => second?.Equals(first) ?? String.IsNullOrEmpty(first);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this Char[] first, [AllowNull] Rope second) => second?.Equals(first) ?? (first is null || first.Length <= 0);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Memory<Char> first, [AllowNull] Rope second) => second?.Equals(first) ?? first.IsEmpty;

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlyMemory<Char> first, [AllowNull] Rope second) => second?.Equals(first) ?? first.IsEmpty;

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Span<Char> first, [AllowNull] Rope second) => second?.Equals(first) ?? first.IsEmpty;

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlySpan<Char> first, [AllowNull] Rope second) => second?.Equals(first) ?? first.IsEmpty;

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="first"/> text.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* first, Int32 length, [AllowNull] Rope second) => second?.Equals(first, length) ?? (first is null || length <= 0);
		#endregion

		#region Equals(Text, Rope, Case)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Char first, [AllowNull] Rope second, Case casing) => second?.Equals(first, casing) ?? false;

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Rune first, [AllowNull] Rope second, Case casing) => second?.Equals(first, casing) ?? false;

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this Rope first, [AllowNull] Rope second, Case casing) => first?.Equals(second, casing) ?? (second is null || second.Count <= 0);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this String first, [AllowNull] Rope second, Case casing) => second?.Equals(first, casing) ?? String.IsNullOrEmpty(first);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this Char[] first, [AllowNull] Rope second, Case casing) => second?.Equals(first, casing) ?? (first is null || first.Length <= 0);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Memory<Char> first, [AllowNull] Rope second, Case casing) => second?.Equals(first, casing) ?? first.IsEmpty;

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlyMemory<Char> first, [AllowNull] Rope second, Case casing) => second?.Equals(first, casing) ?? first.IsEmpty;

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Span<Char> first, [AllowNull] Rope second, Case casing) => second?.Equals(first, casing) ?? first.IsEmpty;

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlySpan<Char> first, [AllowNull] Rope second, Case casing) => second?.Equals(first, casing) ?? first.IsEmpty;

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="first"/> text.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* first, Int32 length, [AllowNull] Rope second, Case casing) => second?.Equals(first, length, casing) ?? (first is null || length <= 0);
		#endregion

		#region Equals(Text, String)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Char first, [AllowNull] String second) => EqualsKernel(first, second.AsSpan());

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Rune first, [AllowNull] String second) => EqualsKernel(first, second.AsSpan());

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this Rope first, [AllowNull] String second) => first?.Equals(second) ?? String.IsNullOrEmpty(second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this String first, [AllowNull] String second) => EqualsKernel(first.AsSpan(), second.AsSpan());

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this Char[] first, [AllowNull] String second) => EqualsKernel(first, second.AsSpan());

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Memory<Char> first, [AllowNull] String second) => EqualsKernel(first.Span, second.AsSpan());

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlyMemory<Char> first, String second) => EqualsKernel(first.Span, second.AsSpan());

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Span<Char> first, [AllowNull] String second) => EqualsKernel(first, second.AsSpan());

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlySpan<Char> first, String second) => EqualsKernel(first, second.AsSpan());

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* first, Int32 length, [AllowNull] String second) => EqualsKernel(new ReadOnlySpan<Char>(first, length), second.AsSpan());
		#endregion

		#region Equals(Text, String, Case)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Char first, [AllowNull] String second, Case casing) => EqualsKernel(first, second.AsSpan(), casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Rune first, [AllowNull] String second, Case casing) => EqualsKernel(first, second.AsSpan(), casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this Rope first, [AllowNull] String second, Case casing) => first?.Equals(second, casing) ?? String.IsNullOrEmpty(second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this String first, [AllowNull] String second, Case casing) => EqualsKernel(first.AsSpan(), second.AsSpan(), casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this Char[] first, [AllowNull] String second, Case casing) => EqualsKernel(first, second.AsSpan(), casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Memory<Char> first, [AllowNull] String second, Case casing) => EqualsKernel(first.Span, second.AsSpan(), casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlyMemory<Char> first, [AllowNull] String second, Case casing) => EqualsKernel(first.Span, second.AsSpan(), casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Span<Char> first, [AllowNull] String second, Case casing) => EqualsKernel(first, second.AsSpan(), casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlySpan<Char> first, [AllowNull] String second, Case casing) => EqualsKernel(first, second.AsSpan(), casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* first, Int32 length, [AllowNull] String second, Case casing) => EqualsKernel(new ReadOnlySpan<Char>(first, length), second.AsSpan(), casing);
		#endregion

		#region Equals(Text, Char[])
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Char first, [AllowNull] Char[] second) => EqualsKernel(first, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Rune first, [AllowNull] Char[] second) => EqualsKernel(first, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this Rope first, [AllowNull] Char[] second) => first?.Equals(second) ?? (second is null || second.Length <= 0);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this String first, [AllowNull] Char[] second) => EqualsKernel(first.AsSpan(), second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this Char[] first, [AllowNull] Char[] second) => EqualsKernel(first, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Memory<Char> first, [AllowNull] Char[] second) => EqualsKernel(first.Span, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlyMemory<Char> first, [AllowNull] Char[] second) => EqualsKernel(first.Span, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Span<Char> first, [AllowNull] Char[] second) => EqualsKernel(first, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlySpan<Char> first, [AllowNull] Char[] second) => EqualsKernel(first, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* first, Int32 length, [AllowNull] Char[] second) => EqualsKernel(new ReadOnlySpan<Char>(first, length), second);
		#endregion

		#region Equals(Text, Char[], Case)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Char first, [AllowNull] Char[] second, Case casing) => EqualsKernel(first, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Rune first, [AllowNull] Char[] second, Case casing) => EqualsKernel(first, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this Rope first, [AllowNull] Char[] second, Case casing) => first?.Equals(second, casing) ?? (second is null || second.Length <= 0);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this String first, [AllowNull] Char[] second, Case casing) => EqualsKernel(first.AsSpan(), second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this Char[] first, [AllowNull] Char[] second, Case casing) => EqualsKernel(first, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Memory<Char> first, [AllowNull] Char[] second, Case casing) => EqualsKernel(first.Span, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlyMemory<Char> first, [AllowNull] Char[] second, Case casing) => EqualsKernel(first.Span, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Span<Char> first, [AllowNull] Char[] second, Case casing) => EqualsKernel(first, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlySpan<Char> first, [AllowNull] Char[] second, Case casing) => EqualsKernel(first, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* first, Int32 length, [AllowNull] Char[] second, Case casing) => EqualsKernel(new ReadOnlySpan<Char>(first, length), second, casing);
		#endregion

		#region Equals(Text, Memory<Char>)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Char first, Memory<Char> second) => EqualsKernel(first, second.Span);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Rune first, Memory<Char> second) => EqualsKernel(first, second.Span);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this Rope first, Memory<Char> second) => first?.Equals(second) ?? second.IsEmpty;

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this String first, Memory<Char> second) => EqualsKernel(first.AsSpan(), second.Span);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this Char[] first, Memory<Char> second) => EqualsKernel(first, second.Span);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Memory<Char> first, Memory<Char> second) => EqualsKernel(first.Span, second.Span);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlyMemory<Char> first, Memory<Char> second) => EqualsKernel(first.Span, second.Span);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Span<Char> first, Memory<Char> second) => EqualsKernel(first, second.Span);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlySpan<Char> first, Memory<Char> second) => EqualsKernel(first, second.Span);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* first, Int32 length, Memory<Char> second) => EqualsKernel(new ReadOnlySpan<Char>(first, length), second.Span);
		#endregion

		#region Equals(Text, Memory<Char>, Case)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Char first, Memory<Char> second, Case casing) => EqualsKernel(first, second.Span, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Rune first, Memory<Char> second, Case casing) => EqualsKernel(first, second.Span, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this Rope first, Memory<Char> second, Case casing) => first?.Equals(second, casing) ?? second.IsEmpty;

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this String first, Memory<Char> second, Case casing) => EqualsKernel(first.AsSpan(), second.Span, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this Char[] first, Memory<Char> second, Case casing) => EqualsKernel(first, second.Span, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Memory<Char> first, Memory<Char> second, Case casing) => EqualsKernel(first.Span, second.Span, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlyMemory<Char> first, Memory<Char> second, Case casing) => EqualsKernel(first.Span, second.Span, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Span<Char> first, Memory<Char> second, Case casing) => EqualsKernel(first, second.Span, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlySpan<Char> first, Memory<Char> second, Case casing) => EqualsKernel(first, second.Span, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* first, Int32 length, Memory<Char> second, Case casing) => EqualsKernel(new ReadOnlySpan<Char>(first, length), second.Span, casing);
		#endregion

		#region Equals(Text, ReadOnlyMemory<Char>)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Char first, ReadOnlyMemory<Char> second) => EqualsKernel(first, second.Span);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Rune first, ReadOnlyMemory<Char> second) => EqualsKernel(first, second.Span);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this Rope first, ReadOnlyMemory<Char> second) => first?.Equals(second) ?? second.IsEmpty;

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this String first, ReadOnlyMemory<Char> second) => EqualsKernel(first.AsSpan(), second.Span);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this Char[] first, ReadOnlyMemory<Char> second) => EqualsKernel(first, second.Span);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Memory<Char> first, ReadOnlyMemory<Char> second) => EqualsKernel(first.Span, second.Span);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlyMemory<Char> first, ReadOnlyMemory<Char> second) => EqualsKernel(first.Span, second.Span);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Span<Char> first, ReadOnlyMemory<Char> second) => EqualsKernel(first, second.Span);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlySpan<Char> first, ReadOnlyMemory<Char> second) => EqualsKernel(first, second.Span);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* first, Int32 length, ReadOnlyMemory<Char> second) => EqualsKernel(new ReadOnlySpan<Char>(first, length), second.Span);
		#endregion

		#region Equals(Text, ReadOnlyMemory<Char>, Case)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Char first, ReadOnlyMemory<Char> second, Case casing) => EqualsKernel(first, second.Span, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Rune first, ReadOnlyMemory<Char> second, Case casing) => EqualsKernel(first, second.Span, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this Rope first, ReadOnlyMemory<Char> second, Case casing) => first?.Equals(second, casing) ?? second.IsEmpty;

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this String first, ReadOnlyMemory<Char> second, Case casing) => EqualsKernel(first.AsSpan(), second.Span, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this Char[] first, ReadOnlyMemory<Char> second, Case casing) => EqualsKernel(first, second.Span, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Memory<Char> first, ReadOnlyMemory<Char> second, Case casing) => EqualsKernel(first.Span, second.Span, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlyMemory<Char> first, ReadOnlyMemory<Char> second, Case casing) => EqualsKernel(first.Span, second.Span, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Span<Char> first, ReadOnlyMemory<Char> second, Case casing) => EqualsKernel(first, second.Span, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlySpan<Char> first, ReadOnlyMemory<Char> second, Case casing) => EqualsKernel(first, second.Span, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* first, Int32 length, ReadOnlyMemory<Char> second, Case casing) => EqualsKernel(new ReadOnlySpan<Char>(first, length), second.Span, casing);
		#endregion

		#region Equals(Text, Span<Char>)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Char first, Span<Char> second) => EqualsKernel(first, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Rune first, Span<Char> second) => EqualsKernel(first, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this Rope first, Span<Char> second) => first?.Equals(second) ?? second.IsEmpty;

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this String first, Span<Char> second) => EqualsKernel(first.AsSpan(), second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this Char[] first, Span<Char> second) => EqualsKernel(first, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Memory<Char> first, Span<Char> second) => EqualsKernel(first.Span, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlyMemory<Char> first, Span<Char> second) => EqualsKernel(first.Span, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Span<Char> first, Span<Char> second) => EqualsKernel(first, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlySpan<Char> first, Span<Char> second) => EqualsKernel(first, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* first, Int32 length, Span<Char> second) => EqualsKernel(new ReadOnlySpan<Char>(first, length), second);
		#endregion

		#region Equals(Text, Span<Char>, Case)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Char first, Span<Char> second, Case casing) => EqualsKernel(first, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Rune first, Span<Char> second, Case casing) => EqualsKernel(first, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this Rope first, Span<Char> second, Case casing) => first?.Equals(second, casing) ?? second.IsEmpty;

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this String first, Span<Char> second, Case casing) => EqualsKernel(first.AsSpan(), second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this Char[] first, Span<Char> second, Case casing) => EqualsKernel(first, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Memory<Char> first, Span<Char> second, Case casing) => EqualsKernel(first.Span, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlyMemory<Char> first, Span<Char> second, Case casing) => EqualsKernel(first.Span, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Span<Char> first, Span<Char> second, Case casing) => EqualsKernel(first, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlySpan<Char> first, Span<Char> second, Case casing) => EqualsKernel(first, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* first, Int32 length, Span<Char> second, Case casing) => EqualsKernel(new ReadOnlySpan<Char>(first, length), second, casing);
		#endregion

		#region Equals(Text, ReadOnlySpan<Char>)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Char first, ReadOnlySpan<Char> second) => EqualsKernel(first, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Rune first, ReadOnlySpan<Char> second) => EqualsKernel(first, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this Rope first, ReadOnlySpan<Char> second) => first?.Equals(second) ?? second.IsEmpty;

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this String first, ReadOnlySpan<Char> second) => EqualsKernel(first.AsSpan(), second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this Char[] first, ReadOnlySpan<Char> second) => EqualsKernel(first, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Memory<Char> first, ReadOnlySpan<Char> second) => EqualsKernel(first.Span, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlyMemory<Char> first, ReadOnlySpan<Char> second) => EqualsKernel(first.Span, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Span<Char> first, ReadOnlySpan<Char> second) => EqualsKernel(first, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlySpan<Char> first, ReadOnlySpan<Char> second) => EqualsKernel(first, second);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <param name="second">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* first, Int32 length, ReadOnlySpan<Char> second) => EqualsKernel(new ReadOnlySpan<Char>(first, length), second);
		#endregion

		#region Equals(Text, ReadOnlySpan<Char>, Case)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Char first, ReadOnlySpan<Char> second, Case casing) => EqualsKernel(first, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Rune first, ReadOnlySpan<Char> second, Case casing) => EqualsKernel(first, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this Rope first, ReadOnlySpan<Char> second, Case casing) => first?.Equals(second, casing) ?? second.IsEmpty;

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this String first, ReadOnlySpan<Char> second, Case casing) => EqualsKernel(first.AsSpan(), second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this Char[] first, ReadOnlySpan<Char> second, Case casing) => EqualsKernel(first, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Memory<Char> first, ReadOnlySpan<Char> second, Case casing) => EqualsKernel(first.Span, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlyMemory<Char> first, ReadOnlySpan<Char> second, Case casing) => EqualsKernel(first.Span, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Span<Char> first, ReadOnlySpan<Char> second, Case casing) => EqualsKernel(first, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlySpan<Char> first, ReadOnlySpan<Char> second, Case casing) => EqualsKernel(first, second, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* first, Int32 length, ReadOnlySpan<Char> second, Case casing) => EqualsKernel(new ReadOnlySpan<Char>(first, length), second, casing);
		#endregion

		#region Equals(Text, Char*)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(this Char first, [AllowNull] Char* second, Int32 length) => EqualsKernel(first, new ReadOnlySpan<Char>(second, length));

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(this Rune first, [AllowNull] Char* second, Int32 length) => EqualsKernel(first, new ReadOnlySpan<Char>(second, length));

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] this Rope first, [AllowNull] Char* second, Int32 length) => first?.Equals(new ReadOnlySpan<Char>(second, length)) ?? (second is null || length <= 0);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] this String first, [AllowNull] Char* second, Int32 length) => EqualsKernel(first.AsSpan(), new ReadOnlySpan<Char>(second, length));

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] this Char[] first, [AllowNull] Char* second, Int32 length) => EqualsKernel(first, new ReadOnlySpan<Char>(second, length));

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(this Memory<Char> first, [AllowNull] Char* second, Int32 length) => EqualsKernel(first.Span, new ReadOnlySpan<Char>(second, length));

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(this ReadOnlyMemory<Char> first, [AllowNull] Char* second, Int32 length) => EqualsKernel(first.Span, new ReadOnlySpan<Char>(second, length));

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(this Span<Char> first, [AllowNull] Char* second, Int32 length) => EqualsKernel(first, new ReadOnlySpan<Char>(second, length));

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(this ReadOnlySpan<Char> first, [AllowNull] Char* second, Int32 length) => EqualsKernel(first, new ReadOnlySpan<Char>(second, length));

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="firstLength">The length of the <paramref name="first"/> text.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="secondLength">The length of the <paramref name="second"/> text.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* first, Int32 firstLength, [AllowNull] Char* second, Int32 secondLength) => EqualsKernel(new ReadOnlySpan<Char>(first, firstLength), new ReadOnlySpan<Char>(second, secondLength));
		#endregion

		#region Equals(Text, Char*, Case)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(this Char first, [AllowNull] Char* second, Int32 length, Case casing) => EqualsKernel(first, new ReadOnlySpan<Char>(second, length), casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(this Rune first, [AllowNull] Char* second, Int32 length, Case casing) => EqualsKernel(first, new ReadOnlySpan<Char>(second, length), casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] this Rope first, [AllowNull] Char* second, Int32 length, Case casing) => first?.Equals(new ReadOnlySpan<Char>(second, length), casing) ?? (second is null || length <= 0);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] this String first, [AllowNull] Char* second, Int32 length, Case casing) => EqualsKernel(first.AsSpan(), new ReadOnlySpan<Char>(second, length), casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] this Char[] first, [AllowNull] Char* second, Int32 length, Case casing) => EqualsKernel(first, new ReadOnlySpan<Char>(second, length), casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(this Memory<Char> first, [AllowNull] Char* second, Int32 length, Case casing) => EqualsKernel(first.Span, new ReadOnlySpan<Char>(second, length), casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(this ReadOnlyMemory<Char> first, [AllowNull] Char* second, Int32 length, Case casing) => EqualsKernel(first.Span, new ReadOnlySpan<Char>(second, length), casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(this Span<Char> first, [AllowNull] Char* second, Int32 length, Case casing) => EqualsKernel(first, new ReadOnlySpan<Char>(second, length), casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="second"/> text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(this ReadOnlySpan<Char> first, [AllowNull] Char* second, Int32 length, Case casing) => EqualsKernel(first, new ReadOnlySpan<Char>(second, length), casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="first">The first text to compare.</param>
		/// <param name="firstLength">The length of the <paramref name="first"/> text.</param>
		/// <param name="second">The second text to compare.</param>
		/// <param name="secondLength">The length of the <paramref name="second"/> text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="second"/> parameter is the same as the <paramref name="first"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* first, Int32 firstLength, [AllowNull] Char* second, Int32 secondLength, Case casing) => EqualsKernel(new ReadOnlySpan<Char>(first, firstLength), new ReadOnlySpan<Char>(second, secondLength), casing);
		#endregion

		private static Boolean EqualsKernel(Char first, ReadOnlySpan<Char> second) => EqualsKernel(first, second, Case.Sensitive);

		private static Boolean EqualsKernel(Char first, ReadOnlySpan<Char> second, Case casing) => EqualsKernel(second, first, casing);

		private static Boolean EqualsKernel(ReadOnlySpan<Char> first, Char second) => EqualsKernel(first, second, Case.Sensitive);

		private static Boolean EqualsKernel(ReadOnlySpan<Char> first, Char second, Case casing) {
			if (first.Length != 1) {
				return false;
			}
			switch (casing) {
			case Case.Insensitive:
				return Char.ToUpper(first[0]).Equals(Char.ToUpper(second));
			case Case.Sensitive:
				return first[0].Equals(second);
			default:
				throw new ArgumentException();
			}
		}
		
		private static Boolean EqualsKernel(Rune first, ReadOnlySpan<Char> second) => EqualsKernel(first, second, Case.Sensitive);

		private static Boolean EqualsKernel(Rune first, ReadOnlySpan<Char> second, Case casing) => EqualsKernel(second, first, casing);

		private static Boolean EqualsKernel(ReadOnlySpan<Char> first, Rune second) => EqualsKernel(first, second, Case.Sensitive);

		private static Boolean EqualsKernel(ReadOnlySpan<Char> first, Rune second, Case casing) {
			if (first.Length != second.Utf16SequenceLength) {
				return false;
			}
			switch (casing) {
			case Case.Insensitive:
				return Rune.ToUpper(first.GetRuneAt(0), CultureInfo.CurrentCulture) == Rune.ToUpper(second, CultureInfo.CurrentCulture);
			case Case.Sensitive:
				return first.GetRuneAt(0) == second;
			default:
				throw new ArgumentException();
			}
		}

		private static Boolean EqualsKernel(ReadOnlySpan<Char> first, ReadOnlySpan<Char> second) => EqualsKernel(first, second, Case.Sensitive);

		private static Boolean EqualsKernel(ReadOnlySpan<Char> first, ReadOnlySpan<Char> second, Case casing) {
			switch (casing) {
			case Case.Insensitive:
				return MemoryExtensions.Equals(first, second, StringComparison.OrdinalIgnoreCase);
			case Case.Sensitive:
				return MemoryExtensions.Equals(first, second, StringComparison.Ordinal);
			default:
				throw new ArgumentException();
			}
		}
	}
}
