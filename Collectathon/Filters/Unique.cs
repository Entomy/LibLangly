using System;
using Langly;
using Langly;

namespace Collectathon.Filters {
	/// <summary>
	/// Filters a data structure by ensuring all its elements are unique.
	/// </summary>
	public sealed class Unique<TElement, TEnumerator> : Filter<TElement> where TEnumerator : IEnumerator<TElement> {
		/// <summary>
		/// The collection to be made unique.
		/// </summary>
		private readonly IEnumerable<TElement, TEnumerator> Collection;

		/// <inheritdoc/>
		internal Unique(IEnumerable<TElement, TEnumerator> collection) : base(adds: true, contains: false) => Collection = collection;

		/// <inheritdoc/>
		public override Filter Type => Filter.Unique;

		/// <inheritdoc/>
		public override Filter<TElement> Clone() => new Unique<TElement, TEnumerator>(Collection);

		/// <inheritdoc/>
		public override Ł3 Contains(TElement element) {
			foreach (TElement item in Collection) {
				if (item?.Equals(element) ?? false) {
					return Ł3.True;
				}
			}
			return Ł3.False;
		}
	}
}
