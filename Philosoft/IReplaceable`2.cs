using System;

namespace Philosoft {
	/// <summary>
	/// Indicates the collection can have elements replaced with other elements.
	/// </summary>
	/// <typeparam name="TOld">The type of the elements in the collection.</typeparam>
	/// <typeparam name="TNew">The type of the elements to replace with.</typeparam>
	public interface IReplaceable<TOld, TNew> {
		/// <summary>
		/// Returns a new collection in which all occurrences of the <paramref name="oldElement"/> are replaced with the <paramref name="newElement"/>.
		/// </summary>
		/// <param name="oldElement">The element to be replaced.</param>
		/// <param name="newElement">The element to replace with.</param>
		void Replace(TOld oldElement, TNew newElement);

		/// <summary>
		/// Returns a new collection in which all replacements described by the <paramref name="map"/> are performed.
		/// </summary>
		/// <param name="map">The mapping of elements to be replaced and their replacements.</param>
		void Replace(params (TOld, TNew)[] map) {
			if (map is null) {
				return;
			}
			foreach ((TOld old, TNew @new) in map) {
				Replace(old, @new);
			}
		}

		/// <summary>
		/// Returns a new collection in which instances that match the specified predicate are replaced with the <paramref name="newElement"/>.
		/// </summary>
		/// <param name="match">The <see cref="Predicate{T}"/> delegate that defines the conditions of the element to replace.</param>
		/// <param name="newElement">The element to be replaced with.</param>
		void Replace(Predicate<TOld> match, TNew newElement);
	}

	public static partial class Extensions {
		/// <summary>
		/// Returns a new collection in which all occurrences of the <paramref name="oldElement"/> are replaced with the <paramref name="newElement"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="oldElement">The element to be replaced.</param>
		/// <param name="newElement">The element to replace with.</param>
		/// <typeparam name="TOld">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TNew">The type of the elements to replace with.</typeparam>
		public static void Replace<TOld, TNew>(this IReplaceable<TOld, TNew> collection, TOld oldElement, TNew newElement) {
			if (collection is null) {
				return;
			}
			collection.Replace(oldElement, newElement);
		}

		/// <summary>
		/// Returns a new collection in which all replacements described by the <paramref name="map"/> are performed.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="map">The mapping of elements to be replaced and their replacements.</param>
		/// <typeparam name="TOld">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TNew">The type of the elements to replace with.</typeparam>
		public static void Replace<TOld, TNew>(this IReplaceable<TOld, TNew> collection, params (TOld, TNew)[] map) {
			if (collection is null) {
				return;
			}
			collection.Replace(map);
		}

		/// <summary>
		/// Returns a new collection in which instances that match the specified predicate are replaced with the <paramref name="newElement"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="match">The <see cref="Predicate{T}"/> delegate that defines the conditions of the element to replace.</param>
		/// <param name="newElement">The element to be replaced with.</param>
		/// <typeparam name="TOld">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TNew">The type of the elements to replace with.</typeparam>
		public static void Replace<TOld, TNew>(this IReplaceable<TOld, TNew> collection, Predicate<TOld> match, TNew newElement) {
			if (collection is null) {
				return;
			}
			collection.Replace(match, newElement);
		}
	}
}
