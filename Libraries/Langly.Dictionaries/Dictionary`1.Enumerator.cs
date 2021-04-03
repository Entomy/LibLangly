using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Langly.Traits;

namespace Langly {
	public sealed partial class Dictionary<TElement> : ISequence<TElement, Dictionary<TElement>.Enumerator> {
		/// <inheritdoc/>
		public Enumerator GetEnumerator() => new Enumerator(this);

		/// <summary>
		/// Provides enumeration over <see cref="Dictionary{TElement}"/>.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[StructLayout(LayoutKind.Auto)]
		public struct Enumerator : IEnumerator<TElement> {
			[NotNull]
			private readonly Dictionary<TElement> Dictionary;

			[AllowNull, MaybeNull]
			private Node N;

			/// <summary>
			/// Initializes a new <see cref="Enumerator"/>.
			/// </summary>
			/// <param name="dictionary">The <see cref="Dictionary{TElement}"/> to enumerate.</param>
			public Enumerator([DisallowNull] Dictionary<TElement> dictionary) {
				Dictionary = dictionary;
				N = Dictionary.Head;
			}

			/// <inheritdoc/>
			[AllowNull, MaybeNull]
			public TElement Current => N.Element;

			/// <inheritdoc/>
			public nint Count => Dictionary.Count;

			/// <inheritdoc/>
			public Boolean MoveNext() => throw new NotImplementedException();

			/// <inheritdoc/>
			public void Reset() => N = Dictionary.Head;
		}
	}
}
