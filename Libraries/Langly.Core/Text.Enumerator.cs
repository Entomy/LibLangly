using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Langly.DataStructures.Views;

namespace Langly {
	public partial class Text : ISequenceBidi<Glyph, Text.Enumerator> {
		/// <inheritdoc/>
		[return: NotNull]
		public override Enumerator GetEnumerator() => throw new NotImplementedException();

		/// <inheritdoc/>
		[return: NotNull]
		public ReverseView<Glyph, ISequenceBidi<Glyph, Enumerator>, Enumerator> Reverse() => throw new NotImplementedException();

		/// <summary>
		/// Provides the enumerator for <see cref="Text"/>.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[StructLayout(LayoutKind.Auto)]
		public struct Enumerator : IEnumeratorBidi<Glyph> {
			/// <inheritdoc/>
			public Glyph Current { get; }

			/// <inheritdoc/>
			public nint Count { get; }

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
