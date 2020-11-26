using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Langly {
	public static partial class Guard {
		/// <summary>
		/// Guard against the collection containing a particular value.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the collection.</typeparam>
		/// <param name="collection">The collection.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="value">The value to look for.</param>
		/// <exception cref="ArgumentContainsException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NotContains<T>(T[] collection, String name, T value) where T : IEquatable<T> {
			if (collection is null) {
				return;
			}
			foreach (T item in collection) {
				if (item.Equals(value)) {
					throw ArgumentContainsException.With(collection, name, value);
				}
			}
		}

		/// <summary>
		/// Guard against the collection containing a particular value.
		/// </summary>
		/// <typeparam name="TCollection">The type of the collection; must be <see cref="ICollection"/>.</typeparam>
		/// <param name="collection">The collection.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="value">The value to look for.</param>
		/// <exception cref="ArgumentContainsException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NotContains<TCollection>(TCollection collection, String name, Object value) where TCollection : ICollection {
			if (collection is null) {
				return;
			}
			foreach (Object item in collection) {
				if (item.Equals(value)) {
					throw ArgumentContainsException.With(collection, name, value);
				}
			}
		}

		/// <summary>
		/// Guard against the collection containing a particular value.
		/// </summary>
		/// <typeparam name="TCollection">The type of the collection; must be <see cref="ICollection{T}"/>.</typeparam>
		/// <typeparam name="T">The type of the elements in the collection.</typeparam>
		/// <param name="collection">The collection.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="value">The value to look for.</param>
		/// <exception cref="ArgumentContainsException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NotContains<T, TCollection>(TCollection collection, String name, T value) where TCollection : ICollection<T> where T : IEquatable<T> {
			if (collection is null) {
				return;
			}
			foreach (T item in collection) {
				if (item.Equals(value)) {
					throw ArgumentContainsException.With(collection, name, value);
				}
			}
		}
	}
}
