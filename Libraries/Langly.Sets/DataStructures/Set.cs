using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures {
	/// <summary>
	/// Provides various operations for <see cref="Set{TElement}"/>.
	/// </summary>
	/// <remarks>
	/// These exist as greatly simplified functions for working with sets. Doing it this way allows the entire generic parameter list to be inferred by context.
	/// </remarks>
	public static class Set {
		/// <summary>
		/// Returns the compliment of the <paramref name="set"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the set.</typeparam>
		/// <typeparam name="TSet">The type of this set.</typeparam>
		/// <param name="set">This set.</param>
		/// <returns>The compliment of the <paramref name="set"/>.</returns>
		[return: NotNull]
		public static Set<TElement> Compliment<TElement, TSet>([AllowNull] TSet set) where TSet : Set<TElement> => set?.ComplimentImpl() ?? Universe<TElement>();

		/// <summary>
		/// Returns the difference of <paramref name="second"/> from <paramref name="first"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the set.</typeparam>
		/// <typeparam name="TFirst">The type of the first set.</typeparam>
		/// <typeparam name="TSecond">The type of the second set.</typeparam>
		/// <param name="first">The first set.</param>
		/// <param name="second">The second set.</param>
		/// <returns>The difference of <paramref name="second"/> from <paramref name="first"/>.</returns>
		[return: NotNull]
		public static Set<TElement> Difference<TElement, TFirst, TSecond>([AllowNull] TFirst first, [AllowNull] TSecond second) where TFirst : Set<TElement> where TSecond : Set<TElement> => first?.DifferenceImpl(second) ?? Empty<TElement>();

		/// <summary>
		/// Returns the disjunction of <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the set.</typeparam>
		/// <typeparam name="TFirst">The type of the first set.</typeparam>
		/// <typeparam name="TSecond">The type of the second set.</typeparam>
		/// <param name="first">The first set.</param>
		/// <param name="second">The second set.</param>
		/// <returns>The disjunction of <paramref name="first"/> and <paramref name="second"/>.</returns>
		[return: NotNull]
		public static Set<TElement> Disjunction<TElement, TFirst, TSecond>([AllowNull] TFirst first, [AllowNull] TSecond second) where TFirst : Set<TElement> where TSecond : Set<TElement> => (first?.DisjunctionImpl(second) ?? second) ?? Universe<TElement>();

		/// <summary>
		/// Returns a singleton instance for the empty set (Ø) of <typeparamref name="TElement"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the set.</typeparam>
		/// <returns></returns>
		[return: NotNull]
		public static Set<TElement> Empty<TElement>() => Set<TElement>.Empty;

		/// <summary>
		/// Returns a set of the <paramref name="elements"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the set.</typeparam>
		/// <param name="elements">The elements of the set.</param>
		/// <returns>A set of the <paramref name="elements"/>.</returns>
		[return: NotNull]
		public static Set<TElement> Of<TElement>([AllowNull] params TElement[] elements) => elements is not null ? new Wrapper<TElement, Array<TElement>>(elements) : Empty<TElement>();

		/// <summary>
		/// Returns a set described by the <paramref name="predicate"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the set.</typeparam>
		/// <param name="predicate">The <see cref="System.Predicate{T}"/> describing the set.</param>
		/// <returns>A set described by the <paramref name="predicate"/>.</returns>
		public static Set<TElement> Of<TElement>([AllowNull] System.Predicate<TElement> predicate) => predicate is not null ? new Predicate<TElement>(predicate) : Empty<TElement>();

		/// <summary>
		/// Returns the intersection of <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the set.</typeparam>
		/// <typeparam name="TFirst">The type of the first set.</typeparam>
		/// <typeparam name="TSecond">The type of the second set.</typeparam>
		/// <param name="first">The first set.</param>
		/// <param name="second">The second set.</param>
		/// <returns>The intersection of <paramref name="first"/> and <paramref name="second"/>.</returns>
		[return: NotNull]
		public static Set<TElement> Intersection<TElement, TFirst, TSecond>([AllowNull] TFirst first, [AllowNull] TSecond second) where TFirst : Set<TElement> where TSecond : Set<TElement> => (first?.IntersectionImpl(second) ?? second) ?? Empty<TElement>();

		/// <summary>
		/// Creates a set representing the range of <paramref name="lower"/>..<paramref name="upper"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements of the set.</typeparam>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <returns>A set representing the range of <paramref name="lower"/>..<paramref name="upper"/>.</returns>
		[return: NotNull]
		public static Set<TElement> Range<TElement>([DisallowNull] TElement lower, [DisallowNull] TElement upper) where TElement : IComparable<TElement> => new Range<TElement>(lower, upper);

		/// <summary>
		/// Creates a set representing the range of <paramref name="lower"/>..<paramref name="upper"/>.
		/// </summary>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <returns>A set representing the range of <paramref name="lower"/>..<paramref name="upper"/>.</returns>
		[return: NotNull]
		public static Set<Int32> Range(Int32 lower, Int32 upper) => new RangeInt32(lower, upper);

		/// <summary>
		/// Returns the union of <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the set.</typeparam>
		/// <typeparam name="TFirst">The type of the first set.</typeparam>
		/// <typeparam name="TSecond">The type of the second set.</typeparam>
		/// <param name="first">The first set.</param>
		/// <param name="second">The second set.</param>
		/// <returns>The union of <paramref name="first"/> and <paramref name="second"/>.</returns>
		[return: NotNull]
		public static Set<TElement> Union<TElement, TFirst, TSecond>([AllowNull] TFirst first, [AllowNull] TSecond second) where TFirst : Set<TElement> where TSecond : Set<TElement> => first?.UnionImpl(second) ?? second;

		/// <summary>
		/// Returns a singleton instance for the universe set (U) of <typeparamref name="TElement"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the set.</typeparam>
		/// <returns></returns>
		[return: NotNull]
		public static Set<TElement> Universe<TElement>() => Set<TElement>.Universe;
	}
}
