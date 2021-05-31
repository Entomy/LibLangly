using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Streamy.Bases;

namespace Numbersome {
	public partial class Random {
		/// <summary>
		/// Represents a pseudo-random number generator, which is an algorithm that produces a sequence of numbers that meet certain statistical requirements for randomness.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public abstract class Generator : StreamBase {
			/// <summary>
			/// Initializes a new instance of the <see cref="Generator"/> class using a default seed value.
			/// </summary>
			protected Generator() { }

			/// <inheritdoc/>
			public sealed override Boolean Readable => true;

			/// <inheritdoc/>
			public sealed override Boolean Seekable => false;

			/// <inheritdoc/>
			public sealed override Boolean Writable => false;

			/// <inheritdoc/>
			public sealed override void Seek(nint offset) => throw new NotSupportedException("Random number generators can't be seeked");

			/// <inheritdoc/>
			public sealed override void Write([AllowNull] Byte element) => throw new NotSupportedException("Random number generators are read-only.");
		}
	}
}
