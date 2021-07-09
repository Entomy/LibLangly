using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type is indexable by reference, read only.
	/// </summary>
	/// <typeparam name="TIndex">The type used to index the collection.</typeparam>
	/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
	[SuppressMessage("Major Code Smell", "S3246:Generic type parameters should be co/contravariant when possible", Justification = "That's not possible with ref returns.")]
	public interface IIndexRefReadOnly<in TIndex, TElement> where TIndex : notnull {
		/// <summary>
		/// Gets a read-only reference to the element at the specified index.
		/// </summary>
		/// <param name="index">The index of the element to get a reference for.</param>
		/// <returns>A read-only reference to the element at the specified index.</returns>
		ref readonly TElement this[[DisallowNull] TIndex index] { get; }
	}
}
