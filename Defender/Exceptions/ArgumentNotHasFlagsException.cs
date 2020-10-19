using System;
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
using System.Runtime.Serialization;
#endif

namespace Defender {
	/// <summary>
	/// Thrown when a flags enum is required to have certain flags set, but doesn't.
	/// </summary>
	/// <typeparam name="E">An <see cref="Enum"/> type.</typeparam>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public class ArgumentNotHasFlagsException<E> : ArgumentNotValidException where E : struct, Enum {
		/// <summary>
		/// Initialize a new <see cref="ArgumentNotHasFlagsException{E}"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="flags">The required flags.</param>
		public ArgumentNotHasFlagsException(E value, String name, E flags) : base(value, name, $"Enum must contain the flags '{flags}'.") { }

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		protected ArgumentNotHasFlagsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}
}
