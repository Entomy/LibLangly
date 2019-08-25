using System.Globalization;

namespace System.Text.Patterns {
	/// <summary>
	/// Represents a textual range pattern
	/// </summary>
	public readonly struct RangePattern : IEquatable<RangePattern>, IEquatable<String> {
		/// <summary>
		/// The head node of the "From" pattern
		/// </summary>
		internal readonly INode From;

		/// <summary>
		/// The head node of the "To" pattern
		/// </summary>
		internal readonly INode To;

		/// <summary>
		/// The head node of the "Escape" pattern
		/// </summary>
		internal readonly INode? Escape;

		/// <summary>
		/// Construct a new <see cref="RangePattern"/> with the specified <paramref name="From"/> and <paramref name="To"/>
		/// </summary>
		/// <param name="From">The <see cref="INode"/> to set as the head of the "From" pattern</param>
		/// <param name="To">The <see cref="INode"/> to set as the head of the "To" pattern</param>
		internal RangePattern(INode From, INode To) {
			this.From = From;
			this.To = To;
			this.Escape = null;
		}

		/// <summary>
		/// Construct a new <see cref="RangePattern"/> with the specified <paramref name="From"/> and <paramref name="To"/>
		/// </summary>
		/// <param name="From">The <see cref="Pattern"/> to set as the head of the "From" pattern</param>
		/// <param name="To">The <see cref="Pattern"/> to set as the head of the "To" pattern</param>
		public RangePattern(Pattern From, Pattern To) : this(From.Head, To.Head) { }

		/// <summary>
		/// Construct a new <see cref="RangePattern"/> with the specified <paramref name="From"/> and <paramref name="To"/>, allowing <paramref name="Escape"/> without ending the capture
		/// </summary>
		/// <param name="From">The <see cref="INode"/> to set as the head of the "From" pattern</param>
		/// <param name="To">The <see cref="INode"/> to set as the head of the "To" pattern</param>
		/// <param name="Escape"The <see cref="INode"/> to set as the head of the "Escape" pattern
		internal RangePattern(INode From, INode To, INode Escape) {
			this.From = From;
			this.To = To;
			this.Escape = Escape;
		}

		/// <summary>
		/// Construct a new <see cref="RangePattern"/> with the specified <paramref name="From"/> and <paramref name="To"/>, allowing <paramref name="Escape"/> without ending the capture
		/// </summary>
		/// <param name="From">The <see cref="Pattern"/> to set as the head of the "From" pattern</param>
		/// <param name="To">The <see cref="Pattern"/> to set as the head of the "To" pattern</param>
		/// <param name="Escape"The <see cref="Pattern"/> to set as the head of the "Escape" pattern
		public RangePattern(Pattern From, Pattern To, Pattern Escape) : this(From.Head, To.Head, Escape.Head) { }

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Source">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured string</returns>
		public Result Consume(String Source) {
			Source source = new Source(Source);
			return Consume(ref source);
		}

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured string</returns>
		public Result Consume(ref Source Source) {
			Int32 OriginalPosition = Source.Position;
			Result Result = From.Consume(ref Source);
			if (!Result) { goto Cleanup; }
			Result = To.Consume(ref Source);
			while (!Result) {
				if (Source.EOF) { goto Cleanup; } //If we're already at the end, abort
				Source.Position++;
				if (!(Escape is null)) { Escape.Consume(ref Source); } //If an escape is defined, check for it now and advance if found, before checking the end of the range
				Result = To.Consume(ref Source);
			}
			goto Done;
		Cleanup:
			Source.Position = OriginalPosition;
		Done:
			Int32 FinalPosition = Source.Position;
			Source.Position = OriginalPosition;
			return new Result(Source.Read(FinalPosition - OriginalPosition), Result);
		}

		/// <summary>
		/// Determines whether two object instances are equal.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
		public override Boolean Equals(Object obj) {
			switch (obj) {
			case RangePattern other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public Boolean Equals(RangePattern other) => From.Equals(other.From) && To.Equals(other.To);

		public Boolean Equals(String other) => ToString().Equals(other);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => From.GetHashCode() ^ To.GetHashCode();

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() => $"from={From} to={To}";

	}
}
