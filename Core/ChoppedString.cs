using System;
using System.Runtime.InteropServices;
using Defender;

namespace Stringier {
	/// <summary>
	/// Represents a <see cref="String"/> that's been chopped into chunks.
	/// </summary>
	[StructLayout(LayoutKind.Auto)]
	public readonly ref struct ChoppedString {
		/// <summary>
		/// The source this <see cref="ChoppedString"/> came from.
		/// </summary>
		private readonly ReadOnlySpan<Char> Source;

		/// <summary>
		/// The length of each chunk.
		/// </summary>
		private readonly Int32 Length;

		/// <summary>
		/// The amount of chunks.
		/// </summary>
		private readonly Int32 Count;

		/// <summary>
		/// Gets the chunk at the specified <paramref name="index"/>.
		/// </summary>
		/// <param name="index">The index of the chunk to get.</param>
		/// <returns>A <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> of the specified chunk.</returns>
		public ReadOnlySpan<Char> this[Int32 index] {
			get {
				Int32 j = index * Length;
				return (j + Length) > Source.Length
					? Source.Slice(j, Source.Length - j)
					: Source.Slice(j, Length);
			}
		}

		/// <summary>
		/// Initializes a new <see cref="ChoppedString"/>.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="length"></param>
		internal ChoppedString(ReadOnlySpan<Char> source, Int32 length) {
			Guard.GreaterThan(length, nameof(length), 0);
			Source = source;
			Length = length;
			Count = (Int32)Math.Ceiling((Double)Source.Length / Length);
		}

		public ChoppedStringEnumerator GetEnumerator() => new ChoppedStringEnumerator(this, Count);
	}
}
