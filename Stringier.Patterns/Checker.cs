namespace System.Text.Patterns {
	internal abstract class Checker : Pattern {
		internal protected readonly String Name;

		internal protected Checker(String Name) => this.Name = Name;
	}
}
