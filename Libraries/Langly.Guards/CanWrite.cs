using System;
using System.IO;
using System.Runtime.CompilerServices;
using Langly.Exceptions;

namespace Langly {
	public static partial class Guard {
		/// <summary>
		/// Guard against the stream being unwritable.
		/// </summary>
		/// <param name="stream">The <see cref="Stream"/> object.</param>
		/// <param name="name">The name of the argument.</param>
		/// <exception cref="ArgumentNotWritableException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void CanWrite(Stream stream, String name) {
			if (stream?.CanWrite != true) {
				throw ArgumentNotWritableException.With(stream, name);
			}
		}

		/// <summary>
		/// Guard against the stream being unwritable.
		/// </summary>
		/// <typeparam name="TElement">The type of element being streamed.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="stream">The <see cref="IWrite{TElement, TError}"/> object.</param>
		/// <param name="name">The name of the argument.</param>
		/// <exception cref="ArgumentNotWritableException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void CanWrite<TElement, TError>(IWrite<TElement, TError> stream, String name) {
			if (stream?.Writable != true) {
				throw ArgumentNotWritableException.With(stream, name);
			}
		}
	}
}
