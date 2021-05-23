using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Traits;
using Langly;

namespace Stringier.Patterns {
	internal partial class CaptureMemory {
		/// <summary>
		/// Provides enumeration over a <see cref="CaptureMemory"/>.
		/// </summary>
		[StructLayout(LayoutKind.Auto)]
		private struct Enumerator : IEnumerator<Char> {
			/// <summary>
			/// The memory being enumerated.
			/// </summary>
			private readonly ReadOnlyMemory<Char> Memory;

			private Int32 i;

			/// <summary>
			/// Initializes a new <see cref="Enumerator"/>.
			/// </summary>
			/// <param name="memory">The memory to enumerate.</param>
			public Enumerator(ReadOnlyMemory<Char> memory) {
				Memory = memory;
				i = -1;
			}

			/// <inheritdoc/>
			public Char Current => Memory.Span[i];

			/// <inheritdoc/>
			[NotNull]
			Object System.Collections.IEnumerator.Current => Current;

			/// <inheritdoc/>
			public nint Count => Memory.Length;

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
			public override String ToString() => Memory.ToString();

			/// <inheritdoc/>
			[return: NotNull]
			public String ToString(nint amount) => $"{Memory.Slice(0, (Int32)amount)}...";
		}
	}
}
