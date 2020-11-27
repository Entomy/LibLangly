using System;
using System.IO;
#if WINDOWS
using System.ComponentModel;
#endif

namespace Langly.Streams.Bases {
	/// <summary>
	/// Represents the base of a <see cref="Stream"/> whos backing data is stored on disk.
	/// </summary>
	internal partial class FileStreamBase : StreamBase {
		/// <summary>
		/// The handle to the file.
		/// </summary>
		private readonly IntPtr Handle;

		/// <summary>
		/// The path to the file.
		/// </summary>
		private readonly String Path;

#if !WINDOWS && !UNIX
		/// <summary>
		/// Initializes a new <see cref="FileStreamBase"/>.
		/// </summary>
		/// <remarks>
		/// This is meant for stub constructors in derived classes.
		/// </remarks>
		protected FileStreamBase() => throw new PlatformNotSupportedException();
#endif

		/// <summary>
		/// Initializes a new <see cref="FileStreamBase"/>.
		/// </summary>
		/// <param name="path">The path to the file.</param>
		/// <param name="mode">The <see cref="FileMode"/> for opening the file.</param>
		internal unsafe FileStreamBase(String path, FileMode mode) {
#if !WINDOWS && !UNIX
			throw new PlatformNotSupportedException();
#else
			Path = System.IO.Path.GetFullPath(path);
#if WINDOWS
			const FileAccess ReadWrite = FileAccess.GenericRead | FileAccess.GenericWrite;
#endif
			switch (mode) {
			case FileMode.Append:
#if WINDOWS
				Handle = CreateFile(Path, ReadWrite | FileAccess.AppendData, FileShare.None, null, FileDisposition.OpenExisting, FileAttributes.Normal, null);
#elif UNIX
#endif
				break;
			case FileMode.Create:
#if WINDOWS
				Handle = CreateFile(Path, ReadWrite, FileShare.None, null, FileDisposition.CreateAlways, FileAttributes.Normal, null);
#elif UNIX
#endif
				break;
			case FileMode.CreateNew:
#if WINDOWS
				Handle = CreateFile(Path, ReadWrite, FileShare.None, null, FileDisposition.CreateNew, FileAttributes.Normal, null);
#elif UNIX
#endif
				break;
			case FileMode.Open:
#if WINDOWS
				Handle = CreateFile(Path, ReadWrite, FileShare.None, null, FileDisposition.OpenExisting, FileAttributes.Normal, null);
#elif UNIX
#endif
				break;
			case FileMode.OpenOrCreate:
#if WINDOWS
				Handle = CreateFile(Path, ReadWrite, FileShare.None, null, FileDisposition.OpenAlways, FileAttributes.Normal, null);
#elif UNIX
#endif
				break;
			case FileMode.Truncate:
#if WINDOWS
				Handle = CreateFile(Path, ReadWrite, FileShare.None, null, FileDisposition.TruncateExisting, FileAttributes.Normal, null);
#elif UNIX
#endif
				break;
			default:
				throw new System.ArgumentException($"FileMode '{mode} wasn't handled.", nameof(mode));
			}
#if WINDOWS
			if (GetFileSize(Handle, out Int64 size)) {
				Length = size;
			} else {
				throw new Win32Exception(GetLastError());
			}
#elif UNIX
#endif
#endif
		}

		/// <summary>
		/// Initializes a new <see cref="FileStreamBase"/>.
		/// </summary>
		/// <param name="handle"></param>
		/// <param name="path"></param>
		protected FileStreamBase(IntPtr handle, String path) {
			Handle = handle;
			Path = path;
		}

		/// <inheritdoc/>
		public override Ł3 AtEnd => Position == Length;

		/// <inheritdoc/>
		public override Boolean Readable => true;

		/// <inheritdoc/>
		public override Boolean Seekable => true;

		/// <inheritdoc/>
		public override Boolean Writable => true;
		/// <summary>
		/// The length of the file, counted in <see cref="Byte"/>s.
		/// </summary>
		private Int64 Length { get; }

		/// <inheritdoc/>
		public override unsafe void Read(out Byte element) {
#if WINDOWS
			Span<Byte> elements = stackalloc Byte[1];
			fixed (void* buffer = elements) {
				ReadFile(Handle, buffer, 1, out _, null);
			}
			element = elements[0];
#else
			throw new PlatformNotSupportedException();
#endif
		}

		/// <inheritdoc/>
		public override void Seek(nint offset) => throw new NotImplementedException();

		/// <inheritdoc/>
		public override String ToString() => Path;

		/// <inheritdoc/>
		public override unsafe Boolean TryRead(Span<Byte> elements, out Errors error) {
#if WINDOWS
			error = Errors.None;
			fixed (void* buffer = elements) {
				if (!ReadFile(Handle, buffer, elements.Length, out Int32 read, null)) {
					//TODO: Use GetLastError() to fill out error
					return false;
				}
			}
			Position += elements.Length;
			return true;
#else
			throw new PlatformNotSupportedException();
#endif
		}

		/// <inheritdoc/>
		public override unsafe Boolean TryWrite(ReadOnlySpan<Byte> elements, out Errors error) {
#if WINDOWS
			error = Errors.None;
			fixed (void* b = elements) {
				if (!WriteFile(Handle, b, elements.Length, out Int32 written, null)) {
					//TODO: Use GetLastError() to fill out error
					return false;
				}
			}
			Position += elements.Length;
			return true;
#else
			throw new PlatformNotSupportedException();
#endif
		}

		/// <inheritdoc/>
		public override unsafe void Write(Byte element) {
#if WINDOWS
			fixed (void* buffer = stackalloc Byte[] { element }) {
				WriteFile(Handle, buffer, 1, out _, null);
			}
#else
			throw new PlatformNotSupportedException();
#endif
		}

		/// <inheritdoc/>
		protected sealed override void DisposeUnmanaged() {
#if WINDOWS
			if (!CloseHandle(Handle)) {
				throw new Win32Exception(GetLastError());
			}
#else
			throw new PlatformNotSupportedException();
#endif
		}
	}
}
