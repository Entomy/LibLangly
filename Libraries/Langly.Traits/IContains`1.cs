﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can contain elements, and test against those.
	/// </summary>
	/// <typeparam name="TElement">The type of element contained in the collection.</typeparam>
	public interface IContains<in TElement> {
		/// <summary>
		/// Determines whether this collection contains the specified <paramref name="element"/>.
		/// </summary>
		/// <param name="element">The element to attempt to find.</param>
		/// <returns><see langword="true"/> if <paramref name="element"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		Boolean Contains([AllowNull] TElement element);

		/// <summary>
		/// Determines whether this collection contains any of the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if any of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		Boolean ContainsAny([AllowNull] params TElement[] elements) {
			if (elements is not null) {
				foreach (TElement element in elements) {
					if (Contains(element)) {
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		/// Determines whether this collection contains all of the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if all of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		Boolean ContainsAll([AllowNull] params TElement[] elements) {
			if (elements is not null) {
				foreach (TElement element in elements) {
					if (!Contains(element)) {
						return false;
					}
				}
			}
			return true;
		}
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Determines whether this collection contains the specified <paramref name="element"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to attempt to find.</param>
		/// <returns><see langword="true"/> if <paramref name="element"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains<TElement>([AllowNull] this IContains<TElement> collection, [AllowNull] TElement element) => collection?.Contains(element) ?? false;

		/// <summary>
		/// Determines whether this collection contains any of the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if any of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		public static Boolean ContainsAny<TElement>([AllowNull] this IContains<TElement> collection, [AllowNull] params TElement[] elements) => collection?.ContainsAny(elements) ?? false;

		/// <summary>
		/// Determines whether this collection contains all of the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if all of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		public static Boolean ContainsAll<TElement>([AllowNull] this IContains<TElement> collection, [AllowNull] params TElement[] elements) => collection?.ContainsAll(elements) ?? false;
	}
}
