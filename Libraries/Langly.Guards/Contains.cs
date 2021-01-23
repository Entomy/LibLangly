using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Langly.Exceptions;

namespace Langly {
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
					return;
				}
			}
		Throw:
			throw ArgumentNotContainsException.With(collection, name, value);
		}

		/// <summary>
		/// Guard against the collection not containing a particular value.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the collection.</typeparam>
		/// <param name="collection">The collection.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="value">The value to look for.</param>
		/// <exception cref="ArgumentNotContainsException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Contains<T>(ICollection collection, String name, T value) {
			if (collection is null) {
				goto Throw;
			}
			foreach (T item in collection) {
				if (item.Equals(value)) {
					return;
				}
			}
		Throw:
			throw ArgumentNotContainsException.With(collection, name, value);
		}

		/// <summary>
		/// Guard against the collection not containing a particular value.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the collection.</typeparam>
		/// <param name="collection">The collection.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="value">The value to look for.</param>
		/// <exception cref="ArgumentNotContainsException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Contains<T>(IReadOnlyCollection<T> collection, String name, T value) where T : IEquatable<T> {
			if (collection is null) {
				goto Throw;
			}
			foreach (T item in collection) {
				if (item.Equals(value)) {
					return;
				}
			}
		Throw:
			throw ArgumentNotContainsException.With(collection, name, value);
		}

		/// <summary>
		/// Guard against the collection not containing a particular value.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the collection.</typeparam>
		/// <param name="collection">The collection.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="value">The value to look for.</param>
		/// <exception cref="ArgumentNotContainsException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Contains<T>(IContains<T> collection, String name, T value) where T : IEquatable<T> {
			if (!(collection?.Contains(value) ?? false)) {
				throw ArgumentNotContainsException.With(collection, name, value);
			}
		}
	}
}
