namespace System.Text.Patterns {
	/// <summary>
	/// Represents a repeater pattern
	/// </summary>
	internal sealed class Repeater : Node, IModifier, IEquatable<Repeater> {

		private readonly Int32 Count;

		private readonly INode Pattern;

		internal Repeater(INode Pattern, Int32 Count) {
			this.Pattern = Pattern;
			this.Count = Count;
		}

		internal Repeater(Pattern Pattern, Int32 Count) : this(Pattern.Head, Count) { }

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured string</returns>
		public override Result Consume(ref Source Source) {
			Int32 OriginalPosition = Source.Position;
			Result Result = new Result("", false);
			for (Int32 i = 0; i < Count; i++) {
				Result = Pattern.Consume(ref Source);
				if (!Result) { goto Cleanup; }
			}
			// Skip cleanup
			goto Done;
		Cleanup:
			Source.Position = OriginalPosition;
		Done:
			Int32 FinalPosition = Source.Position;
			Source.Position = OriginalPosition;
			return new Result(Source.Read(FinalPosition - OriginalPosition), Result);
		}

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case Repeater Other:
				return Equals(Other);
			case String Other:
				return Equals(Other);
			default:
				return false;
			}
		}

		public override Boolean Equals(String other) {
			Source Source = new Source(other);
			Result Result = new Result();
			for (Int32 i = 0; i < Count; i++) {
				Result = Pattern.Consume(ref Source);
			}
			return Result;
		}

		public Boolean Equals(Repeater other) => Pattern.Equals(other.Pattern) && Count.Equals(other.Count);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => Pattern.GetHashCode() ^ Count.GetHashCode();

		/// <summary>
		/// Attempt to consume from the <paramref name="Source"/> while neglecting this <see cref="Pattern"/>
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public override Result Neglect(ref Source Source) {
			Int32 OriginalPosition = Source.Position;
			Result Result = new Result("", false);
			for (Int32 i = 0; i < Count; i++) {
				Result = Pattern.Neglect(ref Source);
				if (!Result) { goto Cleanup; }
			}
			// Skip cleanup
			goto Done;
		Cleanup:
			Source.Position = OriginalPosition;
		Done:
			Int32 FinalPosition = Source.Position;
			Source.Position = OriginalPosition;
			return new Result(Source.Read(FinalPosition - OriginalPosition), Result);
		}

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() {
			StringBuilder Result = new StringBuilder();
			for (Int32 i = 0; i < Count; i++) {
				Result.Append(Pattern);
			}
			return Result.ToString();
		}
	}
}
