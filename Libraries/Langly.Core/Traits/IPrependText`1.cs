using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can have other elements prepended onto it, with additional textual operations.
	/// </summary>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IPrependText<out TResult> : IPrepend<Char, TResult> where TResult : IPrependText<TResult> {
		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>If the prepend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and prepended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Prepend([AllowNull] String elements) => elements is not null ? Prepend(elements.AsMemory()) : (TResult)this;
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>If the prepend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and prepended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Prepend<TResult>([AllowNull] this IPrependText<TResult> collection, [AllowNull] String elements) where TResult : IPrependText<TResult> => collection is not null ? collection.Prepend(elements) : (TResult)collection;
	}
}
