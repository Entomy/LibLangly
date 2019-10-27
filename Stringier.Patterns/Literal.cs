namespace System.Text.Patterns {
	internal abstract class Literal : Node {
		internal readonly Boolean IsCaseSensitive = false;

		protected Literal(Boolean IsCaseSensitive) => this.IsCaseSensitive = IsCaseSensitive;
	}
}
