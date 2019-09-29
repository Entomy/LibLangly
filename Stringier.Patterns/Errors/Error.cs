namespace System.Text.Patterns {
	internal abstract class Error {
		protected readonly String @string;

		protected internal Error(String @string) {
			this.@string = @string;
		}

		internal abstract void Throw();
	}
}
