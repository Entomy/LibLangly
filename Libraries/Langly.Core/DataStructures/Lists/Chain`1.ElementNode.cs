using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures.Lists {
	public partial class Chain<TElement> {
		/// <summary>
		/// Represents a <see cref="Node"/> holding a single element.
		/// </summary>
		private sealed class ElementNode : Node {
			/// <summary>
			/// The element contained in the node.
			/// </summary>
			[AllowNull]
			private TElement Element;

			/// <summary>
			/// Initializes a new <see cref="ElementNode"/>.
			/// </summary>
			/// <param name="element">The element contained in the node.</param>
			/// <param name="previous">The previous node in the chain.</param>
			/// <param name="next">The next node in the chain.</param>
			public ElementNode([AllowNull] TElement element, [AllowNull] Node previous, [AllowNull] Node next) : base(previous, next) => Element = element;

			/// <inheritdoc/>
			public override nint Count => 1;
		}
	}
}
