namespace System.Text.Patterns {
	/// <summary>
	/// Represents the result value of parsing operations. There are two main components. The first is a Boolean representing success of the operation. The second is the captured string during the operation. This type can be used as if it is either individual type.
	/// </summary>
	public ref struct Result {
		internal readonly Int32 Start;

		internal Error? Error;

		private readonly Source Source;

		internal Result(ref Source Source) {
			this.Error = null;
			this.Source = Source;
			this.Start = Source.Position;
			this.Length = 0;
		}

		/// <summary>
		/// The length of the captured text
		/// </summary>
		public Int32 Length {
			get;
			internal set;
		}

		public static implicit operator Boolean(Result Result) => Result.Error is null;

		public static implicit operator String(Result Result) => Result.Source.Substring(Result.Start, Result.Length).ToString();

		/// <summary>
		/// Throw a <see cref="ParserException"/> based on the error that occured
		/// </summary>
		public void ThrowException() => Error?.Throw();

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() => Source.Substring(Start, Length).ToString();

	}
}
