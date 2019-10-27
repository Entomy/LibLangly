namespace System.Text.Patterns.Unsafe.InPlace {
	/// <summary>
	/// Performs in-place operations on <see cref="Pattern"/>.
	/// </summary>
	/// <remarks>
	/// This class is provided as an implementation of advanced, but unsafe, operations for constructing patterns. There's a lot of oddities occuring here, and this should not be used without great understanding. For instance, the normal pattern operators have their default associativity and precedence, and work like you would expect. These do not, despite similar naming.
	/// </remarks>
	public static class InPlaceExtensions {
		public static ref Pattern Alternate(this ref Pattern Left, in Pattern Right) {
			Left.Head = Left.Head.Alternate(Right.Head);
			return ref Left;
		}

		public static ref Pattern Alternate(this ref Pattern Left, Char Right) {
			Left.Head = Left.Head.Alternate(new CharLiteral(Right));
			return ref Left;
		}

		public static ref Pattern Alternate(this ref Pattern Left, String Right) {
			if (Right is null) {
				throw new ArgumentNullException(nameof(Right));
			}
			Left.Head = Left.Head.Alternate(new StringLiteral(Right));
			return ref Left;
		}

		public static ref Pattern Capture(this ref Pattern Pattern, out Capture Capture) {
			Pattern.Head = Pattern.Head.Capture(out Capture);
			return ref Pattern;
		}

		public static ref Pattern Concatenate(this ref Pattern Left, in Pattern Right) {
			Left.Head = Left.Head.Concatenate(Right.Head);
			return ref Left;
		}

		public static ref Pattern Concatenate(this ref Pattern Left, Char Right) {
			Left.Head = Left.Head.Concatenate(new CharLiteral(Right));
			return ref Left;
		}

		public static ref Pattern Concatenate(this ref Pattern Left, String Right) {
			if (Right is null) {
				throw new ArgumentNullException(nameof(Right));
			}
			Left.Head = Left.Head.Concatenate(new StringLiteral(Right));
			return ref Left;
		}

		public static ref Pattern Negate(this ref Pattern Pattern) {
			Pattern.Head = Pattern.Head.Negate();
			return ref Pattern;
		}

		public static ref Pattern Optional(this ref Pattern Pattern) {
			Pattern.Head = Pattern.Head.Optional();
			return ref Pattern;
		}

		public static ref Pattern Repeat(this ref Pattern Pattern, Int32 Count) {
			Pattern.Head = Pattern.Head.Repeat(Count);
			return ref Pattern;
		}

		public static ref Pattern Span(this ref Pattern Pattern) {
			Pattern.Head = Pattern.Head.Span();
			return ref Pattern;
		}
	}
}
