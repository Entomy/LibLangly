using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Patterns {
	internal sealed class PrimativeRepeater : PrimativePattern, IEquatable<PrimativeRepeater> {

		private readonly Int32 Count;

		private readonly PrimativePattern Pattern;

		internal PrimativeRepeater(PrimativePattern Pattern, Int32 Count) {
			this.Pattern = Pattern;
			if (Count < 1) { throw new ArgumentOutOfRangeException(nameof(Count), "Count must be positive"); }
			this.Count = Count;
		}

		protected internal override Int32 Length => Pattern.Length * Count;

		protected internal override Boolean CheckFirstChar(ref Source Source) => Pattern.CheckFirstChar(ref Source);

		public override Result Consume(ref Source Source) {
			if (this.Length > Source.Length) { return new Result(); }
			Int32 length = 0;
			Boolean Success = false;
			for (Int32 i = 0; i < Count; i++) {
				Success = Pattern.Equals(Source.Substring(Source.Position + length, Pattern.Length));
				if (!Success) { break; }
				length += Pattern.Length;
			}
			return new Result(Source.Read(length), Success);
		}

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case PrimativeRepeater other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public override Boolean Equals(ReadOnlySpan<Char> other) {
			if (other.Length != this.Length) { return false; }
			Source Source = new Source(other);
			Result Result = new Result();
			for (Int32 i = 0; i < Count; i++) {
				Result = Pattern.Consume(ref Source);
			}
			return Result;
		}

		public override Boolean Equals(String other) {
			if (other.Length != this.Length) { return false; }
			Source Source = new Source(other);
			Result Result = new Result();
			for (Int32 i = 0; i < Count; i++) {
				Result = Pattern.Consume(ref Source);
			}
			return Result;
		}

		public Boolean Equals(PrimativeRepeater other) => Pattern.Equals(other.Pattern) && Count.Equals(other.Count);

		public override Int32 GetHashCode() => Pattern.GetHashCode() ^ Count.GetHashCode();

		protected internal override Result Neglect(ref Source Source) {
			if (this.Length > Source.Length) { return new Result(); }
			Int32 length = 0;
			Boolean Success = false;
			for (Int32 i = 0; i < Count; i++) {
				Success = !Pattern.Equals(Source.Substring(Source.Position + length, Pattern.Length));
				if (!Success) { break; }
				length += Pattern.Length;
			}
			return new Result(Source.Read(length), Success);
		}

		public override String ToString() => $"{Pattern}×{Count}";
	}
}
