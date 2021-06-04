using System;
using System.Traits;

namespace Streamy {
	public partial class Stream : IRead<Byte>, IRead<SByte>, IRead<Int16>, IRead<UInt16>, IRead<Int32>, IRead<UInt32>, IRead<Int64>, IRead<UInt64>, IRead<Single>, IRead<Double>, IRead<Decimal>, IRead<Boolean> {
		/// <inheritdoc/>
		public Boolean Readable => Source.Readable;

		/// <inheritdoc/>
		public void Read(out Byte element) => Source.Read(out element);

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public void Read(out SByte element) {
			Source.Read(out Byte elmnt);
			element = (SByte)elmnt;
		}

		/// <inheritdoc/>
		public void Read(out Int16 element) {
			Peek(out element);
			Source.ShiftLeft(sizeof(Int16));
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public void Read(out UInt16 element) {
			Peek(out element);
			Source.ShiftLeft(sizeof(UInt16));
		}

		/// <inheritdoc/>
		public void Read(out Int32 element) {
			Peek(out element);
			Source.ShiftLeft(sizeof(Int32));
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public void Read(out UInt32 element) {
			Peek(out element);
			Source.ShiftLeft(sizeof(UInt32));
		}

		/// <inheritdoc/>
		public void Read(out Int64 element) {
			Peek(out element);
			Source.ShiftLeft(sizeof(Int64));
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public void Read(out UInt64 element) {
			Peek(out element);
			Source.ShiftLeft(sizeof(UInt64));
		}

		/// <inheritdoc/>
		public void Read(out Single element) {
			Peek(out element);
			Source.ShiftLeft(sizeof(Single));
		}

		/// <inheritdoc/>
		public void Read(out Double element) {
			Peek(out element);
			Source.ShiftLeft(sizeof(Double));
		}

		/// <inheritdoc/>
		public void Read(out Decimal element) {
			Read(out Int32 lo);
			Read(out Int32 mid);
			Read(out Int32 hi);
			Read(out Boolean isNegative);
			Read(out Byte scale);
			element = new Decimal(lo, mid, hi, isNegative, scale);
		}

		/// <inheritdoc/>
		public void Read(out Boolean element) {
			Peek(out element);
			Source.ShiftLeft(sizeof(Boolean));
		}
	}
}
