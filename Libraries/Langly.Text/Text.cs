using System;
using System.Diagnostics.CodeAnalysis;
using Langly.DataStructures;
using Langly.DataStructures.Lists;

namespace Langly {
	/// <summary>
	/// Represents text as a sequence of <see cref="Glyph"/>.
	/// </summary>
	/// <remarks>
	/// This is, itself, a variation of <see cref="Chain{TElement}"/>, and is very similar to a Rope datastructure, only with some optimizations for ordered data.
	/// </remarks>
	public sealed partial class Text : DataStructure<Glyph, Text, Text.Enumerator> {
		/// <summary>
		/// Initialize a new <see cref="Text"/>.
		/// </summary>
		public Text() : base(DataStructures.Filter.None) { }
	}
}
