namespace System.Text.Patterns {
	public abstract class Pattern : IEquatable<String> {

		public abstract Result Consume(String Candidate);

		public abstract override Boolean Equals(Object obj);

		public abstract Boolean Equals(String Other);

		public abstract override Int32 GetHashCode();

		public abstract override String ToString();
	}
}