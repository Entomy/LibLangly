using System;
using System.Collections;
using System.Collections.Generic;

namespace Stringier.Patterns.Debugging {
	/// <summary>
	/// Represents a graph trace, a collection of the steps taken through a <see cref="Pattern"/> graph.
	/// </summary>
	public sealed class Trace : ITrace {
		/// <summary>
		/// The actual <see cref="Step"/>s taken by this <see cref="Trace"/>.
		/// </summary>
		private readonly List<Step> Steps = new List<Step>();

		/// <summary>
		/// Gets the <see cref="IStep"/> at the declared index <paramref name="i"/>.
		/// </summary>
		/// <param name="i">The index of the <see cref="IStep"/> to get.</param>
		/// <returns>The <see cref="IStep"/> at the declared index <paramref name="i"/>.</returns>
		public IStep this[Int32 i] => Steps[i];

		/// <summary>
		/// Collect the parameters as a trace step.
		/// </summary>
		/// <param name="text"></param>
		/// <param name="position"></param>
		public void Collect(String text, Int32 position) => Steps.Add(new Step(text, position));

		/// <summary>
		/// Collect the parameters as a trace step.
		/// </summary>
		/// <param name="errorType"
		public void Collect(Error error, Int32 position) => Steps.Add(new Step(error, position));

		IEnumerator<IStep> IEnumerable<IStep>.GetEnumerator() => ((IEnumerable<IStep>)Steps).GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)Steps).GetEnumerator();
	}
}
