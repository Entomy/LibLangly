namespace System.Text.Patterns {
	internal sealed class StringChecker : PrimativePattern, IEquatable<StringChecker> {
		private readonly Func<String, Boolean> Check;

		protected internal override Int32 Length { get; }

		/// <summary>
		/// Construct a new <see cref="StringChecker"/> from the specified <paramref name="Check"/> and <paramref name="Length"/>
		/// </summary>
		/// <param name="Check">A <see cref="Func{T, TResult}"/> taking a <see cref="String"/> and returning a <see cref="Boolean"/></param>
		/// <param name="Length">The length of the <see cref="String"/> to check</param>
		internal StringChecker(Func<String, Boolean> Check, Int32 Length) {
			this.Check = Check;
			this.Length = Length;
		}

		/// <summary>
		/// Check the first <see cref="Char"/> of the <paramref name="Source"/> against this <see cref="Pattern"/>
		/// </summary>
		/// <param name="Source"></param>
		/// <returns>True if a full parse would possibly match, false if definately not</returns>
		protected internal override Boolean CheckFirstChar(ref Source Source) => throw new NotImplementedException();


		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		public override Result Consume(ref Source Source) {
			if (Length > Source.Length) { return new Result(); }
			return Check(Source.Peek(Length).ToString()) ? new Result(Source.Read(Length)) : new Result();
		}

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case StringChecker other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public override Boolean Equals(ReadOnlySpan<Char> other) => Length == other.Length ? Check(other.ToString()) : false;

		public override Boolean Equals(String other) => Length == other.Length ? Check(other) : false;

		public Boolean Equals(StringChecker other) => Check.Equals(other.Check) && Length.Equals(other.Length);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => Check.GetHashCode();

		/// <summary>
		/// Attempt to consume from the <paramref name="Source"/> while neglecting the <see cref="ComplexPattern"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		protected internal override Result Neglect(ref Source Source) {
			if (Length > Source.Length) { return new Result(); }
			return Check(Source.Peek(Length).ToString()) ? new Result() : new Result(Source.Read(Length));
		}

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() => Check.ToString();
	}
}
