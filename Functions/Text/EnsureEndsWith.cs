using Defender;
using System;

namespace Stringier {
	public static partial class Text {
		#region EnsureEndsWith(Text, String)
		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required endning.</param>
		/// <returns>A string with the ensured endning.</returns>
		public static String EnsureEndsWith(this String text, String required) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(required, nameof(required));
			return EnsureEndsWith(text.AsSpan(), required.AsSpan());
		}

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required endning.</param>
		/// <returns>A string with the ensured endning.</returns>
		public static String EnsureEndsWith(this Char[] text, String required) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(required, nameof(required));
			return EnsureEndsWith(text.AsSpan(), required.AsSpan());
		}

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required endning.</param>
		/// <returns>A string with the ensured endning.</returns>
		public static String EnsureEndsWith(this Span<Char> text, String required) {
			Guard.NotNull(required, nameof(required));
			return EnsureEndsWith((ReadOnlySpan<Char>)text, required.AsSpan());
		}

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required endning.</param>
		/// <returns>A string with the ensured endning.</returns>
		public static String EnsureEndsWith(this ReadOnlySpan<Char> text, String required) {
			Guard.NotNull(required, nameof(required));
			return EnsureEndsWith(text, required.AsSpan());
		}

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="required">The required endning.</param>
		/// <returns>A string with the ensured endning.</returns>
		[CLSCompliant(false)]
		public static unsafe String EnsureEndsWith(Char* text, Int32 length, String required) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			return EnsureEndsWith(new ReadOnlySpan<Char>(text, length), required.AsSpan());
		}
		#endregion

		#region EnsureEndsWith(Text, String, Case)
		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required endning.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>A string with the ensured endning.</returns>
		public static String EnsureEndsWith(this String text, String required, Case casing) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(required, nameof(required));
			return EnsureEndsWith(text.AsSpan(), required.AsSpan(), casing);
		}

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required endning.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>A string with the ensured endning.</returns>
		public static String EnsureEndsWith(this Char[] text, String required, Case casing) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(required, nameof(required));
			return EnsureEndsWith(text.AsSpan(), required.AsSpan(), casing);
		}

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required endning.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>A string with the ensured endning.</returns>
		public static String EnsureEndsWith(this Span<Char> text, String required, Case casing) {
			Guard.NotNull(required, nameof(required));
			return EnsureEndsWith((ReadOnlySpan<Char>)text, required.AsSpan(), casing);
		}

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required endning.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>A string with the ensured endning.</returns>
		public static String EnsureEndsWith(this ReadOnlySpan<Char> text, String required, Case casing) {
			Guard.NotNull(required, nameof(required));
			return EnsureEndsWith(text, required.AsSpan(), casing);
		}

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="required">The required endning.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>A string with the ensured endning.</returns>
		[CLSCompliant(false)]
		public static unsafe String EnsureEndsWith(Char* text, Int32 length, String required, Case casing) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			return EnsureEndsWith(new ReadOnlySpan<Char>(text, length), required.AsSpan(), casing);
		}
		#endregion

		#region EnsureEndsWith(Text, Char[])
		#endregion

		#region EnsureEndsWith(Text, Char[], Case)
		#endregion

		#region EnsureEndsWith(Text, ReadOnlySpan<Char>)
		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required endning.</param>
		/// <returns>A string with the ensured endning.</returns>
		public static String EnsureEndsWith(this String text, ReadOnlySpan<Char> required) {
			Guard.NotNull(text, nameof(text));
			return EnsureEndsWith(text.AsSpan(), required);
		}

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required endning.</param>
		/// <returns>A string with the ensured endning.</returns>
		public static String EnsureEndsWith(this Char[] text, ReadOnlySpan<Char> required) {
			Guard.NotNull(text, nameof(text));
			return EnsureEndsWith(text.AsSpan(), required);
		}

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required endning.</param>
		/// <returns>A string with the ensured endning.</returns>
		public static String EnsureEndsWith(this Span<Char> text, ReadOnlySpan<Char> required) => EnsureEndsWith((ReadOnlySpan<Char>)text, required);

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required endning.</param>
		/// <returns>A string with the ensured endning.</returns>
		public static String EnsureEndsWith(this ReadOnlySpan<Char> text, ReadOnlySpan<Char> required) => EnsureEndsWith(text, required, Case.Sensitive);

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="required">The required endning.</param>
		/// <returns>A string with the ensured endning.</returns>
		[CLSCompliant(false)]
		public static unsafe String EnsureEndsWith(Char* text, Int32 length, ReadOnlySpan<Char> required) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			return EnsureEndsWith(new ReadOnlySpan<Char>(text, length), required);
		}
		#endregion

		#region EnsureEndsWith(Text, ReadOnlySpan<Char>, Case)
		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required endning.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>A string with the ensured endning.</returns>
		public static String EnsureEndsWith(this String text, ReadOnlySpan<Char> required, Case casing) {
			Guard.NotNull(text, nameof(text));
			return EnsureEndsWith(text.AsSpan(), required, casing);
		}

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required endning.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>A string with the ensured endning.</returns>
		public static String EnsureEndsWith(this Char[] text, ReadOnlySpan<Char> required, Case casing) {
			Guard.NotNull(text, nameof(text));
			return EnsureEndsWith(text.AsSpan(), required, casing);
		}

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required endning.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>A string with the ensured endning.</returns>
		public static String EnsureEndsWith(this Span<Char> text, ReadOnlySpan<Char> required, Case casing) => EnsureEndsWith((ReadOnlySpan<Char>)text, required, casing);

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="required">The required endning.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>A string with the ensured endning.</returns>
		public static String EnsureEndsWith(this ReadOnlySpan<Char> text, ReadOnlySpan<Char> required, Case casing) {
			if (text.EndsWith(required, casing)) {
				return text.ToString();
			} else {
				Span<Char> result = new Char[text.Length + required.Length];
				text.CopyTo(result.Slice(0, text.Length));
				required.CopyTo(result.Slice(text.Length, required.Length));
				return result.ToString();
			}
		}

		/// <summary>
		/// Ensures the <paramref name="text"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="required">The required endning.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>A string with the ensured endning.</returns>
		[CLSCompliant(false)]
		public static unsafe String EnsureEndsWith(Char* text, Int32 length, ReadOnlySpan<Char> required, Case casing) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			return EnsureEndsWith(new ReadOnlySpan<Char>(text, length), required, casing);
		}
		#endregion

		#region EnsureEndsWith(Text, Char*)
		#endregion

		#region EnsureEndsWith(Text, Char*, Case)
		#endregion
	}
}
