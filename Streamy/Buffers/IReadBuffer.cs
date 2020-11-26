using System;
using System.Collections.Generic;
using Langly;
using Streamy.Bases;

namespace Streamy.Buffers {
	/// <summary>
	/// Indicates the type can be used as a read buffer for a <see cref="Streamy.Stream"/>.
	/// </summary>
	public interface IReadBuffer : ILengthy, IPeekable<Byte, Errors>, ISeekable<Byte, Errors>, IShiftable, IEquatable<Byte[]>, IEquatable<IReadOnlyList<Byte>> {
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
		/// Peeks two bytes.
		/// </summary>
		/// <param name="first">The first byte that was peeked.</param>
		/// <param name="second">The second byte that was peeked.</param>
		void Peek(out Byte first, out Byte second);

		/// <summary>
		/// Peeks three bytes.
		/// </summary>
		/// <param name="first">The first byte that was peeked.</param>
		/// <param name="second">The second byte that was peeked.</param>
		/// <param name="third">The third byte that was peeked.</param>
		void Peek(out Byte first, out Byte second, out Byte third);

		/// <summary>
		/// Peeks four bytes.
		/// </summary>
		/// <param name="first">The first byte that was peeked.</param>
		/// <param name="second">The second byte that was peeked.</param>
		/// <param name="third">The third byte that was peeked.</param>
		/// <param name="fourth">The fourth byte that was peeked.</param>
		void Peek(out Byte first, out Byte second, out Byte third, out Byte fourth);

		/// <summary>
		/// Reads two bytes.
		/// </summary>
		/// <param name="first">The first byte that was read.</param>
		/// <param name="second">The second byte that was read.</param>
		/// <remarks>
		/// This assumes the read will never fail, which is an assumption that generally doesn't hold up. It is strongly recommended to use <see cref="TryRead(out Byte, out Byte)"/> or <see cref="TryRead(out Byte, out Byte, out Errors)"/> instead.
		/// </remarks>
		void Read(out Byte first, out Byte second) {
			Read(out first);
			Read(out second);
		}

		/// <summary>
		/// Reads three bytes.
		/// </summary>
		/// <param name="first">The first byte that was read.</param>
		/// <param name="second">The second byte that was read.</param>
		/// <param name="third">The third byte that was read.</param>
		/// <remarks>
		/// This assumes the read will never fail, which is an assumption that generally doesn't hold up. It is strongly recommended to use <see cref="TryRead(out Byte, out Byte)"/> or <see cref="TryRead(out Byte, out Byte, out Errors)"/> instead.
		/// </remarks>
		void Read(out Byte first, out Byte second, out Byte third) {
			Read(out first, out second);
			Read(out third);
		}

