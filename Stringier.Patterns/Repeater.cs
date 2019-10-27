using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Patterns {
	internal sealed class Repeater : Node, IEquatable<Repeater> {
		private readonly Int32 Count;

		private readonly Node Node;

		/// <summary>
		/// Construct a new <see cref="Repeater"/>.
		/// </summary>
		/// <param name="Pattern"></param>
		/// <param name="Count"></param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="Count"/> must be a positive integer.</exception>
		internal Repeater(Node Node, Int32 Count) {
			this.Node = Node;
			if (Count < 1) { throw new ArgumentOutOfRangeException(nameof(Count), "Count must be positive"); }
			this.Count = Count;
		}

		internal override Boolean CheckHeader(ref Source Source) => Node.CheckHeader(ref Source);

		internal override void Consume(ref Source Source, ref Result Result) {
			for (Int32 i = 0; i < Count; i++) {
				Node.Consume(ref Source, ref Result);
				if (!Result) { return; }
			}
		}

		internal override void Neglect(ref Source Source, ref Result Result) {
			for (Int32 i = 0; i < Count; i++) {
				Node.Neglect(ref Source, ref Result);
				if (!Result) { return; }
			}
		}


		public override Boolean Equals(Node node) {
			switch (node) {
			case Repeater other:
				return Equals(other);
			default:
				return false;
			}
		}

		public Boolean Equals(Repeater other) => Node.Equals(other.Node) && Count.Equals(other.Count);

		public override Int32 GetHashCode() => Node.GetHashCode() ^ Count.GetHashCode();

		public override String ToString() => $"{Count}╣{Node}║";
	}
}
