using System;
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
	}

	public static partial class CoreExtensions {
		/// <summary>
		/// Determines whether this collection contains the specified <paramref name="element"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to attempt to find.</param>
		/// <returns><see langword="true"/> if <paramref name="element"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains<TElement>([AllowNull] this IContains<TElement> collection, [AllowNull] TElement element) => collection?.Contains(element) ?? false;
	}
}
