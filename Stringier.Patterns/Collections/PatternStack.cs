using System;
using System.Collections.Generic;
using System.Text.Patterns;

namespace System.Collections.Specialized {
	/// <summary>
	/// Represents a variable size last-in-first-out (LIFO) collection of instances of <see cref="Pattern"/>.
	/// </summary>
	/// <remarks>
	/// This is primarily intended to help with pattern expressions in bespoke languages.
	/// </remarks>
	public sealed class PatternStack : Stack<Pattern> {
		/// <summary>
		/// Declares the two top elements of the stack as alternates of each other, and then pushes the resulting pattern back on.
		/// </summary>
		public void Alternate() {
			Pattern p = Pop();
			Push(Pop().Alternate(p));
		}

		/// <summary>
		/// Declares the specified <paramref name="p"/> and the top element of the stack as alternates of each other, and then pushes the resulting pattern back on.
		/// </summary>
		/// <param name="p">A <see cref="Pattern"/> object.</param>
		public void Alternate(Pattern p) => Push(Pop().Alternate(p));

		/// <summary>
		/// Declares the top element of the stack should be captured into <paramref name="Capture"/> for later reference
		/// </summary>
		/// <param name="Capture">A <see cref="Text.Patterns.Capture"/> object to store into.</param>
		public void Capture(out Capture Capture) => Push(Pop().Capture(out Capture));

		/// <summary>
		/// Concatenates the two top elements of the stack so that the top comes after the next, and then pushes the resulting pattern back on.
		/// </summary>
		public void Concatenate() {
			Pattern p = Pop();
			Push(Pop().Concatenate(p));
		}

		/// <summary>
		/// Concatenates the specified <paramref name="p"/> and the top element of the stack so that <paramref name="p"/> comes after the top element, and then pushes the resulting pattern back on.
		/// </summary>
		/// <param name="p">A <see cref="Pattern"/> object.</param>
		public void Concatenate(Pattern p) => Push(Pop().Concatenate(p));

		/// <summary>
		/// Declares the top element of the stack as negated, and then pushes the resulting pattern back on.
		/// </summary>
		public void Negate() => Push(Pop().Negate());

		/// <summary>
		/// Declares the top element of the stack as optional, and then pushes the resulting pattern back on.
		/// </summary>
		public void Optional() => Push(Pop().Optional());

		/// <summary>
		/// Declares the top element of the stack as spanning, and then pushes the resulting pattern back on.
		/// </summary>
		public void Span() => Push(Pop().Span());
	}
}
