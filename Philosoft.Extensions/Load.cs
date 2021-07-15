using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Loads a byte into this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="source">The source to load data from.</param>
		public static void Load<TElement>([DisallowNull] this IWrite<TElement?> collection, IRead<TElement?>? source) {
			if (source is not null) {
				source.Read(out TElement? element);
				collection.Write(element);
			}
		}

		/// <summary>
		/// Loads <paramref name="amount"/> bytes into this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of elements to load.</param>
		/// <param name="source">The source to load data from.</param>
		public static void Load<TElement>([DisallowNull] this IWrite<TElement?> collection, Int32 amount, IRead<TElement?>? source) {
			for (Int32 i = 0; i < amount; i++) {
				collection.Load(source);
			}
		}
	}
}
