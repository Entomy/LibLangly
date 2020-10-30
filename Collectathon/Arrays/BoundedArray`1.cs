using System;
using System.Diagnostics.CodeAnalysis;
using Collectathon.Filters;
using Defender.Exceptions;
using Philosoft;

namespace Collectathon.Arrays {
	/// <summary>
	/// Represents a bounded array, a type of flexible array who's size can not grow above its capacity, but can freely resize below that capacity.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the array.</typeparam>
	/// <see cref="BoundedArray{TIndex, TElement}"/>
	[Serializable]
	public sealed class BoundedArray<TElement> : FlexibleArray<TElement, BoundedArray<TElement>> {
		/// <summary>
		/// An empty <see cref="BoundedArray{TElement}"/> singleton.
		/// </summary>
		public static BoundedArray<TElement> Empty => Singleton.Instance;

		/// <summary>
		/// Initializes a new <see cref="BoundedArray{TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The maximum capacity.</param>
		public BoundedArray(nint capacity) : base(capacity, Filter.None) { }

		/// <summary>
		/// Initializes a new <see cref="BoundedArray{TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The maximum capacity.</param>
		/// <param name="filter">The type of filter to use.</param>
		public BoundedArray(nint capacity, Filter filter) : base(capacity, filter) { }

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="elements">The set of elements.</param>
		/// <param name="length">The length of this array.</param>
		/// <param name="filter">The type of filter to use.</param>
		private BoundedArray(Memory<TElement> elements, nint length, Filter<TElement> filter) : base(elements, length, filter) { }

		/// <summary>
		/// Converts the <paramref name="array"/> to a <see cref="BoundedArray{TElement}"/>.
		/// </summary>
		/// <param name="array">The <see cref="Array"/> to convert.</param>
		[SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "There is an alternative: one of the constructors.")]
		public static implicit operator BoundedArray<TElement>(TElement[] array) => !(array is null) ? new BoundedArray<TElement>(array, array.Length, NullFilter<TElement>.Instance) : Empty;

		/// <summary>
		/// Converts the <paramref name="memory"/> to a <see cref="BoundedArray{TElement}"/>.
		/// </summary>
		/// <param name="memory">The <see cref="Memory{T}"/> to convert.</param>
		[SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "There is an alternative: one of the constructors.")]
		public static implicit operator BoundedArray<TElement>(Memory<TElement> memory) => new BoundedArray<TElement>(memory, memory.Length, NullFilter<TElement>.Instance);

		/// <inheritdoc/>
		protected override void Add(TElement element) {
			if (Length == Capacity) {
				throw CollectionExceededCapacityException.With(Capacity);
			}
			base.Add(element);
		}

		/// <inheritdoc/>
		protected override BoundedArray<TElement> Clone() => new BoundedArray<TElement>(Elements.Clone(), Length, Filterer.Clone());

		/// <inheritdoc/>
		protected override void Insert(nint index, TElement element) {
			if (Length == Capacity) {
				throw CollectionExceededCapacityException.With(Capacity);
			}
			base.Insert(index, element);
		}

		private static class Singleton {
			static Singleton() { }

			internal static readonly BoundedArray<TElement> Instance = new BoundedArray<TElement>(0);
		}
	}
}
