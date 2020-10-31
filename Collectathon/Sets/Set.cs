using Collectathon.Arrays;
using Philosoft;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Collectathon.Sets {
	/// <summary>
	/// Holds various static operations for <see cref="Set{TElement}"/>.
	/// </summary>
	[SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "Except this is literally the set from set theory...")]
	public static class Set {
		/// <summary>
		/// Returns a singleton instance for the empty set (Ø) of <typeparamref name="TElement"/>.
		/// </summary>
		public static Set<TElement> Empty<TElement>() where TElement : IEquatable<TElement> => Set<TElement>.Empty;

		/// <summary>
		/// Creates a <see cref="Set{TElement}"/> from the given <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <typeparam name="TCollection">The type of the collection.</typeparam>
		/// <param name="collection">The collection.</param>
		/// <returns>A <see cref="Set{TElement}"/> of the elements in the <paramref name="collection"/>.</returns>
		public static Set<TElement> From<TElement, TCollection>(TCollection collection) where TElement : IEquatable<TElement> where TCollection : IContainable<TElement> => new Wrapper<TElement, TCollection>(collection);

		/// <summary>
		/// Creates a <see cref="Set{TElement}"/> from the given <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">The collection.</param>
		/// <returns>A <see cref="Set{TElement}"/> of the elements in the <paramref name="collection"/>.</returns>
		public static Set<TElement> From<TElement>(params TElement[] collection) where TElement : IEquatable<TElement> => new Wrapper<TElement, FixedArray<TElement>>(collection);

		/// <summary>
		/// Creates a new <see cref="Set{TElement}"/> from the given <paramref name="predicate"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="predicate">The function describing existance within the collection.</param>
		/// <returns>A <see cref="Set{TElement}"/> described by the <paramref name="predicate"/>.</returns>
		/// <remarks>
		/// This factory is guarded such that a <see langword="null"/> delegate returns <see cref="Empty{TElement}()"/> and any subsequent calls to <see cref="IContainable{TElement}.Contains(TElement)"/> handle <see langword="null"/> without the delegate needing to.
		/// </remarks>
		public static Set<TElement> From<TElement>(Predicate<TElement> predicate) where TElement : IEquatable<TElement> => predicate is null ? Empty<TElement>() : new Function<TElement>(predicate);

		/// <summary>
		/// Creates a <see cref="Set{TElement}"/> from the range <paramref name="lower"/>..<paramref name="upper"/>.
		/// </summary>
		/// <param name="lower">The lower bound, inclusive.</param>
		/// <param name="upper">The upper bound, inclusive.</param>
		/// <returns>A <see cref="Set{TElement}"/> of the elements in the range.</returns>
		public static Set<TElement> Range<TElement>(TElement lower, TElement upper) where TElement : IComparable<TElement>, IEquatable<TElement> => new Range<TElement>(lower, upper);

		/// <summary>
		/// Creates a <see cref="Set{TElement}"/> from the range <paramref name="lower"/>..<paramref name="upper"/>.
		/// </summary>
		/// <param name="lower">The lower bound, inclusive.</param>
		/// <param name="upper">The upper bound, inclusive.</param>
		/// <returns>A <see cref="Set{TElement}"/> of the elements in the range.</returns>
		public static Set<Int32> Range(Int32 lower, Int32 upper) => new Int32Range(lower, upper);

		/// <summary>
		/// Creates a <see cref="Set{TElement}"/> from the range <paramref name="lower"/>..<paramref name="upper"/>.
		/// </summary>
		/// <param name="lower">The lower bound, inclusive.</param>
		/// <param name="upper">The upper bound, inclusive.</param>
		/// <returns>A <see cref="Set{TElement}"/> of the elements in the range.</returns>
		[CLSCompliant(false)]
		public static Set<UInt32> Range(UInt32 lower, UInt32 upper) => new UInt32Range(lower, upper);

		/// <summary>
		/// Returns a singleton instance for the universe set (U) of <typeparamref name="TElement"/>.
		/// </summary>
		public static Set<TElement> Universe<TElement>() where TElement : IEquatable<TElement> => Set<TElement>.Universe;
	}

	/// <summary>
	/// Represents a abstract set of <typeparamref name="TElement"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the set.</typeparam>
	/// <remarks>
	/// <para>A set is a collection in which any element can only exist once (all other collections are technically multi-sets, if you need a multi-set). Furthermore, sets don't care about data being ordered, although it may be ordered as an internal implementation details.</para>
	/// <para>Unlike <see cref="System.Collections.Generic.ISet{T}"/> this adheres to Set Theory and Set Algebra, so its behavior should not be surprising, and existing techniques and solutions can be easily translated.</para>
	/// </remarks>
	[SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "Except this is literally the set from set theory...")]
	public abstract class Set<TElement> : IContainable<TElement> where TElement : IEquatable<TElement> {
		/// <summary>
		/// Singleton instance for the empty set (Ø) of <typeparamref name="TElement"/>.
		/// </summary>
		public static Set<TElement> Empty { get; } = Empty<TElement>.Instance;

		/// <summary>
		/// Singleton instance for the universe set (U) of <typeparamref name="TElement"/>.
		/// </summary>
		public static Set<TElement> Universe { get; } = Universe<TElement>.Instace;

		/// <summary>
		/// Returns the difference of the <paramref name="first"/> collection and the <paramref name="second"/> collection.
		/// </summary>
		/// <param name="first">The first collection of the difference.</param>
		/// <param name="second">The second collection of the difference.</param>
		/// <returns>A new collection representing the difference between the two collections.</returns>
		public static Set<TElement> operator -(Set<TElement> first, Set<TElement> second) => first.Difference(second);

		/// <summary>
		/// Returns the complement of the <paramref name="set"/> collection.
		/// </summary>
		/// <param name="set">The collection to complement.</param>
		/// <returns>A new collection representing the complement of the collection.</returns>
		public static Set<TElement> operator !(Set<TElement> set) => set?.Complement() ?? Universe;

		/// <summary>
		/// Returns the intersection of the <paramref name="first"/> collection and the <paramref name="second"/> collection.
		/// </summary>
		/// <param name="first">The first collection of the intersection.</param>
		/// <param name="second">The second collection of the intersection.</param>
		/// <returns>A new collection representing the intersection of the two collections.</returns>
		public static Set<TElement> operator &(Set<TElement> first, Set<TElement> second) => first.Intersection(second);

		/// <summary>
		/// Returns the disjunction of the <paramref name="first"/> collection and the <paramref name="second"/> collection.
		/// </summary>
		/// <param name="first">The first collection of the disjunction.</param>
		/// <param name="second">The second collection of the disjunction.</param>
		/// <returns>A new collection representing the disjunction of the two collections.</returns>
		public static Set<TElement> operator ^(Set<TElement> first, Set<TElement> second) => first.Disjunction(second);

		/// <summary>
		/// Returns the union of the <paramref name="first"/> collection and the <paramref name="second"/> collection.
		/// </summary>
		/// <param name="first">The first collection of the union.</param>
		/// <param name="second">The second collection of the union.</param>
		/// <returns>A new collection representing the union of the two collections.</returns>
		public static Set<TElement> operator |(Set<TElement> first, Set<TElement> second) => first.Union(second);

		/// <inheritdoc/>
		Boolean IContainable<TElement>.Contains(TElement element) => Contains(element);

		/// <summary>
		/// Returns the complement of the this collection.
		/// </summary>
		/// <returns>A new collection representing the complement of the collection.</returns>
		internal protected virtual Set<TElement> Complement() => new Complement<TElement>(this);

		/// <summary>
		/// Returns the difference of this collection and the <paramref name="other"/> collection.
		/// </summary>
		/// <param name="other">The other collection of the difference.</param>
		/// <returns>A new collection representing the difference between the two collections.</returns>
		internal protected virtual Set<TElement> Difference(Set<TElement> other) => new Difference<TElement>(this, other);

		/// <summary>
		/// Returns the disjunction of this collection and the <paramref name="other"/> collection.
		/// </summary>
		/// <param name="other">The other collection of the disjunction.</param>
		/// <returns>A new collection representing the disjunction of the two collections.</returns>
		internal protected virtual Set<TElement> Disjunction(Set<TElement> other) => new Disjunction<TElement>(this, other);

		/// <summary>
		/// Returns the intersection of this collection and the <paramref name="other"/> collection.
		/// </summary>
		/// <param name="other">The other collection of the intersection.</param>
		/// <returns>A new collection representing the intersection of the two collections.</returns>
		internal protected virtual Set<TElement> Intersection(Set<TElement> other) => new Intersection<TElement>(this, other);

		/// <summary>
		/// Returns the union of this collection and the <paramref name="other"/> collection.
		/// </summary>
		/// <param name="other">The other collection of the union.</param>
		/// <returns>A new collection representing the union of the two collections.</returns>
		internal protected virtual Set<TElement> Union(Set<TElement> other) => new Union<TElement>(this, other);

		protected abstract Boolean Contains(TElement element);
	}
}
