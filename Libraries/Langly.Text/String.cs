using System;
using System.Diagnostics.CodeAnalysis;
using Langly.DataStructures;

namespace Langly {
	/// <summary>
	/// Represents a fixed piece of text.
	/// </summary>
	public readonly struct String : ICapacity, ICount {
		/// <summary>
		/// The backing memory of the <see cref="String"/>.
		/// </summary>
		private readonly ReadOnlyMemory<Char> Memory;

		/// <summary>
		/// Initializes a new <see cref="String"/>.
		/// </summary>
		/// <param name="text">The <see cref="System.String"/> to reuse.</param>
		public String([AllowNull] System.String text) => Memory = text is not null ? text.AsMemory() : ReadOnlyMemory<Char>.Empty;

		/// <summary>
		/// Initializes a new <see cref="String"/>.
		/// </summary>
		/// <param name="text">The <see cref="Memory{T}"/> of <see cref="Char"/> to reuse.</param>
		public String(Memory<Char> text) => Memory = text;

		/// <summary>
		/// Initializes a new <see cref="String"/>.
		/// </summary>
		/// <param name="text">The <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> to reuse.</param>
		public String(ReadOnlyMemory<Char> text) => Memory = text;

		/// <inheritdoc/>
		nint ICapacity.Capacity => Count;

		/// <inheritdoc/>
		public nint Count => Memory.Length;

		/// <summary>
		/// Reuses the <paramref name="text"/> as a <see cref="String"/>.
		/// </summary>
		/// <param name="text">The <see cref="System.String"/> to reuse.</param>
		public static implicit operator String([AllowNull] System.String text) => new String(text);

		/// <summary>
		/// Reuses the <paramref name="text"/> as a <see cref="String"/>.
		/// </summary>
		/// <param name="text">The <see cref="Memory{T}"/> of <see cref="Char"/> to reuse.</param>
		public static implicit operator String(Memory<Char> text) => new String(text);

		/// <summary>
		/// Reuses the <paramref name="text"/> as a <see cref="String"/>.
		/// </summary>
		/// <param name="text">The <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> to reuse.</param>
		public static implicit operator String(ReadOnlyMemory<Char> text) => new String(text);

		/// <inheritdoc/>
		public override Boolean Equals([AllowNull] System.Object obj) => base.Equals(obj);

		/// <inheritdoc/>
		public override Int32 GetHashCode() => base.GetHashCode();

		/// <inheritdoc/>
		public override System.String ToString() => new System.String(Memory.Span);
	}
}
