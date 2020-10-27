using System;
using System.Runtime.Serialization;

namespace Defender.Exceptions {
	/// <summary>
	/// Thrown when a collections' capacity is not valid.
	/// </summary>
	[Serializable]
	public abstract class CollectionCapacityException : CollectionException {
		/// <summary>
		/// Initialize a new <see cref="CollectionCapacityException"/>.
		/// </summary>
		/// <param name="capacity">The maximum capacity of the collection.</param>
		/// <param name="message">The message that describes the error.</param>
		protected CollectionCapacityException(Int64 capacity, String message) : base($"{message}\nCapacity: {capacity}") { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CollectionCapacityException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// The maximum capacity of the collection.
		/// </summary>
		public Int64 Capacity { get; }
	}
}
