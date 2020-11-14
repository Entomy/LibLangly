using System;
using Philosoft;
using Streamy.Bases;

namespace Streamy.Buffers {
	public interface IReadBuffer : ILengthy, IPeekable<Byte, Errors>, ISeekable<Byte, Errors>, IShiftable {
		/// <summary>
		/// The capacity of this buffer.
		/// </summary>
		nint Capacity { get; }

		/// <summary>
		/// The datastream being buffered.
		/// </summary>
		StreamBase Stream { get; }

		/// <summary>
		/// Gets the <see cref="Byte"/> at the specified <paramref name="index"/>.
		/// </summary>
		/// <param name="index">The index of the <see cref="Byte"/> to get.</param>
		/// <returns>The <see cref="Byte"/> at the <paramref name="index"/>.</returns>
		Byte this[nint index] { get; }

		/// <summary>
		/// Stores the <paramref name="value"/> into this buffer.
		/// </summary>
		/// <param name="value">The <see cref="Byte"/> to store.</param>
		void Store(Byte value);

		/// <summary>
		/// Attempts to ensure <paramref name="amount"/> bytes are loaded into the buffer, loading more only if necessary.
		/// </summary>
		/// <param name="amount">The amount of <see cref="Byte"/> to have loaded.</param>
		/// <returns><see langword="true"/> if the load was successful; otherwise, <see langword="false"/>.</returns>
		Boolean TryEnsureLoaded(nint amount) => TryEnsureLoaded(amount, out _);

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

		Boolean TryLoad() => TryLoad(out _);

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

		Boolean TryLoad(nint amount) => TryLoad(amount, out _);

		Boolean TryLoad(nint amount, out Errors error) {
			error = Errors.None;
			for (nint i = 0; i < amount; i++) {
				if (!TryLoad(out error)) {
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Attempts to store the <paramref name="value"/> into this buffer.
		/// </summary>
		/// <param name="value">The <see cref="Byte"/> to store.</param>
		/// <returns><see langword="true"/> if the store was successful; otherwise, <see langword="false"/>.</returns>
		Boolean TryStore(Byte value) => TryStore(value, out _);

		/// <summary>
		/// Attempts to store the <paramref name="value"/> into this buffer.
		/// </summary>
		/// <param name="value">The <see cref="Byte"/> to store.</param>
		/// <param name="error">The <see cref="Errors"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the store was successful; otherwise, <see langword="false"/>.</returns>
		Boolean TryStore(Byte value, out Errors error);
	}
}
