using System;
using Defender;

namespace Stringier {
	public abstract partial class FormatList {
		/// <summary>
		/// Represents an item within the <see cref="FormatList"/>.
		/// </summary>
		/// <remarks>
		/// This maintains both the text of the item, and the change in <see cref="IndentationLevel"/> that should occur at this item.
		/// </remarks>
		protected sealed class Item {
			/// <summary>
			/// The change in indentation level that should occur at this item.
			/// </summary>
			public readonly Int32 IndentationChange;

			/// <summary>
			/// The text of this item.
			/// </summary>
			public readonly String Text;

			/// <inheritdoc/>
			public Item(String text) : this(0, text) { }

			/// <inheritdoc/>
			public Item(Int32 indentationChange, String text) {
				IndentationChange = indentationChange;
				Text = text;
			}

			/// <inheritdoc/>
			public sealed override String ToString() => Text;
		}
	}
}
