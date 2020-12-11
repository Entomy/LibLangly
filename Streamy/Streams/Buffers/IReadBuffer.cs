using System;
using System.Collections.Generic;
using Langly.Streams.Bases;

namespace Langly.Streams.Buffers {
	/// <summary>
	/// Indicates the type can be used as a read buffer for a <see cref="Streams.Stream"/>.
	/// </summary>
	public interface IReadBuffer : ILengthy, IPeekable<Byte, Errors>, IReadOnlyIndexable<Byte>, IReadOnlySliceable<ReadOnlyMemory<Byte>>, ISeekable<Byte, Errors>, IShiftable, IEquatable<Byte[]>, IEquatable<IReadOnlyList<Byte>> {
		/// <summary>
		/// The capacity of this buffer.
		/// </summary>
		nint Capacity { get; }

		/// <summary>
		/// The datastream being buffered.
		/// </summary>
		StreamBase Stream { get; }

		/// <summary>
		/// Ensures <paramref name="amount"/> bytes are loaded into the buffer, loading more only if necessary.
		/// </summary>
		/// <param name="amount">The amount of <see cref="Byte"/> to have loaded.</param>
		void EnsureLoaded(nint amount) {
			while (Length < amount) {
				Load();
			}
		}

		/// <summary>
		/// Loads a byte into the buffer.
		/// </summary>
		void Load() {
			Stream.Read(out Byte value);
			Store(value);
		}

		/// <summary>
		/// Peeks multiple bytes.
		/// </summary>
		/// <param name="elements">The span to fill.</param>
		void Peek(Span<Byte> elements);

		/// <summary>
		/// Reads multiple bytes.
		/// </summary>
		/// <param name="elements">The span to fill.</param>
		/// <remarks>
		/// This assumes the read will never fail, which is an assumption that generally doesn't hold up. It is strongly recommended to use <see cref="TryRead(Span{Byte}, out Errors)"/> instead.
		/// </remarks>
		void Read(Span<Byte> elements) {
			for (Int32 i = 0; i < elements.Length; i++) {
				Read(out elements[i]);
			}
		}

		/// <summary>
		/// Stores the <paramref name="value"/> into this buffer.
		/// </summary>
		/// <param name="value">The <see cref="Byte"/> to store.</param>
		void Store(Byte value);

		/// <summary>
		/// Attempts to ensure <paramref name="amount"/> bytes are loaded into the buffer, loading more only if necessary.
		/// </summary>
		/// <param name="amount">The amount of <see cref="Byte"/> to have loaded.</param>
		/// <param name="error">The <see cref="Errors"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the load was successful; otherwise, <see langword="false"/>.</returns>
		Boolean TryEnsureLoaded(nint amount, out Errors error) {
			error = Errors.None;
			while (Length < amount) {
				if (!TryLoad(out error)) {
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Attempts to load a byte into the buffer.
		/// </summary>
		/// <param name="error">The <see cref="Errors"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the load was successful; otherwise, <see langword="false"/>.</returns>
		Boolean TryLoad(out Errors error) {
			if (Length >= Capacity) {
				error = Errors.OverloadedBuffer;
				return false;
			}
			if (!Stream.TryRead(out Byte value, out error)) {
				return false;
			}
			Store(value);
			return true;
		}

		/// <summary>
		/// Attempts to peek multiple bytes.
		/// </summary>
		/// <param name="elements">The span to fill.</param>
		/// <param name="error">The <see cref="Errors"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the peek was successful; otherwise, <see langword="false"/>.</returns>
		Boolean TryPeek(Span<Byte> elements, out Errors error);

		/// <summary>
		/// Attempts to read multiple bytes.
		/// </summary>
		/// <param name="elements">The span to fill.</param>
		/// <param name="error">The <see cref="Errors"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the read was successful; otherwise, <see langword="false"/>.</returns>
		Boolean TryRead(Span<Byte> elements, out Errors error) {
			for (Int32 i = 0; i < elements.Length; i++) {
				if (!TryRead(out elements[i], out error)) {
					return false;
				}
			}
			error = default;
			return true;
		}

		/// <summary>
		/// Attempts to store the <paramref name="value"/> into this buffer.
		/// </summary>
		/// <param name="value">The <see cref="Byte"/> to store.</param>
		/// <param name="error">The <see cref="Errors"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the store was successful; otherwise, <see langword="false"/>.</returns>
		Boolean TryStore(Byte value, out Errors error);
	}
}
