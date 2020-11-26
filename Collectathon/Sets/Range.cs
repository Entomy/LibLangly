using System;
using Langly;

namespace Collectathon.Sets {
	/// <summary>
	/// Represents a literal set defined by a range of <typeparamref name="TElement"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the set.</typeparam>
	internal class Range<TElement> : Set<TElement> where TElement : IComparable<TElement>, IEquatable<TElement> {
		/// <summary>
		/// The lower bound.
		/// </summary>
		protected readonly TElement Lower;

		/// <summary>
		/// The upper bound.
		/// </summary>
		protected readonly TElement Upper;

		/// <inheritdoc/>
		public Range(TElement lower, TElement upper) {
			Lower = lower;
			Upper = upper;
		}

		/// <inheritdoc/>
		protected override Boolean Contains(TElement element) => Check.Within(element, Lower, Upper);
	}

	/// <summary>
	/// Represents a literal set defined by a range of <see cref="Int32"/>.
	/// </summary>
	internal sealed class Int32Range : Range<Int32> {
		/// <inheritdoc/>
		public Int32Range(Int32 lower, Int32 upper) : base(lower, upper) { }

		/// <inheritdoc/>
		protected override Boolean Contains(Int32 element) => Check.Within(element, Lower, Upper);
	}

	/// <summary>
	/// Represents a literal set defined by a range of <see cref="UInt32"/>.
	/// </summary>
	internal sealed class UInt32Range : Range<UInt32> {
		/// <inheritdoc/>
		public UInt32Range(UInt32 lower, UInt32 upper) : base(lower, upper) { }

		/// <inheritdoc/>
		protected override Boolean Contains(UInt32 element) => Check.Within(element, Lower, Upper);
	}
}
