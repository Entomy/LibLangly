using System;
using System.Diagnostics.CodeAnalysis;
using Streamy.Bases;
using Streamy.Buffers;

namespace Streamy {
	public partial class CharStream {
		/// <inheritdoc/>
		public void Add(Char element) => Write(element);

		/// <inheritdoc/>
		public virtual void Write([AllowNull] Char element) {
			switch (WriteBuffer) {
			case IWriteCharBuffer wcb:
				wcb.Write(element);
				break;
			case IWriteBuffer wb:
				throw new NotImplementedException();
			default:
				switch (Base) {
				case CharStreamBase csb:
					csb.Write(element);
					break;
				default:
					throw new NotImplementedException();
				}
				break;
			}
		}
	}
}
