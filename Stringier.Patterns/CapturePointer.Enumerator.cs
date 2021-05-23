using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Traits;

namespace Stringier.Patterns {
	internal partial class CapturePointer {
		/// <summary>
		/// Provides enumeration over a <see cref="CapturePointer"/>.
		/// </summary>
		[StructLayout(LayoutKind.Auto)]
		private unsafe struct Enumerator : IEnumerator<Char> {
			private readonly Char* Pointer;

			private Int32 i;

			public Enumerator(Char* pointer, Int32 length) {
				Pointer = pointer;
				Count = length;
				i = -1;
			}

			/// <inheritdoc/>
			public Char Current => Pointer[i];

			/// <inheritdoc/>
			[NotNull]
			Object System.Collections.IEnumerator.Current => Current;

			/// <inheritdoc/>
			public nint Count { get; }

			/// <inheritdoc/>
			public readonly void Dispose() { /* No-op */ }

			/// <inheritdoc/>
			[return: NotNull]
			public IEnumerator<Char> GetEnumerator() => this;

			/// <inheritdoc/>
			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => this;

			/// <inheritdoc/>
			System.Collections.Generic.IEnumerator<Char> System.Collections.Generic.IEnumerable<Char>.GetEnumerator() => this;

			/// <inheritdoc/>
			public Boolean MoveNext() => ++i < Count;

			/// <inheritdoc/>
			public void Reset() => i = -1;

			/// <inheritdoc/>
			public override String ToString() => new String(Pointer, 0, (Int32)Count);

			/// <inheritdoc/>
			[return: NotNull]
			public String ToString(nint amount) => $"{new String(Pointer, 0, (Int32)amount)}...";
		}
	}
}
