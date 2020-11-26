using System;
using System.Runtime.Serialization;

namespace Langly {
	/// <summary>
	/// Thrown when a collection or an operation on a collection is not valid.
	/// </summary>
	[Serializable]
	public abstract class CollectionException : LanglyException {
		/// <summary>
		/// Initialize a new <see cref="CollectionException"/>.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		protected CollectionException(String message) : base(message) { }

		/// <summary>
		/// Initialize a new <see cref="CollectionException"/>.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		/// <param name="inner">The inner exception.</param>
		protected CollectionException(String message, Exception inner) : base(message, inner) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CollectionException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
