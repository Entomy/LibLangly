using System;

namespace Stringier {
	public static partial class Text {
		#region StartsWith(Text, String)
		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean StartsWith(this String text, String required) => StartsWith(text.AsSpan(), required.AsSpan());

		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean StartsWith(this Char[] text, String required) => StartsWith(text.AsSpan(), required.AsSpan());

		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean StartsWith(this ReadOnlySpan<Char> text, String required) => StartsWith(text, required.AsSpan());

		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="required">The string to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean StartsWith(Char* text, Int32 length, String required) => StartsWith(new ReadOnlySpan<Char>(text, length), required.AsSpan());
		#endregion

		#region StartsWith(Text, String, Case)
		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean StartsWith(this String text, String required, Case casing) => StartsWith(text.AsSpan(), required.AsSpan(), casing);

		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean StartsWith(this Char[] text, String required, Case casing) => StartsWith(text.AsSpan(), required.AsSpan(), casing);

		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean StartsWith(this ReadOnlySpan<Char> text, String required, Case casing) => StartsWith(text, required.AsSpan(), casing);

		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean StartsWith(Char* text, Int32 length, String required, Case casing) => StartsWith(new ReadOnlySpan<Char>(text, length), required.AsSpan(), casing);
		#endregion

		#region StartsWith(Text, Char[])
		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean StartsWith(this String text, Char[] required) => StartsWith(text.AsSpan(), required.AsSpan());

		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean StartsWith(this Char[] text, Char[] required) => StartsWith(text.AsSpan(), required.AsSpan());

		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean StartsWith(this ReadOnlySpan<Char> text, Char[] required) => StartsWith(text, required.AsSpan());

		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="required">The string to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean StartsWith(Char* text, Int32 length, Char[] required) => StartsWith(new ReadOnlySpan<Char>(text, length), required.AsSpan());
		#endregion

		#region StartsWith(Text, Char[], Case)
		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean StartsWith(this String text, Char[] required, Case casing) => StartsWith(text.AsSpan(), required.AsSpan(), casing);

		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean StartsWith(this Char[] text, Char[] required, Case casing) => StartsWith(text.AsSpan(), required.AsSpan(), casing);

		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean StartsWith(this ReadOnlySpan<Char> text, Char[] required, Case casing) => Equals(text.Slice(0, required.Length), required.AsSpan(), casing);

		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean StartsWith(Char* text, Int32 length, Char[] required, Case casing) => StartsWith(new ReadOnlySpan<Char>(text, length), required.AsSpan(), casing);
		#endregion

		#region StartsWith(Text, ReadOnlySpan<Char>)
		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean StartsWith(this String text, ReadOnlySpan<Char> required) => StartsWith(text.AsSpan(), required);

		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean StartsWith(this Char[] text, ReadOnlySpan<Char> required) => StartsWith(text.AsSpan(), required);

		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean StartsWith(this ReadOnlySpan<Char> text, ReadOnlySpan<Char> required) => StartsWith(text, required, Case.Insensitive);

		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="required">The string to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean StartsWith(Char* text, Int32 length, ReadOnlySpan<Char> required) => StartsWith(new ReadOnlySpan<Char>(text, length), required);
		#endregion

		#region StartsWith(Text, ReadOnlySpan<Char>, Case)
		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean StartsWith(this String text, ReadOnlySpan<Char> required, Case casing) => StartsWith(text.AsSpan(), required, casing);

		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean StartsWith(this Char[] text, ReadOnlySpan<Char> required, Case casing) => StartsWith(text.AsSpan(), required, casing);

		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean StartsWith(this ReadOnlySpan<Char> text, ReadOnlySpan<Char> required, Case casing) => Equals(text.Slice(0, required.Length), required, casing);

		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean StartsWith(Char* text, Int32 length, ReadOnlySpan<Char> required, Case casing) => StartsWith(new ReadOnlySpan<Char>(text, length), required, casing);
		#endregion

		#region StartsWith(Text, Char*)
		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="length">The length of the <paramref name="required"/>.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean StartsWith(this String text, Char* required, Int32 length) => StartsWith(text.AsSpan(), new ReadOnlySpan<Char>(required, length));

		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="length">The length of the <paramref name="required"/>.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean StartsWith(this Char[] text, Char* required, Int32 length) => StartsWith(text.AsSpan(), new ReadOnlySpan<Char>(required, length));

		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="length">The length of the <paramref name="required"/>.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean StartsWith(this ReadOnlySpan<Char> text, Char* required, Int32 length) => StartsWith(text, new ReadOnlySpan<Char>(required, length));

		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="requiredLength">The length of the <paramref name="required"/>.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean StartsWith(Char* text, Int32 length, Char* required, Int32 requiredLength) => StartsWith(new ReadOnlySpan<Char>(text, length), new ReadOnlySpan<Char>(required, length));
		#endregion

		#region StartsWith(Text, Char*, Case)
		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="length">The length of the <paramref name="required"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean StartsWith(this String text, Char* required, Int32 length, Case casing) => StartsWith(text.AsSpan(), new ReadOnlySpan<Char>(required, length), casing);

		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="length">The length of the <paramref name="required"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean StartsWith(this Char[] text, Char* required, Int32 length, Case casing) => StartsWith(text.AsSpan(), new ReadOnlySpan<Char>(required, length), casing);

		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="length">The length of the <paramref name="required"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean StartsWith(this ReadOnlySpan<Char> text, Char* required, Int32 length, Case casing) => Equals(text.Slice(0, length), new ReadOnlySpan<Char>(required, length), casing);

		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="requiredLength">The length of the <paramref name="required"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the beginning of this text; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean StartsWith(Char* text, Int32 length, Char* required, Int32 requiredLength, Case casing) => StartsWith(new ReadOnlySpan<Char>(text, length), new ReadOnlySpan<Char>(required, requiredLength), casing);
		#endregion
	}
}
