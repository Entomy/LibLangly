using System;
using System.Collections;
using System.Collections.Generic;
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
using System.Runtime.Serialization;
#endif

namespace Defender {
	/// <summary>
	/// Thrown when a collection is not a particular size, but should be.
	/// </summary>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public class ArgumentIsNotSizeException : ArgumentNotEqualException {
		/// <summary>
		/// Intialize a new <see cref="ArgumentIsNotSizeException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="required">The required value.</param>
		public ArgumentIsNotSizeException(Array value, String name, Object required) : base(value, name, $"Array must be of size '{required}'.") { }

		/// <summary>
		/// Intialize a new <see cref="ArgumentIsNotSizeException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="required">The required value.</param>
		public ArgumentIsNotSizeException(ICollection value, String name, Object required) : base(value, name, $"Collection must be of size '{required}'.") { }

		/// <inheritdoc/>
		protected ArgumentIsNotSizeException(Object value, String name, String message) : base(value, name, message) { }

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		protected ArgumentIsNotSizeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}

	/// <summary>
	/// Thrown when a collection is not a particular size, but should be.
	/// </summary>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public sealed class ArgumentIsNotSizeException<T> : ArgumentIsNotSizeException {
		/// <summary>
		/// Intialize a new <see cref="ArgumentIsNotSizeException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="required">The required value.</param>
		public ArgumentIsNotSizeException(ICollection<T> value, String name, Object required) : base(value, name, $"Collection must be of size '{required}'.") { }

#if !NETSTANDARD1_0
		/// <summary>
		/// Intialize a new <see cref="ArgumentIsNotSizeException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="required">The required value.</param>
		public ArgumentIsNotSizeException(Span<T> value, String name, Object required) : base(value.ToArray(), name, message: $"Span must be of size '{required}'.") { }

		/// <summary>
		/// Intialize a new <see cref="ArgumentIsNotSizeException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="required">The required value.</param>
		public ArgumentIsNotSizeException(ReadOnlySpan<T> value, String name, Object required) : base(value.ToArray(), name, message: $"Span must be of size '{required}'.") { }

		/// <summary>
		/// Intialize a new <see cref="ArgumentIsNotSizeException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="required">The required value.</param>
		public ArgumentIsNotSizeException(Memory<T> value, String name, Object required) : base(value, name, $"Memory must be of size '{required}'.") { }

		/// <summary>
		/// Intialize a new <see cref="ArgumentIsNotSizeException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="required">The required value.</param>
		public ArgumentIsNotSizeException(ReadOnlyMemory<T> value, String name, Object required) : base(value, name, $"Memory must be of size '{required}'.") { }
#endif

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		private ArgumentIsNotSizeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}
}
