using System;

namespace Philosoft {
	/// <summary>
	/// Indicates the type is text.
	/// </summary>
	public interface IText<out TSelf, TEnumerator> :
		ICased<TSelf>,
		IComparable, IComparable<String>, IComparable<Char[]>, IComparable<ReadOnlyMemory<Char>>,
		IEnumerable<Char, TEnumerator>,
		IEquatable<String>, IEquatable<Char[]>, IEquatable<ReadOnlyMemory<Char>>
		where TSelf : IText<TSelf, TEnumerator>
		where TEnumerator : IEnumerator<Char>
		{ }
}
