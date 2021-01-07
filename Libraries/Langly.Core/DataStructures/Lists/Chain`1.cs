using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures.Lists {
	public sealed partial class Chain<TElement> : DataStructure<TElement, Chain<TElement>, Chain<TElement>.Enumerator> {
		/// <inheritdoc/>
		[return: NotNull]
		protected override String StructurePrefix() => "Chain";
	}
}
