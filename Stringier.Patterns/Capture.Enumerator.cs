using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Traits;

namespace Stringier.Patterns {
	public partial class Capture {
		/// <summary>
		/// Provides enumeration over a <see cref="Capture"/>.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[StructLayout(LayoutKind.Auto)]
		public struct Enumerator : IEnumerator<Char> {
			/// <summary>
			/// The text being enumerated.
			/// </summary>
			private readonly ReadOnlyMemory<Char> Text;

			private Int32 i;

			/// <summary>
			/// Initializes a new <see cref="Enumerator"/>.
			/// </summary>
			/// <param name="text">The text to enumerate.</param>
			public Enumerator(ReadOnlyMemory<Char> text) {
				Text = text;
				i = -1;
			}

			/// <inheritdoc/>
			public Char Current => Text.Span[i];

			/// <inheritdoc/>
			[NotNull]
			Object System.Collections.IEnumerator.Current => Current;

			/// <inheritdoc/>
			public nint Count => Text.Length;

			/// <inheritdoc/>
			public readonly void Dispose() { /* No-op */ }

			/// <inheritdoc/>
			[return: NotNull]
			public IEnumerator<Char> GetEnumerator() => this;

			/// <inheritdoc/>
			[return: NotNull]
			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => this;

			/// <inheritdoc/>
			[return: NotNull]
			System.Collections.Generic.IEnumerator<Char> System.Collections.Generic.IEnumerable<Char>.GetEnumerator() => this;

			/// <inheritdoc/>
			public Boolean MoveNext() => ++i < Count;

			/// <inheritdoc/>
			public void Reset() => i = -1;

			/// <inheritdoc/>
			public override String ToString() => Text.ToString();

			/// <inheritdoc/>
			[return: NotNull]
			public String ToString(nint amount) => $"{Text.Slice(0, (Int32)amount)}...";
		}
	}
}
