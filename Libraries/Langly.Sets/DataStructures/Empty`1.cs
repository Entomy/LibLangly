﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures {
	/// <summary>
	/// Represents an empty set (Ø)  of <typeparamref name="TElement"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the set.</typeparam>
	internal sealed class Empty<TElement> : Set<TElement> {
		/// <summary>
		/// Initializes a new <see cref="Empty{TElement}"/>.
		/// </summary>
		private Empty() { }

		/// <summary>
		/// An <see cref="Empty{TElement}"/> set singleton.
		/// </summary>
		public static Set<TElement> Instance => Singleton.Instance;

		/// <inheritdoc/>
		protected internal override Set<TElement> ComplimentImpl() => Universe;

		/// <inheritdoc/>
		protected override Boolean Contains([AllowNull] TElement element) => element is null;

		private static class Singleton {
			internal static readonly Empty<TElement> Instance = new Empty<TElement>();

			static Singleton() { }
		}
	}
}