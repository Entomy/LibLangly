using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures {
	/// <summary>
	/// Indicates the type associates values of two other types.
	/// </summary>
	public interface IAssociative<out TIndexView, out TElementView> {
		/// <summary>
		/// Gets a view of the indicies of this collection.
		/// </summary>
		[DisallowNull, NotNull]
		TIndexView Indicies { get; }

		/// <summary>
		/// Gets a view of the elements of this collection.
		/// </summary>
		[DisallowNull, NotNull]
		TElementView Elements { get; }
	}
}
