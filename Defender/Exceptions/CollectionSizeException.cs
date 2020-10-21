using System;
using System.Runtime.Serialization;

namespace Defender.Exceptions {
	/// <summary>
	/// Thrown when a collections' size is not valid.
	/// </summary>
	[Serializable]
	public abstract class CollectionSizeException : CollectionException {
		/// <summary>
		/// Initialize a new <see cref="CollectionSizeException"/>.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		protected CollectionSizeException(String message) : base(message) { }

		/// <summary>
		/// Initialize a new <see cref="CollectionSizeException"/>.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		/// <param name="inner">The inner exception.</param>
		protected CollectionSizeException(String message, Exception inner) : base(message, inner) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CollectionSizeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
