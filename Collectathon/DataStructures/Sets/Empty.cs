using System;

namespace Langly.DataStructures.Sets {
	/// <summary>
	/// Represents the empty set (Ø) of <typeparamref name="TElement"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the set.</typeparam>
	internal sealed class Empty<TElement> : Set<TElement> where TElement : IEquatable<TElement> {
		/// <inheritdoc/>
		private Empty() { }

		/// <summary>
		/// An <see cref="Empty{TElement}"/> set singleton.
		/// </summary>
		public static Set<TElement> Instance => Singleton.Instance;

		/// <inheritdoc/>
		protected internal override Set<TElement> Complement() => Universe;

		/// <inheritdoc/>
		protected override Boolean Contains(TElement element) => element is null;

		private static class Singleton {
			internal static readonly Empty<TElement> Instance = new Empty<TElement>();

			static Singleton() { }
		}
	}
}
