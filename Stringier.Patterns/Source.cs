using System.IO;

namespace System.Text.Patterns {
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
		/// Construct a new <see cref="Source"/> from the specified <paramref name="String"/>
		/// </summary>
		/// <param name="String">A <see cref="String"/> to use as a source</param>
		public Source(String String) {
			Buffer = String.AsSpan();
			position = 0;
		}

		/// <summary>
		/// Construct a new <see cref="Source"/> from the specified <paramref name="Stream"/>
		/// </summary>
		/// <param name="Stream">A <see cref="Stream"/> to use as a source</param>
		public Source(Stream Stream) {
			using (StreamReader Reader = new StreamReader(Stream)) {
				Buffer = Reader.ReadToEnd().AsSpan();
			}
			position = 0;
		}

		/// <summary>
		/// Construct a new <see cref="Source"/> from the specified <paramref name="Span"/>
		/// </summary>
		/// <param name="Span">A <see cref="Span{T}"/> to use as a source</param>
		public Source(Span<Char> Span) {
			Buffer = Span;
			position = 0;
		}

		/// <summary>
		/// Construct a new <see cref="Source"/> from the specified <paramref name="Span"/>
		/// </summary>
		/// <param name="Span">A <see cref="ReadOnlySpan{T}"/> to use as a source</param>
		public Source(ReadOnlySpan<Char> Span) {
			Buffer = Span;
			position = 0;
		}

		/// <summary>
		/// Whether currently at the end of the source
		/// </summary>
		public Boolean EOF => Length == 0;

		/// <summary>
		/// The remaining length of the source
		/// </summary>
		public Int32 Length => Buffer.Length - Position;

		/// <summary>
		/// Private position value, manipulate with <see cref="Position"/> instead
		/// </summary>
		private Int32 position;

		/// <summary>
		/// The position within the source buffer
		/// </summary>
		/// <remarks>
		/// This is for internal manipulation, such as resetting the index after a failed consume
		/// </remarks>
		internal Int32 Position {
			get => position;
			set {
				position = value;
				if (Length < 0) { throw new IndexOutOfRangeException(); }
			}
		}

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
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() => Buffer.Slice(Position).ToString();
	}
}
