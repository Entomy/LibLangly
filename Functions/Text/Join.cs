using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Defender;

namespace Stringier {
	public static partial class Text {
		//Note: Unlike many other functions throughout this library, we can't do as much implementation sharing for this functions. The reason being that, while technically possible, the performance implications of relying on certain abstractions is... horrifying. Luckily, we can provide fantastic type coverage while still leaving in a straightforward mechanism for optimization of special cases, because method resolution will always favor the most specialized function, and gradually fall back to more and more generic functions. In other words, special cases are handled at compile time by the overload resolver, not as branches inside of a method.
		// Note: These functions do not share the same return type. In instances where joins are possible without allocations (very few, but it's possible), then the return type of ReadOnlySpan<Char> is used instead of String.

		#region Join(Sequence<Char>)
		/// <summary>
		/// Joins the <paramref name="sequence"/> into a string.
		/// </summary>
		/// <param name="sequence">The sequence of objects to join.</param>
		/// <returns>The joined text.</returns>
		public static ReadOnlySpan<Char> Join(this Char[] sequence) => sequence.AsSpan();

		/// <summary>
		/// Joins the <paramref name="sequence"/> into a string.
		/// </summary>
		/// <param name="sequence">The sequence of objects to join.</param>
		/// <returns>The joined text.</returns>
		public static String Join(this IEnumerable<Char> sequence) {
			StringBuilder builder = new StringBuilder();
			foreach (Char item in sequence) {
				builder.Append(item);
			}
			return builder.ToString();
		}
		#endregion

		#region Join(Sequence<Rune>)
		#endregion

		#region Join(Sequence<String>)
		#endregion

		#region Join(Sequence<Object>)
		/// <summary>
		/// Joins the <paramref name="sequence"/> into a string.
		/// </summary>
		/// <param name="sequence">The sequence of objects to join.</param>
		/// <returns>The joined text.</returns>
		/// <remarks>
		/// This works by converting every object in the sequence to a string, then joining them together.
		/// </remarks>
		public static String Join(this Object[] sequence) {
			StringBuilder builder = new StringBuilder();
			foreach (Object item in sequence) {
				builder.Append(item);
			}
			return builder.ToString();
		}

		/// <summary>
		/// Joins the <paramref name="sequence"/> into a string.
		/// </summary>
		/// <param name="sequence">The sequence of objects to join.</param>
		/// <returns>The joined text.</returns>
		/// <remarks>
		/// This works by converting every object in the sequence to a string, then joining them together.
		/// </remarks>
		public static String Join(this IEnumerable sequence) {
			StringBuilder builder = new StringBuilder();
			foreach (Object item in sequence) {
				builder.Append(item);
			}
			return builder.ToString();
		}

		/// <summary>
		/// Joins the <paramref name="sequence"/> into a string.
		/// </summary>
		/// <param name="sequence">The sequence of objects to join.</param>
		/// <returns>The joined text.</returns>
		/// <remarks>
		/// This works by converting every object in the sequence to a string, then joining them together.
		/// </remarks>
		public static String Join(this IEnumerable<Object> sequence) {
			StringBuilder builder = new StringBuilder();
			foreach (Object item in sequence) {
				builder.Append(item);
			}
			return builder.ToString();
		}
		#endregion

		#region Join(Sequence<Char>, Char)
		#endregion

		#region Join(Sequence<Rune>, Char)
		#endregion

		#region Join(Sequence<String>, Char)
		#endregion

		#region Join(Sequence<Object>, Char)
		#endregion

		#region Join(Sequence<Char>, Rune)
		#endregion

		#region Join(Sequence<Rune>, Rune)
		#endregion

		#region Join(Sequence<String>, Rune)
		#endregion

		#region Join(Sequence<Object>, Rune)
		#endregion

		#region Join(Sequence<Char>, String)
		#endregion

		#region Join(Sequence<Rune>, String)
		#endregion

		#region Join(Sequence<String>, String)
		#endregion

		#region Join(Sequence<Object>, String)
		#endregion

		#region Join(Sequence<Char>, Object)
		#endregion

		#region Join(Sequence<Rune>, Object)
		#endregion

		#region Join(Sequence<String>, Object)
		#endregion

		#region Join(Sequence<Object>, Object)
		/// <summary>
		/// Joins the <paramref name="sequence"/> into a string.
		/// </summary>
		/// <param name="sequence">The sequence of objects to join.</param>
		/// <param name="separator">The separator object to separate each element of the <paramref name="sequence"/>.</param>
		/// <returns>The joined text.</returns>
		/// <remarks>
		/// This works by converting every object in the sequence to a string, then joining them together.
		/// </remarks>
		public static String Join(this Object[] sequence, Object separator) {
			Guard.NotNull(sequence, nameof(sequence));
			StringBuilder builder;
			IEnumerator enumerator = sequence.GetEnumerator();
			if (enumerator.MoveNext()) {
				builder = new StringBuilder();
				_ = builder.Append(enumerator.Current);
			} else {
				return String.Empty;
			}
			while (enumerator.MoveNext()) {
				_ = builder.Append(separator);
				_ = builder.Append(enumerator.Current);
			}
			return builder.ToString();
		}

		/// <summary>
		/// Joins the <paramref name="sequence"/> into a string.
		/// </summary>
		/// <param name="sequence">The sequence of objects to join.</param>
		/// <param name="separator">The separator object to separate each element of the <paramref name="sequence"/>.</param>
		/// <returns>The joined text.</returns>
		/// <remarks>
		/// This works by converting every object in the sequence to a string, then joining them together.
		/// </remarks>
		public static String Join(this IEnumerable sequence, Object separator) {
			Guard.NotNull(sequence, nameof(sequence));
			StringBuilder builder;
			IEnumerator enumerator = sequence.GetEnumerator();
			if (enumerator.MoveNext()) {
				 builder = new StringBuilder();
				_ = builder.Append(enumerator.Current);
			} else {
				return String.Empty;
			}
			while (enumerator.MoveNext()) {
				_ = builder.Append(separator);
				_ = builder.Append(enumerator.Current);
			}
			return builder.ToString();
		}

		/// <summary>
		/// Joins the <paramref name="sequence"/> into a string.
		/// </summary>
		/// <param name="sequence">The sequence of objects to join.</param>
		/// <param name="separator">The separator object to separate each element of the <paramref name="sequence"/>.</param>
		/// <returns>The joined text.</returns>
		/// <remarks>
		/// This works by converting every object in the sequence to a string, then joining them together.
		/// </remarks>
		public static String Join(this IEnumerable<Object> sequence, Object separator) {
			Guard.NotNull(sequence, nameof(sequence));
			StringBuilder builder;
			IEnumerator enumerator = sequence.GetEnumerator();
			if (enumerator.MoveNext()) {
				builder = new StringBuilder();
				_ = builder.Append(enumerator.Current);
			} else {
				return String.Empty;
			}
			while (enumerator.MoveNext()) {
				_ = builder.Append(separator);
				_ = builder.Append(enumerator.Current);
			}
			return builder.ToString();
		}
		#endregion
	}
}
