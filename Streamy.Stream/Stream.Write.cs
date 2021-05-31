using System;
using System.Traits;

namespace Streamy {
	public partial class Stream : IWrite<Byte>, IWrite<SByte>, IWrite<Int16>, IWrite<UInt16>, IWrite<Int32>, IWrite<UInt32>, IWrite<Int64>, IWrite<UInt64>, IWrite<Single>, IWrite<Double>, IWrite<Decimal>, IWrite<Boolean> {
		/// <inheritdoc/>
		public Boolean Writable => ((WriteBuffer as IWrite<Byte>)?.Writable ?? false) || Base.Writable;

		/// <inheritdoc/>
		public void Add(Byte element) => Write(element);

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public void Add(SByte element) => Write(element);

		/// <inheritdoc/>
		public void Add(Int16 element) => Write(element);

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public void Add(UInt16 element) => Write(element);

		/// <inheritdoc/>
		public void Add(Int32 element) => Write(element);

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public void Add(UInt32 element) => Write(element);

		/// <inheritdoc/>
		public void Add(Int64 element) => Write(element);

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public void Add(UInt64 element) => Write(element);

		/// <inheritdoc/>
		public void Add(Single element) => Write(element);

		/// <inheritdoc/>
		public void Add(Double element) => Write(element);

		/// <inheritdoc/>
		public void Add(Decimal element) => Write(element);

		/// <inheritdoc/>
		public void Add(Boolean element) => Write(element);

		/// <inheritdoc/>
		public void Write(Byte element) {
			if (WriteBuffer is not null) {
				WriteBuffer.Write(element);
			} else {
				Base.Write(element);
			}
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public void Write(SByte element) {
			if (WriteBuffer is not null) {
				WriteBuffer.Write((Byte)element);
			} else {
				Base.Write((Byte)element);
			}
		}

		/// <inheritdoc/>
		public void Write(Int16 element) {
			if (WriteBuffer is not null) {
				foreach (Byte @byte in BitConverter.GetBytes(element)) {
					WriteBuffer.Write(@byte);
				}
			} else {
				foreach (Byte @byte in BitConverter.GetBytes(element)) {
					Base.Write(@byte);
				}
			}
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public void Write(UInt16 element) {
			if (WriteBuffer is not null) {
				foreach (Byte @byte in BitConverter.GetBytes(element)) {
					WriteBuffer.Write(@byte);
				}
			} else {
				foreach (Byte @byte in BitConverter.GetBytes(element)) {
					Base.Write(@byte);
				}
			}
		}

		/// <inheritdoc/>
		public void Write(Int32 element) {
			if (WriteBuffer is not null) {
				foreach (Byte @byte in BitConverter.GetBytes(element)) {
					WriteBuffer.Write(@byte);
				}
			} else {
				foreach (Byte @byte in BitConverter.GetBytes(element)) {
					Base.Write(@byte);
				}
			}
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public void Write(UInt32 element) {
			if (WriteBuffer is not null) {
				foreach (Byte @byte in BitConverter.GetBytes(element)) {
					WriteBuffer.Write(@byte);
				}
			} else {
				foreach (Byte @byte in BitConverter.GetBytes(element)) {
					Base.Write(@byte);
				}
			}
		}

		/// <inheritdoc/>
		public void Write(Int64 element) {
			if (WriteBuffer is not null) {
				foreach (Byte @byte in BitConverter.GetBytes(element)) {
					WriteBuffer.Write(@byte);
				}
			} else {
				foreach (Byte @byte in BitConverter.GetBytes(element)) {
					Base.Write(@byte);
				}
			}
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public void Write(UInt64 element) {
			if (WriteBuffer is not null) {
				foreach (Byte @byte in BitConverter.GetBytes(element)) {
					WriteBuffer.Write(@byte);
				}
			} else {
				foreach (Byte @byte in BitConverter.GetBytes(element)) {
					Base.Write(@byte);
				}
			}
		}

		/// <inheritdoc/>
		public void Write(Single element) {
			if (WriteBuffer is not null) {
				foreach (Byte @byte in BitConverter.GetBytes(element)) {
					WriteBuffer.Write(@byte);
				}
			} else {
				foreach (Byte @byte in BitConverter.GetBytes(element)) {
					Base.Write(@byte);
				}
			}
		}

		/// <inheritdoc/>
		public void Write(Double element) {
			if (WriteBuffer is not null) {
				foreach (Byte @byte in BitConverter.GetBytes(element)) {
					WriteBuffer.Write(@byte);
				}
			} else {
				foreach (Byte @byte in BitConverter.GetBytes(element)) {
					Base.Write(@byte);
				}
			}
		}

		/// <inheritdoc/>
		public void Write(Decimal element) => throw new NotImplementedException();

		/// <inheritdoc/>
		public void Write(Boolean element) {
			if (WriteBuffer is not null) {
				foreach (Byte @byte in BitConverter.GetBytes(element)) {
					WriteBuffer.Write(@byte);
				}
			} else {
				foreach (Byte @byte in BitConverter.GetBytes(element)) {
					Base.Write(@byte);
				}
			}
		}
	}
}
