using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures {
	/// <summary>
	/// Represents a literal set defined by a range of <typeparamref name="TElement"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the set.</typeparam>
	internal class Range<TElement> : Set<TElement> where TElement : IComparable<TElement> {
		/// <summary>
		/// The lower bound.
		/// </summary>
		protected readonly TElement Lower;

		/// <summary>
		/// The upper bound.
		/// </summary>
		protected readonly TElement Upper;

		/// <summary>
		/// Initializes a new <see cref="Range{TElement}"/>.
		/// </summary>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		public Range([DisallowNull] TElement lower, [DisallowNull] TElement upper) {
			Upper = upper;
			Lower = lower;
		}

		/// <inheritdoc/>
		protected override Boolean Contains([AllowNull] TElement element) => Check.Within(element, Lower, Upper);
	}
}
