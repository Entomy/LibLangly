using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Langly.Exceptions;

namespace Langly {
	public static partial class Guard {
		/// <summary>
		/// Guard against the string being empty.
		/// </summary>
		/// <param name="string">The string.</param>
		/// <param name="name">The name of the argument.</param>
		/// <exception cref="ArgumentEmptyException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NotEmpty(String @string, String name) {
			if (@string is null || @string.Length == 0) {
				throw ArgumentEmptyException.With(@string, name);
			}
		}

		/// <summary>
		/// Guard against the array being empty.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="array">The array.</param>
		/// <param name="name">The name of the argument.</param>
		/// <exception cref="ArgumentEmptyException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NotEmpty<T>(T[] array, String name) {
			if (array is null || array.Length == 0) {
				throw ArgumentEmptyException.With(array, name);
			}
		}

		/// <summary>
		/// Guard against the span being empty.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the span.</typeparam>
		/// <param name="span">The span.</param>
		/// <param name="name">The name of the argument.</param>
		/// <exception cref="ArgumentEmptyException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NotEmpty<T>(Span<T> span, String name) {
			if (span.Length == 0) {
				throw ArgumentEmptyException.With(span, name);
			}
		}

		/// <summary>
		/// Guard against the span being empty.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the span.</typeparam>
		/// <param name="span">The span.</param>
		/// <param name="name">The name of the argument.</param>
		/// <exception cref="ArgumentEmptyException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NotEmpty<T>(ReadOnlySpan<T> span, String name) {
			if (span.Length == 0) {
				throw ArgumentEmptyException.With(span, name);
			}
		}

		/// <summary>
		/// Guard against the memory being empty.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the memory.</typeparam>
		/// <param name="memory">The memory.</param>
		/// <param name="name">The name of the argument.</param>
		/// <exception cref="ArgumentEmptyException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NotEmpty<T>(Memory<T> memory, String name) {
			if (memory.Length == 0) {
				throw ArgumentEmptyException.With(memory, name);
			}
		}

		/// <summary>
		/// Guard against the memory being empty.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the memory.</typeparam>
		/// <param name="memory">The memory.</param>
		/// <param name="name">The name of the argument.</param>
		/// <exception cref="ArgumentEmptyException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NotEmpty<T>(ReadOnlyMemory<T> memory, String name) {
			if (memory.Length == 0) {
				throw ArgumentEmptyException.With(memory, name);
			}
		}

		/// <summary>
		/// Guard against the collection being empty.
		/// </summary>
		/// <typeparam name="TCollection">The type of the collection; must be <see cref="ICollection"/>.</typeparam>
		/// <param name="collection">The collection.</param>
		/// <param name="name">The name of the argument.</param>
		/// <exception cref="ArgumentEmptyException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NotEmpty<TCollection>(TCollection collection, String name) where TCollection : ICollection {
			if (collection is null || collection.Count == 0) {
				throw ArgumentEmptyException.With(collection, name);
			}
		}

		/// <summary>
		/// Guard against the collection being empty.
		/// </summary>
		/// <typeparam name="TCollection">The type of the collection; must be <see cref="ICollection{T}"/>.</typeparam>
		/// <typeparam name="T">The type of the elements in the collection.</typeparam>
		/// <param name="collection">The collection.</param>
		/// <param name="name">The name of the argument.</param>
		/// <exception cref="ArgumentEmptyException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NotEmpty<T, TCollection>(TCollection collection, String name) where TCollection : ICollection<T> {
			if (collection is null || collection.Count == 0) {
				throw ArgumentEmptyException.With(collection, name);
			}
		}

		/// <summary>
		/// Guard against the collection being empty.
		/// </summary>
		/// <param name="collection">The collection.</param>
		/// <param name="name">The name of the argument.</param>
		/// <exception cref="ArgumentEmptyException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NotEmpty(ICount collection, String name) {
			if (collection is null || collection.Count == 0) {
				throw ArgumentEmptyException.With(collection, name);
			}
		}
	}
}
