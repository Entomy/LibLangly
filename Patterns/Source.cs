using System;
using System.IO;
using System.Numerics;
using System.Text;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a parsing source.
	/// </summary>
	/// <remarks>
	/// This is a text buffer with an included implicit cursor. This cursor (<see cref="Position"/>) is not exposed to the downstream programmer, but is available for direct manipulation by patterns and parsers within this assembly.
	/// </remarks>
	public ref struct Source {
		/// <summary>
		/// Buffer the source represents.
		/// </summary>
		/// <remarks>
		/// This is actually an array of <see cref="Char"/>, stored as <see cref="UInt16"/> to enable rapid and easy conversions to <see cref="Vector{T}"/> of <see cref="UInt16"/>.
		/// </remarks>
		private readonly UInt16[] Buffer;

		/// <summary>
		/// Whether currently at the end of the source
		/// </summary>
		public Boolean EOF => Length == 0;

		/// <summary>
		/// The remaining length of the source
		/// </summary>
		public Int32 Length => Buffer.Length - Position;

		/// <summary>
		/// The position within the source buffer
		/// </summary>
		/// <remarks>
		/// This is for internal manipulation, such as resetting the index after a failed consume
		/// </remarks>
		internal Int32 Position { get; set; }

		/// <summary>
		/// Construct a new <see cref="Source"/> from the specified <paramref name="String"/>.
		/// </summary>
		/// <param name="String">A <see cref="String"/> to use as a source.</param>
		public Source(String String) : this(String, false) { }

		/// <summary>
		/// Construct a new <see cref="Source"/> from the specified <paramref name="String"/>.
		/// </summary>
		/// <param name="String">A <see cref="String"/> to use as a source.</param>
		/// <param name="Preconvert">Whether to preconvert for case insensitive comparisons.</param>
		public Source(String String, Boolean Preconvert) {
			if (String is null) {
				throw new ArgumentNullException(nameof(String));
			}
			Buffer = new UInt16[String.Length];
			for (Int32 i = 0; i < String.Length; i++) {
				Buffer[i] = Preconvert ? String[i].ToUpperInvariant() : String[i];
			}
			Position = 0;
		}

		/// <summary>
		/// Construct a new <see cref="Source"/> from the specified <paramref name="Stream"/>.
		/// </summary>
		/// <param name="Stream">A <see cref="FileStream"/> to use as a source.</param>
		/// <param name="Preconvert">Whether to preconvert for case insensitive comparisons.</param>
		public Source(FileStream Stream, Boolean Preconvert) {
			if (Stream is null) {
				throw new ArgumentNullException(nameof(Stream));
			}
			Buffer = new UInt16[Stream.Length];
			for (Int32 i = 0; i < Stream.Length; i++) {
				Buffer[i] = Preconvert ? ((UInt16)Stream.ReadByte()).ToUpperInvariant() : ((UInt16)Stream.ReadByte());
			}
			Position = 0;
		}

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns><c>true</c> if equal; otherwise, <c>false</c>.</returns>
		public override Boolean Equals(Object obj) => false;

		public static Boolean operator ==(Source left, Source right) => left.Equals(right);

		public static Boolean operator !=(Source left, Source right) => !left.Equals(right);

		/// <summary>
		/// Determines whether this <see cref="Source"/> and the <paramref name="other"/> <see cref="Source"/> are equal.
		/// </summary>
		/// <param name="other">The <see cref="Source"/> to compare to</param>
		/// <returns><c>true</c> if equal; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <see cref="Source"/> equality doesn't care at all where the cursor is currently. Conceptually, the cursor is a separate object, and is only present inside of this structure for performance considerations and type requirements.
		/// </remarks>
		public Boolean Equals(Source other) => Buffer.Equals(other.Buffer);

		/// <summary>
		/// Returns the hash code for this source.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => Buffer.GetHashCode();

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() {
			StringBuilder Result = new StringBuilder();
			foreach (UInt16 CodePoint in Buffer) {
				_ = Result.Append((Char)CodePoint);
			}
			return Result.ToString();
		}

		/// <summary>
		/// Peek at the next <see cref="Char"/> without advancing the position
		/// </summary>
		/// <returns>The next <see cref="Char"/> in the <see cref="Source"/></returns>
		internal ref UInt16 Peek() => ref Buffer[Position];

		/// <summary>
		/// Peek at the next <paramref name="Count"/> <see cref="Char"/> without advancing the position
		/// </summary>
		/// <param name="Count">A 32-bit integer specifying how many <see cref="Char"/> to return</param>
		/// <returns>The next <paramref name="Count"/> <see cref="Char"/> in the <see cref="Source"/></returns>
		internal ReadOnlySpan<UInt16> Peek(Int32 Count) => Buffer.AsSpan().Slice(Position, Count);

		/// <summary>
		/// Read the next <see cref="Char"/> and advance the position
		/// </summary>
		/// <returns>The next <see cref="Char"/> in the <see cref="Source"/></returns>
		internal ref readonly UInt16 Read() => ref Buffer[Position++];

		/// <summary>
		/// Read the next <paramref name="Count"/> <see cref="Char"/> and advance the position
		/// </summary>
		/// <param name="Count">A 32-bit integer specifying how many <see cref="Char"/> to return</param>
		/// <returns>The next <paramref name="Count"/> <see cref="Char"/> in the <see cref="Source"/></returns>
		internal ReadOnlySpan<UInt16> Read(Int32 Count) {
			ReadOnlySpan<UInt16> Result = Peek(Count);
			Position += Count;
			return Result;
		}
	}
}
