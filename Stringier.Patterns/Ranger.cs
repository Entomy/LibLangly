using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Patterns {
	/// <summary>
	/// Represents the ranger pattern
	/// </summary>
	internal sealed class Ranger : Node, IEquatable<Ranger> {
		private readonly Node From;

		private readonly Node To;

		private readonly Node? Escape;

		internal Ranger(Node From, Node To) {
			this.From = From;
			this.To = To;
		}

		internal Ranger(Pattern From, Pattern To) : this(From.Head, To.Head) { }

		internal Ranger(Node From, Node To, Node Escape) {
			this.From = From;
			this.To = To;
			this.Escape = Escape;
		}

		internal Ranger(Pattern From, Pattern To, Pattern Escape) : this(From.Head, To.Head, Escape.Head) { }

		public static implicit operator Ranger((String From, String To) Range) => new Ranger(Range.From, Range.To);

		public static implicit operator Ranger((String From, String To, String Escape) Range) => new Ranger(Range.From, Range.To, Range.Escape);

		public static implicit operator Ranger((Node From, Node To) Range) => new Ranger(Range.From, Range.To);

		public static implicit operator Ranger((Node From, Node To, Node Escape) Range) => new Ranger(Range.From, Range.To, Range.Escape);

		public static implicit operator Ranger((Pattern From, Pattern To) Range) => new Ranger(Range.From, Range.To);

		public static implicit operator Ranger((Pattern From, Pattern To, Pattern Escape) Range) => new Ranger(Range.From, Range.To, Range.Escape);

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured string</returns>
		public override Result Consume(ref Source Source) {
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

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case Ranger Other:
				return Equals(Other);
			case String Other:
				return Equals(Other);
			default:
				return false;
			}
		}

		public override Boolean Equals(String other) => ToString().Equals(other);

		public Boolean Equals(Ranger other) => From.Equals(other.From) && To.Equals(other.To);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => From.GetHashCode() ^ To.GetHashCode();

		/// <summary>
		/// Attempt to consume from the <paramref name="Source"/> while neglecting the <see cref="Pattern"/>
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured string</returns>
		public override Result Neglect(ref Source Source) => throw new NotImplementedException();

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() => $"from={From} to={To}";
	}
}
