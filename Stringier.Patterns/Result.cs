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
		/// Whether any <see cref="Error"/> occured during parsing; <see cref="ErrorType.None"/> is successful
		/// </summary>
		internal Error Error;

		/// <summary>
		/// The <see cref="Source"/> this <see cref="Result"/> is from
		/// </summary>
		private readonly Source Source;

		internal Result(ref Source Source) {
			this.Error = new Error();
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

		public static implicit operator Boolean(Result Result) => Result.Error.Type == ErrorType.None;

		public static implicit operator ReadOnlySpan<Char>(Result Result) => Result.Source.Substring(Result.Start, Result.Length);

		public static implicit operator String(Result Result) => Result.Source.Substring(Result.Start, Result.Length).ToString();

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		public override Boolean Equals(Object obj) {
			switch (obj) {
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public static Boolean operator ==(Result left, Result right) => left.Equals(right);

		public static Boolean operator !=(Result left, Result right) => !left.Equals(right);

		/// <summary>
		/// Determines whether this <see cref="Result"/> and the <paramref name="other"/> <see cref="Result"/> are equal.
		/// </summary>
		/// <param name="other">The <see cref="Result"/> to compare to</param>
		/// <returns><c>true</c> if equal; otherwise, <c>false</c>.</returns>
		public Boolean Equals(Result other) => Source.Equals(other.Source);

		public static Boolean operator ==(String left, Result right) {
			if (left is null) {
				return false;
			}
			return right.Equals(left);
		}

		public static Boolean operator ==(Result left, String right) {
			if (right is null) {
				return false;
			}
			return left.Equals(right);
		}

		public static Boolean operator !=(String left, Result right) {
			if (left is null) {
				return false;
			}
			return !right.Equals(left);
		}

		public static Boolean operator !=(Result left, String right) {
			if (right is null) {
				return false;
			}
			return !left.Equals(right);
		}

		/// <summary>
		/// Determines whether this <see cref="Result"/> and the <paramref name="other"/> <see cref="String"/> are equal.
		/// </summary>
		/// <param name="other">The <see cref="String"/> to compare to</param>
		/// <returns><c>true</c> if equal; otherwise, <c>false</c>.</returns>
		public Boolean Equals(String other) {
			if (other is null) {
				return false;
			}
			return Stringier.Equals(Source.Substring(Start, Length), other);
		}

		public static Boolean operator ==(ReadOnlySpan<Char> left, Result right) => right.Equals(left);

		public static Boolean operator ==(Result left, ReadOnlySpan<Char> right) => left.Equals(right);

		public static Boolean operator !=(ReadOnlySpan<Char> left, Result right) => !right.Equals(left);

		public static Boolean operator !=(Result left, ReadOnlySpan<Char> right) => !left.Equals(right);

		/// <summary>
		/// Determines whether this <see cref="Result"/> and the <paramref name="other"/> <see cref="ReadOnlySpan<Char>"/> are equal.
		/// </summary>
		/// <param name="other">The <see cref="ReadOnlySpan<Char>"/> to compare to</param>
		/// <returns><c>true</c> if equal; otherwise, <c>false</c>.</returns>
		public Boolean Equals(ReadOnlySpan<Char> other) => Stringier.Equals(Source.Substring(Start, Length), other);

		public override Int32 GetHashCode() => Source.GetHashCode() ^ Start.GetHashCode() ^ Length.GetHashCode();

		/// <summary>
		/// Throw a <see cref="ParserException"/> based on the error that occured, if any
		/// </summary>
		public void ThrowException() => Error.Throw();

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() => Source.Substring(Start, Length).ToString();

	}
}
