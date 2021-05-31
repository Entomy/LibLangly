using System;
using System.Diagnostics.CodeAnalysis;
using Collectathon.Buffers;
using Streamy.Bases;

namespace Streamy {
	internal sealed class MinimalBuffer : IReadBuffer {
		/// <summary>
		/// The <see cref="StreamBase"/> being buffered.
		/// </summary>
		[DisallowNull, NotNull]
		private readonly StreamBase Base;

		/// <summary>
		/// The backing memory of this buffer.
		/// </summary>
		private readonly Byte[] Memory = new Byte[sizeof(Decimal)];

		/// <inheritdoc/>
		public MinimalBuffer([DisallowNull] StreamBase @base) => Base = @base;

		/// <inheritdoc/>
		public nint Capacity => sizeof(Decimal);

		/// <inheritdoc/>
		public nint Count { get; private set; }

		/// <inheritdoc/>
		public Boolean Readable => Count > 0;

		/// <inheritdoc/>
		public void Clear() => Count = 0;

		/// <inheritdoc/>
		public void Peek([MaybeNull] out Byte element) {
			if (Count > 0) {
				element = Memory[Count];
			} else {
				Base.Read(out Memory[Count++]);
				element = Memory[Count - 1];
			}
		}

		/// <inheritdoc/>
		public void Peek([DisallowNull, NotNull] out Byte[] elements, nint required) {
			for (; Count < required; Count++) {
				Base.Read(out Memory[Count]);
			}
			elements = Memory;
		}

		/// <inheritdoc/>
		public void Read([MaybeNull] out Byte element) {
			if (Count == 0) {
				Base.Read(out element);
			} else {
				element = Memory[Count - 1];
				Count--;
			}
		}
	}
}
