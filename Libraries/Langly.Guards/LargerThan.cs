using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Langly.Exceptions;

namespace Langly {
	public static partial class Guard {
		/// <summary>
		/// Guard against the argument being smaller than or equal to <paramref name="lower"/> bound.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="array">The array.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// 	<exception cref="ArgumentIsSizeException">Thrown if the guard clause fails because the size was equal to the bound.</exception>
		/// 	<exception cref="ArgumentSmallerThanException">Thrown if the guard clause fails because the size was smaller than the bound.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void LargerThan<T>(T[] array, String name, Int64 lower) {
			if (!(array is null) && array.Length <= lower) {
				if (array.Length == lower) {
					throw ArgumentIsSizeException.With(array, name, lower);
				} else {
					throw ArgumentSmallerThanException.With(array, name, lower);
				}
			}
		}

		/// <summary>
		/// Guard against the argument being smaller than or equal to <paramref name="lower"/> bound.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the span.</typeparam>
		/// <param name="span">The span.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// 	<exception cref="ArgumentIsSizeException">Thrown if the guard clause fails because the size was equal to the bound.</exception>
		/// 	<exception cref="ArgumentSmallerThanException">Thrown if the guard clause fails because the size was smaller than the bound.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void LargerThan<T>(Span<T> span, String name, Int64 lower) {
			if (span.Length <= lower) {
				if (span.Length == lower) {
					throw ArgumentIsSizeException.With(span, name, lower);
				} else {
					throw ArgumentSmallerThanException.With(span, name, lower);
				}
			}
		}

		/// <summary>
		/// Guard against the argument being smaller than or equal to <paramref name="lower"/> bound.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the span.</typeparam>
		/// <param name="span">The span.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// 	<exception cref="ArgumentIsSizeException">Thrown if the guard clause fails because the size was equal to the bound.</exception>
		/// 	<exception cref="ArgumentSmallerThanException">Thrown if the guard clause fails because the size was smaller than the bound.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void LargerThan<T>(ReadOnlySpan<T> span, String name, Int64 lower) {
			if (span.Length <= lower) {
				if (span.Length == lower) {
					throw ArgumentIsSizeException.With(span, name, lower);
				} else {
					throw ArgumentSmallerThanException.With(span, name, lower);
				}
			}
		}

		/// <summary>
		/// Guard against the argument being smaller than or equal to <paramref name="lower"/> bound.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the memory.</typeparam>
		/// <param name="memory">The memory.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// 	<exception cref="ArgumentIsSizeException">Thrown if the guard clause fails because the size was equal to the bound.</exception>
		/// 	<exception cref="ArgumentSmallerThanException">Thrown if the guard clause fails because the size was smaller than the bound.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void LargerThan<T>(Memory<T> memory, String name, Int64 lower) {
			if (memory.Length <= lower) {
				if (memory.Length == lower) {
					throw ArgumentIsSizeException.With(memory, name, lower);
				} else {
					throw ArgumentSmallerThanException.With(memory, name, lower);
				}
			}
		}

		/// <summary>
		/// Guard against the argument being smaller than or equal to <paramref name="lower"/> bound.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the memory.</typeparam>
		/// <param name="memory">The memory.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// 	<exception cref="ArgumentIsSizeException">Thrown if the guard clause fails because the size was equal to the bound.</exception>
		/// 	<exception cref="ArgumentSmallerThanException">Thrown if the guard clause fails because the size was smaller than the bound.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void LargerThan<T>(ReadOnlyMemory<T> memory, String name, Int64 lower) {
			if (memory.Length <= lower) {
				if (memory.Length == lower) {
					throw ArgumentIsSizeException.With(memory, name, lower);
				} else {
					throw ArgumentSmallerThanException.With(memory, name, lower);
				}
			}
		}

		/// <summary>
		/// Guard against the argument being smaller than or equal to <paramref name="lower"/> bound.
		/// </summary>
		/// <typeparam name="TCollection">The type of the argument; must be <see cref="ICollection"/>.</typeparam>
		/// <param name="collection">The collection.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// 	<exception cref="ArgumentIsSizeException">Thrown if the guard clause fails because the size was equal to the bound.</exception>
		/// 	<exception cref="ArgumentSmallerThanException">Thrown if the guard clause fails because the size was smaller than the bound.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void LargerThan<TCollection>(TCollection collection, String name, Int64 lower) where TCollection : ICollection {
			if (collection.Count <= lower) {
				if (collection.Count == lower) {
					throw ArgumentIsSizeException.With(collection, name, lower);
				} else {
					throw ArgumentIsSizeException.With(collection, name, lower);
				}
			}
		}

		/// <summary>
		/// Guard against the argument being smaller than or equal to <paramref name="lower"/> bound.
		/// </summary>
		/// <typeparam name="T">The type of the elements of <typeparamref name="TCollection"/>.</typeparam>
		/// <typeparam name="TCollection">The type of the argument; must be <see cref="ICollection{T}"/> of <typeparamref name="T"/>.</typeparam>
		/// <param name="collection">The collection.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// 	<exception cref="ArgumentIsSizeException">Thrown if the guard clause fails because the size was equal to the bound.</exception>
		/// 	<exception cref="ArgumentSmallerThanException">Thrown if the guard clause fails because the size was smaller than the bound.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void LargerThan<T, TCollection>(TCollection collection, String name, Int64 lower) where TCollection : ICollection<T> {
			if (collection.Count <= lower) {
				if (collection.Count == lower) {
					throw ArgumentIsSizeException.With(collection, name, lower);
				} else {
					throw ArgumentIsSizeException.With(collection, name, lower);
				}
			}
		}

		/// <summary>
		/// Guard against the argument being smaller than or equal to <paramref name="lower"/> bound.
		/// </summary>
		/// <param name="collection">The collection.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// 	<exception cref="ArgumentIsSizeException">Thrown if the guard clause fails because the size was equal to the bound.</exception>
		/// 	<exception cref="ArgumentSmallerThanException">Thrown if the guard clause fails because the size was smaller than the bound.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void LargerThan(ICount collection, String name, nint lower) {
			if (collection.Count <= lower) {
				if (collection.Count == lower) {
					throw ArgumentIsSizeException.With(collection, name, lower);
				} else {
					throw ArgumentIsSizeException.With(collection, name, lower);
				}
			}
		}
	}
}
