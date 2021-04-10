using System;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type can be seeked.
	/// </summary>
	/// <typeparam name="TElement">The type of the element to seek.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface ISeek<TElement, out TResult> where TResult : ISeek<TElement, TResult> {
		/// <summary>
		/// Can this be seeked?
		/// </summary>
		/// <remarks>
		/// This is a state indicator. Of course an <see cref="ISeek{TElement, TError}"/> can be seeked, but that doesn't mean it can always be seeked. Rather, this being <see langword="true"/> indicates the type can currently be seeked.
		/// </remarks>
		Boolean Seekable { get; }

		/// <summary>
		/// The position within the datastream, counted by <typeparamref name="TElement"/> offset.
		/// </summary>
		nint Position { get; set; }

		/// <summary>
		/// Seeks to the <paramref name="offset"/>.
		/// </summary>
		/// <param name="offset">The offset of <typeparamref name="TElement"/> from the current position to seek to.</param>
		[return: NotNull]
		TResult Seek(nint offset);
	}
}
