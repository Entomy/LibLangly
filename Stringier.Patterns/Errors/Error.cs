using System.Runtime.InteropServices;

namespace System.Text.Patterns {
	[StructLayout(LayoutKind.Explicit)]
	internal ref struct Error {
		[FieldOffset(0)] internal ErrorType Type;
		[FieldOffset(1)] private ErrorData Data;
		[FieldOffset(0)] private Int32 Code;
		[FieldOffset(4)] private Char Char;
		[FieldOffset(8)] private Pattern Pattern;
		[FieldOffset(8)] private String String;

		internal void Clear() {
			this.Code = 0x0000;
		}

		internal void Set(ErrorType Type, Char Char) {
			this.Type = Type;
			this.Data = ErrorData.Char;
			this.Char = Char;
		}

		internal void Set(ErrorType Type, Pattern Pattern) {
			this.Type = Type;
			this.Data = ErrorData.Pattern;
			this.Pattern = Pattern;
		}

		internal void Set(ErrorType Type, String String) {
			this.Type = Type;
			this.Data = ErrorData.String;
			this.String = String;
		}

		public void Throw() {
			String String;
			switch (Data) {
			case ErrorData.None:
				return;
			case ErrorData.Char:
				String = Char.ToString();
				break;
			case ErrorData.Pattern:
				String = Pattern.ToString();
				break;
			case ErrorData.String:
				String = this.String;
				break;
			default:
				throw new NotImplementedException($"{Data} doesn't have a handler.");
			}
			switch (Type) {
			case ErrorType.None:
				return;
			case ErrorType.ConsumeFailed:
				throw new ConsumeFailedException($"Consume failed. Expected: {String}.");
			case ErrorType.EndOfSource:
				throw new EndOfSourceException($"End of source has been reached before able to parse. Expected: {String}");
			case ErrorType.NeglectFailed:
				throw new NeglectFailedException($"Neglect failed. Neglected: {String}.");
			default:
				throw new NotImplementedException($"{Type} doesn't have a conversion.");
			}
		}
	}
}
