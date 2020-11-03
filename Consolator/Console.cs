using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Consolator {
	/// <summary>
	/// Represents the standard input, output, and error streams.
	/// </summary>
	/// <remarks>
	/// This is intended as a replacement for <see cref="System.Console"/>. It bypasses much of the .NET runtime functionality, instead binding to the native console API's directly. It also operates in a uniquely different way, going for the direct API's rather than operating as a stream.
	/// </remarks>
	[SuppressMessage("Class Design", "AV1008:Class should not be static", Justification = "No. Just no.")]
	[SuppressMessage("Blocker Code Smell", "S3427:Method overloads with default parameter values should not overlap ", Justification = "Yet again, Sonar doesn't understand patterns.")]
	public static partial class Console {
		/// <summary>
		/// Gets the alternate screen buffer, and actives it.
		/// </summary>
		public static ScreenBuffer Buffer {
			get {
				Write("\x1B[?1049h");
				return ScreenBuffer.Instance;
			}
		}

		/// <summary>
		/// Gets or sets the console window title.
		/// </summary>
		[SuppressMessage("Design", "CA1044:Properties should not be write only", Justification = "There's no corresponding get-title sequence we can use.")]
		[SuppressMessage("Major Code Smell", "S2376:Write-only properties should not be used", Justification = "There's no corresponding get-title sequence we can use.")]
		public static String Title {
			set {
				if (value is not null) {
					WriteLine($"\x1B]2;{value}\b");
				} else {
					using Process process = Process.GetCurrentProcess();
					WriteLine($"\x1B]2;{process.ProcessName}\b");
				}
			}
		}
	}
}
