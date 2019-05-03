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

		public Int32 Length => Buffer.Length - Position;

		internal Int32 Position { get; set; }

		internal ReadOnlySpan<Char> Peek(Int32 Count) => Buffer.Slice(Position, Count);

		internal ReadOnlySpan<Char> Read(Int32 Count) {
			ReadOnlySpan<Char> Result = Peek(Count);
			Position += Count;
			return Result;
		}

		public override String ToString() => Buffer.Slice(Position).ToString();
	}
}
