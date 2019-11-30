using System;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents any possible checker, a <see cref="Pattern"/> node which uses a generic function to describe the pattern, instead of literals.
	/// </summary>
	internal abstract class Checker : Primative {
		/// <summary>
		/// The name of the <see cref="Checker"/>; the <see cref="String"/> to display when this <see cref="Pattern"/> is written as text.
		/// </summary>
		internal protected readonly String Name;

		/// <summary>
		/// Initialize a new <see cref="Checker"/> with the specified <paramref name="name"/>.
		/// </summary>
		/// <param name="name">The name of the <see cref="Checker"/>; the <see cref="String"/> to display when this <see cref="Pattern"/> is written as text.</param>
		protected Checker(String name) => Name = name;
	}
}
