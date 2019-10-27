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
	public sealed class PatternStack : ICollection, IEnumerable<Node>, IReadOnlyCollection<Node> {
		private readonly Stack<Node> Stack = new Stack<Node>();

		public Int32 Count => Stack.Count;

		public Boolean IsSynchronized => ((ICollection)Stack).IsSynchronized;

		public Object SyncRoot => ((ICollection)Stack).SyncRoot;

		/// <summary>
		/// Declares the two top elements of the stack as alternates of each other, and then pushes the resulting pattern back on.
		/// </summary>
		public void Alternate() {
			Node p = Stack.Pop();
			Stack.Push(Stack.Pop().Alternate(p));
		}

		/// <summary>
		/// Declares the specified <paramref name="p"/> and the top element of the stack as alternates of each other, and then pushes the resulting pattern back on.
		/// </summary>
		/// <param name="p">A <see cref="Pattern"/> object.</param>
		public void Alternate(Pattern p) => Stack.Push(Stack.Pop().Alternate(p.Head));

		/// <summary>
		/// Declares the top element of the stack should be captured into <paramref name="Capture"/> for later reference
		/// </summary>
		/// <param name="Capture">A <see cref="Text.Patterns.Capture"/> object to store into.</param>
		public void Capture(out Capture Capture) => Stack.Push(Stack.Pop().Capture(out Capture));

		/// <summary>
		/// Concatenates the two top elements of the stack so that the top comes after the next, and then pushes the resulting pattern back on.
		/// </summary>
		public void Concatenate() {
			Node p = Stack.Pop();
			Stack.Push(Stack.Pop().Concatenate(p));
		}

		/// <summary>
		/// Concatenates the specified <paramref name="p"/> and the top element of the stack so that <paramref name="p"/> comes after the top element, and then pushes the resulting pattern back on.
		/// </summary>
		/// <param name="p">A <see cref="Pattern"/> object.</param>
		public void Concatenate(Pattern p) => Stack.Push(Stack.Pop().Concatenate(p.Head));

		void ICollection.CopyTo(Array array, Int32 index) => ((ICollection)Stack).CopyTo(array, index);

		IEnumerator<Node> IEnumerable<Node>.GetEnumerator() => ((IReadOnlyCollection<Node>)Stack).GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => ((IReadOnlyCollection<Node>)Stack).GetEnumerator();

		/// <summary>
		/// Declares the top element of the stack as negated, and then pushes the resulting pattern back on.
		/// </summary>
		public void Negate() => Stack.Push(Stack.Pop().Negate());

		/// <summary>
		/// Declares the top element of the stack as optional, and then pushes the resulting pattern back on.
		/// </summary>
		public void Optional() => Stack.Push(Stack.Pop().Optional());

		/// <summary>
		/// Returns the object at the top of the <see cref="PatternStack"/> without removing it.
		/// </summary>
		/// <returns></returns>
		public Pattern Peek() => new Pattern(Stack.Peek());

		/// <summary>
		/// Removes and returns the <see cref="Pattern"/> at the top of the <see cref="PatternStack"/>.
		/// </summary>
		/// <returns></returns>
		public Pattern Pop() => new Pattern(Stack.Pop());

		/// <summary>
		/// Inserts an object at the top of the <see cref="PatternStack"/>.
		/// </summary>
		/// <param name="Pattern"></param>
		public void Push(Pattern Pattern) => Stack.Push(Pattern.Head);

		/// <summary>
		/// Declares the top element of the stack as spanning, and then pushes the resulting pattern back on.
		/// </summary>
		public void Span() => Stack.Push(Stack.Pop().Span());
	}
}
