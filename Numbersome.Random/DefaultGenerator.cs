using System;
using System.Diagnostics.CodeAnalysis;

namespace Numbersome {
	/// <summary>
	/// Provides the default <see cref="Random.Generator"/> for <see cref="Random"/>.
	/// </summary>
	internal sealed class DefaultGenerator : Random.Generator {
		/// <summary>
		/// The <see cref="System.Random"/> object preforming the generation.
		/// </summary>
		[DisallowNull, NotNull]
		private readonly System.Random Random;

		/// <summary>
		/// Initializes a new <see cref="DefaultGenerator"/>.
		/// </summary>
		public DefaultGenerator() => Random = new System.Random();

		/// <summary>
		/// Initializes a new <see cref="DefaultGenerator"/>.
		/// </summary>
		/// <param name="seed">The initial seed.</param>
		public DefaultGenerator(Int32 seed) => Random = new System.Random(seed);

		/// <inheritdoc/>
		public override unsafe void Read([MaybeNull] out Byte element) {
			Span<Byte> buffer = stackalloc Byte[1];
			Random.NextBytes(buffer);
			element = buffer[0];
		}
	}
}
