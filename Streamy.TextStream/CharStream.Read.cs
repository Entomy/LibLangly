using System;
using Streamy.Buffers;

namespace Streamy {
	public partial class CharStream {
		/// <inheritdoc/>
		public virtual void Read(out Char element) {
			switch (ReadBuffer) {
			case IReadCharBuffer rcb:
				rcb.Read(out element);
				break;
			default:
				throw new NotImplementedException();
			}
		}
	}
}
