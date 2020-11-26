using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Langly;

namespace Stringier {
	/// <summary>
	/// Represents a <see cref="String"/> that's been split into chunks.
	/// </summary>
	[StructLayout(LayoutKind.Auto)]
	public readonly ref partial struct SplitString {
		/// <summary>
		/// The regions for each chunk.
		/// </summary>
		private readonly IReadOnlyList<(Int32 start, Int32 length)> Regions;

		/// <summary>
		/// The source this <see cref="SplitString"/> came from.
		/// </summary>
		private readonly ReadOnlySpan<Char> Source;

		/// <summary>
		/// Initializes a new <see cref="SplitString"/>.
		/// </summary>
		/// <param name="source">The source this <see cref="SplitString"/> comes from.</param>
		/// <param name="regions">The regions for each chunk.</param>
		internal SplitString(ReadOnlySpan<Char> source, IReadOnlyList<(Int32 start, Int32 length)> regions) {
			Source = source;
			Regions = regions;
		}

		/// <summary>
		/// The amount of chunks.
		/// </summary>
		private Int32 Count => Regions.Count;

		/// <summary>
		/// Gets the chunk at the specified <paramref name="index"/>.
		/// </summary>
		/// <param name="index">The index of the chunk to get.</param>
		/// <returns>A <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> of the specified chunk.</returns>
		public ReadOnlySpan<Char> this[Int32 index] {
			get {
				Guard.Index(index, nameof(index), Source);
				(Int32 start, Int32 length) = Regions[index];
				return Source.Slice(start, length);
			}
		}

		public static Boolean operator !=(SplitString left, SplitString right) => !left.Equals(right);

		public static Boolean operator ==(SplitString left, SplitString right) => left.Equals(right);

		/// <inheritdoc/>
		public override Boolean Equals(Object obj) => false;

		/// <inheritdoc/>
		public Boolean Equals([AllowNull] SplitString other) => Source.Equals(other.Source) && Count.Equals(other.Count);

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Int32 GetHashCode() => Source.GetHashCode();
	}
}
