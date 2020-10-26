using System;
using System.Diagnostics.CodeAnalysis;

namespace Philosoft {
	/// <summary>
	/// Indicates the collection is countable.
	/// </summary>
	public interface ILengthy : ICountable {
		/// <summary>
		/// Gets the number of elements contained in the collection
		/// </summary>
		/// <value>The number of elements contained in the collection.</value>
		nint Length { get; }

		/// <inheritdoc/>
		[SuppressMessage("Design", "CA1033:Interface methods should be callable by child types", Justification = "It still is, the name change is a matter of convention, but that's all that is going on here: a name change. Everything is still functioanlly present.")]
		nint ICountable.Count => Length;
	}
}
