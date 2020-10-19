namespace Defender.Serialization {
	/// <summary>
	/// Indicates the type is serializable.
	/// </summary>
	public interface ISerializable {
		/// <summary>
		/// Serializes this object.
		/// </summary>
		/// <returns>A <see cref="Payload"/> representing this object.</returns>
		Payload Serialize();
	}
}
