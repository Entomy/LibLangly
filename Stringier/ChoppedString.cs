using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Defender;

namespace Stringier {
	/// <summary>
	/// Represents text that's been chopped into chunks.
	/// </summary>
	[StructLayout(LayoutKind.Auto)]
	public readonly ref partial struct ChoppedString {
		/// <summary>
		/// The amount of chunks.
		/// </summary>
		private readonly Int32 Count;

		/// <summary>
		/// The length of each chunk.
		/// </summary>
		private readonly Int32 Length;

		/// <summary>
		/// The source this <see cref="ChoppedString"/> came from.
		/// </summary>
		private readonly ReadOnlySpan<Char> Source;

		/// <summary>
		/// Initializes a new <see cref="ChoppedString"/>.
		/// </summary>
		/// <param name="source">The source this <see cref="ChoppedString"/> comes from.</param>
		/// <param name="length">The length of each chunk.</param>
		internal ChoppedString(ReadOnlySpan<Char> source, Int32 length) {
			Guard.GreaterThan(length, nameof(length), 0);
			Source = source;
			Length = length;
			Count = (Int32)Math.Ceiling((Double)Source.Length / Length); // Precompute the amount of chunks
		}

		/// <summary>
		/// Gets the chunk at the specified <paramref name="index"/>.
		/// </summary>
		/// <param name="index">The index of the chunk to get.</param>
		/// <returns>A <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> of the specified chunk.</returns>
		public ReadOnlySpan<Char> this[Int32 index] {
			get {
				Int32 j = index * Length;
				return (j + Length) > Source.Length // If we're going to reach the end
					? Source.Slice(j, Source.Length - j) // Return a chunk from the starting point up to the end of the source
					: Source.Slice(j, Length); // Otherwise, return a fully sized chunk starting at the current position
			}
		}

		public static Boolean operator !=(ChoppedString left, ChoppedString right) => !left.Equals(right);

		public static Boolean operator ==(ChoppedString left, ChoppedString right) => left.Equals(right);

		/// <inheritdoc/>
		public override Boolean Equals([AllowNull] Object obj) => false;

		/// <inheritdoc/>
		public Boolean Equals(ChoppedString other) => Source.Equals(other.Source) && Count.Equals(other.Count);

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Int32 GetHashCode() => Source.GetHashCode();
	}
}
