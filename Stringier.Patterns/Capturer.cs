using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Patterns {
	/// <summary>
	/// Represents a capturer pattern
	/// </summary>
	internal sealed class Capturer : Node, IModifier, IEquatable<Capturer> {
		private readonly INode Pattern;

		private readonly Capture Capture = new Capture();

		internal Capturer(INode Pattern, out Capture Capture) {
			this.Pattern = Pattern;
			Capture = this.Capture;
		}

		internal Capturer(Pattern Pattern, out Capture Capture) : this(Pattern.Head, out Capture) { }

		public override Result Consume(ref Source Source) {
			Result Result = Pattern.Consume(ref Source);
			Capture.Value = Result;
			return Result;
		}

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case Capturer other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public override Boolean Equals(String other) => Pattern.Equals(other);

		public Boolean Equals(Capturer other) => Pattern.Equals(other);

		public override Int32 GetHashCode() => Pattern.GetHashCode();

		public override Result Neglect(ref Source Source) {
			Result Result = Pattern.Neglect(ref Source);
			Capture.Value = Result;
			return Result;
		}

		public override String ToString() => Pattern.ToString();
	}
}
