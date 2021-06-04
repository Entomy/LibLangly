using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Streamy.Buffers {
	/// <summary>
	/// Indicates the type can be used as a buffer for <see cref="IRead{TElement}"/> operations.
	/// </summary>
	[CLSCompliant(false)]
	public interface IReadBuffer : ICapacity, IClear, ICount, IControlled, IPeek<Byte>, ISeek, IShift {
		/// <summary>
		/// Peeks at the <paramref name="required"/> amount of <see cref="Byte"/>.
		/// </summary>
		/// <param name="elements">The <see cref="ReadOnlySpan{T}"/> of <see cref="Byte"/> that were read.</param>
		/// <param name="required">The amount of <see cref="Byte"/> required to be read and returned.</param>
		public void Peek([DisallowNull, NotNull] out Byte[] elements, nint required);
	}
}
