using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures {
	/// <summary>
	/// Represents a set of <typeparamref name="TElement"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of elements  in the set.</typeparam>
	/// <remarks>
	/// <para>A set is a collection in which any element can only exist once. All other collections are technically multi-sets, if you need such. Furthermore, sets don't care about data being ordered.</para>
	/// <para>Unlike <see cref="System.Collections.Generic.ISet{T}"/> this adheres to Set Theory and Set Algebra, so its behavior should not be surprising, and existing techniques and solutions can easily be translated.</para>
	/// </remarks>
	public abstract class Set<TElement> : Object, IContains<TElement> {
		/// <summary>
		/// Singleton instance for the empty set (Ø) of <typeparamref name="TElement"/>.
		/// </summary>
		public static Set<TElement> Empty => Empty<TElement>.Instance;

		/// <summary>
		/// Singleton instance for the universe set (U) of <typeparamref name="TElement"/>.
		/// </summary>
		public static Set<TElement> Universe => Universe<TElement>.Instance;

		/// <summary>
		/// Returns the difference of <paramref name="right"/> from <paramref name="left"/>.
		/// </summary>
		/// <param name="left">The lefthand set.</param>
		/// <param name="right">The righthand set.</param>
		/// <returns>The difference of <paramref name="right"/> from <paramref name="left"/>.</returns>
		[return: NotNull]
		public static Set<TElement> operator -([AllowNull] Set<TElement> left, [AllowNull] Set<TElement> right) => Set.Difference<TElement, Set<TElement>, Set<TElement>>(left, right);

		/// <summary>
		/// Returns the compliment of the <paramref name="set"/>.
		/// </summary>
		/// <param name="set">This set.</param>
		/// <returns>The compliment of the <paramref name="set"/>.</returns>
		[return: NotNull]
		public static Set<TElement> operator !([AllowNull] Set<TElement> set) => Set.Compliment<TElement, Set<TElement>>(set);

		/// <summary>
		/// Returns the intersection of <paramref name="left"/> and <paramref name="right"/>.
		/// </summary>
		/// <param name="left">The lefthand set.</param>
		/// <param name="right">The righthand set.</param>
		/// <returns>The intersection of <paramref name="left"/> and <paramref name="right"/>.</returns>
		[return: NotNull]
		public static Set<TElement> operator &([AllowNull] Set<TElement> left, [AllowNull] Set<TElement> right) => Set.Intersection<TElement, Set<TElement>, Set<TElement>>(left, right);

		/// <summary>
		/// Returns the disjunction of <paramref name="left"/> and <paramref name="right"/>.
		/// </summary>
		/// <param name="left">The lefthand set.</param>
		/// <param name="right">The righthand set.</param>
		/// <returns>The disjunction of <paramref name="left"/> and <paramref name="right"/>.</returns>
		[return: NotNull]
		public static Set<TElement> operator ^([AllowNull] Set<TElement> left, [AllowNull] Set<TElement> right) => Set.Disjunction<TElement, Set<TElement>, Set<TElement>>(left, right);

		/// <summary>
		/// Returns the union of <paramref name="left"/> and <paramref name="right"/>.
		/// </summary>
		/// <param name="left">The lefthand set.</param>
		/// <param name="right">The righthand set.</param>
		/// <returns>The union of <paramref name="left"/> and <paramref name="right"/>.</returns>
		[return: NotNull]
		public static Set<TElement> operator |([AllowNull] Set<TElement> left, [AllowNull] Set<TElement> right) => Set.Union<TElement, Set<TElement>, Set<TElement>>(left, right);

		/// <inheritdoc/>
		Boolean IContains<TElement>.Contains([AllowNull] TElement element) => Contains(element);

		/// <summary>
		/// Provides the core implementation for <see cref="Set.Compliment{TElement, TSet}(TSet)"/>.
		/// </summary>
		/// <returns>The compliment of this set.</returns>
		[return: NotNull]
		protected internal virtual Set<TElement> ComplimentImpl() => new Compliment<TElement, Set<TElement>>(this);

		/// <summary>
		/// Provides the core implementation for <see cref="Set.Difference{TElement, TFirst, TSecond}(TFirst, TSecond)"/>.
		/// </summary>
		/// <typeparam name="TOther">The type of <paramref name="other"/>.</typeparam>
		/// <param name="other">The other set.</param>
		/// <returns>The difference of the <paramref name="other"/> set from this one.</returns>
		[return: NotNull]
		protected internal virtual Set<TElement> DifferenceImpl<TOther>([DisallowNull] TOther other) where TOther : Set<TElement> => new Difference<TElement, Set<TElement>, Set<TElement>>(this, other);

		/// <summary>
		/// Provides  the core implementation for <see cref="Set.Disjunction{TElement, TFirst, TSecond}(TFirst, TSecond)"/>.
		/// </summary>
		/// <typeparam name="TOther">The type of <paramref name="other"/>.</typeparam>
		/// <param name="other">The other set.</param>
		/// <returns>The disjunction of this set and the <paramref name="other"/> set.</returns>
		[return: NotNull]
		protected internal virtual Set<TElement> DisjunctionImpl<TOther>([DisallowNull] TOther other) where TOther : Set<TElement> => new Disjunction<TElement, Set<TElement>, Set<TElement>>(this, other);

		/// <summary>
		/// Provides the core implementation for <see cref="Set.Intersection{TElement, TFirst, TSecond}(TFirst, TSecond)"/>.
		/// </summary>
		/// <typeparam name="TOther">The type of <paramref name="other"/>.</typeparam>
		/// <param name="other">The other set.</param>
		/// <returns>The intersection of this set and the <paramref name="other"/> set.</returns>
		[return: NotNull]
		protected internal virtual Set<TElement> IntersectionImpl<TOther>([DisallowNull] TOther other) where TOther : Set<TElement> => new Intersection<TElement, Set<TElement>, Set<TElement>>(this, other);

		/// <summary>
		/// Provides the core implemenation for <see cref="Set.Union{TElement, TFirst, TSecond}(TFirst, TSecond)"/>.
		/// </summary>
		/// <typeparam name="TOther">The type of <paramref name="other"/>.</typeparam>
		/// <param name="other">The other set.</param>
		/// <returns>The union of this set and the <paramref name="other"/> set.</returns>
		[return: NotNull]
		protected internal virtual Set<TElement> UnionImpl<TOther>([DisallowNull] TOther other) where TOther : Set<TElement> => new Union<TElement, Set<TElement>, Set<TElement>>(this, other);

		/// <summary>
		/// Provides the actual implementation of <see cref="IContains{TElement}.Contains(TElement)"/>.
		/// </summary>
		/// <param name="element">The element to attempt to find.</param>
		/// <returns><see langword="true"/> if <paramref name="element"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		protected abstract Boolean Contains([AllowNull] TElement element);
	}
}
