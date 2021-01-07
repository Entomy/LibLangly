using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Langly.DataStructures.Views;

namespace Langly.DataStructures {
	public partial class Array<TElement> : ISequenceBidi<TElement, Array<TElement>.Enumerator> {
		/// <inheritdoc/>
		[return: NotNull]
		public override Array<TElement>.Enumerator GetEnumerator() => new Enumerator(Memory.Slice(0, (Int32)Count));

		/// <inheritdoc/>
		[return: NotNull]
		public ReverseView<TElement, ISequenceBidi<TElement, Array<TElement>.Enumerator>, Array<TElement>.Enumerator> Reverse() => new ReverseView<TElement, ISequenceBidi<TElement, Array<TElement>.Enumerator>, Enumerator>(this);

		/// <summary>
		/// Provides enumeration over <see cref="Array{TElement}"/>.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[StructLayout(LayoutKind.Auto)]
		public struct Enumerator : IEnumeratorBidi<TElement>, IEquals<Enumerator> {
			private readonly Memory<TElement> Elements;

			private Int32 i;

			internal Enumerator(Memory<TElement> elements) {
				Elements = elements;
				i = -1;
			}

			/// <inheritdoc/>
			public TElement Current => Elements.Span[i];

			public static Boolean operator !=(Array<TElement>.Enumerator left, Array<TElement>.Enumerator right) => !left.Equals(right);

			public static Boolean operator ==(Array<TElement>.Enumerator left, Array<TElement>.Enumerator right) => left.Equals(right);

			/// <inheritdoc/>
			public override Boolean Equals([AllowNull] System.Object obj) {
				switch (obj) {
				case Enumerator enumerator:
					return Equals(enumerator);
				default:
					return false;
				}
			}

			/// <inheritdoc/>
			public Boolean Equals(Array<TElement>.Enumerator other) => Elements.Equals(other.Elements);

			/// <inheritdoc/>
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override Int32 GetHashCode() => 0;

			/// <inheritdoc/>
			public Boolean MoveNext() => ++i < Elements.Length;

			/// <inheritdoc/>
			public Boolean MovePrevious() => i-- > 0;

			/// <inheritdoc/>
			public void ResetBeginning() => i = -1;

			/// <inheritdoc/>
			public void ResetEnding() => i = Elements.Length;
		}
	}
}
