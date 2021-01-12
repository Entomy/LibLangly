using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures {
	/// <summary>
	/// Represents the union between two <see cref="Set{TElement}"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the set.</typeparam>
	/// <typeparam name="TFirst">The type of the first set.</typeparam>
	/// <typeparam name="TSecond">The type of the second set.</typeparam>
	internal sealed class Union<TElement, TFirst, TSecond> : Combinator<TElement, TFirst, TSecond>
		where TFirst : Set<TElement>
		where TSecond : Set<TElement>{
		/// <summary>
		/// Initializes a new <see cref="Union{TElement, TFirst, TSecond}"/>.
		/// </summary>
		/// <param name="first">The first set.</param>
		/// <param name="second">The second set.</param>
		internal Union([DisallowNull] TFirst first, [DisallowNull] TSecond second) : base(first, second) { }

		/// <inheritdoc/>
		protected override Boolean Contains([AllowNull] TElement element) => ((IContains<TElement>)First).Contains(element) || ((IContains<TElement>)Second).Contains(element);
	}
}
