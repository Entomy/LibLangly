using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Langly {
	public static partial class Guard {
		/// <summary>
		/// Guard against the argument being larger than or equal to <paramref name="upper"/> bound.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="array">The array.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="upper">The upper bound.</param>
		/// 	<exception cref="ArgumentIsSizeException">Thrown if the guard clause fails because the size was equal to the bound.</exception>
		/// 	<exception cref="ArgumentLargerThanException">Thrown if the guard clause fails because the size was larger than the bound.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SmallerThan<T>(T[] array, String name, Int64 upper) {
			if (!(array is null) && array.Length >= upper) {
				if (array.Length == upper) {
					throw ArgumentIsSizeException.With(array, name, upper);
				} else {
					throw ArgumentLargerThanException.With(array, name, upper);
				}
			}
		}

		/// <summary>
		/// Guard against the argument being larger than <paramref name="upper"/> bound.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the span.</typeparam>
		/// <param name="span">The span.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="upper">The upper bound.</param>
		/// 	<exception cref="ArgumentIsSizeException">Thrown if the guard clause fails because the size was equal to the bound.</exception>
		/// 	<exception cref="ArgumentLargerThanException">Thrown if the guard clause fails because the size was larger than the bound.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SmallerThan<T>(Span<T> span, String name, Int64 upper) {
			if (span.Length >= upper) {
				if (span.Length == upper) {
					throw ArgumentIsSizeException.With(span, name, upper);
				} else {
					throw ArgumentLargerThanException.With(span, name, upper);
				}
			}
		}

		/// <summary>
		/// Guard against the argument being larger than <paramref name="upper"/> bound.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the span.</typeparam>
		/// <param name="span">The span.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="upper">The upper bound.</param>
		/// 	<exception cref="ArgumentIsSizeException">Thrown if the guard clause fails because the size was equal to the bound.</exception>
		/// 	<exception cref="ArgumentLargerThanException">Thrown if the guard clause fails because the size was larger than the bound.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SmallerThan<T>(ReadOnlySpan<T> span, String name, Int64 upper) {
			if (span.Length >= upper) {
				if (span.Length == upper) {
					throw ArgumentIsSizeException.With(span, name, upper);
				} else {
					throw ArgumentLargerThanException.With(span, name, upper);
				}
			}
		}

		/// <summary>
		/// Guard against the argument being larger than <paramref name="upper"/> bound.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the memory.</typeparam>
		/// <param name="memory">The memory.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="upper">The upper bound.</param>
		/// 	<exception cref="ArgumentIsSizeException">Thrown if the guard clause fails because the size was equal to the bound.</exception>
		/// 	<exception cref="ArgumentLargerThanException">Thrown if the guard clause fails because the size was larger than the bound.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SmallerThan<T>(Memory<T> memory, String name, Int64 upper) {
			if (memory.Length >= upper) {
				if (memory.Length == upper) {
					throw ArgumentIsSizeException.With(memory, name, upper);
				} else {
					throw ArgumentLargerThanException.With(memory, name, upper);
				}
			}
		}

		/// <summary>
		/// Guard against the argument being larger than <paramref name="upper"/> bound.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the memory.</typeparam>
		/// <param name="memory">The memory.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="upper">The upper bound.</param>
		/// 	<exception cref="ArgumentIsSizeException">Thrown if the guard clause fails because the size was equal to the bound.</exception>
		/// 	<exception cref="ArgumentLargerThanException">Thrown if the guard clause fails because the size was larger than the bound.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SmallerThan<T>(ReadOnlyMemory<T> memory, String name, Int64 upper) {
			if (memory.Length >= upper) {
				if (memory.Length == upper) {
					throw ArgumentIsSizeException.With(memory, name, upper);
				} else {
					throw ArgumentLargerThanException.With(memory, name, upper);
				}
			}
		}

		/// <summary>
		/// Guard against the argument being larger than or equal to <paramref name="upper"/> bound.
		/// </summary>
		/// <typeparam name="TCollection">The type of the argument; must be <see cref="ICollection"/>.</typeparam>
		/// <param name="collection">The collection.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="upper">The upper bound.</param>
		/// 	<exception cref="ArgumentIsSizeException">Thrown if the guard clause fails because the size was equal to the bound.</exception>
		/// 	<exception cref="ArgumentLargerThanException">Thrown if the guard clause fails because the size was larger than the bound.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SmallerThan<TCollection>(TCollection collection, String name, Int64 upper) where TCollection : ICollection {
			if (!(collection is null) && collection.Count >= upper) {
				if (collection.Count == upper) {
					throw ArgumentIsSizeException.With(collection, name, upper);
				} else {
					throw ArgumentLargerThanException.With(collection, name, upper);
				}
			}
		}

		/// <summary>
		/// Guard against the argument being larger than or equal to <paramref name="upper"/> bound.
		/// </summary>
		/// <typeparam name="TCollection">The type of the argument; must be <see cref="ICollection{T}"/> of <typeparamref name="T"/>.</typeparam>
		/// <typeparam name="T">The type of the elements of <typeparamref name="TCollection"/>.</typeparam>
		/// <param name="collection">The collection.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="upper">The upper bound.</param>
		/// 	<exception cref="ArgumentIsSizeException">Thrown if the guard clause fails because the size was equal to the bound.</exception>
		/// 	<exception cref="ArgumentLargerThanException">Thrown if the guard clause fails because the size was larger than the bound.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SmallerThan<T, TCollection>(TCollection collection, String name, Int64 upper) where TCollection : ICollection<T> {
			if (!(collection is null) && collection.Count >= upper) {
				if (collection.Count == upper) {
					throw ArgumentIsSizeException.With(collection, name, upper);
				} else {
					throw ArgumentLargerThanException.With(collection, name, upper);
				}
			}
		}

		/// <summary>
		/// Guard against the argument being larger than or equal to <paramref name="upper"/> bound.
		/// </summary>
		/// <param name="collection">The collection.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="upper">The upper bound.</param>
		/// 	<exception cref="ArgumentIsSizeException">Thrown if the guard clause fails because the size was equal to the bound.</exception>
		/// 	<exception cref="ArgumentLargerThanException">Thrown if the guard clause fails because the size was larger than the bound.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SmallerThan(ICountable collection, String name, nint upper) {
			if (!(collection is null) && collection.Count >= upper) {
				if (collection.Count == upper) {
					throw ArgumentIsSizeException.With(collection, name, upper);
				} else {
					throw ArgumentLargerThanException.With(collection, name, upper);
				}
			}
		}
	}
}
