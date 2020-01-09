using System;
using System.IO;
using System.Text;

namespace Stringier.Streams {
	/// <summary>
	/// Creates a stream whos backing store is memory and represents a <see cref="String"/>.
	/// </summary>
	public sealed class StringStream : MemoryStream {
		/// <summary>
		/// Initializes a new non-resizable instance of the <see cref="StringStream"/> class based on the specified <paramref name="string"/>.
		/// </summary>
		/// <param name="string">The <see cref="String"/> to stream.</param>
		public StringStream(String @string) : base(Encoding.UTF8.GetBytes(@string)) { }
	}
}
