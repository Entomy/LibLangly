using System;
using System.Traits;

namespace Streamy {
	public partial class Stream : ISeek {
		/// <inheritdoc/>
		public Boolean Seekable => Source.Seekable;

		/// <summary>
		/// The position within the datastream, counted by a <see cref="Byte"/> offset from the start.
		/// </summary>
		public Int32 Position {
			get => Source.Position;
			set => Source.Position = value;
		}

		/// <summary>
		/// Seeks to the <paramref name="offset"/>, counted by <see cref="Byte"/>.
		/// </summary>
		/// <param name="offset">The amount of <see cref="Byte"/> to seek.</param>
		public void Seek(Int32 offset) => Source.Seek(offset);
	}
}
