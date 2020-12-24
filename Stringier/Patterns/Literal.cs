using System;

namespace Langly.Patterns {
	/// <summary>
	/// Represents any possible literal, a <see cref="Primative"/> <see cref="Pattern"/> representing exactly itself.
	/// </summary>
	internal abstract class Literal : Primative {
		/// <summary>
		/// Initializes a new <see cref="Literal"/>.
		/// </summary>
		protected Literal() { }
	}
}
