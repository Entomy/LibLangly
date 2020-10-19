using System;
using System.Collections;
using System.Collections.Generic;
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
using System.Runtime.Serialization;
#endif

namespace Defender {
	/// <summary>
	/// Thrown when a collection is a particular size, but should not be.
	/// </summary>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public class ArgumentIsSizeException : ArgumentEqualException {
		/// <summary>
		/// Intialize a new <see cref="ArgumentIsSizeException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="excluded">The excluded value.</param>
		public ArgumentIsSizeException(Array value, String name, Object excluded) : base(value, name, $"Array must not be of size '{excluded}'.") { }

		/// <summary>
		/// Intialize a new <see cref="ArgumentIsSizeException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="excluded">The excluded value.</param>
		public ArgumentIsSizeException(ICollection value, String name, Object excluded) : base(value, name, $"Collection must not be of size '{excluded}'.") { }

		/// <inheritdoc/>
		protected ArgumentIsSizeException(Object value, String name, String message) : base(value, name, message) { }

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		protected ArgumentIsSizeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}

	/// <summary>
	/// Thrown when a collection is a particular size, but should not be.
	/// </summary>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public sealed class ArgumentIsSizeException<T> : ArgumentIsSizeException {
		/// <summary>
		/// Intialize a new <see cref="ArgumentIsSizeException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="excluded">The excluded value.</param>
		public ArgumentIsSizeException(ICollection<T> value, String name, Object excluded) : base(value, name, $"Collection must not be of size '{excluded}'.") { }

#if !NETSTANDARD1_0
		/// <summary>
		/// Intialize a new <see cref="ArgumentIsSizeException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="excluded">The excluded value.</param>
		public ArgumentIsSizeException(Span<T> value, String name, Object excluded) : base(value.ToArray(), name, message: $"Span must not be of size '{excluded}'.") { }

		/// <summary>
		/// Intialize a new <see cref="ArgumentIsSizeException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="excluded">The excluded value.</param>
		public ArgumentIsSizeException(ReadOnlySpan<T> value, String name, Object excluded) : base(value.ToArray(), name, message: $"Span must not be of size '{excluded}'.") { }

		/// <summary>
		/// Intialize a new <see cref="ArgumentIsSizeException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="excluded">The excluded value.</param>
		public ArgumentIsSizeException(Memory<T> value, String name, Object excluded) : base(value, name, $"Memory must not be of size '{excluded}'.") { }

		/// <summary>
		/// Intialize a new <see cref="ArgumentIsSizeException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="excluded">The excluded value.</param>
		public ArgumentIsSizeException(ReadOnlyMemory<T> value, String name, Object excluded) : base(value, name, $"Memory must not be of size '{excluded}'.") { }
#endif

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		private ArgumentIsSizeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}
}
