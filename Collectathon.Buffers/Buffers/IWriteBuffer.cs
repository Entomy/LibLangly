using System;
using System.Traits;

namespace Collectathon.Buffers {
	/// <summary>
	/// Indicates the type can be used as a buffer for <see cref="IWrite{TElement}"/> operations.
	/// </summary>
	[CLSCompliant(false)]
	public interface IWriteBuffer : ICapacity, IClear, ICount, IWrite<Byte>, IWrite<SByte>, IWrite<Int16>, IWrite<UInt16>, IWrite<Int32>, IWrite<UInt32>, IWrite<Int64>, IWrite<UInt64>, IWrite<Single>, IWrite<Double>, IWrite<Decimal> { }
}
