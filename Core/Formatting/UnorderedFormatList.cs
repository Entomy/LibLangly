using System;
using System.Text;
using Defender;

namespace Stringier {
	/// <summary>
	/// Helper class for list formatting, where each item has no relevant ordering.
	/// </summary>
	public sealed class UnorderedFormatList : FormatList {
		/// <summary>
		/// The prefix for each item in the list, by default, no prefix.
		/// </summary>
		private readonly String Prefix;

		/// <inheritdoc/>
		public UnorderedFormatList() : this(String.Empty) { }

		/// <inheritdoc/>
		public UnorderedFormatList(String prefix) => Prefix = prefix;

		/// <inheritdoc/>
		public UnorderedFormatList(String prefix, String indentation) : base(indentation) => Prefix = prefix;

		/// <inheritdoc/>
		public override String ToString() {
			StringBuilder builder = new StringBuilder();
			foreach (Item item in Items) {
				// Doing this avoids the need for any control logic, and relies instead of incredibly fast and branchless addition. Note that we'd need to add regardless, so having the item store a delta makes this efficient.
				IndentationLevel += item.IndentationChange;
				// Now actually do the formatting.
				_ = builder
					.Append(Indentation.Repeat(IndentationLevel))
					.Append(Prefix)
					.AppendLine(item.ToString());
			}
			return builder.ToString();
		}
	}
}
