using System;
using System.Diagnostics.CodeAnalysis;
using Langly.Traits;

namespace Langly.Traits {
	/// <summary>
	/// Indicates the type can have other elements postpended onto it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IPostpend<TElement, out TResult> where TResult : IPostpend<TElement, TResult> {
		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <param name="element">The element to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Postpend([AllowNull] TElement element);

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Postpend([AllowNull] params TElement[] elements) {
			if (elements is null) {
				return (TResult)this;
			}
			return Postpend(elements.AsMemory());
		}

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Postpend(Memory<TElement> elements) => Postpend((ReadOnlyMemory<TElement>)elements);

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Postpend(ReadOnlyMemory<TElement> elements) {
			TResult? result = (TResult)this;
			for (Int32 i = elements.Length - 1; i >= 0; i--) {
				if ((result = result!.Postpend(elements.Span[i])) is null) { return default; }
			}
			return result;
		}

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator for the <paramref name="elements"/>.</typeparam>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Postpend<TEnumerator>([AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			TResult? result = (TResult)this;
			if (elements is not null) {
				foreach (TElement element in elements) {
					if ((result = result!.Postpend(element)) is null) { return default; }
				}
			}
			return result;
		}
	}
}

namespace Langly {
	public static partial class TraitExtensions {
		#region Postpend(Collection, TElement)
		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Postpend<TElement, TResult>([AllowNull] this IPostpend<TElement, TResult> collection, [AllowNull] TElement element) where TResult : IPostpend<TElement, TResult> => collection is not null ? collection.Postpend(element) : (TResult)collection;

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to postpend.</param>
		/// <returns>Returns a <see cref="Array"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection"), NotNullIfNotNull("element")]
		public static TElement[] Postpend<TElement>([AllowNull] this TElement[] collection, [AllowNull] TElement element) {
			if (element is null) {
				return collection;
			} else if (collection is null || collection.Length == 0) {
				return new[] { element };
			}
			TElement[] Array = new TElement[collection.Length + 1];
			System.Array.Copy(collection, Array, collection.Length);
			Array[collection.Length] = element;
			return Array;
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to postpend.</param>
		/// <returns>Returns a <see cref="Memory{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static Memory<TElement> Postpend<TElement>([AllowNull] this Memory<TElement> collection, [AllowNull] TElement element) {
			if (element is null) {
				return collection;
			} else if (collection.Length == 0) {
				return new[] { element };
			}
			TElement[] Array = new TElement[collection.Length + 1];
			collection.CopyTo(Array);
			Array[collection.Length] = element;
			return Array;
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static ReadOnlyMemory<TElement> Postpend<TElement>([AllowNull] this ReadOnlyMemory<TElement> collection, [AllowNull] TElement element) {
			if (element is null) {
				return collection;
			} else if (collection.Length == 0) {
				return new[] { element };
			}
			TElement[] Array = new TElement[collection.Length + 1];
			collection.CopyTo(Array);
			Array[collection.Length] = element;
			return Array;
		}
		#endregion

		#region Postpend(Collection, TElement[])
		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Postpend<TElement, TResult>([AllowNull] this IPostpend<TElement, TResult> collection, [AllowNull] params TElement[] elements) where TResult : IPostpend<TElement, TResult> => collection is not null ? collection.Postpend(elements) : (TResult)collection;

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="Array"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection"), NotNullIfNotNull("elements")]
		public static TElement[] Postpend<TElement>([AllowNull] this TElement[] collection, [AllowNull] params TElement[] elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			TElement[] Array = new TElement[collection.Length + elements.Length];
			System.Array.Copy(collection, Array, collection.Length);
			elements.CopyTo(Array.AsMemory().Slice(collection.Length, elements.Length));
			return Array;
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="Memory{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static Memory<TElement> Postpend<TElement>([AllowNull] this Memory<TElement> collection, [AllowNull] params TElement[] elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			TElement[] Array = new TElement[collection.Length + elements.Length];
			collection.CopyTo(Array);
			elements.CopyTo(Array.AsMemory().Slice(collection.Length, elements.Length));
			return Array;
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static ReadOnlyMemory<TElement> Postpend<TElement>([AllowNull] this ReadOnlyMemory<TElement> collection, [AllowNull] params TElement[] elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			TElement[] Array = new TElement[collection.Length + elements.Length];
			collection.CopyTo(Array);
			elements.CopyTo(Array.AsMemory().Slice(collection.Length, elements.Length));
			return Array;
		}
		#endregion

		#region Postpend(Collection, Memory<TElement>)
		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Postpend<TElement, TResult>([AllowNull] this IPostpend<TElement, TResult> collection, Memory<TElement> elements) where TResult : IPostpend<TElement, TResult> => collection is not null ? collection.Postpend(elements) : (TResult)collection;

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="Memory{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static Memory<TElement> Postpend<TElement>([AllowNull] this TElement[] collection, Memory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			TElement[] Array = new TElement[collection.Length + elements.Length];
			System.Array.Copy(collection, Array, collection.Length);
			elements.CopyTo(Array.AsMemory().Slice(collection.Length, elements.Length));
			return Array;
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="Memory{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static Memory<TElement> Postpend<TElement>([AllowNull] this Memory<TElement> collection, Memory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			TElement[] Array = new TElement[collection.Length + elements.Length];
			collection.CopyTo(Array);
			elements.CopyTo(Array.AsMemory().Slice(collection.Length, elements.Length));
			return Array;
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static ReadOnlyMemory<TElement> Postpend<TElement>([AllowNull] this ReadOnlyMemory<TElement> collection, Memory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			TElement[] Array = new TElement[collection.Length + elements.Length];
			collection.CopyTo(Array);
			elements.CopyTo(Array.AsMemory().Slice(collection.Length, elements.Length));
			return Array;
		}
		#endregion

		#region Postpend(Collection, ReadOnlyMemory<TElement>)
		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Postpend<TElement, TResult>([AllowNull] this IPostpend<TElement, TResult> collection, ReadOnlyMemory<TElement> elements) where TResult : IPostpend<TElement, TResult> => collection is not null ? collection.Postpend(elements) : (TResult)collection;

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static ReadOnlyMemory<TElement> Postpend<TElement>([AllowNull] this TElement[] collection, ReadOnlyMemory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			TElement[] Array = new TElement[collection.Length + elements.Length];
			System.Array.Copy(collection, Array, collection.Length);
			elements.CopyTo(Array.AsMemory().Slice(collection.Length, elements.Length));
			return Array;
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static ReadOnlyMemory<TElement> Postpend<TElement>([AllowNull] this Memory<TElement> collection, ReadOnlyMemory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			TElement[] Array = new TElement[collection.Length + elements.Length];
			collection.CopyTo(Array);
			elements.CopyTo(Array.AsMemory().Slice(collection.Length, elements.Length));
			return Array;
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static ReadOnlyMemory<TElement> Postpend<TElement>([AllowNull] this ReadOnlyMemory<TElement> collection, ReadOnlyMemory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			TElement[] Array = new TElement[collection.Length + elements.Length];
			collection.CopyTo(Array);
			elements.CopyTo(Array.AsMemory().Slice(collection.Length, elements.Length));
			return Array;
		}
		#endregion

		#region Postpend(Collection, Sequence)
		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Postpend<TElement, TResult, TEnumerator>([AllowNull] this IPostpend<TElement, TResult> collection, [AllowNull] ISequence<TElement, TEnumerator> elements) where TResult : IPostpend<TElement, TResult> where TEnumerator : IEnumerator<TElement> => collection is not null ? collection.Postpend(elements) : (TResult)collection;
		#endregion

		#region Postpend(Collection, String)
		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Postpend<TResult>([AllowNull] this IPostpend<Char, TResult> collection, [AllowNull] String elements) where TResult : IPostpend<Char, TResult> => collection is not null && elements is not null ? collection.Postpend(elements.AsMemory()) : (TResult)collection;
		#endregion
	}
}
