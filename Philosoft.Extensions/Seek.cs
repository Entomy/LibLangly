using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Seeks to the <paramref name="offset"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to seek.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="offset">The offset of <typeparamref name="TElement"/> from the current position to seek to.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Seek<TElement, TResult>([AllowNull] this ISeek<TElement, TResult> collection, nint offset) where TResult : ISeek<TElement, TResult> => collection is not null ? collection.Seek(offset) : (TResult)collection;
	}
}
