using System;
using System.IO;
using Defender;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a parsing source
	/// </summary>
	/// <remarks>
	/// This is a text buffer with an included implicit cursor. This cursor (<see cref="Position"/>) is not exposed to the downstream programmer, but is available for direct manipulation by patterns and parsers within this assembly.
	/// </remarks>
	public ref struct Source {
		/// <summary>
		/// Buffer the source represents
		/// </summary>
		private readonly ReadOnlySpan<Char> Buffer;

		/// <summary>
		/// The hash code of this instance.
		/// </summary>
		/// <remarks>
		/// We don't have an actual, immutible, way to get a hash code computed from the other fields in this struct. As a result, we have to create and manage hash codes ourself.
		/// </remarks>
		private readonly Int32 HashCode;

		/// <summary>
		/// Construct a new <see cref="Source"/> from the specified <paramref name="string"/>
		/// </summary>
		/// <param name="string">A <see cref="String"/> to use as a source</param>
		public Source(String @string) {
			Guard.NotNull(@string, nameof(@string));
			Buffer = @string.AsSpan();
			Position = 0;
			HashCode = Rng.Next();
		}

		/// <summary>
		/// Construct a new <see cref="Source"/> from the specified <paramref name="stream"/>
		/// </summary>
		/// <param name="stream">A <see cref="Stream"/> to use as a source</param>
		public Source(Stream stream) {
			Guard.NotNull(stream, nameof(stream));
			using (StreamReader Reader = new StreamReader(stream)) {
				Buffer = Reader.ReadToEnd().AsSpan();
			}
			Position = 0;
			HashCode = Rng.Next();
		}

		/// <summary>
		/// Construct a new <see cref="Source"/> from the specified <paramref name="span"/>
		/// </summary>
		/// <param name="span">A <see cref="Span{T}"/> to use as a source</param>
		public Source(Span<Char> span) {
			Buffer = span;
			Position = 0;
			HashCode = Rng.Next();
		}

		/// <summary>
		/// Construct a new <see cref="Source"/> from the specified <paramref name="span"/>
		/// </summary>
		/// <param name="span">A <see cref="ReadOnlySpan{T}"/> to use as a source</param>
		public Source(ReadOnlySpan<Char> span) {
			Buffer = span;
			Position = 0;
			HashCode = Rng.Next();
		}

		/// <summary>
		/// Construct a new <see cref="Source"/>, using the <paramref name="result"/>
		/// </summary>
		/// <param name="result">A <see cref="Result"/> to use as the source</param>
		public Source(Result result) {
			Buffer = result.AsSpan();
			Position = 0;
			HashCode = Rng.Next();
		}

		public ref readonly Char this[Int32 index] => ref Buffer[index];

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
		/// This is mutable for internal manipulation, such as advancing on a match or resetting the index after a failed consume.
		/// </remarks>
		public Int32 Position { get; internal set; }

		public static Boolean operator !=(Source left, Source right) => !left.Equals(right);

		public static Boolean operator ==(Source left, Source right) => left.Equals(right);

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns>Always <c>false</c>, as ref struct's don't inherit from <see cref="Object"/>.</returns>
		public override Boolean Equals(Object? obj) => false;

		/// <summary>
		/// Determines whether this <see cref="Source"/> and the <paramref name="other"/> <see cref="Source"/> are equal.
		/// </summary>
		/// <param name="other">The <see cref="Source"/> to compare to</param>
		/// <returns><c>true</c> if equal; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <see cref="Source"/> equality doesn't care at all where the cursor is currently. Conceptually, the cursor is a separate object, and is only present inside of this structure for performance considerations and type requirements.
		/// </remarks>
		public Boolean Equals(Source other) => Buffer.Equals(other.Buffer, StringComparison.OrdinalIgnoreCase);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => HashCode;

		/// <summary>
		/// Attempt to restore the state of this <see cref="Source"/> from the specified <paramref name="State"/>.
		/// </summary>
		/// <param name="State">A <see cref="SourceState"/> object to restore from.</param>
		public void Restore(SourceState State) {
			if (State.Source == this) {
				Position = State.Position;
			} else {
				throw new SourceStateMismatchException();
			}
		}

		/// <summary>
		/// Store the current state of this <see cref="Source"/> into a <see cref="SourceState"/> object.
		/// </summary>
		/// <returns>The <see cref="SourceState"/> representing the current state.</returns>
		public SourceState Store() => new SourceState(this, Position);

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() => Buffer.Slice(Position).ToString();

		/// <summary>
		/// Peek at the next <see cref="Char"/> without advancing the position
		/// </summary>
		/// <returns>The next <see cref="Char"/> in the <see cref="Source"/></returns>
		internal ref readonly Char Peek() => ref Buffer[Position];

		/// <summary>
		/// Peek at the next <paramref name="Count"/> <see cref="Char"/> without advancing the position
		/// </summary>
		/// <param name="Count">A 32-bit integer specifying how many <see cref="Char"/> to return</param>
		/// <returns>The next <paramref name="Count"/> <see cref="Char"/> in the <see cref="Source"/></returns>
		internal ReadOnlySpan<Char> Peek(Int32 Count) => Buffer.Slice(Position, Count);

		/// <summary>
		/// Read the next <see cref="Char"/> and advance the position
		/// </summary>
		/// <returns>The next <see cref="Char"/> in the <see cref="Source"/></returns>
		internal ref readonly Char Read() => ref Buffer[Position++];

		/// <summary>
		/// Read the next <paramref name="Count"/> <see cref="Char"/> and advance the position
		/// </summary>
		/// <param name="Count">A 32-bit integer specifying how many <see cref="Char"/> to return</param>
		/// <returns>The next <paramref name="Count"/> <see cref="Char"/> in the <see cref="Source"/></returns>
		internal ReadOnlySpan<Char> Read(Int32 Count) {
			ReadOnlySpan<Char> Result = Peek(Count);
			Position += Count;
			return Result;
		}

		/// <summary>
		/// Retrieves a substring from this instance. The substring starts at a specified character position and continues to the end of the string.
		/// </summary>
		/// <param name="startIndex">The zero-based starting character position of a substring in this instance.</param>
		/// <returns>A <see cref="String"/> that is equivalent to the substring that begins at <paramref name="startIndex"/> in this instance, or Empty if <paramref name="startIndex"/> is equal to the length of this instance.</returns>
		internal ReadOnlySpan<Char> Substring(Int32 startIndex) => Buffer.Slice(startIndex);

		/// <summary>
		/// Retrieves a substring from this instance. The substring starts at a specified character position and has a specified length.
		/// </summary>
		/// <param name="startIndex">The zero-based starting character position of a substring in this instance.</param>
		/// <param name="length">The number of characters in the substring.</param>
		/// <returns>A <see cref="String"/> that is equivalent to the substring of length <paramref name="length"/> that begins at <paramref name="startIndex"/> in this instance, or Empty if <paramref name="startIndex"/> is equal to the length of this instance and <paramref name="length"/> is zero.</returns>
		internal ReadOnlySpan<Char> Substring(Int32 startIndex, Int32 length) => Buffer.Slice(startIndex, length);
	}
}
