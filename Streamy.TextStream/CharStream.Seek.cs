using System;
using System.Traits;
using Streamy.Bases;

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
				switch (Base) {
				case CharStreamBase csb:
					return csb.Position;
				default:
					throw new NotImplementedException();
				}
			}
			set {
				switch (Base) {
				case CharStreamBase csb:
					csb.Position = value;
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
			switch (Base) {
			case CharStreamBase csb:
				throw new NotImplementedException();
			default:
				throw new NotImplementedException();
			}
		}
	}
}
