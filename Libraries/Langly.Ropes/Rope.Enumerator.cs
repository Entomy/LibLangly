using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Langly.Traits;

namespace Langly {
	public partial class Rope : ISequence<Glyph, Rope.Enumerator> {
		/// <inheritdoc/>
		[return: NotNull]
		public override Enumerator GetEnumerator() => throw new NotImplementedException();

		/// <summary>
		/// Provides the enumerator for <see cref="Rope"/>.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[StructLayout(LayoutKind.Auto)]
		public struct Enumerator : IEnumerator<Glyph> {
			/// <inheritdoc/>
			public Glyph Current { get; }

			/// <inheritdoc/>
			public nint Count { get; }

			/// <inheritdoc/>
			public Boolean MoveNext() => throw new NotImplementedException();

			/// <inheritdoc/>
			public void Reset() => throw new NotImplementedException();
		}
	}
}
