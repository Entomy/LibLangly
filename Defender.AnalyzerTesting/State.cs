using System;
using System.Diagnostics.CodeAnalysis;

namespace Defender {
	/// <summary>
	/// Holds global state, hence the name.
	/// </summary>
	internal static class State {
		/// <summary>
		/// The path to the test files on disk.
		/// </summary>
		[DisallowNull, NotNull]
		private static String path = $".{System.IO.Path.DirectorySeparatorChar}";

		/// <summary>
		/// The path to the test files on disk.
		/// </summary>
		[AllowNull, NotNull]
		internal static String Path {
			get => path;
			set {
				// We don't want to deal with returning a null path, so just make it valid right now
				if (value is null) {
					path = $".{System.IO.Path.DirectorySeparatorChar}";
				} else {
					// If we have a path, make sure it has the appropriate stuff
					String? prefix = value.StartsWith($".{System.IO.Path.DirectorySeparatorChar}") ? "" : $".{System.IO.Path.DirectorySeparatorChar}";
					String? suffix = value.EndsWith($"{System.IO.Path.DirectorySeparatorChar}") ? "" : $"{System.IO.Path.DirectorySeparatorChar}";
					path = $"{prefix}{value}{suffix}";
				}
			}
		}
	}
}
