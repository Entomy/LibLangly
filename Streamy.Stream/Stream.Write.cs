using System;
using System.Traits;

namespace Streamy {
	public partial class Stream : IWrite<Byte>, IWrite<SByte>, IWrite<Int16>, IWrite<UInt16>, IWrite<Int32>, IWrite<UInt32>, IWrite<Int64>, IWrite<UInt64>, IWrite<Single>, IWrite<Double>, IWrite<Decimal>, IWrite<Boolean> {
		/// <inheritdoc/>
		public Boolean Writable => ((WriteBuffer as IWrite<Byte>)?.Writable ?? false) || Base.Writable;

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
		public virtual void Write(Byte element) {
			if (WriteBuffer is not null) {
				WriteBuffer.Write(element);
			} else {
				Base.Write(element);
			}
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public virtual void Write(SByte element) {
			if (WriteBuffer is not null) {
				WriteBuffer.Write((Byte)element);
			} else {
				Base.Write((Byte)element);
			}
		}

		/// <inheritdoc/>
		public virtual void Write(Int16 element) {
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
		public virtual void Write(UInt16 element) {
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
		public virtual void Write(Int32 element) {
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
		public virtual void Write(UInt32 element) {
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
		public virtual void Write(Int64 element) {
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
		public virtual void Write(UInt64 element) {
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
		public virtual void Write(Single element) {
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
		public virtual void Write(Double element) {
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
		public virtual void Write(Decimal element) => throw new NotImplementedException();

		/// <inheritdoc/>
		public virtual void Write(Boolean element) {
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
