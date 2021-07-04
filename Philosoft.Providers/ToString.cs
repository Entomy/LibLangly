using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace System.Traits.Concepts {
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
		/// <param name="indicies">The indicies of this sequence.</param>
		/// <param name="elements">The elements of this sequence.</param>
		/// <returns>A <see cref="String"/> representing this collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static String ToString<TIndex, TElement>([DisallowNull] TIndex[] indicies, [DisallowNull] TElement[] elements) => ToString(indicies.AsSpan(), elements.AsSpan());

		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="indicies">The indicies of this sequence.</param>
		/// <param name="elements">The elements of this sequence.</param>
		/// <returns>A <see cref="String"/> representing this collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static String ToString<TIndex, TElement>(Memory<TIndex> indicies, Memory<TElement> elements) => ToString(indicies.Span, elements.Span);

		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="indicies">The indicies of this sequence.</param>
		/// <param name="elements">The elements of this sequence.</param>
		/// <returns>A <see cref="String"/> representing this collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static String ToString<TIndex, TElement>(ReadOnlyMemory<TIndex> indicies, ReadOnlyMemory<TElement> elements) => ToString(indicies.Span, elements.Span);

		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="indicies">The indicies of this sequence.</param>
		/// <param name="elements">The elements of this sequence.</param>
		/// <returns>A <see cref="String"/> representing this collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static String ToString<TIndex, TElement>(Span<TIndex> indicies, Span<TElement> elements) => ToString((ReadOnlySpan<TIndex>)indicies, (ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="indicies">The indicies of this sequence.</param>
		/// <param name="elements">The elements of this sequence.</param>
		/// <returns>A <see cref="String"/> representing this collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static String ToString<TIndex, TElement>(ReadOnlySpan<TIndex> indicies, ReadOnlySpan<TElement> elements) {
			StringBuilder builder = new StringBuilder();
			for (Int32 i = 0; i < indicies.Length; i++) {
				if (i == indicies.Length) {
					_ = builder.Append(indicies[i]).Append(':').Append(elements[i]);
					break;
				} else {
					_ = builder.Append(indicies[i]).Append(':').Append(elements[i]).Append(", ");
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
		public static String ToString<TNode>([AllowNull] TNode head, Int32 count) where TNode : class, INext<TNode> {
			StringBuilder builder = new StringBuilder();
			if (head is not null) {
				TNode? N = head;
				Int32 i = 0;
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
		public static String ToString<TElement>([AllowNull] TElement[] elements, Int32 amount) => ToString(elements.AsSpan(), amount);

		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="elements">The elements of this sequence.</param>
		/// <param name="amount">The maximum amount of elements to display.</param>
		/// <returns>A <see cref="String"/> representing this collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static String ToString<TElement>(Memory<TElement> elements, Int32 amount) => ToString(elements.Span, amount);

		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="elements">The elements of this sequence.</param>
		/// <param name="amount">The maximum amount of elements to display.</param>
		/// <returns>A <see cref="String"/> representing this collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static String ToString<TElement>(ReadOnlyMemory<TElement> elements, Int32 amount) => ToString(elements.Span, amount);

		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="elements">The elements of this sequence.</param>
		/// <param name="amount">The maximum amount of elements to display.</param>
		/// <returns>A <see cref="String"/> representing this collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static String ToString<TElement>(Span<TElement> elements, Int32 amount) => ToString((ReadOnlySpan<TElement>)elements, amount);

		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="elements">The elements of this sequence.</param>
		/// <param name="amount">The maximum amount of elements to display.</param>
		/// <returns>A <see cref="String"/> representing this collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static String ToString<TElement>(ReadOnlySpan<TElement> elements, Int32 amount) {
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
		/// <param name="indicies">The indicies of this sequence.</param>
		/// <param name="elements">The elements of this sequence.</param>
		/// <param name="amount">The maximum amount of elements to display.</param>
		/// <returns>A <see cref="String"/> representing this collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static String ToString<TIndex, TElement>([DisallowNull] TIndex[] indicies, [DisallowNull] TElement[] elements, Int32 amount) => ToString(indicies.AsSpan(), elements.AsSpan(), amount);

		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="indicies">The indicies of this sequence.</param>
		/// <param name="elements">The elements of this sequence.</param>
		/// <param name="amount">The maximum amount of elements to display.</param>
		/// <returns>A <see cref="String"/> representing this collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static String ToString<TIndex, TElement>(Memory<TIndex> indicies, Memory<TElement> elements, Int32 amount) => ToString(indicies.Span, elements.Span, amount);

		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="indicies">The indicies of this sequence.</param>
		/// <param name="elements">The elements of this sequence.</param>
		/// <param name="amount">The maximum amount of elements to display.</param>
		/// <returns>A <see cref="String"/> representing this collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static String ToString<TIndex, TElement>(ReadOnlyMemory<TIndex> indicies, ReadOnlyMemory<TElement> elements, Int32 amount) => ToString(indicies.Span, elements.Span, amount);

		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="indicies">The indicies of this sequence.</param>
		/// <param name="elements">The elements of this sequence.</param>
		/// <param name="amount">The maximum amount of elements to display.</param>
		/// <returns>A <see cref="String"/> representing this collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static String ToString<TIndex, TElement>(Span<TIndex> indicies, Span<TElement> elements, Int32 amount) => ToString((ReadOnlySpan<TIndex>)indicies, (ReadOnlySpan<TElement>)elements, amount);

		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="indicies">The indicies of this sequence.</param>
		/// <param name="elements">The elements of this sequence.</param>
		/// <param name="amount">The maximum amount of elements to display.</param>
		/// <returns>A <see cref="String"/> representing this collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static String ToString<TIndex, TElement>(ReadOnlySpan<TIndex> indicies, ReadOnlySpan<TElement> elements, Int32 amount) {
			StringBuilder builder = new StringBuilder();
			for (Int32 i = 0; i < indicies.Length; i++) {
				if (i + 1 == indicies.Length) {
					_ = builder.Append(indicies[i]).Append(':').Append(elements[i]);
					break;
				} else if (i + 1 == amount) {
					_ = builder.Append(indicies[i]).Append(':').Append(elements[i]).Append("...");
					break;
				} else {
					_ = builder.Append(indicies[i]).Append(':').Append(elements[i]).Append(", ");
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
		public static String ToString<TNode>([AllowNull] TNode head, Int32 count, Int32 amount) where TNode : class, INext<TNode> {
			StringBuilder builder = new StringBuilder();
			if (head is not null) {
				TNode? N = head;
				Int32 i = 0;
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
