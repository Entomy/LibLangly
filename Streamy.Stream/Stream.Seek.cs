using System;
using System.Traits;

namespace Streamy {
	public partial class Stream : ISeek {
		/// <inheritdoc/>
		public Boolean Seekable => Base.Seekable;

		/// <inheritdoc/>
		public virtual nint Position {
			get => Base.Position;
			set => Base.Position = value;
		}

		/// <inheritdoc/>
		public virtual void Seek(nint offset) => Base.Seek(offset);
	}
}
