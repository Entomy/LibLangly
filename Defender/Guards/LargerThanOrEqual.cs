﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Defender.Exceptions;

namespace Defender {
	public static partial class Guard {
		/// <summary>
		/// Guard against the argument being smaller than <paramref name="lower"/> bound.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the array.</typeparam>
		/// <param name="array">The array.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// 	<exception cref="ArgumentSmallerThanException">Thrown if the guard clause fails because the size was smaller than the bound.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void LargerThanOrEqual<T>(T[] array, String name, Int64 lower) {
			if (array is null || array.Length < lower) {
				throw ArgumentSmallerThanException.With(array, name, lower);
			}
		}

		/// <summary>
		/// Guard against the argument being smaller than <paramref name="lower"/> bound.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the span.</typeparam>
		/// <param name="span">The span.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// 	<exception cref="ArgumentSmallerThanException">Thrown if the guard clause fails because the size was smaller than the bound.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void LargerThanOrEqual<T>(Span<T> span, String name, Int64 lower) {
			if (span.Length < lower) {
				throw ArgumentSmallerThanException.With(span, name, lower);
			}
		}

		/// <summary>
		/// Guard against the argument being smaller than <paramref name="lower"/> bound.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the span.</typeparam>
		/// <param name="span">The span.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// 	<exception cref="ArgumentSmallerThanException">Thrown if the guard clause fails because the size was smaller than the bound.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void LargerThanOrEqual<T>(ReadOnlySpan<T> span, String name, Int64 lower) {
			if (span.Length < lower) {
				throw ArgumentSmallerThanException.With(span, name, lower);
			}
		}

		/// <summary>
		/// Guard against the argument being smaller than <paramref name="lower"/> bound.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the memory.</typeparam>
		/// <param name="memory">The memory.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// 	<exception cref="ArgumentSmallerThanException">Thrown if the guard clause fails because the size was smaller than the bound.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void LargerThanOrEqual<T>(Memory<T> memory, String name, Int64 lower) {
			if (memory.Length < lower) {
				throw ArgumentSmallerThanException.With(memory, name, lower);
			}
		}

		/// <summary>
		/// Guard against the argument being smaller than <paramref name="lower"/> bound.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the memory.</typeparam>
		/// <param name="memory">The memory.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// 	<exception cref="ArgumentSmallerThanException">Thrown if the guard clause fails because the size was smaller than the bound.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void LargerThanOrEqual<T>(ReadOnlyMemory<T> memory, String name, Int64 lower) {
			if (memory.Length < lower) {
				throw ArgumentSmallerThanException.With(memory, name, lower);
			}
		}

		/// <summary>
		/// Guard against the argument being smaller than <paramref name="lower"/> bound.
		/// </summary>
		/// <typeparam name="TCollection">The type of the argument; must be <see cref="ICollection"/>.</typeparam>
		/// <param name="collection">The collection.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// 	<exception cref="ArgumentSmallerThanException">Thrown if the guard clause fails because the size was smaller than the bound.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void LargerThanOrEqual<TCollection>(TCollection collection, String name, Int64 lower) where TCollection : ICollection {
			if (collection is null || collection.Count < lower) {
				throw ArgumentSmallerThanException.With(collection, name, lower);
			}
		}

		/// <summary>
		/// Guard against the argument being smaller than or equal to <paramref name="lower"/> bound.
		/// </summary>
		/// <typeparam name="TCollection">The type of the argument; must be <see cref="ICollection{T}"/> of <typeparamref name="T"/>.</typeparam>
		/// <typeparam name="T">The type of the elements of <typeparamref name="TCollection"/>.</typeparam>
		/// <param name="collection">The collection.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// 	<exception cref="ArgumentSmallerThanException">Thrown if the guard clause fails because the size was smaller than the bound.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void LargerThanOrEqual<T, TCollection>(TCollection collection, String name, Int64 lower) where TCollection : ICollection<T> {
			if (collection is null || collection.Count < lower) {
				throw ArgumentSmallerThanException.With(collection, name, lower);
			}
		}
	}
}