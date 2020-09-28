using Defender;
using System;

namespace Stringier {
	public static partial class Text {
		#region EnsureStartsWith(Text, String)
		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required beginning.</param>
		/// <returns>A string with the ensured beginning.</returns>
		public static String EnsureStartsWith(this String text, String required) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(required, nameof(required));
			return EnsureStartsWith(text.AsSpan(), required.AsSpan());
		}

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required beginning.</param>
		/// <returns>A string with the ensured beginning.</returns>
		public static String EnsureStartsWith(this Char[] text, String required) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(required, nameof(required));
			return EnsureStartsWith(text.AsSpan(), required.AsSpan());
		}

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required beginning.</param>
		/// <returns>A string with the ensured beginning.</returns>
		public static String EnsureStartsWith(this Span<Char> text, String required) {
			Guard.NotNull(required, nameof(required));
			return EnsureStartsWith((ReadOnlySpan<Char>)text, required.AsSpan());
		}

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required beginning.</param>
		/// <returns>A string with the ensured beginning.</returns>
		public static String EnsureStartsWith(this ReadOnlySpan<Char> text, String required) {
			Guard.NotNull(required, nameof(required));
			return EnsureStartsWith(text, required.AsSpan());
		}

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="required">The required beginning.</param>
		/// <returns>A string with the ensured beginning.</returns>
		[CLSCompliant(false)]
		public static unsafe String EnsureStartsWith(Char* text, Int32 length, String required) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			return EnsureStartsWith(new ReadOnlySpan<Char>(text, length), required.AsSpan());
		}
		#endregion

		#region EnsureStartsWith(Text, String, Case)
		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required beginning.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>A string with the ensured beginning.</returns>
		public static String EnsureStartsWith(this String text, String required, Case casing) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(required, nameof(required));
			return EnsureStartsWith(text.AsSpan(), required.AsSpan(), casing);
		}

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required beginning.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>A string with the ensured beginning.</returns>
		public static String EnsureStartsWith(this Char[] text, String required, Case casing) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(required, nameof(required));
			return EnsureStartsWith(text.AsSpan(), required.AsSpan(), casing);
		}

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required beginning.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>A string with the ensured beginning.</returns>
		public static String EnsureStartsWith(this Span<Char> text, String required, Case casing) {
			Guard.NotNull(required, nameof(required));
			return EnsureStartsWith((ReadOnlySpan<Char>)text, required.AsSpan(), casing);
		}

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required beginning.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>A string with the ensured beginning.</returns>
		public static String EnsureStartsWith(this ReadOnlySpan<Char> text, String required, Case casing) {
			Guard.NotNull(required, nameof(required));
			return EnsureStartsWith(text, required.AsSpan(), casing);
		}

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="required">The required beginning.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>A string with the ensured beginning.</returns>
		[CLSCompliant(false)]
		public static unsafe String EnsureStartsWith(Char* text, Int32 length, String required, Case casing) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			return EnsureStartsWith(new ReadOnlySpan<Char>(text, length), required.AsSpan(), casing);
		}
		#endregion

		#region EnsureStartsWith(Text, Char[])
		#endregion

		#region EnsureStartsWith(Text, Char[], Case)
		#endregion

		#region EnsureStartsWith(Text, ReadOnlySpan<Char>)
		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required beginning.</param>
		/// <returns>A string with the ensured beginning.</returns>
		public static String EnsureStartsWith(this String text, ReadOnlySpan<Char> required) {
			Guard.NotNull(text, nameof(text));
			return EnsureStartsWith(text.AsSpan(), required);
		}

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required beginning.</param>
		/// <returns>A string with the ensured beginning.</returns>
		public static String EnsureStartsWith(this Char[] text, ReadOnlySpan<Char> required) {
			Guard.NotNull(text, nameof(text));
			return EnsureStartsWith(text.AsSpan(), required);
		}

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required beginning.</param>
		/// <returns>A string with the ensured beginning.</returns>
		public static String EnsureStartsWith(this Span<Char> text, ReadOnlySpan<Char> required) => EnsureStartsWith((ReadOnlySpan<Char>)text, required);

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required beginning.</param>
		/// <returns>A string with the ensured beginning.</returns>
		public static String EnsureStartsWith(this ReadOnlySpan<Char> text, ReadOnlySpan<Char> required) => EnsureStartsWith(text, required, Case.Sensitive);

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="required">The required beginning.</param>
		/// <returns>A string with the ensured beginning.</returns>
		[CLSCompliant(false)]
		public static unsafe String EnsureStartsWith(Char* text, Int32 length, ReadOnlySpan<Char> required) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			return EnsureStartsWith(new ReadOnlySpan<Char>(text, length), required);
		}
		#endregion

		#region EnsureStartsWith(Text, ReadOnlySpan<Char>, Case)
		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required beginning.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>A string with the ensured beginning.</returns>
		public static String EnsureStartsWith(this String text, ReadOnlySpan<Char> required, Case casing) {
			Guard.NotNull(text, nameof(text));
			return EnsureStartsWith(text.AsSpan(), required, casing);
		}

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required beginning.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>A string with the ensured beginning.</returns>
		public static String EnsureStartsWith(this Char[] text, ReadOnlySpan<Char> required, Case casing) {
			Guard.NotNull(text, nameof(text));
			return EnsureStartsWith(text.AsSpan(), required, casing);
		}

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required beginning.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>A string with the ensured beginning.</returns>
		public static String EnsureStartsWith(this Span<Char> text, ReadOnlySpan<Char> required, Case casing) => EnsureStartsWith((ReadOnlySpan<Char>)text, required, casing);

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required beginning.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>A string with the ensured beginning.</returns>
		public static String EnsureStartsWith(this ReadOnlySpan<Char> text, ReadOnlySpan<Char> required, Case casing) {
			if (text.StartsWith(required, casing)) {
				return text;
			} else {
				Span<Char> result = new Char[text.Length + required.Length];
				required.CopyTo(result.Slice(0, required.Length));
				text.CopyTo(result.Slice(required.Length, text.Length));
				return result;
			}
		}

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="required">The required beginning.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>A string with the ensured beginning.</returns>
		[CLSCompliant(false)]
		public static unsafe String EnsureStartsWith(Char* text, Int32 length, ReadOnlySpan<Char> required, Case casing) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			return EnsureStartsWith(new ReadOnlySpan<Char>(text, length), required, casing);
		}
		#endregion

		#region EnsureStartsWith(Text, Char*)
		#endregion

		#region EnsureStartsWith(Text, Char*, Case)
		#endregion
	}
}
