using System;
using System.Traits;
using System.Traits.Concepts;

namespace Streamy.Buffers {
	/// <summary>
	/// Indicates the type can be used as a buffer for <see cref="IWrite{TElement}"/> operations.
	/// </summary>
	[CLSCompliant(false)]
	public interface IWriteBuffer : ICapacity, IClear, ICount, IControlled, IWrite<Byte>, ISeek, IShift { }
}
