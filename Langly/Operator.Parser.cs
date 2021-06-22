namespace Langly {
	public abstract partial class Operator {
		/// <summary>
		/// Represents a parser object for a <see cref="Operator"/>.
		/// </summary>
		new protected abstract class Parser : Lexeme.Parser { }
	}
}
