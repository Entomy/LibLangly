using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Defender.Exceptions;

namespace Defender {
	public static partial class Guard {
		/// <summary>
		/// Guard against the collection not containing a particular value.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the collection.</typeparam>
		/// <param name="collection">The collection.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="value">The value to look for.</param>
		/// <exception cref="ArgumentNotContainsException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Contains<T>(T[] collection, String name, T value) where T : IEquatable<T> {
			if (collection is null) {
				goto Throw;
			}
			foreach (T item in collection) {
				if (item.Equals(value)) {
					goto Throw;
				}
			}
			return;
		Throw:
			throw ArgumentNotContainsException.With(collection, name, value);
		}

		/// <summary>
		/// Guard against the collection not containing a particular value.
		/// </summary>
		/// <typeparam name="TCollection">The type of the collection; must be <see cref="ICollection"/>.</typeparam>
		/// <param name="collection">The collection.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="value">The value to look for.</param>
		/// <exception cref="ArgumentNotContainsException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Contains<TCollection>(TCollection collection, String name, Object value) where TCollection : ICollection {
			if (collection is null) {
				goto Throw;
			}
			foreach (Object item in collection) {
				if (item.Equals(value)) {
					goto Throw;
				}
			}
			return;
		Throw:
			throw ArgumentNotContainsException.With(collection, name, value);
		}

		/// <summary>
		/// Guard against the collection not containing a particular value.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TCollection">The type of the collection; must be <see cref="ICollection{T}"/>.</typeparam>
		/// <param name="collection">The collection.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="value">The value to look for.</param>
		/// <exception cref="ArgumentNotContainsException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Contains<T, TCollection>(TCollection collection, String name, T value) where T : IEquatable<T> where TCollection : ICollection<T> {
			if (collection is null) {
				goto Throw;
			}
			foreach (T item in collection) {
				if (item.Equals(value)) {
					goto Throw;
				}
			}
		Throw:
			throw ArgumentNotContainsException.With(collection, name, value);
		}
	}
}
