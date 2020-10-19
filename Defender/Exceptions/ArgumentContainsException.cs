using System;
using System.Collections;
using System.Collections.Generic;
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
using System.Runtime.Serialization;
#endif

namespace Defender {
	/// <summary>
	/// Thrown when a collection contains an item, but shouldn't.
	/// </summary>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public class ArgumentContainsException : ArgumentException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentContainsException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="excluded">The excluded member of the collection.</param>
		public ArgumentContainsException(String value, String name, Object excluded) : base(value, name, $"String must not contain '{excluded}'.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentContainsException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="excluded">The excluded member of the collection.</param>
		public ArgumentContainsException(Array value, String name, Object excluded) : base(value, name, $"Array must not contain '{excluded}'.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentContainsException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="excluded">The excluded member of the collection.</param>
		public ArgumentContainsException(IEnumerable value, String name, Object excluded) : base(value, name, $"Enumerable must not contain '{excluded}'.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentContainsException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="excluded">The excluded member of the collection.</param>
		public ArgumentContainsException(IEnumerable<Object> value, String name, Object excluded) : base(value, name, $"Enumerable must not contain '{excluded}'.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentContainsException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="excluded">The excluded member of the collection.</param>
		public ArgumentContainsException(ICollection value, String name, Object excluded) : base(value, name, $"Collection must not contain '{excluded}'.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentContainsException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="excluded">The excluded member of the collection.</param>
		public ArgumentContainsException(ICollection<Object> value, String name, Object excluded) : base(value, name, $"Collection must not contain '{excluded}'.") { }

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		protected ArgumentContainsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}
}
