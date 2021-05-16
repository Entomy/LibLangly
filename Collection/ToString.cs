using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;
using System.Traits;

namespace Langly {
	internal static partial class Collection {
		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="sequence">The sequence to convert.</param>
		/// <returns>A <see cref="String"/> representing the <paramref name="sequence"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: MaybeNull, NotNullIfNotNull("sequence")]
		public static String ToString<TEnumerator>([DisallowNull] ISequence<Char, TEnumerator> sequence) where TEnumerator : IEnumerator<Char> {
			StringBuilder builder = new StringBuilder();
			foreach (Char element in sequence) {
				_ = builder.Append(element);
			}
			return $"{builder}";
		}

		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="sequence">The sequence to convert.</param>
		/// <returns>A <see cref="String"/> representing the <paramref name="sequence"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: MaybeNull, NotNullIfNotNull("sequence")]
		public static String ToString<TElement, TEnumerator>([DisallowNull] ISequence<TElement, TEnumerator> sequence) where TEnumerator : IEnumerator<TElement> {
			StringBuilder builder = new StringBuilder();
			nint i = 0;
			foreach (TElement element in sequence) {
				if (++i == sequence.Count) {
					_ = builder.Append(element);
					break;
				} else {
					_ = builder.Append(element).Append(", ");
				}
			}
			return $"[{builder}]";
		}

		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="sequence">The sequence to convert.</param>
		/// <param name="amount">The maximum amount of elements to display.</param>
		/// <returns>A <see cref="String"/> representing the <paramref name="sequence"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: MaybeNull, NotNullIfNotNull("sequence")]
		public static String ToString<TEnumerator>([DisallowNull] ISequence<Char, TEnumerator> sequence, nint amount) where TEnumerator : IEnumerator<Char> {
			StringBuilder builder = new StringBuilder();
			nint i = 0;
			foreach (Char element in sequence) {
				if (++i == sequence.Count) {
					_ = builder.Append(element);
					break;
				} else if (i == amount) {
					_ = builder.Append(element).Append("...");
					break;
				} else {
					_ = builder.Append(element);
				}
			}
			return $"{builder}";
		}

		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="sequence">The sequence to convert.</param>
		/// <param name="amount">The maximum amount of elements to display.</param>
		/// <returns>A <see cref="String"/> representing the <paramref name="sequence"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: MaybeNull, NotNullIfNotNull("sequence")]
		public static String ToString<TElement, TEnumerator>([DisallowNull] ISequence<TElement, TEnumerator> sequence, nint amount) where TEnumerator : IEnumerator<TElement> {
			StringBuilder builder = new StringBuilder();
			nint i = 0;
			foreach (TElement element in sequence) {
				if (++i == sequence.Count) {
					_ = builder.Append(element);
					break;
				} else if (i == amount) {
					_ = builder.Append(element).Append("...");
					break;
				} else {
					_ = builder.Append(element).Append(", ");
				}
			}
			return $"[{builder}]";
		}
	}
}
