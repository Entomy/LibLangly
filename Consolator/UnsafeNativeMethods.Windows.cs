#if WINDOWS
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Consolator {
	internal static partial class UnsafeNativeMethods {
		/// <summary>
		/// File control options.
		/// </summary>
		[Flags]
		[SuppressMessage("Critical Code Smell", "S2346:Flags enumerations zero-value members should be named \"None\"", Justification = "We don't control this type and can't change it.")]
		[SuppressMessage("Naming", "AV1704:Identifier contains one or more digits in its name", Justification = "We don't control this type and can't change it.")]
		internal enum FileControl {
			/// <summary>
			/// Open for reading only.
			/// </summary>
			ReadOnly = 0x0,

			/// <summary>
			/// Open for writing only.
			/// </summary>
			WriteOnly = 0x1,

			/// <summary>
			/// Open for reading and writing.
			/// </summary>
			ReadWrite = 1 << 1,

			/// <summary>
			/// Writes done at EOF.
			/// </summary>
			Append = 1 << 3,

			/// <summary>
			/// File access is primarily random.
			/// </summary>
			Random = 1 << 4,

			/// <summary>
			/// File access is primarily sequential.
			/// </summary>
			Sequential = 1 << 5,

			/// <summary>
			/// Temporary file; file is deleted when last handle is closed.
			/// </summary>
			Temporary = 1 << 6,

			/// <summary>
			/// Child process doesn't inherit file.
			/// </summary>
			NoInherit = 1 << 7,

			/// <summary>
			/// Create and open file.
			/// </summary>
			Create = 1 << 8,

			/// <summary>
			/// Open and truncate.
			/// </summary>
			Truncate = 1 << 9,

			/// <summary>
			/// Open only if file doesn't already exist.
			/// </summary>
			OpenNew = 1 << 10,

			/// <summary>
			/// Open only if file doesn't already exist.
			/// </summary>
			Exclusive = OpenNew,

			/// <summary>
			/// Temporary storage file, try not to flush.
			/// </summary>
			ShortLived = 1 << 12,

			/// <summary>
			/// Get information about a directory.
			/// </summary>
			ObtainDirectory = 1 << 13,

			/// <summary>
			/// File mode is text (translated).
			/// </summary>
			Text = 1 << 14,

			/// <summary>
			/// File mode is binary (untranslated).
			/// </summary>
			Binary = 1 << 15,

			/// <summary>
			/// File mode is binary (untranslated).
			/// </summary>
			Raw = Binary,

			/// <summary>
			/// File mode is UTF-16 with BOM (translated).
			/// </summary>
			WideText = 1 << 16,

			/// <summary>
			/// File mode is UTF-16 with no BOM (translated).
			/// </summary>
			U16Text = 1 << 17,

			/// <summary>
			/// File mode is UTF-8 with no BOM (translated).
			/// </summary>
			U8Text = 1 << 18,
		}

		/// <summary>
		/// The standard device.
		/// </summary>
		internal enum StdHandle {
			/// <summary>
			/// The standard error device. Initially, this is the active console screen buffer, CONOUT$.
			/// </summary>
			Error = -12,

			/// <summary>
			/// The standard output device. Initially, this is the active console screen buffer, CONOUT$.
			/// </summary>
			Output = -11,

			/// <summary>
			/// The standard input device. Initially, this is the console input buffer, CONIN$.
			/// </summary>
			Input = -10,
		}

		/// <summary>
		/// Generates simple tones on the speaker. The function is synchronous; it performs an alertable wait and does not return control to its caller until the sound finishes.
		/// </summary>
		/// <param name="frequency">The frequency of the sound, in hertz. This parameter must be in the range 37 through 32,767 (0x25 through 0x7FFF).</param>
		/// <param name="duration">The duration of the sound, in milliseconds.</param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero.
		/// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.
		/// </returns>
		[DllImport("Kernel32", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern Boolean Beep(Int32 frequency, Int32 duration);

		/// <summary>
		/// Gets the file descriptor associated with a stream.
		/// </summary>
		/// <param name="stream">Pointer to the FILE structure.</param>
		/// <returns>
		/// <para>_fileno returns the file descriptor. There's no error return. The result is undefined if stream does not specify an open file. If stream is NULL, _fileno invokes the invalid parameter handler, as described in Parameter Validation. If execution is allowed to continue, this function returns -1 and sets errno to EINVAL.</para>
		/// </returns>
		[DllImport("Win32", EntryPoint = "_fileno", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.I4)]
		internal static extern Int32 FileNo(IntPtr stream);

		/// <summary>
		/// Retrieves the calling thread's last-error code value. The last-error code is maintained on a per-thread basis. Multiple threads do not overwrite each other's last-error code.
		/// </summary>
		/// <returns>
		/// <para>The return value is the calling thread's last-error code.</para>
		/// <para>The Return Value section of the documentation for each function that sets the last-error code notes the conditions under which the function sets the last-error code. Most functions that set the thread's last-error code set it when they fail. However, some functions also set the last-error code when they succeed. If the function is not documented to set the last-error code, the value returned by this function is simply the most recent last-error code to have been set; some functions set the last-error code to 0 on success and others do not.</para>
		/// </returns>
		internal static Int32 GetLastError() => Marshal.GetLastWin32Error(); // This technically isn't a p/invoke, but rather a call through the marshaller that does some appropriate and non-obvious things. Calling the WinAPI without doing anything else, because we have a GC running, can in certain situations overwrite the last error value. The marshaller method handles this. This binding is still provided to allow users to call this as they would expect to.

		/// <summary>
		/// Retrieves a handle to the specified standard device (standard input, standard output, or standard error).
		/// </summary>
		/// <param name="nStdHandle">The standard device.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to the specified device, or a redirected handle set by a previous call to SetStdHandle. The handle has GENERIC_READ and GENERIC_WRITE access rights, unless the application has used SetStdHandle to set a standard handle with lesser access.</para>
		/// <para>If the function fails, the return value is INVALID_HANDLE_VALUE.To get extended error information, call GetLastError.</para>
		/// <para>If an application does not have associated standard handles, such as a service running on an interactive desktop, and has not redirected them, the return value is NULL.</para>
		/// </returns>
		[DllImport("Kernel32", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.SysInt)]
		internal static extern unsafe IntPtr GetStdHandle(StdHandle nStdHandle);

		/// <summary>
		/// Sets the file translation mode.
		/// </summary>
		/// <param name="fd">File descriptor.</param>
		/// <param name="mode">New translation mode.</param>
		/// <returns>
		/// <para>If successful, returns the previous translation mode.</para>
		/// <para>If invalid parameters are passed to this function, the invalid-parameter handler is invoked, as described in Parameter Validation.If execution is allowed to continue, this function returns -1 and sets errno to either EBADF, which indicates an invalid file descriptor, or EINVAL, which indicates an invalid mode argument.</para>
		/// </returns>
		[DllImport("Win32", EntryPoint = "_setmode", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.I4)]
		internal static extern Int32 SetMode(Int32 fd, FileControl mode);

		/// <summary>
		/// Writes a character string to a console screen buffer beginning at the current cursor location.
		/// </summary>
		/// <param name="hConsoleOutput">A handle to the console screen buffer. The handle must have the GENERIC_WRITE access right.</param>
		/// <param name="lpBuffer">A pointer to a buffer that contains characters to be written to the console screen buffer.</param>
		/// <param name="nNumberOfBytesToWrite">The number of characters to be written. If the total size of the specified number of characters exceeds the available heap, the function fails with ERROR_NOT_ENOUGH_MEMORY.</param>
		/// <param name="lpNumberOfCharsWritten">A pointer to a variable that receives the number of characters actually written.</param>
		/// <param name="lpReserved">Reserved; must be NULL.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.To get extended error information, call <see cref="GetLastError()"/>.</para>
		/// </returns>
		[DllImport("Kernel32", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern unsafe Boolean WriteConsole(IntPtr hConsoleOutput, void* lpBuffer, Int32 nNumberOfBytesToWrite, out Int32 lpNumberOfCharsWritten, void* lpReserved);
	}
}
#endif