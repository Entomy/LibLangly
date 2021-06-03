using System;
using System.Traits;

namespace Streamy {
	public partial class Stream : ISeek {
		/// <inheritdoc/>
		public Boolean Seekable => Base.Seekable;

		/// <summary>
		/// The position within the datastream, counted by a <see cref="Byte"/> offset from the start.
		/// </summary>
		public nint Position {
			get => Base.Position;
			set => Base.Position = value;
		}

		/// <summary>
		/// Seeks to the <paramref name="offset"/>, counted by <see cref="Byte"/>.
		/// </summary>
		/// <param name="offset">The amount of <see cref="Byte"/> to seek.</param>
		public void Seek(nint offset) => Base.Seek(offset);
	}
}
