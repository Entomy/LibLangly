namespace System.Text.Patterns {
	/// <summary>
	/// This is an internal pattern used to programatically check a <see cref="Char"/> for existance within a set.
	/// </summary>
	/// <remarks>
	/// Specifically, it's used in the construction of predefined patterns. This is because it's considerably easier to define a range of codepoints and check for the existance within that. The code to do this is clunky and awkward however, so not something to expose publicly.
	/// Testing: While it might seem like testing this class is somehow not possible because of the visibility, this isn't the case at all. <see cref="Checker"/> is exposed, non-obviously, through the predefined patterns, and can easily be checked that way; if those fail while the isolated tests pass, the issue is almost certainly with this class.
	/// </remarks>
	internal sealed class Checker : IPrimativeNode, IEquatable<Checker> {
		private readonly Func<Char, Boolean> Check;

		Int32 IPrimative.Length => 1;

		/// <summary>
		/// Construct a new <see cref="Checker"/> from the specified <paramref name="Check"/>
		/// </summary>
		/// <param name="Check">A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/></param>
		internal Checker(Func<Char, Boolean> Check) => this.Check = Check;

		public static implicit operator Checker(Func<Char, Boolean> Check) => new Checker(Check);

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Source">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		public Result Consume(String Source) {
			Source source = new Source(Source);
			return Consume(ref source);
		}

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		public Result Consume(ref Source Source) {
			if (Source.Length == 0) { return new Result(); }
			return Check(Source.Peek()) ? new Result(Source.Read(1)) : new Result();
		}

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case String Other:
				return Equals(Other);
			case Checker Other:
				return Equals(Other);
			default:
				return false;
			}
		}

		public Boolean Equals(String other) => throw new NotImplementedException();

		public Boolean Equals(Checker other) => Check.Equals(other);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => Check.GetHashCode();

		/// <summary>
		/// Attempt to consume from the <paramref name="Source"/> while neglecting the <see name="Pattern"/>
		/// </summary>
		/// <param name="Source">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		public Result Neglect(String Source) {
			Source source = new Source(Source);
			return Neglect(ref source);
		}

		/// <summary>
		/// Attempt to consume from the <paramref name="Source"/> while neglecting the <see cref="Pattern"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		public Result Neglect(ref Source Source) {
			if (Source.Length == 0) { return new Result(); }
			return Check(Source.Peek()) ? new Result() : new Result(Source.Read(1));
		}

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() => Check.ToString();
	}
}
