using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Langly {
	public static partial class Guard {
		/// <summary>
		/// Guard against the argument being larger than <paramref name="upper"/> bound.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="array">The array.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="upper">The upper bound.</param>
		/// <exception cref="ArgumentLargerThanException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SmallerThanOrEqual<T>(T[] array, String name, Int64 upper) {
			if (array.Length > upper) {
				throw ArgumentLargerThanException.With(array, name, upper);
			}
		}

		/// <summary>
		/// Guard against the argument being larger than <paramref name="upper"/> bound.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the span.</typeparam>
		/// <param name="span">The span.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="upper">The upper bound.</param>
		/// <exception cref="ArgumentLargerThanException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SmallerThanOrEqual<T>(Span<T> span, String name, Int64 upper) {
			if (span.Length > upper) {
				throw ArgumentLargerThanException.With(span, name, upper);
			}
		}

		/// <summary>
		/// Guard against the argument being larger than <paramref name="upper"/> bound.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the span.</typeparam>
		/// <param name="span">The span.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="upper">The upper bound.</param>
		/// <exception cref="ArgumentLargerThanException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SmallerThanOrEqual<T>(ReadOnlySpan<T> span, String name, Int64 upper) {
			if (span.Length > upper) {
				throw ArgumentLargerThanException.With(span, name, upper);
			}
		}

		/// <summary>
		/// Guard against the argument being larger than <paramref name="upper"/> bound.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the memory.</typeparam>
		/// <param name="memory">The memory.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="upper">The upper bound.</param>
		/// <exception cref="ArgumentLargerThanException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SmallerThanOrEqual<T>(Memory<T> memory, String name, Int64 upper) {
			if (memory.Length > upper) {
				throw ArgumentLargerThanException.With(memory, name, upper);
			}
		}

		/// <summary>
		/// Guard against the argument being larger than <paramref name="upper"/> bound.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the memory.</typeparam>
		/// <param name="memory">The memory.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="upper">The upper bound.</param>
		/// <exception cref="ArgumentLargerThanException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SmallerThanOrEqual<T>(ReadOnlyMemory<T> memory, String name, Int64 upper) {
			if (memory.Length > upper) {
				throw ArgumentLargerThanException.With(memory, name, upper);
			}
		}

		/// <summary>
		/// Guard against the argument being larger than <paramref name="upper"/> bound.
		/// </summary>
		/// <typeparam name="TCollection">The type of the argument; must be <see cref="ICollection"/>.</typeparam>
		/// <param name="collection">The collection.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="upper">The upper bound.</param>
		/// <exception cref="ArgumentLargerThanException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SmallerThanOrEqual<TCollection>(TCollection collection, String name, Int64 upper) where TCollection : ICollection {
			if (collection.Count > upper) {
				throw ArgumentLargerThanException.With(collection, name, upper);
			}
		}

		/// <summary>
		/// Guard against the argument being larger than <paramref name="upper"/> bound.
		/// </summary>
		/// <typeparam name="TCollection">The type of the argument; must be <see cref="ICollection{T}"/> of <typeparamref name="T"/>.</typeparam>
		/// <typeparam name="T">The type of the elements of <typeparamref name="TCollection"/>.</typeparam>
		/// <param name="collection">The collection.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="upper">The upper bound.</param>
		/// <exception cref="ArgumentLargerThanException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SmallerThanOrEqual<T, TCollection>(TCollection collection, String name, Int64 upper) where TCollection : ICollection<T> {
			if (collection.Count > upper) {
				throw ArgumentLargerThanException.With(collection, name, upper);
			}
		}
	}
}
