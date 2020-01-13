using System;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Replaces one or more format items in the <paramref name="string"/> with the string representation of a specified object.
		/// </summary>
		/// <param name="string">A composite format string.</param>
		/// <param name="arg0">The object to format.</param>
		/// <returns>A copy of <paramref name="string"/> in which any format items are replaced by the string representation of <paramref name="arg0"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="string"/> is <see langword="null"/>.</exception>
		/// <exception cref="FormatException">
		/// <para>The format item in <paramref name="string"/> is invalid.</para>
		/// -or-
		/// <para>The index of a format item is not zero.</para>
		/// </exception>
		public static String Format(this String @string, Object arg0) => String.Format(@string, arg0);

		/// <summary>
		/// Replaces one or more format items in the <paramref name="string"/> with the string representation of a specified object.
		/// </summary>
		/// <param name="string">A composite format string.</param>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		/// <param name="arg0">The object to format.</param>
		/// <returns>A copy of <paramref name="string"/> in which any format items are replaced by the string representation of <paramref name="arg0"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="string"/> is <see langword="null"/>.</exception>
		/// <exception cref="FormatException">
		/// <para>The format item in <paramref name="string"/> is invalid.</para>
		/// -or-
		/// <para>The index of a format item is not zero.</para>
		/// </exception>
		public static String Format(this String @string, IFormatProvider provider, Object arg0) => String.Format(provider, @string, arg0);

		/// <summary>
		/// Replaces the format items in the <paramref name="string"/> with the string representation of the two specified objects.
		/// </summary>
		/// <param name="string">A composite format string.</param>
		/// <param name="arg0">The first object to format.</param>
		/// <param name="arg1">The second object to format.</param>
		/// <returns>A copy of <paramref name="string"/> in which format items are replaced by the string representations of <paramref name="arg0"/> and <paramref name="arg1"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="string"/> is <see langword="null"/>.</exception>
		/// <exception cref="FormatException">
		/// <para><paramref name="string"/> is invalid.</para>
		/// -or-
		/// <para>The index of a format item is not zero or one.</para>
		/// </exception>
		public static String Format(this String @string, Object arg0, Object arg1) => String.Format(@string, arg0, arg1);

		/// <summary>
		/// Replaces the format items in the <paramref name="string"/> with the string representation of the two specified objects.
		/// </summary>
		/// <param name="string">A composite format string.</param>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		/// <param name="arg0">The first object to format.</param>
		/// <param name="arg1">The second object to format.</param>
		/// <returns>A copy of <paramref name="string"/> in which format items are replaced by the string representations of <paramref name="arg0"/> and <paramref name="arg1"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="string"/> is <see langword="null"/>.</exception>
		/// <exception cref="FormatException">
		/// <para><paramref name="string"/> is invalid.</para>
		/// -or-
		/// <para>The index of a format item is not zero or one.</para>
		/// </exception>
		public static String Format(this String @string, IFormatProvider provider, Object arg0, Object arg1) => String.Format(provider, @string, arg0, arg1);

		/// <summary>
		/// Replaces the format items in the <paramref name="string"/> with the string representation of three specified objects.
		/// </summary>
		/// <param name="string">A composite format string.</param>
		/// <param name="arg0">The first object to format.</param>
		/// <param name="arg1">The second object to format.</param>
		/// <param name="arg2">The third object to format.</param>
		/// <returns>A copy of <paramref name="string"/> in which the format items have been replaced by the string representations of <paramref name="arg0"/>, <paramref name="arg1"/>, and <paramref name="arg2"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="string"/> is <see langword="null"/>.</exception>
		/// <exception cref="FormatException">
		/// <para><paramref name="string"/> is invalid.</para>
		/// -or-
		/// <para>The index of a format item is less than zero, or greater than two.</para>
		/// </exception>
		public static String Format(this String @string, Object arg0, Object arg1, Object arg2) => String.Format(@string, arg0, arg1, arg2);

		/// <summary>
		/// Replaces the format items in the <paramref name="string"/> with the string representation of three specified objects.
		/// </summary>
		/// <param name="string">A composite format string.</param>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		/// <param name="arg0">The first object to format.</param>
		/// <param name="arg1">The second object to format.</param>
		/// <param name="arg2">The third object to format.</param>
		/// <returns>A copy of <paramref name="string"/> in which the format items have been replaced by the string representations of <paramref name="arg0"/>, <paramref name="arg1"/>, and <paramref name="arg2"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="string"/> is <see langword="null"/>.</exception>
		/// <exception cref="FormatException">
		/// <para><paramref name="string"/> is invalid.</para>
		/// -or-
		/// <para>The index of a format item is less than zero, or greater than two.</para>
		/// </exception>
		public static String Format(this String @string, IFormatProvider provider, Object arg0, Object arg1, Object arg2) => String.Format(provider, @string, arg0, arg1, arg2);

		/// <summary>
		/// Replaces the format item in the <paramref name="string"/> with the string representation of a corresponding object in a specified array.
		/// </summary>
		/// <param name="string">A composite format string.</param>
		/// <param name="args">An object array that contains zero or more objects to format.</param>
		/// <returns>A copy of <paramref name="string"/> in which the format items have been replaced by the string representation of the corresponding objects in <paramref name="args"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="string"/> or <paramref name="args"/> is <see langword="null"/>.</exception>
		public static String Format(this String @string, params Object[] args) => String.Format(@string, args);

		/// <summary>
		/// Replaces the format item in the <paramref name="string"/> with the string representation of a corresponding object in a specified array.
		/// </summary>
		/// <param name="string">A composite format string.</param>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		/// <param name="args">An object array that contains zero or more objects to format.</param>
		/// <returns>A copy of <paramref name="string"/> in which the format items have been replaced by the string representation of the corresponding objects in <paramref name="args"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="string"/> or <paramref name="args"/> is <see langword="null"/>.</exception>
		public static String Format(this String @string, IFormatProvider provider, params Object[] args) => String.Format(provider, @string, args);
	}
}
