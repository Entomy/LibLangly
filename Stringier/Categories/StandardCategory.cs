using System;
using System.Globalization;
using System.Text;
using System.Unicode;

namespace Langly {
	/// <summary>
	/// A helper class for creation of categories based on <see cref="System.Globalization.UnicodeCategory"/>.
	/// </summary>
	internal sealed class StandardCategory : Category {
		/// <summary>
		/// The <see cref="System.Globalization.UnicodeCategory"/> defining this <see cref="Category"/>.
		/// </summary>
		private readonly UnicodeCategory UnicodeCategory;

		/// <summary>
		/// Initialize a new <see cref="Category"/> with the given <paramref name="unicodeCategory"/>.
		/// </summary>
		/// <param name="unicodeCategory">The <see cref="System.Globalization.UnicodeCategory"/> defining this <see cref="Category"/>.</param>
		internal StandardCategory(UnicodeCategory unicodeCategory) => UnicodeCategory = unicodeCategory;

		/// <inheritdoc/>
		protected override Boolean Contains(Char element) => UnicodeInfo.GetCategory(element) == UnicodeCategory;

		/// <inheritdoc/>
		protected override Boolean Contains(Rune element) => UnicodeInfo.GetCategory(element.Value) == UnicodeCategory;

		/// <inheritdoc/>
		protected override Boolean Contains(Glyph element) => element.Code <= Int32.MaxValue && UnicodeInfo.GetCategory(unchecked((Int32)element.Code)) == UnicodeCategory;
	}
}
