using System.IO;

namespace System.Text.Patterns {
	/// <summary>
	/// Represents a parsing source
	/// </summary>
	public ref struct Source {
		private readonly ReadOnlySpan<Char> Buffer;

		public Source(String String) {
			Buffer = String.AsSpan();
			Position = 0;
		}

		public Source(Stream Stream) {
			using (StreamReader Reader = new StreamReader(Stream)) {
				Buffer = Reader.ReadToEnd().AsSpan();
			}
			Position = 0;
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
		/// 
		/// </summary>
		/// <remarks>
		/// This is for internal manipulation, such as resetting the index after a failed consume
		/// </remarks>
		internal Int32 Position { get; set; }

		internal ref readonly Char Peek() => ref Buffer[Position];

		internal ReadOnlySpan<Char> Peek(Int32 Count) => Buffer.Slice(Position, Count);

		internal ref readonly Char Read() => ref Buffer[Position++];

		internal ReadOnlySpan<Char> Read(Int32 Count) {
			ReadOnlySpan<Char> Result = Peek(Count);
			Position += Count;
			return Result;
		}

		public override String ToString() => Buffer.Slice(Position).ToString();
	}
}
