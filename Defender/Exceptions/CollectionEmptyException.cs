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
		protected CollectionEmptyException() : base(0, "The collection was empty an an operation was attempted that required contents.") { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CollectionEmptyException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Initializes a new <see cref="CollectionEmptyException"/> with the provided values.
		/// </summary>
		/// <returns>A <see cref="CollectionEmptyException"/> instance.</returns>
		public static CollectionEmptyException With() => new CollectionEmptyException();
	}
}
