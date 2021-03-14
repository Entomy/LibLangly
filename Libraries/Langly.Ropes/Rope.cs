using Langly.DataStructures;
using Langly.DataStructures.Lists;

namespace Langly {
	/// <summary>
	/// Represents text as a sequence of <see cref="Glyph"/>.
	/// </summary>
	/// <remarks>
	/// This is, itself, a variation of <see cref="Chain{TElement}"/>, and is very similar to a Rope datastructure, only with some optimizations for ordered data. The Rope name is reused, but in the pedantic sense, this is not a Rope, as it's not a binary tree. Never-the-less, it serves the same role as a proper Rope.
	/// </remarks>
	public sealed partial class Rope : DataStructure<Glyph, Rope, Rope.Enumerator> {
		/// <summary>
		/// Initializes a new <see cref="Rope"/>.
		/// </summary>
		public Rope() : base(DataStructures.Filter.None) { }
	}
}
