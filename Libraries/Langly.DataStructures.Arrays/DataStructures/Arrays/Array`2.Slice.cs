using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Langly.DataStructures.Views;

namespace Langly.DataStructures.Arrays {
	public partial class Array<TElement, TSelf> : ISlice<Array<TElement, TSelf>.Slice> {
		/// <inheritdoc/>
		[return: NotNull]
		Array<TElement, TSelf>.Slice ISlice<Array<TElement, TSelf>.Slice>.Slice(nint start, nint length) => new Slice(Elements.Slice((Int32)start, (Int32)length));

		/// <summary>
		/// Provides slices of <see cref="Array{TElement, TSelf}"/>.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[StructLayout(LayoutKind.Auto)]
		public readonly struct Slice :
			IEquals<Slice>, IEquals<TSelf>,
			IIndexRef<TElement>,
			ISequenceBidi<TElement, Enumerator>,
			ISlice<Slice> {
			/// <summary>
			/// The backing memory.
			/// </summary>
			private readonly Memory<TElement> Elements;

			/// <summary>
			/// Initialize a new <see cref="Array{TElement, TSelf}.Slice"/>.
			/// </summary>
			/// <param name="elements">The elements of the slice.</param>
			internal Slice(Memory<TElement> elements) => Elements = elements;

			/// <inheritdoc/>
			public nint Count => Elements.Length;

			/// <inheritdoc/>
			public ref TElement this[nint index] => ref Elements.Span[(Int32)index];

			/// <inheritdoc/>
			ref readonly TElement IIndexRefReadOnly<nint, TElement>.this[nint index] => ref this[index];

			public static Boolean operator !=(Slice left, Slice right) => !left.Equals(right);

			public static Boolean operator !=(Slice left, TSelf right) => !left.Equals(right);

			public static Boolean operator !=(TSelf left, Slice right) => !right.Equals(left);

			public static Boolean operator ==(Slice left, Slice right) => left.Equals(right);

			public static Boolean operator ==(Slice left, TSelf right) => left.Equals(right);

			public static Boolean operator ==(TSelf left, Slice right) => right.Equals(left);

			/// <inheritdoc/>
			public override Boolean Equals([AllowNull] System.Object obj) {
				switch (obj) {
				case Slice slice:
					return Equals(slice);
				case TSelf array:
					return Equals(array);
				default:
					return false;
				}
			}

			/// <inheritdoc/>
			public Boolean Equals(Slice other) => Elements.Equals(other.Elements);

			/// <inheritdoc/>
			public Boolean Equals([AllowNull] TSelf other) => other is not null && Elements.Equals(other.Elements);

			/// <inheritdoc/>
			public override Int32 GetHashCode() => base.GetHashCode();

			/// <inheritdoc/>
			Slice ISlice<Slice>.Slice(nint start, nint length) => new Slice(Elements.Slice((Int32)start, (Int32)length));

			/// <inheritdoc/>
			[return: NotNull]
			public ReverseView<TElement, ISequenceBidi<TElement, Array<TElement, TSelf>.Enumerator>, Array<TElement, TSelf>.Enumerator> Reverse() => new ReverseView<TElement, ISequenceBidi<TElement, Enumerator>, Enumerator>(this);

			/// <inheritdoc/>
			[return: NotNull]
			public Array<TElement, TSelf>.Enumerator GetEnumerator() => new Enumerator(Elements);
		}
	}
}