		/// <summary>
		/// Reads four bytes.
		/// </summary>
		/// <param name="first">The first byte that was read.</param>
		/// <param name="second">The second byte that was read.</param>
		/// <param name="third">The third byte that was read.</param>
		/// <param name="fourth">The fourth byte that was read.</param>
		/// <remarks>
		/// This assumes the read will never fail, which is an assumption that generally doesn't hold up. It is strongly recommended to use <see cref="TryRead(out Byte, out Byte)"/> or <see cref="TryRead(out Byte, out Byte, out Errors)"/> instead.
		/// </remarks>
		void Read(out Byte first, out Byte second, out Byte third, out Byte fourth) {
			Read(out first, out second, out third);
			Read(out fourth);
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

		/// <summary>
		/// Attempts to load a byte into the buffer.
		/// </summary>
		/// <returns><see langword="true"/> if the load was successful; otherwise, <see langword="false"/>.</returns>
		Boolean TryLoad() => TryLoad(out _);

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
		/// Attempts to peek two bytes.
		/// </summary>
		/// <param name="first">The first byte that was peeked.</param>
		/// <param name="second">The second byte that was peeked.</param>
		/// <returns><see langword="true"/> if the peek was successful; otherwise, <see langword="false"/>.</returns>
		/// <seealso cref="TryPeek(out Byte, out Byte, out Errors)"/>
		Boolean TryPeek(out Byte first, out Byte second) => TryPeek(out first, out second, error: out _);

		/// <summary>
		/// Attempts to peek two bytes.
		/// </summary>
		/// <param name="first">The first byte that was peeked.</param>
		/// <param name="second">The second byte that was peeked.</param>
		/// <param name="error">The <see cref="Errors"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the peek was successful; otherwise, <see langword="false"/>.</returns>
		/// <seealso cref="TryPeek(out Byte, out Byte)"/>
		Boolean TryPeek(out Byte first, out Byte second, out Errors error);

		/// <summary>
		/// Attempts to peek three bytes.
		/// </summary>
		/// <param name="first">The first byte that was peeked.</param>
		/// <param name="second">The second byte that was peeked.</param>
		/// <param name="third">The third byte that was peeked.</param>
		/// <returns><see langword="true"/> if the peek was successful; otherwise, <see langword="false"/>.</returns>
		/// <seealso cref="TryPeek(out Byte, out Byte, out Byte, out Errors)"/>
		Boolean TryPeek(out Byte first, out Byte second, out Byte third) => TryPeek(out first, out second, out third, error: out _);

		/// <summary>
		/// Attempts to peek three bytes.
		/// </summary>
		/// <param name="first">The first byte that was peeked.</param>
		/// <param name="second">The second byte that was peeked.</param>
		/// <param name="third">The third byte that was peeked.</param>
		/// <param name="error">The <see cref="Errors"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the peek was successful; otherwise, <see langword="false"/>.</returns>
		/// <seealso cref="TryPeek(out Byte, out Byte, out Byte)"/>
		Boolean TryPeek(out Byte first, out Byte second, out Byte third, out Errors error);

		/// <summary>
		/// Attempts to peek four bytes.
		/// </summary>
		/// <param name="first">The first byte that was peeked.</param>
		/// <param name="second">The second byte that was peeked.</param>
		/// <param name="third">The third byte that was peeked.</param>
		/// <param name="fourth">The fourth byte that was peeked.</param>
		/// <returns><see langword="true"/> if the peek was successful; otherwise, <see langword="false"/>.</returns>
		/// <seealso cref="TryPeek(out Byte, out Byte, out Byte, out Byte, out Errors)"/>
		Boolean TryPeek(out Byte first, out Byte second, out Byte third, out Byte fourth) => TryPeek(out first, out second, out third, out fourth, error: out _);

		/// <summary>
		/// Attempts to peek four bytes.
		/// </summary>
		/// <param name="first">The first byte that was peeked.</param>
		/// <param name="second">The second byte that was peeked.</param>
		/// <param name="third">The third byte that was peeked.</param>
		/// <param name="fourth">The fourth byte that was peeked.</param>
		/// <param name="error">The <see cref="Errors"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the peek was successful; otherwise, <see langword="false"/>.</returns>
		/// <seealso cref="TryPeek(out Byte, out Byte, out Byte, out Byte)"/>
		Boolean TryPeek(out Byte first, out Byte second, out Byte third, out Byte fourth, out Errors error);

		/// <summary>
		/// Attempts to read two bytes.
		/// </summary>
		/// <param name="first">The first byte that was read.</param>
		/// <param name="second">The second byte that was read.</param>
		/// <returns><see langword="true"/> if the read was successful; otherwise, <see langword="false"/>.</returns>
		/// <seealso cref="TryRead(out Byte, out Byte, out Errors)"/>
		Boolean TryRead(out Byte first, out Byte second) {
			second = 0;
			return TryRead(out first) && TryRead(out second);
		}

		/// <summary>
		/// Attempts to read two bytes.
		/// </summary>
		/// <param name="first">The first byte that was read.</param>
		/// <param name="second">The second byte that was read.</param>
		/// <param name="error">The <see cref="Errors"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the read was successful; otherwise, <see langword="false"/>.</returns>
		/// <seealso cref="TryRead(out Byte, out Byte)"/>
		Boolean TryRead(out Byte first, out Byte second, out Errors error) {
			second = 0;
			return TryRead(out first, out error) && TryRead(out second, out error);
		}

		/// <summary>
		/// Attempts to read three bytes.
		/// </summary>
		/// <param name="first">The first byte that was read.</param>
		/// <param name="second">The second byte that was read.</param>
		/// <param name="third">The third byte that was read.</param>
		/// <returns><see langword="true"/> if the read was successful; otherwise, <see langword="false"/>.</returns>
		/// <seealso cref="TryRead(out Byte, out Byte, out Byte, out Errors)"/>
		Boolean TryRead(out Byte first, out Byte second, out Byte third) {
			third = 0;
			return TryRead(out first, out second) && TryRead(out third);
		}

		/// <summary>
		/// Attempts to read three bytes.
		/// </summary>
		/// <param name="first">The first byte that was read.</param>
		/// <param name="second">The second byte that was read.</param>
		/// <param name="third">The third byte that was read.</param>
		/// <param name="error">The <see cref="Errors"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the read was successful; otherwise, <see langword="false"/>.</returns>
		/// <seealso cref="TryRead(out Byte, out Byte, out Byte)"/>
		Boolean TryRead(out Byte first, out Byte second, out Byte third, out Errors error) {
			third = 0;
			return TryRead(out first, out second, out error) && TryRead(out third, out error);
		}

		/// <summary>
		/// Attempts to read four bytes.
		/// </summary>
		/// <param name="first">The first byte that was read.</param>
		/// <param name="second">The second byte that was read.</param>
		/// <param name="third">The third byte that was read.</param>
		/// <param name="fourth">The fourth byte that was read.</param>
		/// <returns><see langword="true"/> if the read was successful; otherwise, <see langword="false"/>.</returns>
		/// <seealso cref="TryRead(out Byte, out Byte, out Byte, out Byte, out Errors)"/>
		Boolean TryRead(out Byte first, out Byte second, out Byte third, out Byte fourth) {
			fourth = 0;
			return TryRead(out first, out second, out third) && TryRead(out fourth);
		}

		/// <summary>
		/// Attempts to read two bytes.
		/// </summary>
		/// <param name="first">The first byte that was read.</param>
		/// <param name="second">The second byte that was read.</param>
		/// <param name="third">The third byte that was read.</param>
		/// <param name="fourth">The fourth byte that was read.</param>
		/// <param name="error">The <see cref="Errors"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the read was successful; otherwise, <see langword="false"/>.</returns>
		/// <seealso cref="TryRead(out Byte, out Byte, out Byte, out Byte)"/>
		Boolean TryRead(out Byte first, out Byte second, out Byte third, out Byte fourth, out Errors error) {
			fourth = 0;
			return TryRead(out first, out second, out third, out error) && TryRead(out fourth, out error);
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
