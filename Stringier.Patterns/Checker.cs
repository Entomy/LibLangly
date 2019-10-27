namespace System.Text.Patterns {
	internal abstract class Checker : Node {
		internal protected readonly String Name;

		internal protected Checker(String Name) => this.Name = Name;
	}
}
