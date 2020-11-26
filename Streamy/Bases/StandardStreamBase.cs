using System;
using System.IO;
using Langly;

namespace Streamy.Bases {
	/// <summary>
	/// Represents the base of a <see cref="Stream"/> who's backing is the standard input and standard ouput.
	/// </summary>
	internal sealed class StandardStreamBase : FileStreamBase {
		/// <inheritdoc/>
		internal unsafe StandardStreamBase(Standard stream)
#if WINDOWS
			: base(CreateFile(GetPath(stream), GetFileAccess(stream), FileShare.None, null, FileDisposition.OpenExisting, FileAttributes.Normal, null), GetPath(stream))
#elif UNIX
			: base(GetPath(stream), FileMode.Open)
#endif
			{
#if WINDOWS || UNIX
			switch (stream) {
			case Standard.Input:
				Readable = true;
				Writable = false;
				break;
			case Standard.Output:
			case Standard.Error:
				Readable = false;
				Writable = true;
				break;
			}
#else
			throw new PlatformNotSupportedException();
#endif
		}

		/// <inheritdoc/>
		public override Boolean Readable { get; }

		/// <inheritdoc/>
		public override Boolean Seekable => false;

		/// <inheritdoc/>
		public override Boolean Writable { get; }

		/// <inheritdoc/>
		public override Ł3 AtEnd => false; // Standard streams have no end, ever

		/// <inheritdoc/>
		public override String ToString() => "Console";

#if WINDOWS
		private static FileAccess GetFileAccess(Standard stream) {
			switch (stream) {
			case Standard.Input:
				return FileAccess.GenericRead;
			case Standard.Output:
			case Standard.Error:
				return FileAccess.GenericWrite;
			default:
				throw InvalidStandard(stream);
			}
		}
#endif

		private static String GetPath(Standard stream) {
#if WINDOWS
			switch (stream) {
			case Standard.Input:
				return "CONIN$";
			case Standard.Output:
			case Standard.Error:
				return "CONOUT$";
			default:
				throw InvalidStandard(stream);
			}
#elif UNIX
			return "/dev/tty";
#else
			throw new PlatformNotSupportedException();
#endif
		}

		private static Exception InvalidStandard(Standard standard) => new ArgumentException($"Standard '{standard}' was not handled");
	}
}
