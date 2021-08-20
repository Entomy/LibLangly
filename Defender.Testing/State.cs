using System;
namespace Defender {
	/// <summary>
	/// Holds global state, hence the name.
	/// </summary>
	internal static class State {
		/// <summary>
		/// The amount of elements in arrays or other collections to print when tests fail.
		/// </summary>
		private static Int32 printCount;

		/// <summary>
		/// The amount of elements in arrays or other collections to print when tests fail.
		/// </summary>
		internal static Int32 PrintCount {
			get => printCount;
			set => printCount = value;
		}
	}
}
