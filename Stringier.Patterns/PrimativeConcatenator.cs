using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Patterns {
	internal sealed class PrimativeConcatenator : IPrimativeNode, IEquatable<PrimativeConcatenator> {
		private readonly IPrimativeNode Left;

		private readonly IPrimativeNode Right;

		internal PrimativeConcatenator(IPrimativeNode Left, IPrimativeNode Right) {
			this.Left = Left;
			this.Right = Right;
		}

		public Int32 Length => Left.Length + Right.Length;

		public Result Consume(String Source) {
			Source source = new Source(Source);
			return Consume(ref source);
		}

		public Result Consume(ref Source Source) {
			Int32 OriginalPosition = Source.Position;
			Result Result;
			// Try consuming the left side
			Result = Left.Consume(ref Source);
			if (!Result) { goto Cleanup; }
			// Try consuming the right side
			Result = Right.Consume(ref Source);
			if (!Result) { goto Cleanup; }
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
			case PrimativeConcatenator other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public Boolean Equals(String other) => throw new NotImplementedException();

		public Boolean Equals(PrimativeConcatenator other) => Left.Equals(other.Left) && Right.Equals(other.Right);

		public override Int32 GetHashCode() => Left.GetHashCode() & Right.GetHashCode();

		public Result Neglect(String Source) => throw new NotImplementedException();

		public Result Neglect(ref Source Source) => throw new NotImplementedException();

		public override String ToString() => $"{Left}{Right}";

	}
}
