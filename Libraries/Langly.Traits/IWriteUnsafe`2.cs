using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can be written to, with additional unsafe operations.
	/// </summary>
	/// <typeparam name="TElement">The type of the element to write.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	[CLSCompliant(false)]
	public interface IWriteUnsafe<TElement, out TResult> : IWrite<TElement, TResult> where TElement : unmanaged where TResult : IWriteUnsafe<TElement, TResult> {
		/// <inheritdoc/>
		[return: MaybeNull]
		unsafe TResult IWrite<TElement, TResult>.Write(ReadOnlySpan<TElement> elements) {
			TResult result = (TResult)this;
			fixed (TElement* elmts = elements) {
				result = result.Write(elmts, elements.Length);
			}
			return result;
		}

		/// <summary>
		/// Writes the <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">A pointer to the <typeparamref name="TElement"/> values to write.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		unsafe TResult Write([AllowNull] TElement* elements, Int32 length) {
			TResult result = (TResult)this;
			if (elements != null) {
				for (Int32 i = 0; i < length; i++) {
					result = result.Write(elements[i]);
					if (result is null) {
						goto Result;
					}
				}
			}
		Result:
			return result;
		}
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Writes the <paramref name="elements"/> to the <paramref name="stream"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TResult">The type of the error object.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="elements">A pointer to the <see cref="Char"/> values to write.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[CLSCompliant(false)]
		[return: MaybeNull]
		public static unsafe TResult Write<TElement, TResult>([AllowNull] this IWriteUnsafe<TElement, TResult> stream, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged where TResult : IWriteUnsafe<TElement, TResult> => stream is not null ? stream.Write(elements, length) : (TResult)stream;

		/// <summary>
		/// Writes the <paramref name="elements"/> and a line terminator to the <paramref name="stream"/>.
		/// </summary>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="elements">The text to write.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[CLSCompliant(false)]
		[return: MaybeNull]
		public static unsafe TResult WriteLine<TResult>([AllowNull] this IWriteUnsafe<Char, TResult> stream, [AllowNull] Char* elements, Int32 length) where TResult : IWriteText<TResult>, IWriteUnsafe<Char, TResult> => stream is not null ? stream.Write(elements, length).WriteLine() : (TResult)stream;
	}
}
