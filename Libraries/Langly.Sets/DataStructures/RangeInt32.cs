using System;

namespace Langly.DataStructures {
	/// <summary>
	/// Represents a literal set defined by a range of <see cref="Int32"/>.
	/// </summary>
	internal sealed class RangeInt32 : Range<Int32> {
		/// <summary>
		/// Initializes a new <see cref="RangeInt32"/>.
		/// </summary>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		public RangeInt32(Int32 lower, Int32 upper) : base(lower, upper) { }

		/// <inheritdoc/>
		protected override Boolean Contains(Int32 element) => Lower <= element && element <= Upper;
	}
}
