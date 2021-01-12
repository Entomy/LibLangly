using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures {
	/// <summary>
	/// Represents the universe set (U) of <typeparamref name="TElement"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the set.</typeparam>
	internal sealed class Universe<TElement> : Set<TElement> {
		/// <summary>
		/// Initializes a new <see cref="Universe{TElement}"/>.
		/// </summary>
		private Universe() { }

		/// <summary>
		/// An <see cref="Universe{TElement}"/> set singleton.
		/// </summary>
		public static Universe<TElement> Instance => Singleton.Instance;

		/// <inheritdoc/>
		protected override Boolean Contains([AllowNull] TElement element) => element is not null;

		/// <inheritdoc/>
		protected internal override Set<TElement> ComplimentImpl() => Empty;

		private static class Singleton {
			internal static readonly Universe<TElement> Instance = new Universe<TElement>();

			static Singleton() { }
		}
	}
}
