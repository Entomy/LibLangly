namespace System.Text.Patterns {
	internal sealed class Negator : Node, IEquatable<Negator> {
		private readonly Node Node;

		internal Negator(Node Node) => this.Node = Node;

		internal override Boolean CheckHeader(ref Source Source) => !Node.CheckHeader(ref Source);

		internal override void Consume(ref Source Source, ref Result Result) {
			Node.Neglect(ref Source, ref Result);
		}

		internal override void Neglect(ref Source Source, ref Result Result) {
			Node.Consume(ref Source, ref Result);
		}

		public override Boolean Equals(Node node) {
			switch (node) {
			case Negator other:
				return Equals(other);
			default:
				return false;
			}
		}

		public Boolean Equals(Negator other) => Node.Equals(other.Node);

		public override Boolean Equals(ReadOnlySpan<Char> other) {
			Source Source = new Source(other);
			Result Result = new Result(ref Source);
			Consume(ref Source, ref Result);
			if (Result) {
				return true;
			} else {
				//We have to do some manual work here
				//Normally we would store the source position, but since we create the source in this method, the original position is always 0
				//Call the underlying neglect
				Node.Consume(ref Source, ref Result);
				if (Result) {
					//If this was successful, check if it consumed the entire source
					return Source.Length != 0;
				} else {
					//Otherwise it's definately not a match
					return false;
				}
			}
		}

		public override Boolean Equals(String other) {
			Source Source = new Source(other);
			Result Result = new Result(ref Source);
			Consume(ref Source, ref Result);
			if (Result) {
				return true;
			} else {
				//We have to do some manual work here
				//Normally we would store the source position, but since we create the source in this method, the original position is always 0
				//Call the underlying neglect
				Node.Consume(ref Source, ref Result);
				if (Result) {
					//If this was successful, check if it consumed the entire source
					return Source.Length != 0;
				} else {
					//Otherwise it's definately not a match
					return false;
				}
			}
		}

		public override Int32 GetHashCode() => -Node.GetHashCode();

		public override String ToString() => $"!╣{Node}║";
	}
}
