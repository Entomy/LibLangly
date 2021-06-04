using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Streamy.Bases;

namespace Streamy.Buffers {
	[DebuggerDisplay("{ToString(5),nq}")]
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
		public Boolean Disposed { get; set; }

		/// <inheritdoc/>
		public nint Position {
			get => Base.Position;
			set {
				if (Count == 0) {
					Base.Position = value;
				} else {
					throw new NotImplementedException();
				}
			}
		}

		/// <inheritdoc/>
		public Boolean Readable => Count > 0;

		/// <inheritdoc/>
		public Boolean Seekable => Base.Seekable || Count > 0;

		/// <inheritdoc/>
		public void Clear() => Count = 0;

		/// <inheritdoc/>
		public void Dispose(Boolean disposing) {
			if (!Disposed) {
				if (disposing) {
					DisposeManaged();
				}
				DisposeUnmanaged();
				NullLargeFields();
				Disposed = true;
			}
		}

		/// <inheritdoc/>
		public void Dispose() {
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		/// <inheritdoc/>
		public void DisposeManaged() => Base.Dispose();

		/// <inheritdoc/>
		public void DisposeUnmanaged() { /* No-op */ }

		/// <inheritdoc/>
		public void NullLargeFields() { /* No-op */ }

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
		public void Seek(nint offset) => throw new NotImplementedException();

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Base.ToString();

		/// <inheritdoc/>
		[return: NotNull]
		public String ToString(nint amount) {
			StringBuilder builder = new StringBuilder();
			nint i = 0;
			foreach (Byte element in Memory) {
				if (++i == Count) {
					_ = builder.Append(element);
					break;
				} else if (i == amount) {
					_ = builder.Append(element).Append("...");
					break;
				} else {
					_ = builder.Append(element).Append(", ");
				}
			}
			return $"[{builder}]";
		}

	}
}
