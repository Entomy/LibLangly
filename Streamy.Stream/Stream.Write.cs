using System;
using System.Runtime.CompilerServices;
using System.Traits;

namespace Streamy {
	public partial class Stream : IWrite<Byte>, IWrite<SByte>, IWrite<Int16>, IWrite<UInt16>, IWrite<Int32>, IWrite<UInt32>, IWrite<Int64>, IWrite<UInt64>, IWrite<Single>, IWrite<Double>, IWrite<Decimal>, IWrite<Boolean> {
		/// <inheritdoc/>
		public Boolean Writable => Sink.Writable;

		/// <inheritdoc/>
		public virtual void Add(Byte element) => Write(element);

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public virtual void Add(SByte element) => Write(element);

		/// <inheritdoc/>
		public virtual void Add(Int16 element) => Write(element);

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public virtual void Add(UInt16 element) => Write(element);

		/// <inheritdoc/>
		public virtual void Add(Int32 element) => Write(element);

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public virtual void Add(UInt32 element) => Write(element);

		/// <inheritdoc/>
		public virtual void Add(Int64 element) => Write(element);

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public virtual void Add(UInt64 element) => Write(element);

		/// <inheritdoc/>
		public virtual void Add(Single element) => Write(element);

		/// <inheritdoc/>
		public virtual void Add(Double element) => Write(element);

		/// <inheritdoc/>
		public void Add(Decimal element) => Write(element);

		/// <inheritdoc/>
		public virtual void Add(Boolean element) => Write(element);

		/// <inheritdoc/>
		public virtual void Write(Byte element) => Sink.Write(element);

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public virtual void Write(SByte element) => Sink.Write((Byte)(element));

		/// <inheritdoc/>
		public virtual void Write(Int16 element) {
			switch (Endianness) {
			case Endian.Big:
				Sink.Write((Byte)(element >> 8));
				Sink.Write((Byte)element);
				break;
			case Endian.Little:
				Sink.Write((Byte)element);
				Sink.Write((Byte)(element >> 8));
				break;
			default:
				throw new NotSupportedException($"Not sure how to write '{Endianness}' endian streams.");
			}
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public virtual void Write(UInt16 element) {
			switch (Endianness) {
			case Endian.Big:
				Sink.Write((Byte)(element >> 8));
				Sink.Write((Byte)element);
				break;
			case Endian.Little:
				Sink.Write((Byte)element);
				Sink.Write((Byte)(element >> 8));
				break;
			default:
				throw new NotSupportedException($"Not sure how to write '{Endianness}' endian streams.");
			}
		}

		/// <inheritdoc/>
		public virtual void Write(Int32 element) {
			switch (Endianness) {
			case Endian.Big:
				Sink.Write((Byte)(element >> 24));
				Sink.Write((Byte)(element >> 16));
				Sink.Write((Byte)(element >> 8));
				Sink.Write((Byte)element);
				break;
			case Endian.Little:
				Sink.Write((Byte)element);
				Sink.Write((Byte)(element >> 8));
				Sink.Write((Byte)(element >> 16));
				Sink.Write((Byte)(element >> 24));
				break;
			default:
				throw new NotSupportedException($"Not sure how to write '{Endianness}' endian streams.");
			}
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public virtual void Write(UInt32 element) {
			switch (Endianness) {
			case Endian.Big:
				Sink.Write((Byte)(element >> 24));
				Sink.Write((Byte)(element >> 16));
				Sink.Write((Byte)(element >> 8));
				Sink.Write((Byte)element);
				break;
			case Endian.Little:
				Sink.Write((Byte)element);
				Sink.Write((Byte)(element >> 8));
				Sink.Write((Byte)(element >> 16));
				Sink.Write((Byte)(element >> 24));
				break;
			default:
				throw new NotSupportedException($"Not sure how to write '{Endianness}' endian streams.");
			}
		}

		/// <inheritdoc/>
		public virtual void Write(Int64 element) {
			switch (Endianness) {
			case Endian.Big:
				Sink.Write((Byte)(element >> 56));
				Sink.Write((Byte)(element >> 48));
				Sink.Write((Byte)(element >> 40));
				Sink.Write((Byte)(element >> 32));
				Sink.Write((Byte)(element >> 24));
				Sink.Write((Byte)(element >> 16));
				Sink.Write((Byte)(element >> 8));
				Sink.Write((Byte)element);
				break;
			case Endian.Little:
				Sink.Write((Byte)element);
				Sink.Write((Byte)(element >> 8));
				Sink.Write((Byte)(element >> 16));
				Sink.Write((Byte)(element >> 24));
				Sink.Write((Byte)(element >> 32));
				Sink.Write((Byte)(element >> 40));
				Sink.Write((Byte)(element >> 48));
				Sink.Write((Byte)(element >> 56));
				break;
			default:
				throw new NotSupportedException($"Not sure how to write '{Endianness}' endian streams.");
			}
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public virtual void Write(UInt64 element) {
			switch (Endianness) {
			case Endian.Big:
				Sink.Write((Byte)(element >> 56));
				Sink.Write((Byte)(element >> 48));
				Sink.Write((Byte)(element >> 40));
				Sink.Write((Byte)(element >> 32));
				Sink.Write((Byte)(element >> 24));
				Sink.Write((Byte)(element >> 16));
				Sink.Write((Byte)(element >> 8));
				Sink.Write((Byte)element);
				break;
			case Endian.Little:
				Sink.Write((Byte)element);
				Sink.Write((Byte)(element >> 8));
				Sink.Write((Byte)(element >> 16));
				Sink.Write((Byte)(element >> 24));
				Sink.Write((Byte)(element >> 32));
				Sink.Write((Byte)(element >> 40));
				Sink.Write((Byte)(element >> 48));
				Sink.Write((Byte)(element >> 56));
				break;
			default:
				throw new NotSupportedException($"Not sure how to write '{Endianness}' endian streams.");
			}
		}

		/// <inheritdoc/>
		public virtual void Write(Single element) {
			ref Int32 elmt = ref Unsafe.As<Single, Int32>(ref element);
			Write(elmt);
		}

		/// <inheritdoc/>
		public virtual void Write(Double element) {
			ref Int64 elmt = ref Unsafe.As<Double, Int64>(ref element);
			Write(elmt);
		}

		/// <inheritdoc/>
		public virtual void Write(Decimal element) => throw new NotImplementedException();

		/// <inheritdoc/>
		public virtual void Write(Boolean element) => Sink.Write((Byte)(element ? 1 : 0));
	}
}
