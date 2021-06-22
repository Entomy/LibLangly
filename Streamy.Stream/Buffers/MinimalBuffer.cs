using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Streamy.Bases;

namespace Streamy.Buffers {
	[DebuggerDisplay("{ToString(5),nq}")]
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
		public Int32 Capacity => sizeof(Decimal);

		/// <inheritdoc/>
		public Int32 Count { get; private set; }

		/// <inheritdoc/>
		public Boolean Disposed { get; set; }

		/// <inheritdoc/>
		public Int32 Position {
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
		public void Peek([MaybeNull] out Byte element) {
			if (Count > 0) {
				element = Memory[Count - 1];
			} else {
				Base.Read(out Memory[Count++]);
				element = Memory[Count - 1];
			}
		}

		/// <inheritdoc/>
		public void Peek([DisallowNull, NotNull] out Byte[] elements, Int32 required) {
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
				element = Memory[--Count];
			}
		}

		/// <inheritdoc/>
		public void Seek(Int32 offset) {
			if (Count == 0) {
				Base.Seek(offset);
			} else {
				throw new NotImplementedException();
			}
		}

		/// <inheritdoc/>
		public void ShiftLeft() => Count--;

		/// <inheritdoc/>
		public void ShiftLeft(Int32 amount) => Count -= amount;

		/// <inheritdoc/>
		public void ShiftRight() => Count++;

		/// <inheritdoc/>
		public void ShiftRight(Int32 amount) => Count += amount;

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Base.ToString();

		/// <inheritdoc/>
		[return: NotNull]
		public String ToString(Int32 amount) {
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
