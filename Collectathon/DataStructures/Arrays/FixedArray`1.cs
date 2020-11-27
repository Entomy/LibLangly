using System;
using System.Diagnostics.CodeAnalysis;
using Langly.DataStructures.Filters;

namespace Langly.DataStructures.Arrays {
	/// <summary>
	/// Represents a fixed array, a type of array whos size is always its initial capacity.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the array.</typeparam>
	/// <seealso cref="FixedArray{TElement, TIndex}"/>
	[Serializable]
	public sealed class FixedArray<TElement> : Array<TElement, FixedArray<TElement>> {
		/// <summary>
		/// An empty <see cref="FixedArray{TElement}"/> singleton.
		/// </summary>
		public static FixedArray<TElement> Empty => Singleton.Instance;

		/// <summary>
		/// Initialize a new <see cref="FixedArray{TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The capacity.</param>
		public FixedArray(nint capacity) : base(capacity, Filter.None) { }

		/// <summary>
		/// Initialize a new <see cref="FixedArray{TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The capacity.</param>
		/// <param name="filter">The type of filter to use.</param>
		public FixedArray(nint capacity, Filter filter) : base(capacity, filter) { }

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="elements">The set of elements.</param>
		/// <param name="length">The length of the array.</param>
		/// <param name="filterer">The <see cref="Filter{TElement}"/> responsible for this data structure.</param>
		private FixedArray(Memory<TElement> elements, nint length, Filter<TElement> filterer) : base(elements, length, filterer) { }

		/// <summary>
		/// Converts the <paramref name="array"/> to a <see cref="FixedArray{TElement}"/>.
		/// </summary>
		/// <param name="array">The <see cref="Array"/> to convert.</param>
		[SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "There is an alternative: one of the constructors.")]
		public static implicit operator FixedArray<TElement>(TElement[] array) => !(array is null) ? new FixedArray<TElement>(array, array.Length, NullFilter<TElement>.Instance) : Empty;

		/// <summary>
		/// Converts the <paramref name="memory"/> to a <see cref="FixedArray{TElement}"/>.
		/// </summary>
		/// <param name="memory">The <see cref="Memory{T}"/> to convert.</param>
		[SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "There is an alternative: one of the constructors.")]
		public static implicit operator FixedArray<TElement>(Memory<TElement> memory) => new FixedArray<TElement>(memory, memory.Length, NullFilter<TElement>.Instance);

		/// <inheritdoc/>
		protected override FixedArray<TElement> Clone() => new FixedArray<TElement>(Elements.Clone(), Length, Filterer.Clone());

		private static class Singleton {
			static Singleton() { }

			internal static readonly FixedArray<TElement> Instance = new FixedArray<TElement>(0);
		}
	}
}
