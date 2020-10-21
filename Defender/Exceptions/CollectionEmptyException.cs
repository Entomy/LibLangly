using System;
using System.Runtime.Serialization;

namespace Defender.Exceptions {
	/// <summary>
	/// Thrown when a collection is empty and an operation was attempted that requires contents.
	/// </summary>
	[Serializable]
	public class CollectionEmptyException : CollectionSizeException {
		/// <summary>
		/// Initializes a new <see cref="CollectionEmptyException"/>.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		protected CollectionEmptyException(String message) : base(message) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CollectionEmptyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
