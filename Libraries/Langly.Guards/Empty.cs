using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Langly.Exceptions;

namespace Langly {
	public static partial class Guard {
		/// <summary>
		/// Guard against the string having characters.
		/// </summary>
		/// <param name="string">The string.</param>
		/// <param name="name">The name of the argument.</param>
		/// <exception cref="ArgumentNotEmptyException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Empty(String @string, String name) {
			if (@string is not null && @string.Length != 0) {
				throw ArgumentNotEmptyException.With(@string, name);
			}
		}

		/// <summary>
		/// Guard against the array having elements.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="array">The array.</param>
		/// <param name="name">The name of the argument.</param>
		/// <exception cref="ArgumentNotEmptyException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Empty<T>(T[] array, String name) {
			if (array is not null && array.Length != 0) {
				throw ArgumentNotEmptyException.With(array, name);
			}
		}

		/// <summary>
		/// Guard against the span having elements.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the span.</typeparam>
		/// <param name="span">The span.</param>
		/// <param name="name">The name of the argument.</param>
		/// <exception cref="ArgumentNotEmptyException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Empty<T>(Span<T> span, String name) {
			if (span.Length != 0) {
				throw ArgumentNotEmptyException.With(span, name);
			}
		}

		/// <summary>
		/// Guard against the span having elements.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the span.</typeparam>
		/// <param name="span">The span.</param>
		/// <param name="name">The name of the argument.</param>
		/// <exception cref="ArgumentNotEmptyException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Empty<T>(ReadOnlySpan<T> span, String name) {
			if (span.Length != 0) {
				throw ArgumentNotEmptyException.With(span, name);
			}
		}

		/// <summary>
		/// Guard against the memory having elements.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the memory.</typeparam>
		/// <param name="memory">The memory.</param>
		/// <param name="name">The name of the argument.</param>
		/// <exception cref="ArgumentNotEmptyException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Empty<T>(Memory<T> memory, String name) {
			if (memory.Length != 0) {
				throw ArgumentNotEmptyException.With(memory, name);
			}
		}

		/// <summary>
		/// Guard against the memory having elements.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the memory.</typeparam>
		/// <param name="memory">The memory.</param>
		/// <param name="name">The name of the argument.</param>
		/// <exception cref="ArgumentNotEmptyException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Empty<T>(ReadOnlyMemory<T> memory, String name) {
			if (memory.Length != 0) {
				throw ArgumentNotEmptyException.With(memory, name);
			}
		}

		/// <summary>
		/// Guard against the collection having elements.
		/// </summary>
		/// <typeparam name="TCollection">The type of the collection; must be <see cref="ICollection"/>.</typeparam>
		/// <param name="collection">The collection.</param>
		/// <param name="name">The name of the argument.</param>
		/// <exception cref="ArgumentNotEmptyException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Empty<TCollection>(TCollection collection, String name) where TCollection : ICollection {
			if (collection is not null && collection.Count != 0) {
				throw ArgumentNotEmptyException.With(collection, name);
			}
		}

		/// <summary>
		/// Guard against the collection having elements.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TCollection">The type of the collection; must be <see cref="IReadOnlyCollection{T}"/>.</typeparam>
		/// <param name="collection">The collection.</param>
		/// <param name="name">The name of the argument.</param>
		/// <exception cref="ArgumentNotEmptyException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Empty<T, TCollection>(TCollection collection, String name) where TCollection : IReadOnlyCollection<T> {
			if (collection is not null && collection.Count != 0) {
				throw ArgumentNotEmptyException.With(collection, name);
			}
		}

		/// <summary>
		/// Guard against the collection having elements.
		/// </summary>
		/// <param name="collection">The collection.</param>
		/// <param name="name">The name of the argument.</param>
		/// <exception cref="ArgumentNotEmptyException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Empty(ICount collection, String name) {
			if (collection is not null && collection.Count != 0) {
				throw ArgumentNotEmptyException.With(collection, name);
			}
		}
	}
}
