using System;
using System.Diagnostics.CodeAnalysis;
using Langly.Traits;

namespace Langly.Traits {
	/// <summary>
	/// Indicates the type can have other elements postpended onto it, with additional textual operations.
	/// </summary>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IPostpendText<out TResult> : IPostpend<Char, TResult> where TResult : IPostpendText<TResult> {
		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Postpend([AllowNull] String elements) => elements is not null ? Postpend(elements.AsMemory()) : (TResult)this;
	}
}

namespace Langly {
	public static partial class TraitExtensions {
		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Postpend<TResult>([AllowNull] this IPostpendText<TResult> collection, [AllowNull] String elements) where TResult : IPostpendText<TResult> => collection is not null ? collection.Postpend(elements) : (TResult)collection;
	}
}
