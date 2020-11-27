using System;
using System.Text;
using System.Unicode;
using Langly;
using Langly.DataStructures.Sets;

namespace Stringier.Categories {
	/// <summary>
	/// A helper class for creation of categories based on <see cref="ContributoryProperties"/>.
	/// </summary>
	internal sealed class PropertyCategory : Category {
		/// <summary>
		/// The <see cref="ContributoryProperties"/> defining this <see cref="Category"/>.
		/// </summary>
		private readonly ContributoryProperties Properties;

		/// <summary>
		/// Initialize a new <see cref="Category"/> with the given <paramref name="properties"/>.
		/// </summary>
		/// <param name="properties">The <see cref="ContributoryProperties"/> defining this <see cref="Category"/>.</param>
		internal PropertyCategory(ContributoryProperties properties) => Properties = properties;

		/// <inheritdoc/>
		protected sealed override Boolean Contains(Char element) => (UnicodeInfo.GetCharInfo(element).ContributoryProperties & Properties) != 0;

		/// <inheritdoc/>
		protected sealed override Boolean Contains(Rune element) => (UnicodeInfo.GetCharInfo(element.Value).ContributoryProperties & Properties) != 0;

		/// <inheritdoc/>
		protected sealed override Boolean Contains(Glyph element) => element.Code <= Int32.MaxValue && (UnicodeInfo.GetCharInfo(unchecked((Int32)element.Code)).ContributoryProperties & Properties) != 0;
	}
}
