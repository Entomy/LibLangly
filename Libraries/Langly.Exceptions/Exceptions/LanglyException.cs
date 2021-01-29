using System;
using System.Runtime.Serialization;

namespace Langly.Exceptions {
	/// <summary>
	/// Thrown when there is an issue within LibLangly.Exceptions.
	/// </summary>
	[Serializable]
	public abstract class LanglyException : Exception {
		/// <summary>
		/// Initialize a new <see cref="LanglyException"/>.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		protected LanglyException(String message) : base(message) { }

		/// <summary>
		/// Initialize a new <see cref="LanglyException"/>.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		/// <param name="inner">The inner exception.</param>
		protected LanglyException(String message, Exception inner) : base(message, inner) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected LanglyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
