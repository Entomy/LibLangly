using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type can be read from.
	/// </summary>
	/// <typeparam name="TElement">The type of the element to read.</typeparam>
	public interface IRead<TElement> {
		/// <summary>
		/// Can this be read from?
		/// </summary>
		/// <remarks>
		/// This is a state indicator. Of course an <see cref="IRead{TElement}"/> can be read from, but that doesn't mean it can always be read from. Rather, this being <see langword="true"/> indicates the type can currently be read from.
		/// </remarks>
		Boolean Readable { get; }

		/// <summary>
		/// Reads a <typeparamref name="TElement"/>.
		/// </summary>
		/// <param name="element">The <typeparamref name="TElement"/> value that was read.</param>
		void Read([MaybeNull] out TElement element);
	}
}
