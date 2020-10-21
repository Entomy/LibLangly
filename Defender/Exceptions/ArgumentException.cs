using System;
using System.Runtime.Serialization;

namespace Defender.Exceptions {
	/// <summary>
	/// Thrown when one of the arguments provided to a method is not valid.
	/// </summary>
	[Serializable]
	public abstract class ArgumentException : Exception {
		/// <summary>
		/// Initialize a new <see cref="ArgumentException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="message">The message that describes the error.</param>
		protected ArgumentException(Object value, String name, String message) : base($"{message}\nArgument: {name} = {value ?? "null"}") {
			Value = value;
			Name = name;
		}

		/// <summary>
		/// Deserialize a <see cref="ArgumentException"/>.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ArgumentException(SerializationInfo info, StreamingContext context) : base(info, context) {
			Name = info.GetString(nameof(Name));
			Value = info.GetValue(nameof(Value), typeof(Object));
		}

		/// <summary>
		/// The name of the argument responsible.
		/// </summary>
		public String Name { get; }

		/// <summary>
		/// The value of the argument responsible.
		/// </summary>
		public Object Value { get; }
	}
}
