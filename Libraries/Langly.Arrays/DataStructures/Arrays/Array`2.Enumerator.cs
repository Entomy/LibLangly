using Langly.DataStructures.Views;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Langly.DataStructures.Arrays {
	public partial class Array<TElement, TSelf> : ISequenceBidi<TElement, Array<TElement, TSelf>.Enumerator> {
		/// <inheritdoc/>
		[return: NotNull]
		public override Array<TElement, TSelf>.Enumerator GetEnumerator() => new Enumerator(Elements.Slice(0, (Int32)Count));

		/// <inheritdoc/>
		[return: NotNull]
		public ReverseView<TElement, ISequenceBidi<TElement, Array<TElement, TSelf>.Enumerator>, Array<TElement, TSelf>.Enumerator> Reverse() => throw new NotImplementedException();

		/// <summary>
		/// Provides enumeration over <see cref="Array{TElement, TSelf}"/>.
		/// </summary>
		[StructLayout(LayoutKind.Auto)]
		public struct Enumerator : IEnumeratorBidi<TElement>, IEquatable<Enumerator> {
			private readonly ReadOnlyMemory<TElement> Elements;

			private nint i;

			/// <summary>
			/// Initializes a new <see cref="Enumerator"/>.
			/// </summary>
			/// <param name="elements">The elements to enumerate over.</param>
			public Enumerator(ReadOnlyMemory<TElement> elements) {
				Elements = elements;
				i = -1;
			}

			/// <inheritdoc/>
			public TElement Current => Elements.Span[(Int32)i];

			/// <inheritdoc/>
			public nint Count => Elements.Length;

			public static Boolean operator !=(Enumerator left, Enumerator right) => !left.Equals(right);

			public static Boolean operator ==(Enumerator left, Enumerator right) => left.Equals(right);

			/// <inheritdoc/>
			public override Boolean Equals(System.Object obj) {
				switch (obj) {
				case Enumerator enumerator:
					return Equals(enumerator);
				default:
					return false;
				}
			}

			/// <inheritdoc/>
			public Boolean Equals(Enumerator other) => Elements.Equals(other.Elements);

			/// <inheritdoc/>
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override Int32 GetHashCode() => base.GetHashCode();

			/// <inheritdoc/>
			public Boolean MoveNext() => ++i < Count;

			/// <inheritdoc/>
			public Boolean MovePrevious() => i-- > 0;

			/// <inheritdoc/>
			public void ResetBeginning() => i = -1;

			/// <inheritdoc/>
			public void ResetEnding() => i = Count;
		}
	}
}
