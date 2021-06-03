using System;
using System.Traits;

namespace Streamy {
	public partial class Stream : IPeek<Byte>, IPeek<SByte>, IPeek<Int16>, IPeek<UInt16>, IPeek<Int32>, IPeek<UInt32>, IPeek<Int64>, IPeek<UInt64>, IPeek<Single>, IPeek<Double>, IPeek<Decimal>, IPeek<Boolean> {
		/// <inheritdoc/>
		public virtual void Peek(out Byte element) => ReadBuffer.Peek(out element);

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public virtual void Peek(out SByte element) {
			ReadBuffer.Peek(out Byte elmnt);
			element = (SByte)elmnt;
		}

		/// <inheritdoc/>
		public virtual void Peek(out Int16 element) {
			ReadBuffer.Peek(out Byte[] buffer, sizeof(Int16));
			element = BitConverter.ToInt16(buffer, 0);
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public virtual void Peek(out UInt16 element) {
			ReadBuffer.Peek(out Byte[] buffer, sizeof(UInt16));
			element = BitConverter.ToUInt16(buffer, 0);
		}

		/// <inheritdoc/>
		public virtual void Peek(out Int32 element) {
			ReadBuffer.Peek(out Byte[] buffer, sizeof(Int32));
			element = BitConverter.ToInt32(buffer, 0);
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public virtual void Peek(out UInt32 element) {
			ReadBuffer.Peek(out Byte[] buffer, sizeof(UInt32));
			element = BitConverter.ToUInt32(buffer, 0);
		}

		/// <inheritdoc/>
		public virtual void Peek(out Int64 element) {
			ReadBuffer.Peek(out Byte[] buffer, sizeof(Int64));
			element = BitConverter.ToInt64(buffer, 0);
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public virtual void Peek(out UInt64 element) {
			ReadBuffer.Peek(out Byte[] buffer, sizeof(UInt64));
			element = BitConverter.ToUInt64(buffer, 0);
		}

		/// <inheritdoc/>
		public virtual void Peek(out Single element) {
			ReadBuffer.Peek(out Byte[] buffer, sizeof(Single));
			element = BitConverter.ToSingle(buffer, 0);
		}

		/// <inheritdoc/>
		public virtual void Peek(out Double element) {
			ReadBuffer.Peek(out Byte[] buffer, sizeof(Double));
			element = BitConverter.ToDouble(buffer, 0);
		}

		/// <inheritdoc/>
		public virtual void Peek(out Decimal element) {
			ReadBuffer.Peek(out Byte[] buffer, sizeof(Decimal));
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
			ReadBuffer.Peek(out Byte[] buffer, sizeof(Boolean));
			element = BitConverter.ToBoolean(buffer, 0);
		}
	}
}
