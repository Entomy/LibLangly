using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Reads until the <paramref name="elements"/> is filled.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The <see cref="Array"/> of <typeparamref name="TElement"/> to fill.</param>
		public static void Read<TElement>([DisallowNull] this IRead<TElement> collection, [AllowNull] TElement[] elements) => Read(collection, elements.AsSpan());

		/// <summary>
		/// Reads until the <paramref name="elements"/> is filled.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The <see cref="Memory{T}"/> of <typeparamref name="TElement"/> to fill.</param>
		public static void Read<TElement>([DisallowNull] this IRead<TElement> collection, Memory<TElement> elements) => Read(collection, elements.Span);

		/// <summary>
		/// Reads <paramref name="amount"/> of <typeparamref name="TElement"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of elements to read.</param>
		/// <param name="elements">The <typeparamref name="TElement"/> values that were read.</param>
		public static void Read<TElement>([DisallowNull] this IRead<TElement> collection, nint amount, out ReadOnlyMemory<TElement> elements) {
			Memory<TElement> buffer = new TElement[amount];
			Int32 i = 0;
			for (; i < amount; i++) {
				collection.Read(out buffer.Span[i]);
			}
			elements = buffer.Slice(0, i);
		}

		/// <summary>
		/// Reads until the <paramref name="elements"/> is filled.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The <see cref="Span{T}"/> of <typeparamref name="TElement"/> to fill.</param>
		public static void Read<TElement>([DisallowNull] this IRead<TElement> collection, Span<TElement> elements) {
			for (Int32 i = 0; i < elements.Length; i++) {
				collection.Read(out elements[i]);
			}
		}

		/// <summary>
		/// Reads <paramref name="amount"/> of <typeparamref name="TElement"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of elements to read.</param>
		/// <param name="elements">The <typeparamref name="TElement"/> values that were read.</param>
		public static void Read<TElement>([DisallowNull] this IRead<TElement> collection, nint amount, out ReadOnlySpan<TElement> elements) {
			Read(collection, amount, out ReadOnlyMemory<TElement> elmts);
			elements = elmts.Span;
		}

		/// <summary>
		/// Reads until the <paramref name="elements"/> is filled.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The pointer of <typeparamref name="TElement"/> to fill.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		[CLSCompliant(false)]
		public static unsafe void Read<TElement>([DisallowNull] this IRead<TElement> collection, [DisallowNull] TElement* elements, Int32 length) where TElement : unmanaged {
			for (Int32 i = 0; i < length; i++) {
				collection.Read(out elements[i]);
			}
		}
	}
}
