using System;
using System.Traits;

namespace Streamy {
	public partial class Stream : ISeek {
		/// <inheritdoc/>
		public Boolean Seekable { get; }

		/// <inheritdoc/>
		public virtual nint Position { get; set; }

		/// <inheritdoc/>
		public virtual void Seek(nint offset) => throw new NotImplementedException();
	}
}
