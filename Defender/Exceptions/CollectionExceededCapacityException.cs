using System;
using System.Runtime.Serialization;

namespace Langly {
	/// <summary>
	/// Thrown when a collection is at maximum capacity and an operation was attempted that would add more to the collection.
	/// </summary>
	[Serializable]
	public class CollectionExceededCapacityException : CollectionCapacityException {
		/// <summary>
		/// Initializes a new <see cref="CollectionExceededCapacityException"/>.
		/// </summary>
		/// <param name="capacity">The maximum capacity of the collection.</param>
		protected CollectionExceededCapacityException(Int64 capacity) : base(capacity, "The collection is at maximum capacity and an operation was attempted that would add more to the collection.") { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CollectionExceededCapacityException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Initializes a <see cref="CollectionExceededCapacityException"/> with the provided values.
		/// </summary>
		/// <param name="capacity">The maximum capacity of the collection.</param>
		/// <returns>A <see cref="CollectionExceededCapacityException"/> instance.</returns>
		public static CollectionExceededCapacityException With(Int64 capacity) => new CollectionExceededCapacityException(capacity);
	}
}
