using System;

namespace Langly.DataStructures.Sets {
	/// <summary>
	/// Represents the universe set (U) of <typeparamref name="TElement"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the set.</typeparam>
	internal sealed class Universe<TElement> : Set<TElement> where TElement : IEquatable<TElement> {
		/// <inheritdoc/>
		private Universe() { }

		/// <summary>
		/// An <see cref="Universe{TElement}"/> set singleton.
		/// </summary>
		public static Universe<TElement> Instace => Singleton.Instance;

		/// <inheritdoc/>
		protected internal override Set<TElement> Complement() => Empty;

		/// <inheritdoc/>
		protected override Boolean Contains(TElement element) => element is not null;

		private static class Singleton {
			internal static readonly Universe<TElement> Instance = new Universe<TElement>();

			static Singleton() { }
		}
	}
}
