using System;

namespace Defender {
	/// <summary>
	/// Represents a <see cref="Tests"/> configurer.
	/// </summary>
	public readonly ref struct Config {
		/// <summary>
		/// Sets the amount of elements in arrays or other collections to print when tests fail.
		/// </summary>
		/// <param name="count">The maximum amount of elements to print.</param>
		public static void SetPrintCount(Int32 count) => State.PrintCount = count;
	}
}
