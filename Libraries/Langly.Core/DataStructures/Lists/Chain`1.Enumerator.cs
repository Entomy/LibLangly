using Langly.DataStructures.Views;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Langly.DataStructures.Lists {
	public partial class Chain<TElement> : ISequenceBidi<TElement, Chain<TElement>.Enumerator> {
		/// <inheritdoc/>
		public override Chain<TElement>.Enumerator GetEnumerator() => new Enumerator(this);

		/// <inheritdoc/>
		public ReverseView<TElement, ISequenceBidi<TElement, Chain<TElement>.Enumerator>, Chain<TElement>.Enumerator> Reverse() => throw new NotImplementedException();

		/// <summary>
		/// Provides enumeration over a <see cref="Chain{TElement}"/>.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[StructLayout(LayoutKind.Auto)]
		public readonly struct Enumerator : IEnumeratorBidi<TElement> {
			private readonly Chain<TElement> Chain;

			public Enumerator(Chain<TElement> chain) => Chain = chain;

			/// <inheritdoc/>
			public TElement Current => throw new NotImplementedException();

			/// <inheritdoc/>
			public nint Count => Chain.Count;

			/// <inheritdoc/>
			public Boolean MoveNext() => throw new NotImplementedException();

			/// <inheritdoc/>
			public Boolean MovePrevious() => throw new NotImplementedException();

			/// <inheritdoc/>
			public void ResetBeginning() => throw new NotImplementedException();

			/// <inheritdoc/>
			public void ResetEnding() => throw new NotImplementedException();
		}
	}
}
