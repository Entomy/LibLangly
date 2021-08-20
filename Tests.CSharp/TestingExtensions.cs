using Collectathon;
using Collectathon.Enumerators;

namespace Defender {
	/// <summary>
	/// Helpers for using <see cref="Defender"/> with trickier types.
	/// </summary>
	public static class TestingExtensions {
		/// <summary>
		/// Prepares <paramref name="actual"/> to make assertions against it.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the <see cref="BoundedArray{TElement}"/>.</typeparam>
		/// <param name="_">This <see cref="Assert"/>.</param>
		/// <param name="actual">The instance of <see cref="BoundedArray{TElement}"/> to make assertions against.</param>
		/// <returns>A <see cref="SequenceAsserter{TElement, TCollection, TEnumerator}"/> instance.</returns>
		public static SequenceAsserter<TElement, BoundedArray<TElement>, ArrayEnumerator<TElement>> That<TElement>(this Assert _, BoundedArray<TElement> actual) => new SequenceAsserter<TElement, BoundedArray<TElement>, ArrayEnumerator<TElement>>(actual);
	}
}
