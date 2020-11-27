using System;
using System.Text;

namespace Langly {
	/// <summary>
	/// Indicates the type is a text element.
	/// </summary>
	public interface ITextElement<out TSelf> :
		ICased<TSelf>,
		IComparable, IComparable<Char>, IComparable<Rune>, IComparable<Glyph>,
		IEquatable<Char>, IEquatable<Rune>, IEquatable<Glyph>
		where TSelf : ITextElement<TSelf>
		{ }
}
