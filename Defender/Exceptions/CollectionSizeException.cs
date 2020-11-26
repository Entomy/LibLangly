using System;
using System.Runtime.Serialization;

namespace Langly {
	/// <summary>
	/// Thrown when a collections' size is not valid.
	/// </summary>
	[Serializable]
	public abstract class CollectionSizeException : CollectionException {
		/// <summary>
		/// Initialize a new <see cref="CollectionSizeException"/>.
		/// </summary>
		/// <param name="size">The size of the collection.</param>
		/// <param name="message">The message that describes the error.</param>
		protected CollectionSizeException(Int64 size, String message) : base($"{message}\nSize: {size}") { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CollectionSizeException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// The size of the collection.
		/// </summary>
		public Int64 Size { get; }
	}
}
