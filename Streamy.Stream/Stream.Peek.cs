using System;
using System.Runtime.CompilerServices;
using System.Traits;

namespace Streamy {
	public partial class Stream : IPeek<Byte>, IPeek<SByte>, IPeek<Int16>, IPeek<UInt16>, IPeek<Int32>, IPeek<UInt32>, IPeek<Int64>, IPeek<UInt64>, IPeek<Single>, IPeek<Double>, IPeek<Decimal>, IPeek<Boolean> {
		/// <inheritdoc/>
		public virtual void Peek(out Byte element) => Source.Peek(out element);

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public virtual void Peek(out SByte element) {
			Source.Peek(out Byte elmnt);
			element = (SByte)elmnt;
		}

		/// <inheritdoc/>
		public virtual void Peek(out Int16 element) {
			Source.Peek(out Byte[] buffer, sizeof(Int16));
			switch (Endianness) {
			case Endian.Big:
				element = (Int16)(buffer[0] << 8);
				element += buffer[1];
				break;
			case Endian.Little:
				element = buffer[0];
				element += (Int16)(buffer[1] << 8);
				break;
			default:
				throw new NotSupportedException($"Not sure how to read '{Endianness}' endian streams.");
			}
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public virtual void Peek(out UInt16 element) {
			Source.Peek(out Byte[] buffer, sizeof(UInt16));
			switch (Endianness) {
			case Endian.Big:
				element = (UInt16)(buffer[0] << 8);
				element += buffer[1];
				break;
			case Endian.Little:
				element = buffer[0];
				element += (UInt16)(buffer[1] << 8);
				break;
			default:
				throw new NotSupportedException($"Not sure how to read '{Endianness}' endian streams.");
			}
		}

		/// <inheritdoc/>
		public virtual void Peek(out Int32 element) {
			Source.Peek(out Byte[] buffer, sizeof(Int32));
			switch (Endianness) {
			case Endian.Big:
				element = buffer[0] << 24;
				element += buffer[1] << 16;
				element += buffer[2] << 8;
				element += buffer[3];
				break;
			case Endian.Little:
				element = buffer[0];
				element += buffer[1] << 8;
				element += buffer[2] << 16;
				element += buffer[3] << 24;
				break;
			default:
				throw new NotSupportedException($"Not sure how to read '{Endianness}' endian streams.");
			}
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public virtual void Peek(out UInt32 element) {
			Source.Peek(out Byte[] buffer, sizeof(UInt32));
			switch (Endianness) {
			case Endian.Big:
				element = (UInt32)(buffer[0] << 24);
				element += (UInt32)(buffer[1] << 16);
				element += (UInt32)(buffer[2] << 8);
				element += buffer[3];
				break;
			case Endian.Little:
				element = buffer[0];
				element += (UInt32)(buffer[1] << 8);
				element += (UInt32)(buffer[2] << 16);
				element += (UInt32)(buffer[3] << 24);
				break;
			default:
				throw new NotSupportedException($"Not sure how to read '{Endianness}' endian streams.");
			}
		}

		/// <inheritdoc/>
		public virtual void Peek(out Int64 element) {
			Source.Peek(out Byte[] buffer, sizeof(Int64));
			switch (Endianness) {
			case Endian.Big:
				element = (Int64)buffer[0] << 56;
				element += (Int64)buffer[1] << 48;
				element += (Int64)buffer[2] << 40;
				element += (Int64)buffer[3] << 36;
				element += (Int64)buffer[4] << 24;
				element += (Int64)buffer[5] << 16;
				element += (Int64)buffer[6] << 8;
				element += buffer[7];
				break;
			case Endian.Little:
				element = buffer[0];
				element += (Int64)buffer[1] << 8;
				element += (Int64)buffer[2] << 16;
				element += (Int64)buffer[3] << 24;
				element += (Int64)buffer[4] << 32;
				element += (Int64)buffer[5] << 40;
				element += (Int64)buffer[6] << 48;
				element += (Int64)buffer[7] << 56;
				break;
			default:
				throw new NotSupportedException($"Not sure how to read '{Endianness}' endian streams.");
			}
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public virtual void Peek(out UInt64 element) {
			Source.Peek(out Byte[] buffer, sizeof(UInt64));
			switch (Endianness) {
			case Endian.Big:
				element = (UInt64)buffer[0] << 56;
				element += (UInt64)buffer[1] << 48;
				element += (UInt64)buffer[2] << 40;
				element += (UInt64)buffer[3] << 36;
				element += (UInt64)buffer[4] << 24;
				element += (UInt64)buffer[5] << 16;
				element += (UInt64)buffer[6] << 8;
				element += buffer[7];
				break;
			case Endian.Little:
				element = buffer[0];
				element += (UInt64)buffer[1] << 8;
				element += (UInt64)buffer[2] << 16;
				element += (UInt64)buffer[3] << 24;
				element += (UInt64)buffer[4] << 32;
				element += (UInt64)buffer[5] << 40;
				element += (UInt64)buffer[6] << 48;
				element += (UInt64)buffer[7] << 56;
				break;
			default:
				throw new NotSupportedException($"Not sure how to read '{Endianness}' endian streams.");
			}
		}

		/// <inheritdoc/>
		public virtual void Peek(out Single element) {
			Peek(out Int32 elmt);
			element = Unsafe.As<Int32, Single>(ref elmt);
		}

		/// <inheritdoc/>
		public virtual void Peek(out Double element) {
			Peek(out Int64 elmt);
			element = Unsafe.As<Int64, Double>(ref elmt);
		}

		/// <inheritdoc/>
		public virtual void Peek(out Decimal element) {
			Source.Peek(out Byte[] buffer, sizeof(Decimal));
			Int32 i = 0;
			Int32 lo = BitConverter.ToInt32(buffer, i);
			i += sizeof(Int32);
			Int32 mid = BitConverter.ToInt32(buffer, i);
			i += sizeof(Int32);
			Int32 hi = BitConverter.ToInt32(buffer, i);
			i += sizeof(Int32);
			Boolean isNegative = BitConverter.ToBoolean(buffer, i);
			i += sizeof(Boolean);
			Byte scale = buffer[i];
			element = new Decimal(lo, mid, hi, isNegative, scale);
		}

		/// <inheritdoc/>
		public virtual void Peek(out Boolean element) {
			Source.Peek(out Byte elmt);
			element = elmt > 0;
		}
	}
}
