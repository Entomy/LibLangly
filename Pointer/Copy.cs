using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	internal static partial class Pointer {
		/// <summary>
		/// Copies a range of elements from one pointer to another pointer.
		/// </summary>
		/// <param name="source">The pointer that contains the data to copy.</param>
		/// <param name="destination">The pointer that receives the data.</param>
		/// <param name="length">A 32-bit integer that represents the number of elements to copy.</param>
		/// <exception cref="ArgumentNullException"><paramref name="destination"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="length"/> is less than zero.</exception>
		public static unsafe void Copy<T>([AllowNull] T* source, Int32 length, [AllowNull] T[] destination) where T : unmanaged {
			if (destination is null) {
				throw new ArgumentNullException(nameof(destination), "The destination is null.");
			} else {
				Copy(source, length, destination.AsSpan());
			}
		}

		/// <summary>
		/// Copies a range of elements from one pointer to another pointer.
		/// </summary>
		/// <param name="source">The pointer that contains the data to copy.</param>
		/// <param name="destination">The pointer that receives the data.</param>
		/// <param name="length">A 32-bit integer that represents the number of elements to copy.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="length"/> is less than zero.</exception>
		public static unsafe void Copy<T>([AllowNull] T* source, Int32 length, Memory<T> destination) where T : unmanaged => Copy(source, length, destination.Span);

		/// <summary>
		/// Copies a range of elements from one pointer to another pointer.
		/// </summary>
		/// <param name="source">The pointer that contains the data to copy.</param>
		/// <param name="destination">The pointer that receives the data.</param>
		/// <param name="length">A 32-bit integer that represents the number of elements to copy.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="length"/> is less than zero.</exception>
		public static unsafe void Copy<T>([AllowNull] T* source, Int32 length, Span<T> destination) where T : unmanaged {
			if (length < 0) {
				throw new ArgumentOutOfRangeException(nameof(length), "Length is less than zero.");
			} else if (source is not null) {
				for (Int32 i = 0; i < length; i++) {
					destination[i] = source[i];
				}
			}
		}

		/// <summary>
		/// Copies a range of elements from one pointer to another pointer.
		/// </summary>
		/// <param name="source">The pointer that contains the data to copy.</param>
		/// <param name="destination">The pointer that receives the data.</param>
		/// <param name="length">A 32-bit integer that represents the number of elements to copy.</param>
		/// <exception cref="ArgumentNullException"><paramref name="destination"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="length"/> is less than zero.</exception>
		public static unsafe void Copy<T>([AllowNull] T* source, [DisallowNull] T* destination, Int32 length) where T : unmanaged {
			if (destination is null) {
				throw new ArgumentNullException(nameof(destination), "Destination is null.");
			} else {
				Copy(source, length, new Span<T>(destination, length));
			}
		}
	}
}
