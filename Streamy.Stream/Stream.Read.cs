using System;
using System.Traits;

namespace Streamy {
	public partial class Stream : IRead<Byte>, IRead<SByte>, IRead<Int16>, IRead<UInt16>, IRead<Int32>, IRead<UInt32>, IRead<Int64>, IRead<UInt64>, IRead<Single>, IRead<Double>, IRead<Decimal>, IRead<Boolean> {
		/// <inheritdoc/>
		public Boolean Readable => ReadBuffer.Readable || Base.Readable;

		/// <inheritdoc/>
		public virtual void Read(out Byte element) => ReadBuffer.Read(out element);

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public virtual void Read(out SByte element) {
			ReadBuffer.Read(out Byte elmnt);
			element = (SByte)elmnt;
		}

		/// <inheritdoc/>
		public virtual void Read(out Int16 element) {
			Peek(out element);
			ReadBuffer.Clear();
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public virtual void Read(out UInt16 element) {
			Peek(out element);
			ReadBuffer.Clear();
		}

		/// <inheritdoc/>
		public virtual void Read(out Int32 element) {
			Peek(out element);
			ReadBuffer.Clear();
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public virtual void Read(out UInt32 element) {
			Peek(out element);
			ReadBuffer.Clear();
		}

		/// <inheritdoc/>
		public virtual void Read(out Int64 element) {
			Peek(out element);
			ReadBuffer.Clear();
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public virtual void Read(out UInt64 element) {
			Peek(out element);
			ReadBuffer.Clear();
		}

		/// <inheritdoc/>
		public virtual void Read(out Single element) {
			Peek(out element);
			ReadBuffer.Clear();
		}

		/// <inheritdoc/>
		public virtual void Read(out Double element) {
			Peek(out element);
			ReadBuffer.Clear();
		}

		/// <inheritdoc/>
		public virtual void Read(out Decimal element) {
			Read(out Int32 lo);
			Read(out Int32 mid);
			Read(out Int32 hi);
			Read(out Boolean isNegative);
			Read(out Byte scale);
			element = new Decimal(lo, mid, hi, isNegative, scale);
		}

		/// <inheritdoc/>
		public virtual void Read(out Boolean element) {
			Peek(out element);
			ReadBuffer.Clear();
		}
	}
}
