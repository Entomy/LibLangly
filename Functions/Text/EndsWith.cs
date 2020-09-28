using System;

namespace Stringier {
	public static partial class Text {
		#region EndsWith(Text, String)
		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean EndsWith(this String text, String required) => EndsWith(text.AsSpan(), required.AsSpan());

		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean EndsWith(this Char[] text, String required) => EndsWith(text.AsSpan(), required.AsSpan());

		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean EndsWith(this ReadOnlySpan<Char> text, String required) => EndsWith(text, required.AsSpan());

		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="required">The string to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean EndsWith(Char* text, Int32 length, String required) => EndsWith(new ReadOnlySpan<Char>(text, length), required.AsSpan());
		#endregion

		#region EndsWith(Text, String, Case)
		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean EndsWith(this String text, String required, Case casing) => EndsWith(text.AsSpan(), required.AsSpan(), casing);

		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean EndsWith(this Char[] text, String required, Case casing) => EndsWith(text.AsSpan(), required.AsSpan(), casing);

		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean EndsWith(this ReadOnlySpan<Char> text, String required, Case casing) => EndsWith(text, required.AsSpan(), casing);

		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean EndsWith(Char* text, Int32 length, String required, Case casing) => EndsWith(new ReadOnlySpan<Char>(text, length), required.AsSpan(), casing);
		#endregion

		#region EndsWith(Text, Char[])
		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean EndsWith(this String text, Char[] required) => EndsWith(text.AsSpan(), required.AsSpan());

		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean EndsWith(this Char[] text, Char[] required) => EndsWith(text.AsSpan(), required.AsSpan());

		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean EndsWith(this ReadOnlySpan<Char> text, Char[] required) => EndsWith(text, required.AsSpan());

		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="required">The string to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean EndsWith(Char* text, Int32 length, Char[] required) => EndsWith(new ReadOnlySpan<Char>(text, length), required.AsSpan());
		#endregion

		#region EndsWith(Text, Char[], Case)
		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean EndsWith(this String text, Char[] required, Case casing) => EndsWith(text.AsSpan(), required.AsSpan(), casing);

		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean EndsWith(this Char[] text, Char[] required, Case casing) => EndsWith(text.AsSpan(), required.AsSpan(), casing);

		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean EndsWith(this ReadOnlySpan<Char> text, Char[] required, Case casing) => Equals(text.Slice(text.Length - required.Length, required.Length), required.AsSpan(), casing);

		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean EndsWith(Char* text, Int32 length, Char[] required, Case casing) => EndsWith(new ReadOnlySpan<Char>(text, length), required.AsSpan(), casing);
		#endregion

		#region EndsWith(Text, ReadOnlySpan<Char>)
		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean EndsWith(this String text, ReadOnlySpan<Char> required) => EndsWith(text.AsSpan(), required);

		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean EndsWith(this Char[] text, ReadOnlySpan<Char> required) => EndsWith(text.AsSpan(), required);

		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean EndsWith(this ReadOnlySpan<Char> text, ReadOnlySpan<Char> required) => EndsWith(text, required, Case.Insensitive);

		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="required">The string to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean EndsWith(Char* text, Int32 length, ReadOnlySpan<Char> required) => EndsWith(new ReadOnlySpan<Char>(text, length), required);
		#endregion

		#region EndsWith(Text, ReadOnlySpan<Char>, Case)
		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean EndsWith(this String text, ReadOnlySpan<Char> required, Case casing) => EndsWith(text.AsSpan(), required, casing);

		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean EndsWith(this Char[] text, ReadOnlySpan<Char> required, Case casing) => EndsWith(text.AsSpan(), required, casing);

		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		public static Boolean EndsWith(this ReadOnlySpan<Char> text, ReadOnlySpan<Char> required, Case casing) => Equals(text.Slice(text.Length - required.Length, required.Length), required, casing);

		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean EndsWith(Char* text, Int32 length, ReadOnlySpan<Char> required, Case casing) => EndsWith(new ReadOnlySpan<Char>(text, length), required, casing);
		#endregion

		#region EndsWith(Text, Char*)
		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="length">The length of the <paramref name="required"/>.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean EndsWith(this String text, Char* required, Int32 length) => EndsWith(text.AsSpan(), new ReadOnlySpan<Char>(required, length));

		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="length">The length of the <paramref name="required"/>.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean EndsWith(this Char[] text, Char* required, Int32 length) => EndsWith(text.AsSpan(), new ReadOnlySpan<Char>(required, length));

		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="length">The length of the <paramref name="required"/>.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean EndsWith(this ReadOnlySpan<Char> text, Char* required, Int32 length) => EndsWith(text, new ReadOnlySpan<Char>(required, length));

		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="requiredLength">The length of the <paramref name="required"/>.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean EndsWith(Char* text, Int32 length, Char* required, Int32 requiredLength) => EndsWith(new ReadOnlySpan<Char>(text, length), new ReadOnlySpan<Char>(required, length));
		#endregion

		#region EndsWith(Text, Char*, Case)
		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="length">The length of the <paramref name="required"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean EndsWith(this String text, Char* required, Int32 length, Case casing) => EndsWith(text.AsSpan(), new ReadOnlySpan<Char>(required, length), casing);

		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="length">The length of the <paramref name="required"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean EndsWith(this Char[] text, Char* required, Int32 length, Case casing) => EndsWith(text.AsSpan(), new ReadOnlySpan<Char>(required, length), casing);

		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="length">The length of the <paramref name="required"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean EndsWith(this ReadOnlySpan<Char> text, Char* required, Int32 length, Case casing) => Equals(text.Slice(0, length), new ReadOnlySpan<Char>(required, length), casing);

		/// <summary>
		/// Determines whether the ending of this string instance matches the specified string.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="required">The string to compare.</param>
		/// <param name="requiredLength">The length of the <paramref name="required"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if <paramref name="required"/> matches the ending of this text; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean EndsWith(Char* text, Int32 length, Char* required, Int32 requiredLength, Case casing) => EndsWith(new ReadOnlySpan<Char>(text, length), new ReadOnlySpan<Char>(required, requiredLength), casing);
		#endregion
	}
}
