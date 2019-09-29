namespace System.Text.Patterns {
	/// <summary>
	/// Represents the result value of parsing operations.
	/// </summary>
	/// <remarks>
	/// <para>In very simple terms, there are two main components. The first is a Boolean representing success of the operation. The second is the captured string during the operation. This type can be used as if it is either individual type.</para>
	/// <para>In more technicaly terms, this type only appears to be those, and may actually be implemented using complete different means.</para>
	/// </remarks>
	public ref struct Result {
		/// <summary>
		/// The position in the <see cref="Source"/> where this <see cref="Result"/> starts from
		/// </summary>
		internal readonly Int32 Start;

		/// <summary>
		/// Whether any <see cref="Error"/> occured during parsing; <c>null</c> is successful
		/// </summary>
		internal Error? Error;

		/// <summary>
		/// The <see cref="Source"/> this <see cref="Result"/> is from
		/// </summary>
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

		public static implicit operator ReadOnlySpan<Char>(Result Result) => Result.Source.Substring(Result.Start, Result.Length);

		public static implicit operator String(Result Result) => Result.Source.Substring(Result.Start, Result.Length).ToString();

		/// <summary>
		/// Throw a <see cref="ParserException"/> based on the error that occured, if any
		/// </summary>
		public void ThrowException() => Error?.Throw();

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() => Source.Substring(Start, Length).ToString();

	}
}
