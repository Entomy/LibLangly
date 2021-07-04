using System;
using System.ComponentModel;
using System.Traits;

namespace Numbersome {
	public partial class Random {
		/// <summary>
		/// Represents a pseudo-random number generator, which is an algorithm that produces a sequence of numbers that meet certain statistical requirements for randomness.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public abstract class Generator : IRead<Byte> {
			/// <summary>
			/// Initializes a new instance of the <see cref="Generator"/> class using a default seed value.
			/// </summary>
			protected Generator() { }

			/// <inheritdoc/>
			public abstract void Read(out Byte element);
		}
	}
}
