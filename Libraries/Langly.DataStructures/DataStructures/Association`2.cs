using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Langly.DataStructures {
	/// <summary>
	/// Associates the <typeparamref name="TIndex"/> and <typeparamref name="TElement"/> objects.
	/// </summary>
	/// <typeparam name="TIndex">The type of the index.</typeparam>
	/// <typeparam name="TElement">The type of the element.</typeparam>
	[StructLayout(LayoutKind.Auto)]
	public struct Association<TIndex, TElement> : IEquals<Association<TIndex, TElement>> {
		/// <summary>
		/// The index of the <see cref="Element"/>.
		/// </summary>
		public readonly TIndex Index;

		/// <summary>
		/// The element.
		/// </summary>
		public TElement Element;

		/// <summary>
		/// Initialize a new <see cref="Association{TIndex, TElement}"/>.
		/// </summary>
		/// <param name="index">The index of the <paramref name="element"/>.</param>
		/// <param name="element">The element.</param>
		public Association(TIndex index, TElement element) {
			Index = index;
			Element = element;
		}

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Boolean Equals([AllowNull] System.Object obj) {
			switch (obj) {
			case Association<TIndex, TElement> other:
				return Equals(other);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals(Association<TIndex, TElement> other) => Index.Equals(other.Index) && Element.Equals(other.Element);

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public override Int32 GetHashCode() => Index.GetHashCode();

		/// <inheritdoc/>
		public override String ToString() => $"{Index}:{Element}";
	}
}
