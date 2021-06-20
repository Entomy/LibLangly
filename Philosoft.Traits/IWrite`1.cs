using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type can be written to.
	/// </summary>
	/// <typeparam name="TElement">The type of the element to write.</typeparam>
	public interface IWrite<in TElement> : IAdd<TElement> {
		/// <summary>
		/// Can this be written to?
		/// </summary>
		/// <remarks>
		/// This is a state indicator. Of course an <see cref="IWrite{TElement}"/> can be written to, but that doesn't mean it can always be written to. Rather, this being <see langword="true"/> indicates the type can currently be written to.
		/// </remarks>
		Boolean Writable { get; }

		/// <summary>
		/// Writes a <paramref name="element"/>.
		/// </summary>
		/// <param name="element">The <typeparamref name="TElement"/> value to write.</param>
		void Write([AllowNull] TElement element);
	}
}
