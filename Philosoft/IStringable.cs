using System;

namespace Philosoft {
	/// <summary>
	/// Indicates the value type can be efficiently converted to a <see cref="String"/>.
	/// </summary>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	public interface IStringable<TSelf> where TSelf : struct, IStringable<TSelf> {
		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		/// <remarks>
		/// This is a special devirtualizing call, by avoiding the need to box and push the value into the heap just to call a method.
		/// </remarks>
		String ToString();
	}
}
