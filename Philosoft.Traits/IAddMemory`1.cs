using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type can have other elements added to it, with additional array and memory operations.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IAddMemory<TElement> : IAdd<TElement> {
		/// <summary>
		/// Adds the elements to this object, as a batch.
		/// </summary>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		void Add([AllowNull] params TElement?[] elements);

		/// <summary>
		/// Adds the elements to this object, as a batch.
		/// </summary>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		void Add(ArraySegment<TElement?> elements);

		/// <summary>
		/// Adds the elements to this object, as a batch.
		/// </summary>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		void Add(Memory<TElement?> elements);

		/// <summary>
		/// Adds the elements to this object, as a batch.
		/// </summary>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		void Add(ReadOnlyMemory<TElement?> elements);
	}
}
