using System;
using Streamy.Buffers;

namespace Streamy {
	public partial class CharStream {
		/// <inheritdoc/>
		public virtual void Peek(out Char element) {
			switch (ReadBuffer) {
			case IReadCharBuffer rcb:
				rcb.Peek(out element);
				break;
			default:
				throw new NotImplementedException();
			}
		}
	}
}
