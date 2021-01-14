using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures {
	/// <summary>
	/// Represents the combination of two <see cref="Set{TElement}"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the set.</typeparam>
	/// <typeparam name="TFirst">The type of the first set.</typeparam>
	/// <typeparam name="TSecond">The type of the second set.</typeparam>
	internal abstract class Combinator<TElement, TFirst, TSecond> : Set<TElement>
		where TFirst : Set<TElement>
		where TSecond : Set<TElement> {
		/// <summary>
		/// The first set.
		/// </summary>
		protected readonly TFirst First;

		/// <summary>
		/// The second set.
		/// </summary>
		protected readonly TSecond Second;

		/// <summary>
		/// Initializes a new <see cref="Combinator{TElement, TFirst, TSecond}"/>.
		/// </summary>
		/// <param name="first">The first set.</param>
		/// <param name="second">The second set.</param>
		protected Combinator([DisallowNull] TFirst first, [DisallowNull] TSecond second) {
			First = first;
			Second = second;
		}
	}
}
