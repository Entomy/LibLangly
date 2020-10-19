using System;
using System.Collections;
using System.Collections.Generic;
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
using System.Runtime.Serialization;
#endif

namespace Defender {
	/// <summary>
	/// Thrown when a collection doesn't contain an item, but should.
	/// </summary>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public class ArgumentNotContainsException : ArgumentException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentNotContainsException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="required">The required member of the collection.</param>
		public ArgumentNotContainsException(Array value, String name, Object required) : base(value, name, $"Array must contain '{required}'.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentNotContainsException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="required">The required member of the collection.</param>
		public ArgumentNotContainsException(IEnumerable value, String name, Object required) : base(value, name, $"Enumerable must contain '{required}'.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentNotContainsException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="required">The required member of the collection.</param>
		public ArgumentNotContainsException(IEnumerable<Object> value, String name, Object required) : base(value, name, $"Enumerable must contain '{required}'.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentNotContainsException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="required">The required member of the collection.</param>
		public ArgumentNotContainsException(ICollection value, String name, Object required) : base(value, name, $"Collection must contain '{required}'.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentNotContainsException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="required">The required member of the collection.</param>
		public ArgumentNotContainsException(ICollection<Object> value, String name, Object required) : base(value, name, $"Collection must contain '{required}'.") { }

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		private ArgumentNotContainsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}
}
