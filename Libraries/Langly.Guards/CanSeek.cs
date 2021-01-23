using System;
using System.IO;
using System.Runtime.CompilerServices;
using Langly.Exceptions;

namespace Langly {
	public static partial class Guard {
		/// <summary>
		/// Guard against the stream being unseekable.
		/// </summary>
		/// <param name="stream">The <see cref="Stream"/> object.</param>
		/// <param name="name">The name of the argument.</param>
		/// <exception cref="ArgumentNotSeekableException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void CanSeek(Stream stream, String name) {
			if (stream?.CanSeek != true) {
				throw ArgumentNotSeekableException.With(stream, name);
			}
		}

		/// <summary>
		/// Guard against the stream being unseekable.
		/// </summary>
		/// <typeparam name="TElement">The type of element being streamed.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="stream">The <see cref="IRead{TElement, TError}"/> object.</param>
		/// <param name="name">The name of the argument.</param>
		/// <exception cref="ArgumentNotSeekableException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void CanSeek<TElement, TError>(ISeek<TElement, TError> stream, String name) {
			if (stream?.Seekable != true) {
				throw ArgumentNotSeekableException.With(stream, name);
			}
		}
	}
}
