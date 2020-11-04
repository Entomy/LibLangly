using System;
using System.Runtime.Serialization;

namespace Defender.Exceptions {
	/// <summary>
	/// Thrown when a glyph or an operation on a glyph is not valid.
	/// </summary>
	[Serializable]
	public abstract class GlyphException : LanglyException {
		/// <summary>
		/// Initialize a new <see cref="GlyphException"/>.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		protected GlyphException(String message) : base(message) { }

		/// <summary>
		/// Initialize a new <see cref="GlyphException"/>.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		/// <param name="inner">The inner exception</param>
		protected GlyphException(String message, Exception inner) : base(message, inner) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected GlyphException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
