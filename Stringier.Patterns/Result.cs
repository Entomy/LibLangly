namespace System.Text.Patterns {
	/// <summary>
	/// Represents the result value of parsing operations. There are two main components. The first is a Boolean representing success of the operation. The second is the captured string during the operation. This type can be used as if it is either individual type.
	/// </summary>
	public ref struct Result {
		/// <summary>
		/// Whether the parsing attempt was successful
		/// </summary>
		internal Boolean Success;

		/// <summary>
		/// What was captured by the parser, if anything
		/// </summary>
		/// <remarks>
		/// It is important to understand that this being empty does not mean an unsuccessful parse, as certain pattern types, like the optor, are successful regardless
		/// </remarks>
		private readonly ReadOnlySpan<Char> Capture;

		internal Result(Char Capture) : this(new ReadOnlySpan<Char>(new Char[] { Capture })) { }

		internal Result(Char Capture, Boolean Success) : this(new ReadOnlySpan<Char>(new Char[] { Capture }), Success) { }

		internal Result(ReadOnlySpan<Char> Capture) {
			this.Success = true;
			this.Capture = Capture;
		}

		internal Result(ReadOnlySpan<Char> Capture, Boolean Success) {
			this.Success = Success;
			this.Capture = Capture;
		}

		internal Result(String Capture) {
			this.Success = true;
			this.Capture = Capture.AsSpan();
		}

		internal Result(String Capture, Boolean Success) {
			this.Success = Success;
			this.Capture = Capture.AsSpan();
		}

		/// <summary>
		/// Get the <see cref="Char"/> at the specified <paramref name="Index"/>
		/// </summary>
		/// <param name="Index">A 32-bit integer describing the position of the <see cref="Char"/> to get</param>
		/// <returns>The <see cref="Char"/> at the specified <paramref name="Index"/></returns>
		public Char this[Int32 Index] => Capture[Index];

		/// <summary>
		/// The length of the captured text
		/// </summary>
		public Int32 Length => Capture.Length;

		public static implicit operator Boolean(Result Result) => Result.Success;

		public static implicit operator String(Result Result) => Result.Capture.ToString();

		public static implicit operator Source(Result Result) => new Source(Result.Capture);

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() => Capture.ToString();

	}
}
