using System;
using System.Collections.Generic;
using Defender;

namespace Stringier {
	/// <summary>
	/// Helper class for list formatting.
	/// </summary>
	/// <remarks>
	/// This represents either an unordered list or an ordered list, and in either case, additionally supports indentation levels, via nesting of lists.
	/// </remarks>
	public abstract partial class FormatList {
		/// <summary>
		/// The items that make up this list.
		/// </summary>
		protected readonly List<Item> Items = new List<Item>();

		/// <summary>
		/// The indentation string for a single level.
		/// </summary>
		protected readonly String Indentation;

		/// <summary>
		/// The indentation level of the current items in the list.
		/// </summary>
		protected Int32 IndentationLevel = 0;

		/// <inheritdoc/>
		protected FormatList() : this("\t") { }

		/// <inheritdoc/>
		protected FormatList(String indentation) => Indentation = indentation;

		/// <summary>
		/// Places the format items in a new record of the <see cref="FormatList"/> with the string representation of the specified object.
		/// </summary>
		/// <param name="arg">The object to format.</param>
		public void Format(Object arg) {
			Guard.NotNull(arg, nameof(arg));
			Items.Add(new Item(arg.ToString()));
		}

		/// <summary>
		/// Places the format items in a new record of the <see cref="FormatList"/>
		/// </summary>
		/// <param name="arg">The object to format.</param>
		/// <param name="indent">The change to indentation level.</param>
		public void Format(Object arg, Indent indent) {
			Guard.NotNull(arg, nameof(arg));
			Guard.Valid(indent, nameof(indent));
			Items.Add(new Item((Int32)indent, arg.ToString()));
		}

		/// <inheritdoc/>
		public abstract override String ToString();
	}
}
