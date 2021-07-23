using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace System.Traits.Providers {
	public static partial class Collection {
		/// <summary>
		/// Returns a string that represents this sequence.
		/// </summary>
		/// <param name="elements">The elements of this sequence.</param>
		/// <returns>A <see cref="String"/> representing this collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static String ToString<TElement>(TElement[] elements) {
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
		public static String ToString<TIndex, TElement>(TIndex[] indicies, TElement[] elements) where TIndex : notnull {
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
		public static String ToString<TNode>(TNode? head, Int32 count) where TNode : class, INext<TNode?> {
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
		public static String ToString<TElement>(TElement[] elements, Int32 amount) {
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
		public static String ToString<TIndex, TElement>(TIndex[] indicies, TElement[] elements, Int32 amount) where TIndex : notnull {
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
		[return: NotNull]
		public static String ToString<TNode>(TNode? head, Int32 count, Int32 amount) where TNode : class, INext<TNode?> {
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
