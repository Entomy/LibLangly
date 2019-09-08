using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Patterns {
	internal sealed class Repeater : Pattern, IEquatable<Repeater> {
		private readonly Int32 Count;

		private readonly Pattern Pattern;

		/// <summary>
		/// Construct a new <see cref="Repeater"/>.
		/// </summary>
		/// <param name="Pattern"></param>
		/// <param name="Count"></param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="Count"/> must be a positive integer.</exception>
		internal Repeater(Pattern Pattern, Int32 Count) {
			this.Pattern = Pattern;
			if (Count < 1) { throw new ArgumentOutOfRangeException(nameof(Count), "Count must be positive"); }
			this.Count = Count;
		}

		internal override void Consume(ref Source Source, ref Result Result) {
			for (Int32 i = 0; i < Count; i++) {
				Pattern.Consume(ref Source, ref Result);
				if (!Result) { return; }
			}
		}

		internal override void Neglect(ref Source Source, ref Result Result) {
			for (Int32 i = 0; i < Count; i++) {
				Pattern.Neglect(ref Source, ref Result);
				if (!Result) { return; }
			}
		}


		public override Boolean Equals(Object obj) {
			switch (obj) {
			case Repeater other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public Boolean Equals(Repeater other) => Pattern.Equals(other.Pattern) && Count.Equals(other.Count);

		public override Int32 GetHashCode() => Pattern.GetHashCode() ^ Count.GetHashCode();

		public override String ToString() => $"{Count}╣{Pattern}║";
	}
}
