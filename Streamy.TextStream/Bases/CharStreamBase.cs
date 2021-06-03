using System;
using System.Traits;

namespace Streamy.Bases {
	/// <summary>
	/// Represents an optimized base for <see cref="CharStream"/>.
	/// </summary>
	/// <remarks>
	/// <see cref="CharStream"/> doesn't necessarily use this, since it's derived from <see cref="Stream"/> and has to use any <see cref="StreamBase"/>. This is, instead, support for a common hot-path by optimizing those cases. If the <see cref="CharStream"/> recognizes it's using a <see cref="CharStreamBase"/>, these optimized paths will be taken.
	/// </remarks>
	public abstract class CharStreamBase : StreamBase, IRead<Char>, IWrite<Char> {
		/// <inheritdoc/>
		public void Add(Char element) => Write(element);

		/// <inheritdoc/>
		public abstract void Read(out Char element);

		/// <inheritdoc/>
		public abstract void Write(Char element);
	}
}
