using System;
using System.Traits;
using Streamy.Buffers;

namespace Streamy {
	public partial class CharStream {
		/// <inheritdoc/>
		nint ISeek.Position {
			get => Position;
			set => Position = value;
		}

		/// <summary>
		/// The position within the datastream, counted by a <see cref="Char"/> offset from the start.
		/// </summary>
		new public nint Position {
			get {
				switch (Source) {
				case IReadCharBuffer rcb:
					return rcb.Position;
				default:
					throw new NotImplementedException();
				}
			}
			set {
				switch (Source) {
				case IReadCharBuffer rcb:
					rcb.Position = value;
					break;
				default:
					throw new NotImplementedException();
				}
			}
		}

		/// <inheritdoc/>
		void ISeek.Seek(nint offset) => Seek(offset);

		/// <summary>
		/// Seeks to the <paramref name="offset"/>, counted by <see cref="Char"/>.
		/// </summary>
		/// <param name="offset">The amount of <see cref="Char"/> to seek.</param>
		new public void Seek(nint offset) {
			switch (Source) {
			case IReadCharBuffer rcb:
				rcb.Seek(offset);
				break;
			default:
				throw new NotImplementedException();
			}
		}
	}
}
