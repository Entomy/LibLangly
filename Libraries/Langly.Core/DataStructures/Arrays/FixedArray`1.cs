using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures.Arrays {
	/// <summary>
	/// Represents a fixed array, a type of array whos size is always its initial capacity.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the array.</typeparam>
	public sealed class FixedArray<TElement> : Array<TElement, FixedArray<TElement>> {
		/// <summary>
		/// Initializes a new <see cref="FixedArray{TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The capacity of the array.</param>
		public FixedArray(nint capacity) : base(capacity) => Count = capacity;

		/// <summary>
		/// Initializes a new <see cref="FixedArray{TElement}"/> with the given <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The elements of the array.</param>
		public FixedArray(Memory<TElement> elements) : base(elements) => Count = elements.Length;

		/// <summary>
		/// An empty <see cref="FixedArray{TElement}"/> singleton.
		/// </summary>
		public static FixedArray<TElement> Empty => Singleton.Instance;

		/// <inheritdoc/>
		[return: NotNull]
		protected override String StructurePrefix() => "Fixed";

		private static class Singleton {
			internal static readonly FixedArray<TElement> Instance = new FixedArray<TElement>(Memory<TElement>.Empty);

			static Singleton() { }
		}
	}
}
