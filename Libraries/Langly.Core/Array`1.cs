using System;
using System.Diagnostics.CodeAnalysis;
using Langly.DataStructures;
using Langly.DataStructures.Lists;

namespace Langly {
	/// <summary>
	/// Represents an array of contiguous elements.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the array.</typeparam>
	public sealed partial class Array<TElement> : DataStructure<TElement, Array<TElement>, Array<TElement>.Enumerator>,
		ICapacity,
		IIndexRef<TElement>,
		IInsert<TElement, Chain<TElement>>,
		IShift,
		ISlice<Array<TElement>> {
		/// <summary>
		/// The backing memory.
		/// </summary>
		private readonly Memory<TElement> Memory;

		/// <summary>
		/// Initializes a new <see cref="Array{TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The capacity; how many elements it can hold.</param>
		[SuppressMessage("Performance", "HAA0501:Explicit new array type allocation", Justification = "This has to allocate by definition.")]
		public Array(nint capacity) => Memory = new TElement[capacity];

		/// <summary>
		/// Initializes a new <see cref="Array{TElement}"/> with the given <paramref name="memory"/>.
		/// </summary>
		/// <param name="memory">The backing memory of the array.</param>
		public Array(Memory<TElement> memory) => Memory = memory;

		/// <summary>
		/// An empty <see cref="Array{TElement}"/> singleton.
		/// </summary>
		public static Array<TElement> Empty => Singleton.Instance;

		/// <inheritdoc/>
		public nint Capacity => Memory.Length;

		/// <inheritdoc/>
		public override nint Count => Memory.Length;

		/// <inheritdoc/>
		public ref TElement this[nint index] => ref Memory.Span[(Int32)index];

		/// <inheritdoc/>
		ref readonly TElement IIndexRefReadOnly<nint, TElement>.this[nint index] => ref this[index];

		/// <summary>
		/// Initializes a new <see cref="Array{TElement}"/> with the given <paramref name="memory"/>.
		/// </summary>
		/// <param name="memory">The backing memory of the array.</param>
		public static implicit operator Array<TElement>(Memory<TElement> memory) => new Array<TElement>(memory);

		/// <inheritdoc/>
		[return: NotNull]
		Chain<TElement> IInsert<nint, TElement, Chain<TElement>>.Insert(nint index, [AllowNull] TElement element) {
			Chain<TElement> result;
			if (element is null) {
				result = new Chain<TElement>(Memory);
			} else {
				result = new Chain<TElement>();
				_ = result
					.Add(this.Slice(0, index))
					.Add(element)
					.Add(this.Slice(index, Count - index));
			}
			return result;
		}

		/// <inheritdoc/>
		void IShift.ShiftLeft(nint amount) {
			Int32 i = 0;
			for (; i < Count - amount; i++) {
				Memory.Span[i] = Memory.Span[(Int32)(i + amount)];
			}
			for (; i < Count; i++) {
				Memory.Span[i] = default;
			}
		}

		/// <inheritdoc/>
		void IShift.ShiftRight(nint amount) {
			Int32 i = (Int32)(Count - 1);
			for (; i >= amount; i--) {
				Memory.Span[i] = Memory.Span[(Int32)(i - amount)];
			}
			for (; i >= 0; i--) {
				Memory.Span[i] = default;
			}
		}

		/// <inheritdoc/>
		Array<TElement> ISlice<Array<TElement>>.Slice(nint start, nint length) => new Array<TElement>(Memory.Slice((Int32)start, (Int32)length));

		private static class Singleton {
			internal static readonly Array<TElement> Instance = new Array<TElement>(Memory<TElement>.Empty);

			static Singleton() { }
		}
	}
}
