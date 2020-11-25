using System;
using System.Runtime.Serialization;

namespace Defender.Exceptions {
	/// <summary>
	/// Thrown when a pattern or an operation on a pattern is not valid.
	/// </summary>
	[Serializable]
	public abstract class PatternException : LanglyException {
		/// <summary>
		/// Initializes a new <see cref="PatternException"/>.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		protected PatternException(String message) : base(message) { }

		/// <summary>
		/// Initialize a new <see cref="PatternException"/>.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		/// <param name="inner">The inner exception.</param>
		protected PatternException(String message, Exception inner) : base(message, inner) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected PatternException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
