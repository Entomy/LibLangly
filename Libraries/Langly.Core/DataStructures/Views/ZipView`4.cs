using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;

namespace Langly.DataStructures.Views {
	/// <summary>
	/// Represents an associative (zipped) view of two different collections.
	/// </summary>
	[DebuggerDisplay("{ToString(5),nq}")]
	[StructLayout(LayoutKind.Auto)]
	public readonly partial struct ZipView<TIndex, TElement, TIndexCollection, TElementCollection>
		where TIndexCollection : IEnumerable<TIndex>
		where TElementCollection : IEnumerable<TElement> {
		[DisallowNull, NotNull]
		private readonly TIndexCollection Indicies;

		[DisallowNull, NotNull]
		private readonly TElementCollection Elements;

		internal ZipView([DisallowNull] TIndexCollection indicies, [DisallowNull] TElementCollection elements, nint count) {
			Indicies = indicies;
			Elements = elements;
			Count = count;
		}

		/// <inheritdoc/>
		public nint Count { get; }

		/// <inheritdoc/>
		public override String ToString() => ToString(5);

		/// <summary>
		/// Returns a string that represents the current object, with no more than <paramref name="amount"/> elements.
		/// </summary>
		/// <param name="amount">The maximum amount of elements to display.</param>
		public String ToString(nint amount) {
			StringBuilder builder = new StringBuilder();
			nint i = 0;
			foreach ((TIndex index, TElement element) in this) {
				if (++i == Count) {
					_ = builder.Append(index).Append(':').Append(element);
					break;
				} else if (i == amount) {
					_ = builder.Append(index).Append(':').Append(element).Append("...");
					break;
				} else {
					_ = builder.Append(index).Append(':').Append(element).Append(", ");
				}
			}
			return $"[{builder}]";
		}
	}
}
