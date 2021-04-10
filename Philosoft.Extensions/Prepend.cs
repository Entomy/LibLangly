using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class PhilosoftExtensions {
		#region Prepend(Collection, TElement)
		/// <summary>
		/// Prepends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to prepend.</param>
		/// <returns>If the prepend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and prepended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Prepend<TElement, TResult>([AllowNull] this IPrepend<TElement, TResult> collection, [AllowNull] TElement element) where TResult : IPrepend<TElement, TResult> => collection is not null ? collection.Prepend(element) : (TResult)collection;

		/// <summary>
		/// Prepends the element onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to prepend.</param>
		/// <returns>Returns an <see cref="String"/> containing the original and prepended elements.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection"), NotNullIfNotNull("element")]
		public static String Prepend(this String collection, Char element) {
			if (collection is null || collection.Length == 0) {
				return new String(element, 1);
			}
			Char[] Array = new Char[collection.Length + 1];
			collection.AsMemory().CopyTo(Array.Slice(1));
			Array[0] = element;
			return new(Array);
		}

		/// <summary>
		/// Prepends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to prepend.</param>
		/// <returns>Returns an <see cref="Array"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection"), NotNullIfNotNull("element")]
		public static TElement[] Prepend<TElement>([AllowNull] this TElement[] collection, [AllowNull] TElement element) {
			if (element is null) {
				return collection;
			} else if (collection is null || collection.Length == 0) {
				return new[] { element };
			}
			TElement[] Array = new TElement[collection.Length + 1];
			collection.CopyTo(Array.Slice(1));
			Array[0] = element;
			return Array;
		}

		/// <summary>
		/// Prepends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to prepend.</param>
		/// <returns>Returns a <see cref="Memory{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		public static Memory<TElement> Prepend<TElement>(this Memory<TElement> collection, [AllowNull] TElement element) {
			if (element is null) {
				return collection;
			} else if (collection.Length == 0) {
				return new[] { element };
			}
			TElement[] Array = new TElement[collection.Length + 1];
			collection.CopyTo(Array.Slice(1));
			Array[0] = element;
			return Array;
		}

		/// <summary>
		/// Prepends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to prepend.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		public static ReadOnlyMemory<TElement> Prepend<TElement>(this ReadOnlyMemory<TElement> collection, [AllowNull] TElement element) {
			if (element is null) {
				return collection;
			} else if (collection.Length == 0) {
				return new[] { element };
			}
			TElement[] Array = new TElement[collection.Length + 1];
			collection.CopyTo(Array.Slice(1));
			Array[0] = element;
			return Array;
		}
		#endregion

		#region Prepend(Collection, TElement[])
		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>If the prepend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and prepended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Prepend<TElement, TResult>([AllowNull] this IPrepend<TElement, TResult> collection, [AllowNull] params TElement[] elements) where TResult : IPrepend<TElement, TResult> => collection is not null ? collection.Prepend(elements) : (TResult)collection;

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="String"/> containing the original and prepended elements.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection"), NotNullIfNotNull("element")]
		public static String Prepend([AllowNull] this String collection, [AllowNull] params Char[] elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection is null || collection.Length == 0) {
				return new(elements);
			}
			Char[] Array = new Char[collection.Length + elements.Length];
			collection.AsMemory().CopyTo(Array.Slice(elements.Length));
			System.Array.Copy(elements, Array, elements.Length);
			return new(Array);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="Array"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection"), NotNullIfNotNull("element")]
		public static TElement[] Prepend<TElement>([AllowNull] this TElement[] collection, [AllowNull] params TElement[] elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			TElement[] Array = new TElement[collection.Length + elements.Length];
			collection.CopyTo(Array.Slice(elements.Length));
			System.Array.Copy(elements, Array, elements.Length);
			return Array;
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="Memory{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		public static Memory<TElement> Prepend<TElement>(this Memory<TElement> collection, [AllowNull] params TElement[] elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			TElement[] Array = new TElement[collection.Length + elements.Length];
			collection.CopyTo(Array.Slice(elements.Length));
			System.Array.Copy(elements, Array, elements.Length);
			return Array;
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		public static ReadOnlyMemory<TElement> Prepend<TElement>(this ReadOnlyMemory<TElement> collection, [AllowNull] params TElement[] elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			TElement[] Array = new TElement[collection.Length + elements.Length];
			collection.CopyTo(Array.Slice(elements.Length));
			System.Array.Copy(elements, Array, elements.Length);
			return Array;
		}
		#endregion

		#region Prepend(Collection, Memory<TElement>)
		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>If the prepend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and prepended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Prepend<TElement, TResult>([AllowNull] this IPrepend<TElement, TResult> collection, Memory<TElement> elements) where TResult : IPrepend<TElement, TResult> => collection is not null ? collection.Prepend(elements) : (TResult)collection;

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="String"/> containing the original and prepended elements.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static String Prepend([AllowNull] this String collection, Memory<Char> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection is null || collection.Length == 0) {
				return new(elements.Span);
			}
			Char[] Array = new Char[collection.Length + elements.Length];
			collection.AsMemory().CopyTo(Array.Slice(elements.Length));
			elements.CopyTo(Array);
			return new(Array);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="Memory{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		public static Memory<TElement> Prepend<TElement>([AllowNull] this TElement[] collection, Memory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			TElement[] Array = new TElement[collection.Length + elements.Length];
			collection.CopyTo(Array.Slice(elements.Length));
			elements.CopyTo(Array);
			return Array;
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="Memory{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		public static Memory<TElement> Prepend<TElement>(this Memory<TElement> collection, Memory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			TElement[] Array = new TElement[collection.Length + elements.Length];
			collection.CopyTo(Array.Slice(elements.Length));
			elements.CopyTo(Array);
			return Array;
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		public static ReadOnlyMemory<TElement> Prepend<TElement>(this ReadOnlyMemory<TElement> collection, Memory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			TElement[] Array = new TElement[collection.Length + elements.Length];
			collection.CopyTo(Array.Slice(elements.Length));
			elements.CopyTo(Array);
			return Array;
		}
		#endregion

		#region Prepend(Collection, ReadOnlyMemory<TElement>)
		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>If the prepend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and prepended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Prepend<TElement, TResult>([AllowNull] this IPrepend<TElement, TResult> collection, ReadOnlyMemory<TElement> elements) where TResult : IPrepend<TElement, TResult> => collection is not null ? collection.Prepend(elements) : (TResult)collection;

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="String"/> containing the original and prepended elements.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static String Prepend([AllowNull] this String collection, ReadOnlyMemory<Char> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection is null || collection.Length == 0) {
				return new(elements.Span);
			}
			Char[] Array = new Char[collection.Length + elements.Length];
			collection.AsMemory().CopyTo(Array.Slice(elements.Length));
			elements.CopyTo(Array);
			return new(Array);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		public static ReadOnlyMemory<TElement> Prepend<TElement>([AllowNull] this TElement[] collection, ReadOnlyMemory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			TElement[] Array = new TElement[collection.Length + elements.Length];
			collection.CopyTo(Array.Slice(elements.Length));
			elements.CopyTo(Array);
			return Array;
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		public static ReadOnlyMemory<TElement> Prepend<TElement>(this Memory<TElement> collection, ReadOnlyMemory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			TElement[] Array = new TElement[collection.Length + elements.Length];
			collection.CopyTo(Array.Slice(elements.Length));
			elements.CopyTo(Array);
			return Array;
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		public static ReadOnlyMemory<TElement> Prepend<TElement>(this ReadOnlyMemory<TElement> collection, ReadOnlyMemory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			TElement[] Array = new TElement[collection.Length + elements.Length];
			collection.CopyTo(Array.Slice(elements.Length));
			elements.CopyTo(Array);
			return Array;
		}
		#endregion

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>If the prepend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and prepended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Prepend<TElement, TResult>([AllowNull] this IPrependSpan<TElement, TResult> collection, Span<TElement> elements) where TResult : IPrependSpan<TElement, TResult> => collection is not null ? collection.Prepend(elements) : (TResult)collection;

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>If the prepend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and prepended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Prepend<TElement, TResult>([AllowNull] this IPrependSpan<TElement, TResult> collection, ReadOnlySpan<TElement> elements) where TResult : IPrependSpan<TElement, TResult> => collection is not null ? collection.Prepend(elements) : (TResult)collection;

		#region Prepend(Collection, Sequence)
		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>If the prepend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and prepended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Prepend<TElement, TResult, TEnumerator>([AllowNull] this IPrepend<TElement, TResult> collection, [AllowNull] ISequence<TElement, TEnumerator> elements) where TResult : IPrepend<TElement, TResult> where TEnumerator : IEnumerator<TElement> => collection is not null ? collection.Prepend(elements) : (TResult)collection;
		#endregion

		#region Prepend(Collection, String)
		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>If the prepend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and prepended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Prepend<TResult>([AllowNull] this IPrepend<Char, TResult> collection, [AllowNull] String elements) where TResult : IPrepend<Char, TResult> => collection is not null ? collection.Prepend(elements.AsMemory()) : (TResult)collection;

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="String"/> containing the original and prepended elements.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection"), NotNullIfNotNull("element")]
		public static String Prepend([AllowNull] this String collection, [AllowNull] String elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection is null || collection.Length == 0) {
				return new(elements);
			}
			Char[] Array = new Char[collection.Length + elements.Length];
			collection.AsMemory().CopyTo(Array.Slice(elements.Length));
			elements.AsMemory().CopyTo(Array.Slice(0, elements.Length));
			return new(Array);
		}
		#endregion
	}
}
