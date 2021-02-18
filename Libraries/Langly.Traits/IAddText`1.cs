using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can have other elements added to it, with additional textual operations.
	/// </summary>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IAddText<out TResult> : IAdd<Char, TResult> where TResult : IAddText<TResult> {
		/// <summary>
		/// Adds the elements to this object.
		/// </summary>
		/// <param name="elements">The elements to add.</param>
		/// <returns>If the add occurred successfully, returns a <typeparamref name="TResult"/> containing the original and added elements; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull]
		TResult Add([AllowNull] String elements) => elements is not null ? Add(elements.AsMemory()) : (TResult)this;
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>If the add occurred successfully, returns a <typeparamref name="TResult"/> containing the original and added elements; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull]
		public static TResult Add<TResult>([AllowNull] this IAddText<TResult> collection, [AllowNull] String elements) where TResult : IAddText<TResult> => collection is not null ? collection.Add(elements) : (TResult)collection;
	}
}
