using Defender;
using Philosoft;
using System;

namespace Streamy.Serialization {
	/// <summary>
	/// Represents a serialization payload; the serialized data.
	/// </summary>
	public sealed class Payload : IAddable<Boolean>, IAddable<Byte>, IAddable<SByte>, IAddable<Char>, IAddable<Decimal>, IAddable<Double>, IAddable<Single>, IAddable<Int16>, IAddable<UInt16>, IAddable<Int32>, IAddable<UInt32>, IAddable<Int64>, IAddable<UInt64>, IAddable<Payload>, IAddable<ISerializable>, ILengthy, IResizable {
		/// <summary>
		/// The actual data of the payload.
		/// </summary>
		private Byte[] Data = Array.Empty<Byte>();

		/// <inheritdoc/>
		private nint Capacity => Data.Length;

		/// <inheritdoc/>
		nint IResizable.Capacity => Capacity;

		/// <inheritdoc/>
		public nint Length { get; private set; }

		/// <inheritdoc/>
		void IAddable<Boolean>.Add(Boolean element) {
			Byte[] bytes = BitConverter.GetBytes(element);
			while (Length + bytes.Length <= Capacity) {
				this.Grow();
			}
			bytes.CopyTo(Data, Length);
			Length += bytes.Length;
		}

		/// <inheritdoc/>
		void IAddable<Byte>.Add(Byte element) {
			if (Length == Capacity) {
				this.Grow();
			}
			Data[Length++] = element;
		}

		/// <inheritdoc/>
		void IAddable<SByte>.Add(SByte element) {
			if (Length == Capacity) {
				this.Grow();
			}
			Data[Length++] = unchecked((Byte)element);
		}

		/// <inheritdoc/>
		void IAddable<Char>.Add(Char element) {
			Byte[] bytes = BitConverter.GetBytes(element);
			while (Length + bytes.Length <= Capacity) {
				this.Grow();
			}
			bytes.CopyTo(Data, Length);
			Length += bytes.Length;
		}

		/// <inheritdoc/>
		void IAddable<Decimal>.Add(Decimal element) {
			foreach (Int32 val in Decimal.GetBits(element)) {
				this.Add(val);
			}
		}

		/// <inheritdoc/>
		void IAddable<Double>.Add(Double element) {
			Byte[] bytes = BitConverter.GetBytes(element);
			while (Length + bytes.Length <= Capacity) {
				this.Grow();
			}
			bytes.CopyTo(Data, Length);
			Length += bytes.Length;
		}

		/// <inheritdoc/>
		void IAddable<Single>.Add(Single element) {
			Byte[] bytes = BitConverter.GetBytes(element);
			while (Length + bytes.Length <= Capacity) {
				this.Grow();
			}
			bytes.CopyTo(Data, Length);
			Length += bytes.Length;
		}

		/// <inheritdoc/>
		void IAddable<Int16>.Add(Int16 element) {
			Byte[] bytes = BitConverter.GetBytes(element);
			while (Length + bytes.Length <= Capacity) {
				this.Grow();
			}
			bytes.CopyTo(Data, Length);
			Length += bytes.Length;
		}

		/// <inheritdoc/>
		void IAddable<UInt16>.Add(UInt16 element) {
			Byte[] bytes = BitConverter.GetBytes(element);
			while (Length + bytes.Length <= Capacity) {
				this.Grow();
			}
			bytes.CopyTo(Data, Length);
			Length += bytes.Length;
		}

		/// <inheritdoc/>
		void IAddable<Int32>.Add(Int32 element) {
			Byte[] bytes = BitConverter.GetBytes(element);
			while (Length + bytes.Length <= Capacity) {
				this.Grow();
			}
			bytes.CopyTo(Data, Length);
			Length += bytes.Length;
		}

		/// <inheritdoc/>
		void IAddable<UInt32>.Add(UInt32 element) {
			Byte[] bytes = BitConverter.GetBytes(element);
			while (Length + bytes.Length <= Capacity) {
				this.Grow();
			}
			bytes.CopyTo(Data, Length);
			Length += bytes.Length;
		}

		/// <inheritdoc/>
		void IAddable<Int64>.Add(Int64 element) {
			Byte[] bytes = BitConverter.GetBytes(element);
			while (Length + bytes.Length <= Capacity) {
				this.Grow();
			}
			bytes.CopyTo(Data, Length);
			Length += bytes.Length;
		}

		/// <inheritdoc/>
		void IAddable<UInt64>.Add(UInt64 element) {
			Byte[] bytes = BitConverter.GetBytes(element);
			while (Length + bytes.Length <= Capacity) {
				this.Grow();
			}
			bytes.CopyTo(Data, Length);
			Length += bytes.Length;
		}

		/// <inheritdoc/>
		void IAddable<Payload>.Add(Payload element) {
			while (Length + element.Length <= Capacity) {
				this.Grow();
			}
			element.Data.CopyTo(Data, Length);
			Length += element.Length;
		}

		/// <inheritdoc/>
		void IAddable<ISerializable>.Add(ISerializable element) => this.Add(element.Serialize());

		/// <inheritdoc/>
		void IResizable.Resize(nint capacity) {
			Guard.GreaterThan(Length, nameof(Length), capacity);
			Byte[] newData = new Byte[capacity];
			Data.AsSpan().CopyTo(newData.AsSpan());
			Data = newData;
		}
	}
}
