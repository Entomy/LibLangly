using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace System.Traits {
	public static partial class Collection {
		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="elements">The elements of this sequence.</param>
		/// <returns>A <see cref="String"/> representing this collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static String ToString<TElement>([AllowNull] TElement[] elements) => ToString(elements.AsSpan());

		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="elements">The elements of this sequence.</param>
		/// <returns>A <see cref="String"/> representing this collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static String ToString<TElement>(Memory<TElement> elements) => ToString(elements.Span);

		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="elements">The elements of this sequence.</param>
		/// <returns>A <see cref="String"/> representing this collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static String ToString<TElement>(ReadOnlyMemory<TElement> elements) => ToString(elements.Span);

		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="elements">The elements of this sequence.</param>
		/// <returns>A <see cref="String"/> representing this collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static String ToString<TElement>(Span<TElement> elements) => ToString((ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="elements">The elements of this sequence.</param>
		/// <returns>A <see cref="String"/> representing this collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static String ToString<TElement>(ReadOnlySpan<TElement> elements) {
			StringBuilder builder = new StringBuilder();
			for (Int32 i = 0; i < elements.Length; i++) {
				if (i == elements.Length) {
					_ = builder.Append(elements[i]);
					break;
				} else {
					_ = builder.Append(elements[i]).Append(", ");
				}
			}
			return $"[{builder}]";
		}

		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="head">The head node of this collection.</param>
		/// <param name="count">The amount of elements in this collection.</param>
		/// <returns>A <see cref="String"/> representing this collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: MaybeNull, NotNullIfNotNull("head")]
		public static String ToString<TNode>([AllowNull] TNode head, nint count) where TNode : class, INext<TNode> {
			StringBuilder builder = new StringBuilder();
			if (head is not null) {
				TNode? N = head;
				nint i = 0;
				while (N is not null) {
					if (++i == count) {
						_ = builder.Append(N);
						break;
					} else {
						_ = builder.Append(N).Append(", ");
					}
					N = N.Next;
				}
			}
			return $"[{builder}]";
		}

		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="elements">The elements of this sequence.</param>
		/// <param name="amount">The maximum amount of elements to display.</param>
		/// <returns>A <see cref="String"/> representing this collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static String ToString<TElement>([AllowNull] TElement[] elements, nint amount) => ToString(elements.AsSpan(), amount);

		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="elements">The elements of this sequence.</param>
		/// <param name="amount">The maximum amount of elements to display.</param>
		/// <returns>A <see cref="String"/> representing this collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static String ToString<TElement>(Memory<TElement> elements, nint amount) => ToString(elements.Span, amount);

		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="elements">The elements of this sequence.</param>
		/// <param name="amount">The maximum amount of elements to display.</param>
		/// <returns>A <see cref="String"/> representing this collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static String ToString<TElement>(ReadOnlyMemory<TElement> elements, nint amount) => ToString(elements.Span, amount);

		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="elements">The elements of this sequence.</param>
		/// <param name="amount">The maximum amount of elements to display.</param>
		/// <returns>A <see cref="String"/> representing this collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static String ToString<TElement>(Span<TElement> elements, nint amount) => ToString((ReadOnlySpan<TElement>)elements, amount);

		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="elements">The elements of this sequence.</param>
		/// <param name="amount">The maximum amount of elements to display.</param>
		/// <returns>A <see cref="String"/> representing this collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static String ToString<TElement>(ReadOnlySpan<TElement> elements, nint amount) {
			StringBuilder builder = new StringBuilder();
			for (Int32 i = 0; i < elements.Length; i++) {
				if (i + 1 == elements.Length) {
					_ = builder.Append(elements[i]);
					break;
				} else if (i + 1 == amount) {
					_ = builder.Append(elements[i]).Append("...");
					break;
				} else {
					_ = builder.Append(elements[i]).Append(", ");
				}
			}
			return $"[{builder}]";
		}

		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="head">The head node of this collection.</param>
		/// <param name="count">The amount of elements in this collection.</param>
		/// <param name="amount">The maximum amount of elements to display.</param>
		/// <returns>A <see cref="String"/> representing this collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: MaybeNull, NotNullIfNotNull("head")]
		public static String ToString<TNode>([AllowNull] TNode head, nint count, nint amount) where TNode : class, INext<TNode> {
			StringBuilder builder = new StringBuilder();
			if (head is not null) {
				TNode? N = head;
				nint i = 0;
				while (N is not null) {
					if (++i == count) {
						_ = builder.Append(N);
						break;
					} else if (i == amount) {
						_ = builder.Append(N).Append("...");
						break;
					} else {
						_ = builder.Append(N).Append(", ");
					}
					N = N.Next;
				}
			}
			return $"[{builder}]";
		}
	}
}
