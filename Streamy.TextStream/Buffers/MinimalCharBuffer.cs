using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Streamy.Bases;

namespace Streamy.Buffers {
	[DebuggerDisplay("{ToString(),nq}")]
	internal sealed class MinimalCharBuffer : IReadCharBuffer {
		/// <summary>
		/// The <see cref="StreamBase"/> being buffered.
		/// </summary>
		[DisallowNull, NotNull]
		private readonly CharStreamBase Base;

		/// <summary>
		/// The backing memory of this buffer.
		/// </summary>
		private readonly Char[] Memory = new Char[sizeof(Decimal) / sizeof(Char)];

		/// <inheritdoc/>
		public MinimalCharBuffer([DisallowNull] CharStreamBase @base) => Base = @base;

		/// <inheritdoc/>
		public nint Capacity => sizeof(Decimal) / sizeof(Char);

		/// <inheritdoc/>
		public nint Count { get; private set; }

		/// <inheritdoc/>
		public Boolean Readable => Count > 0;

		/// <inheritdoc/>
		public void Clear() => Count = 0;

		/// <inheritdoc/>
		public void Peek([DisallowNull, NotNull] out Char[] elements, nint required) {
			for (; Count < required; Count++) {
				Base.Read(out Memory[Count]);
			}
			elements = Memory;
		}

		/// <inheritdoc/>
		public void Peek([DisallowNull, NotNull] out Byte[] elements, nint required) => throw new NotImplementedException();

		/// <inheritdoc/>
		public void Peek([MaybeNull] out Byte element) => throw new NotImplementedException();

		/// <inheritdoc/>
		public void Peek([MaybeNull] out Char element) {
			if (Count > 0) {
				element = Memory[Count - 1];
			} else {
				Base.Read(out Memory[Count++]);
				element = Memory[Count - 1];
			}
		}

		/// <inheritdoc/>
		public void Read([MaybeNull] out Byte element) => throw new NotImplementedException();

		/// <inheritdoc/>
		public void Read([MaybeNull] out Char element) {
			if (Count == 0) {
				Base.Read(out element);
			} else {
				element = Memory[--Count];
			}
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() {
			StringBuilder builder = new StringBuilder();
			nint i = 0;
			foreach (Byte element in Memory) {
				if (++i == Count) {
					_ = builder.Append(element);
					break;
				} else if (i == 5) {
					_ = builder.Append(element).Append("...");
					break;
				} else {
					_ = builder.Append(element);
				}
			}
			return $"{builder}";
		}
	}
}
