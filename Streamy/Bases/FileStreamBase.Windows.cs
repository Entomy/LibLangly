#if WINDOWS
using System;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Streamy.Bases {
	internal partial class FileStreamBase {
		/// <summary>
		/// File attributes are metadata values stored by the file system on disk and are used by the system and are available to developers via various file I/O APIs. For a list of related APIs and topics, see the See Also section.
		/// </summary>
		[Flags]
		[SuppressMessage("Design", "RCS1135:Declare enum member with zero value (when enum has FlagsAttribute).", Justification = "Take this up with Microsoft then, they're the ones who made up this absolutely asinine layout.")]
		protected enum FileAttribute {
			/// <summary>
			/// A file that is read-only. Applications can read the file, but cannot write to it or delete it. This attribute is not honored on directories. For more information, see You cannot view or change the Read-only or the System attributes of folders in Windows Server 2003, in Windows XP, in Windows Vista or in Windows 7.
			/// </summary>
			ReadOnly = 1 << 0,

			/// <summary>
			/// The file or directory is hidden. It is not included in an ordinary directory listing.
			/// </summary>
			Hidden = 1 << 1,

			/// <summary>
			/// A file or directory that the operating system uses a part of, or uses exclusively.
			/// </summary>
			System = 1 << 2,

			/// <summary>
			/// The handle that identifies a directory.
			/// </summary>
			Directory = 1 << 4,

			/// <summary>
			/// A file or directory that is an archive file or directory. Applications typically use this attribute to mark files for backup or removal .
			/// </summary>
			Archive = 1 << 5,

			/// <summary>
			/// This value is reserved for system use.
			/// </summary>
			Device = 1 << 6,

			/// <summary>
			/// A file that does not have other attributes set. This attribute is valid only when used alone.
			/// </summary>
			Normal = 1 << 7,

			/// <summary>
			/// A file that is being used for temporary storage. File systems avoid writing data back to mass storage if sufficient cache memory is available, because typically, an application deletes a temporary file after the handle is closed. In that scenario, the system can entirely avoid writing the data. Otherwise, the data is written after the handle is closed.
			/// </summary>
			Temporary = 1 << 8,

			/// <summary>
			/// A file that is a sparse file.
			/// </summary>
			SparseFile = 1 << 9,

			/// <summary>
			/// A file or directory that has an associated reparse point, or a file that is a symbolic link.
			/// </summary>
			ReparsePoint = 1 << 10,

			/// <summary>
			/// A file or directory that is compressed. For a file, all of the data in the file is compressed. For a directory, compression is the default for newly created files and subdirectories.
			/// </summary>
			Compressed = 1 << 11,

			/// <summary>
			/// The data of a file is not available immediately. This attribute indicates that the file data is physically moved to offline storage. This attribute is used by Remote Storage, which is the hierarchical storage management software. Applications should not arbitrarily change this attribute.
			/// </summary>
			Offline = 1 << 12,

			/// <summary>
			/// The file or directory is not to be indexed by the content indexing service.
			/// </summary>
			NotContentIndexed = 1 << 13,

			/// <summary>
			/// A file or directory that is encrypted. For a file, all data streams in the file are encrypted. For a directory, encryption is the default for newly created files and subdirectories.
			/// </summary>
			Encrypted = 1 << 14,

			/// <summary>
			/// <para>The directory or user data stream is configured with integrity (only supported on ReFS volumes). It is not included in an ordinary directory listing. The integrity setting persists with the file if it's renamed. If a file is copied the destination file will have integrity set if either the source file or destination directory have integrity set.</para>
			/// <para>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported until Windows Server 2012.</para>
			/// </summary>
			IntegrityStream = 1 << 15,

			/// <summary>
			/// This value is reserved for system use.
			/// </summary>
			Virtual = 1 << 16,

			/// <summary>
			/// <para>The user data stream not to be read by the background data integrity scanner (AKA scrubber). When set on a directory it only provides inheritance. This flag is only supported on Storage Spaces and ReFS volumes. It is not included in an ordinary directory listing.</para>
			/// <para>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported until Windows 8 and Windows Server 2012.</para>
			/// </summary>
			NoScrubData = 1 << 17,

			/// <summary>
			/// This attribute only appears in directory enumeration classes (FILE_DIRECTORY_INFORMATION, FILE_BOTH_DIR_INFORMATION, etc.). When this attribute is set, it means that the file or directory has no physical representation on the local system; the item is virtual. Opening the item will be more expensive than normal, e.g. it will cause at least some of it to be fetched from a remote store.
			/// </summary>
			RecallOnOpen = 1 << 18,

			/// <summary>
			/// When this attribute is set, it means that the file or directory is not fully present locally. For a file that means that not all of its data is on local storage (e.g. it may be sparse with some data still in remote storage). For a directory it means that some of the directory contents are being virtualized from another location. Reading the file / enumerating the directory will be more expensive than normal, e.g. it will cause at least some of the file/directory content to be fetched from a remote store. Only kernel-mode callers can set this bit.
			/// </summary>
			RecallOnDataAccess = 1 << 22,
		}

		/// <summary>
		/// The <see cref="FileAccess"/> data type is a value that defines standard, specific, and generic rights. These rights are used in access control entries (ACEs) and are the primary means of specifying the requested or granted access to an object.
		/// </summary>
		[Flags]
		protected enum FileAccess {
			/// <summary>
			/// For a file object, the right to read the corresponding file data. For a directory object, the right to read the corresponding directory data.
			/// </summary>
			ReadData = 1 << 0,

			/// <summary>
			/// For a file object, the right to write data to the file. For a directory object, the right to create a file in the directory (FILE_ADD_FILE).
			/// </summary>
			WriteData = 1 << 1,

			/// <summary>
			/// For a directory, the right to create a file in the directory.
			/// </summary>
			AddFile = 1 << 2,

			/// <summary>
			/// For a file object, the right to append data to the file. (For local files, write operations will not overwrite existing data if this flag is specified without FILE_WRITE_DATA.) For a directory object, the right to create a subdirectory (FILE_ADD_SUBDIRECTORY).
			/// </summary>
			AppendData = 1 << 4,

			/// <summary>
			/// Delete access.
			/// </summary>
			Delete = 1 << 16,

			/// <summary>
			/// Read access to the owner, group, and discretionary access control list (DACL) of the security descriptor.
			/// </summary>
			ReadControl = 1 << 17,

			/// <summary>
			/// Write access to the DACL.
			/// </summary>
			WriteDAC = 1 << 18,

			/// <summary>
			/// Write access to owner.
			/// </summary>
			WriteOwner = 1 << 19,

			/// <summary>
			/// Synchronize access.
			/// </summary>
			Synchronize = 1 << 20,

			/// <summary>
			/// Maximum allowed.
			/// </summary>
			MaximumAllowed = 1 << 25,

			/// <summary>
			/// Generic all.
			/// </summary>
			GenericAll = 1 << 28,

			/// <summary>
			/// Generic execute.
			/// </summary>
			GenericExecute = 1 << 29,

			/// <summary>
			/// Generic write.
			/// </summary>
			GenericWrite = 1 << 30,

			/// <summary>
			/// Generic read.
			/// </summary>
			GenericRead = 1 << 31,
		}

		/// <summary>
		/// An action to take on a file or device that exists or does not exist.
		/// </summary>
		protected enum FileDisposition {
			/// <summary>
			/// <para>Creates a new file, only if it does not already exist. If the specified file exists, the function fails and the last-error code is set to ERROR_FILE_EXISTS (80).</para>
			/// <para>If the specified file does not exist and is a valid path to a writable location, a new file is created.</para>
			/// </summary>
			CreateNew = 1,

			/// <summary>
			/// <para>Creates a new file, always. If the specified file exists and is writable, the function overwrites the file, the function succeeds, and last-error code is set to ERROR_ALREADY_EXISTS (183).</para>
			/// <para>If the specified file does not exist and is a valid path, a new file is created, the function succeeds, and the last-error code is set to zero.</para>
			/// <para>For more information, see the Remarks section of this topic.</para>
			/// </summary>
			CreateAlways = 2,

			/// <summary>
			/// <para>Opens a file or device, only if it exists. If the specified file or device does not exist, the function fails and the last-error code is set to ERROR_FILE_NOT_FOUND (2).</para>
			/// <para>For more information about devices, see the Remarks section.</para>
			/// </summary>
			OpenExisting = 3,

			/// <summary>
			/// <para>Opens a file, always. If the specified file exists, the function succeeds and the last-error code is set to ERROR_ALREADY_EXISTS (183).</para>
			/// <para>If the specified file does not exist and is a valid path to a writable location, the function creates a file and the last-error code is set to zero.</para>
			/// </summary>
			OpenAlways = 4,

			/// <summary>
			/// <para>Opens a file and truncates it so that its size is zero bytes, only if it exists. If the specified file does not exist, the function fails and the last-error code is set to ERROR_FILE_NOT_FOUND (2).</para>
			/// <para>The calling process must open the file with the GENERIC_WRITE bit set as part of the dwDesiredAccess parameter.</para>
			/// </summary>
			TruncateExisting = 5,
		}

		/// <summary>
		/// The requested sharing mode of the file or device, which can be read, write, both, delete, all of these, or none.
		/// </summary>
		[Flags]
		protected enum FileShare {
			/// <summary>
			/// Prevents other processes from opening a file or device if they request delete, read, or write access.
			/// </summary>
			None = 0,

			/// <summary>
			/// <para>Enables subsequent open operations on a file or device to request read access. Otherwise, other processes cannot open the file or device if they request read access.</para>
			/// <para>If this flag is not specified, but the file or device has been opened for read access, the function fails.</para>
			/// </summary>
			Read = 1 << 0,

			/// <summary>
			/// <para>Enables subsequent open operations on a file or device to request write access. Otherwise, other processes cannot open the file or device if they request write access.</para>
			/// <para>If this flag is not specified, but the file or device has been opened for write access or has a file mapping with write access, the function fails.</para>
			/// </summary>
			Write = 1 << 1,

			/// <summary>
			/// <para>Enables subsequent open operations on a file or device to request delete access. Otherwise, other processes cannot open the file or device if they request delete access.</para>
			/// <para>If this flag is not specified, but the file or device has been opened for delete access, the function fails.</para>
			/// </summary>
			Delete = 1 << 2,
		}

		/// <summary>
		/// The type of the file.
		/// </summary>
		protected enum FileType {
			/// <summary>
			/// Either the type of the specified file is unknown, or the function failed.
			/// </summary>
			Unknown = 0x0000,

			/// <summary>
			/// The specified file is a disk file.
			/// </summary>
			Disk = 0x0001,

			/// <summary>
			/// The specified file is a character file, typically an LPT device or a console.
			/// </summary>
			Char = 0x0002,

			/// <summary>
			/// The specified file is a socket, a named pipe, or an anonymous pipe.
			/// </summary>
			Pipe = 0x0003,

			/// <summary>
			/// Unused.
			/// </summary>
			Remote = 0x8000,
		}

		/// <summary>
		/// Closes an open object handle.
		/// </summary>
		/// <param name="hObject">A valid handle to an open object.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// <para>If the application is running under a debugger, the function will throw an exception if it receives either a handle value that is not valid or a pseudo-handle value. This can happen if you close a handle twice, or if you call CloseHandle on a handle returned by the FindFirstFile function instead of calling the FindClose function.</para>
		/// </returns>
		[DllImport("Kernel32")]
		[return:MarshalAs(UnmanagedType.Bool)]
		protected static extern Boolean CloseHandle(IntPtr hObject);

		/// <summary>
		/// Creates or opens a file or I/O device. The most commonly used I/O devices are as follows: file, file stream, directory, physical disk, volume, console buffer, tape drive, communications resource, mailslot, and pipe. The function returns a handle that can be used to access the file or device for various types of I/O depending on the file or device and the flags and attributes specified.
		/// </summary>
		/// <param name="lpFileName">
		/// <para>The name of the file or device to be created or opened. You may use either forward slashes (/) or backslashes (\) in this name.</para>
		/// <para>In the ANSI version of this function, the name is limited to MAX_PATH characters. To extend this limit to 32,767 wide characters, use this Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming Files, Paths, and Namespaces.</para>
		/// <para>For information on special device names, see Defining an MS-DOS Device Name.</para>
		/// <para>To create a file stream, specify the name of the file, a colon, and then the name of the stream. For more information, see File Streams.</para>
		/// </param>
		/// <param name="dwDesiredAccess">
		/// <para>The requested access to the file or device, which can be summarized as read, write, both or neither zero).</para>
		/// <para>The most commonly used values are <see cref="FileAccess.GenericRead"/>, <see cref="FileAccess.GenericWrite"/>, or both (<see cref="FileAccess.GenericRead"/> | <see cref="FileAccess.GenericWrite"/>). For more information, see Generic Access Rights, File Security and Access Rights, File Access Rights Constants, and <see cref="FileAccess"/>.</para>
		/// <para>If this parameter is zero, the application can query certain metadata such as file, directory, or device attributes without accessing that file or device, even if GENERIC_READ access would have been denied.</para>
		/// <para>You cannot request an access mode that conflicts with the sharing mode that is specified by the dwShareMode parameter in an open request that already has an open handle.</para>
		/// <para>For more information, see the Remarks section of this topic and Creating and Opening Files.</para>
		/// </param>
		/// <param name="dwShareMode">
		/// <para>The requested sharing mode of the file or device, which can be read, write, both, delete, all of these, or none (refer to the following table). Access requests to attributes or extended attributes are not affected by this flag.</para>
		/// <para>If this parameter is zero and <see cref="CreateFile(String, FileAccess, FileShare, void*, FileDisposition, FileAttributes, void*)"/> succeeds, the file or device cannot be shared and cannot be opened again until the handle to the file or device is closed. For more information, see the Remarks section.</para>
		/// <para>You cannot request a sharing mode that conflicts with the access mode that is specified in an existing request that has an open handle. <see cref="CreateFile(String, FileAccess, FileShare, void*, FileDisposition, FileAttributes, void*)"/> would fail and the <see cref="GetLastError()"/> function would return ERROR_SHARING_VIOLATION.</para>
		/// <para>To enable a process to share a file or device while another process has the file or device open, use a compatible combination of one or more of the following values. For more information about valid combinations of this parameter with the dwDesiredAccess parameter, see Creating and Opening Files.</para>
		/// </param>
		/// <param name="lpSecurityAttributes">
		/// <para>A pointer to a SECURITY_ATTRIBUTES structure that contains two separate but related data members: an optional security descriptor, and a Boolean value that determines whether the returned handle can be inherited by child processes.</para>
		/// <para>This parameter can be NULL.</para>
		/// <para>If this parameter is NULL, the handle returned by CreateFile cannot be inherited by any child processes the application may create and the file or device associated with the returned handle gets a default security descriptor.</para>
		/// <para>The lpSecurityDescriptor member of the structure specifies a SECURITY_DESCRIPTOR for a file or device. If this member is NULL, the file or device associated with the returned handle is assigned a default security descriptor.</para>
		/// <para><see cref="CreateFile(String, FileAccess, FileShare, void*, FileDisposition, FileAttributes, void*)"/> ignores the lpSecurityDescriptor member when opening an existing file or device, but continues to use the bInheritHandle member.</para>
		/// <para>The bInheritHandlemember of the structure specifies whether the returned handle can be inherited.</para>
		/// <para>For more information, see the Remarks section.</para>
		/// </param>
		/// <param name="dwCreationDisposition">
		/// <para>An action to take on a file or device that exists or does not exist.</para>
		/// <para>For devices other than files, this parameter is usually set to OPEN_EXISTING.</para>
		/// <para>For more information, see the Remarks section.</para>
		/// </param>
		/// <param name="dwFlagsAndAttributes">
		/// <para>The file or device attributes and flags, <see cref="FileAttribute.Normal"/> being the most common default value for files.</para>
		/// <para>This parameter can include any combination of the available file attributes (FILE_ATTRIBUTE_*). All other file attributes override <see cref="FileAttribute.Normal"/>.</para>
		/// <para>This parameter can also contain combinations of flags (FILE_FLAG_) for control of file or device caching behavior, access modes, and other special-purpose flags. These combine with any FILE_ATTRIBUTE_ values.</para>
		/// <para>This parameter can also contain Security Quality of Service (SQOS) information by specifying the SECURITY_SQOS_PRESENT flag. Additional SQOS-related flags information is presented in the table following the attributes and flags tables.</para>
		/// </param>
		/// <param name="hTemplateFile">
		/// <para>A valid handle to a template file with the <see cref="FileAccess.GenericRead"/> access right. The template file supplies file attributes and extended attributes for the file that is being created.</para>
		/// <para>This parameter can be NULL.</para>
		/// <para>When opening an existing file, <see cref="CreateFile(String, FileAccess, FileShare, void*, FileDisposition, FileAttributes, void*)"/> ignores this parameter.</para>
		/// <para>When opening a new encrypted file, the file inherits the discretionary access control list from its parent directory. For additional information, see File Encryption.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is an open handle to the specified file, device, named pipe, or mail slot.</para>
		/// <para>If the function fails, the return value is INVALID_HANDLE_VALUE. To get extended error information, call GetLastError.</para>
		/// </returns>
		[DllImport("Kernel32", CharSet = CharSet.Unicode, EntryPoint = "CreateFileW")]
		protected static extern unsafe IntPtr CreateFile(String lpFileName, FileAccess dwDesiredAccess, FileShare dwShareMode, void* lpSecurityAttributes, FileDisposition dwCreationDisposition, FileAttributes dwFlagsAndAttributes, void* hTemplateFile);

		/// <summary>
		/// Retrieves the size of the specified file.
		/// </summary>
		/// <param name="hFile">A handle to the file. The handle must have been created with the FILE_READ_ATTRIBUTES access right or equivalent, or the caller must have sufficient permission on the directory that contains the file. For more information, see File Security and Access Rights.</param>
		/// <param name="lpFileSize">A pointer to a <see cref="LargeInteger"/> structure that receives the file size, in bytes.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError()"/>.</para>
		/// </returns>
		[DllImport("Kernel32", EntryPoint = "GetFileSizeEx")]
		[return: MarshalAs(UnmanagedType.Bool)]
		protected static extern unsafe Boolean GetFileSize(IntPtr hFile, out Int64 lpFileSize);

		/// <summary>
		/// Retrieves the calling thread's last-error code value. The last-error code is maintained on a per-thread basis. Multiple threads do not overwrite each other's last-error code.
		/// </summary>
		/// <returns>
		/// <para>The return value is the calling thread's last-error code.</para>
		/// <para>The Return Value section of the documentation for each function that sets the last-error code notes the conditions under which the function sets the last-error code. Most functions that set the thread's last-error code set it when they fail. However, some functions also set the last-error code when they succeed. If the function is not documented to set the last-error code, the value returned by this function is simply the most recent last-error code to have been set; some functions set the last-error code to 0 on success and others do not.</para>
		/// </returns>
		[DllImport("Kernel32")]
		[return: MarshalAs(UnmanagedType.I4)]
		protected static extern Int32 GetLastError();

		/// <summary>
		/// Retrieves file system attributes for a specified file or directory.
		/// </summary>
		/// <param name="lpFileName">
		/// <para>The name of the file or directory.</para>
		/// <para>In the ANSI version of this function, the name is limited to MAX_PATH characters. To extend this limit to 32,767 wide characters, call the Unicode version of the function (GetFileAttributesW), and prepend "\\?\" to the path. For more information, see File Names, Paths, and Namespaces.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value contains the attributes of the specified file or directory. For a list of attribute values and their descriptions, see File Attribute Constants.</para>
		/// <para>If the function fails, the return value is INVALID_FILE_ATTRIBUTES. To get extended error information, call <see cref="GetLastError()"/>.</para>
		/// </returns>
		[DllImport("Kernel32", CharSet = CharSet.Unicode, EntryPoint = "GetFileAttributesW")]
		protected static extern FileAttribute GetFileAttributes(String lpFileName);

		/// <summary>
		/// Retrieves the file type of the specified file.
		/// </summary>
		/// <param name="hFile">A handle to the file.</param>
		/// <returns>
		/// <para>The function returns a <see cref="FileType"/> value.</para>
		/// <para>You can distinguish between a "valid" return of FILE_TYPE_UNKNOWN and its return due to a calling error (for example, passing an invalid handle to GetFileType) by calling GetLastError.</para>
		/// <para>If the function worked properly and FILE_TYPE_UNKNOWN was returned, a call to GetLastError will return NO_ERROR.</para>
		/// <para>If the function returned FILE_TYPE_UNKNOWN due to an error in calling GetFileType, GetLastError will return the error code.</para>
		/// </returns>
		[DllImport("Kernel32")]
		protected static extern FileType GetFileType(IntPtr hFile);

		/// <summary>
		/// Reads data from the specified file or input/output (I/O) device. Reads occur at the position specified by the file pointer if supported by the device.
		/// </summary>
		/// <param name="hFile">
		/// <para>A handle to the device (for example, a file, file stream, physical disk, volume, console buffer, tape drive, socket, communications resource, mailslot, or pipe).</para>
		/// <para>The hFile parameter must have been created with read access. For more information, see Generic Access Rights and File Security and Access Rights.</para>
		/// <para>For asynchronous read operations, hFile can be any handle that is opened with the FILE_FLAG_OVERLAPPED flag by the CreateFile function, or a socket handle returned by the socket or accept function.</para>
		/// </param>
		/// <param name="lpBuffer">
		/// <para>A pointer to the buffer that receives the data read from a file or device.</para>
		/// <para>This buffer must remain valid for the duration of the read operation. The caller must not use this buffer until the read operation is completed.</para>
		/// </param>
		/// <param name="nNumberOfBytesToRead">The maximum number of bytes to be read.</param>
		/// <param name="lpNumberOfBytesRead">
		/// <para>A pointer to the variable that receives the number of bytes read when using a synchronous hFile parameter. ReadFile sets this value to zero before doing any work or error checking. Use NULL for this parameter if this is an asynchronous operation to avoid potentially erroneous results.</para>
		/// <para>This parameter can be NULL only when the lpOverlapped parameter is not NULL.</para>
		/// <para>For more information, see the Remarks section.</para>
		/// </param>
		/// <param name="lpOverlapped">
		/// <para>A pointer to an OVERLAPPED structure is required if the hFile parameter was opened with FILE_FLAG_OVERLAPPED, otherwise it can be NULL.</para>
		/// <para>If hFile is opened with FILE_FLAG_OVERLAPPED, the lpOverlapped parameter must point to a valid and unique OVERLAPPED structure, otherwise the function can incorrectly report that the read operation is complete.</para>
		/// <para>For an hFile that supports byte offsets, if you use this parameter you must specify a byte offset at which to start reading from the file or device. This offset is specified by setting the Offset and OffsetHigh members of the OVERLAPPED structure. For an hFile that does not support byte offsets, Offset and OffsetHigh are ignored.</para>
		/// <para>For more information about different combinations of lpOverlapped and FILE_FLAG_OVERLAPPED, see the Remarks section and the Synchronization and File Position section.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero (TRUE).</para>
		/// <para>If the function fails, or is completing asynchronously, the return value is zero (FALSE). To get extended error information, call the <see cref="GetLastError()"/> function.</para>
		/// </returns>
		[DllImport("Kernel32")]
		[return: MarshalAs(UnmanagedType.Bool)]
		protected static extern unsafe Boolean ReadFile(IntPtr hFile, void* lpBuffer, Int32 nNumberOfBytesToRead, out Int32 lpNumberOfBytesRead, void* lpOverlapped);

		/// <summary>
		/// Writes data to the specified file or input/output (I/O) device.
		/// </summary>
		/// <param name="hFile">
		/// <para>A handle to the file or I/O device (for example, a file, file stream, physical disk, volume, console buffer, tape drive, socket, communications resource, mailslot, or pipe).</para>
		/// <para>The hFile parameter must have been created with the write access. For more information, see Generic Access Rights and File Security and Access Rights.</para>
		/// <para>For asynchronous write operations, hFile can be any handle opened with the CreateFile function using the FILE_FLAG_OVERLAPPED flag or a socket handle returned by the socket or accept function.</para>
		/// </param>
		/// <param name="lpBuffer">
		/// <para>A pointer to the buffer containing the data to be written to the file or device.</para>
		/// <para>This buffer must remain valid for the duration of the write operation. The caller must not use this buffer until the write operation is completed.</para>
		/// </param>
		/// <param name="nNumberOfBytesToWrite">
		/// <para>The number of bytes to be written to the file or device.</para>
		/// <para>A value of zero specifies a null write operation. The behavior of a null write operation depends on the underlying file system or communications technology.</para>
		/// </param>
		/// <param name="lpNumberOfBytesWritten">
		/// <para>A pointer to the variable that receives the number of bytes written when using a synchronous hFile parameter. WriteFile sets this value to zero before doing any work or error checking. Use NULL for this parameter if this is an asynchronous operation to avoid potentially erroneous results.</para>
		/// <para>This parameter can be NULL only when the lpOverlapped parameter is not NULL.</para>
		/// <para>For more information, see the Remarks section.</para>
		/// </param>
		/// <param name="lpOverlapped">
		/// <para>A pointer to an OVERLAPPED structure is required if the hFile parameter was opened with FILE_FLAG_OVERLAPPED, otherwise this parameter can be NULL.</para>
		/// <para>For an hFile that supports byte offsets, if you use this parameter you must specify a byte offset at which to start writing to the file or device. This offset is specified by setting the Offset and OffsetHigh members of the OVERLAPPED structure. For an hFile that does not support byte offsets, Offset and OffsetHigh are ignored.</para>
		/// <para>To write to the end of file, specify both the Offset and OffsetHigh members of the OVERLAPPED structure as 0xFFFFFFFF. This is functionally equivalent to previously calling the CreateFile function to open hFile using FILE_APPEND_DATA access.</para>
		/// <para>For more information about different combinations of lpOverlapped and FILE_FLAG_OVERLAPPED, see the Remarks section and the Synchronization and File Position section.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero (TRUE).</para>
		/// <para>If the function fails, or is completing asynchronously, the return value is zero (FALSE). To get extended error information, call the GetLastError function.</para>
		/// </returns>
		[DllImport("Kernel32")]
		[return: MarshalAs(UnmanagedType.Bool)]
		protected static extern unsafe Boolean WriteFile(IntPtr hFile, void* lpBuffer, Int32 nNumberOfBytesToWrite, out Int32 lpNumberOfBytesWritten, void* lpOverlapped);
	}
}
#endif
