using System;
using System.Runtime.InteropServices;

namespace Stringier.Patterns.Errors {
	/// <summary>
	/// Represents the parsing error state.
	/// </summary>
	/// <remarks>
	/// This is used rather than exceptions for a variety of reasons.
	/// * It is considerably faster to use this.
	///	  * Exceptions are not always thrown, and the entire exception trace stack is remarkably heavy.
	///	  * This still becomes an exception when needed.
	///	* Unlike exceptions, this can be reused in-place, which means only one <see cref="Error"/> is allocated for each parse, ever.
	///	  * Because this is a ref struct, it only ever exists on the stack, further reducing allocation burden, and cleanup burdern.
	/// </remarks>
	[StructLayout(LayoutKind.Explicit)]
	internal ref struct Error {
		[FieldOffset(0)] internal ErrorType Type;
		[FieldOffset(1)] private ErrorData Data;
		[FieldOffset(0)] private Int32 Code;
		[FieldOffset(4)] private Char Char;
		[FieldOffset(8)] private Node Node;
		[FieldOffset(8)] private Pattern Pattern;
		[FieldOffset(8)] private String String;

		/// <summary>
		/// Clears out the error struct, such that no error is represented.
		/// </summary>
		internal void Clear() {
			Code = 0x0000;
		}

		/// <summary>
		/// Sets the error to the <paramref name="type"/> with the <paramref name="char"/> data source.
		/// </summary>
		/// <param name="type">The <see cref="ErrorType"/> to set.</param>
		/// <param name="char">The <see cref="System.Char"/> data source.</param>
		internal void Set(ErrorType type, Char @char) {
			Type = type;
			Data = ErrorData.Char;
			Char = @char;
		}

		/// <summary>
		/// Sets the error to the <paramref name="type"/> with the <paramref name="node"/> data source.
		/// </summary>
		/// <param name="type">The <see cref="ErrorType"/> to set.</param>
		/// <param name="node">The <see cref="Patterns.Node"/> data source.</param>
		internal void Set(ErrorType type, Node node) {
			if (node is null) {
				throw new ArgumentNullException(nameof(node));
			}
			this.Type = type;
			this.Data = ErrorData.Node;
			this.Node = node;
		}

		/// <summary>
		/// Sets the error to the <paramref name="type"/> with the <paramref name="pattern"/> data source.
		/// </summary>
		/// <param name="type">The <see cref="ErrorType"/> to set.</param>
		/// <param name="pattern">The <see cref="Patterns.Pattern"/> data source.</param>
		internal void Set(ErrorType type, Pattern pattern) {
			this.Type = type;
			this.Data = ErrorData.Pattern;
			this.Pattern = pattern;
		}

		/// <summary>
		/// Sets the error to the <paramref name="type"/> with the <paramref name="string"/> data source.
		/// </summary>
		/// <param name="type">The <see cref="ErrorType"/> to set.</param>
		/// <param name="string">The <see cref="System.String"/> data source.</param>
		internal void Set(ErrorType type, String @string) {
			if (@string is null) {
				throw new ArgumentNullException(nameof(@string));
			}
			this.Type = type;
			this.Data = ErrorData.String;
			this.String = @string;
		}

		/// <summary>
		/// Throw the corresponding <see cref="Exception"/>, or do nothing if there is no error.
		/// </summary>
		public void Throw() {
			String @string;
			switch (Data) {
			case ErrorData.None:
				return;
			case ErrorData.Char:
				@string = Char.ToString();
				break;
			case ErrorData.Node:
				@string = Node.ToString();
				break;
			case ErrorData.Pattern:
				@string = Pattern.ToString();
				break;
			case ErrorData.String:
				@string = String;
				break;
			default:
				throw new NotImplementedException($"{Data} doesn't have a handler.");
			}
			switch (Type) {
			case ErrorType.None:
				return;
			case ErrorType.ConsumeFailed:
				throw new ConsumeFailedException($"Consume failed. Expected: {@string}.");
			case ErrorType.EndOfSource:
				throw new EndOfSourceException($"End of source has been reached before able to parse. Expected: {@string}");
			case ErrorType.NeglectFailed:
				throw new NeglectFailedException($"Neglect failed. Neglected: {@string}.");
			default:
				throw new NotImplementedException($"{Type} doesn't have a conversion.");
			}
		}
	}
}
