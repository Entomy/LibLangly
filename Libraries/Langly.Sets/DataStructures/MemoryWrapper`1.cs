using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures {
	/// <summary>
	/// Represents a literal set defined by the <see cref="Memory{T}"/> wrapped into a <see cref="Set{TElement}"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the set.</typeparam>
	internal sealed class MemoryWrapper<TElement> : Set<TElement> {
		/// <summary>
		/// The backing memory of the set.
		/// </summary>
		private readonly ReadOnlyMemory<TElement> Memory;

		/// <summary>
		/// Initializes a new <see cref="MemoryWrapper{TElement}"/>.
		/// </summary>
		/// <param name="memory">The backing memory of the set.</param>
		internal MemoryWrapper(ReadOnlyMemory<TElement> memory) => Memory = memory;

		/// <inheritdoc/>
		protected override Boolean Contains([AllowNull] TElement element) {
			foreach (TElement item in Memory.Span) {
				if (item is null && element is null) {
					return true;
				} else if (item?.Equals(element) ?? false) {
					return true;
				}
			}
			return false;
		}
	}
}
