using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Langly;

namespace System {
	public static partial class TraitExtensions {
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
		/// <returns>Returns an <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and prepended elements.</returns>
		public static ReadOnlyMemory<Char> Prepend([AllowNull] this String collection, Char element) {
			if (collection is null || collection.Length == 0) {
				return new[] { element };
			}
			return PrependKernel<Char>(collection, element);
		}

		/// <summary>
		/// Prepends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to prepend.</param>
		/// <returns>Returns an <see cref="Memory{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		public static Memory<TElement> Prepend<TElement>([AllowNull] this TElement[] collection, [AllowNull] TElement element) {
			if (element is null) {
				return collection;
			} else if (collection is null || collection.Length == 0) {
				return new[] { element };
			}
			return PrependKernel<TElement>(collection, element);
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
			return PrependKernel<TElement>(collection.Span, element);
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
			return PrependKernel<TElement>(collection.Span, element);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The elements to prepend.</param>
		/// <returns>Returns a <see cref="Span{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		public static Span<TElement> Prepend<TElement>(this Span<TElement> collection, [AllowNull] TElement element) {
			if (element is null) {
				return collection;
			} else if (collection.Length == 0) {
				return new[] { element };
			}
			return PrependKernel<TElement>(collection, element);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The elements to prepend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		public static ReadOnlySpan<TElement> Prepend<TElement>(this ReadOnlySpan<TElement> collection, [AllowNull] TElement element) {
			if (element is null) {
				return collection;
			} else if (collection.Length == 0) {
				return new[] { element };
			}
			return PrependKernel<TElement>(collection, element);
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
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and prepended elements.</returns>
		public static ReadOnlyMemory<Char> Prepend([AllowNull] this String collection, [AllowNull] params Char[] elements) {
			if (elements is null || elements.Length == 0) {
				return collection.AsMemory();
			} else if (collection is null || collection.Length == 0) {
				return elements.AsMemory();
			}
			return PrependKernel<Char>(collection, elements);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="Memory{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		public static Memory<TElement> Prepend<TElement>([AllowNull] this TElement[] collection, [AllowNull] params TElement[] elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			return PrependKernel<TElement>(collection, elements);
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
			return PrependKernel<TElement>(collection.Span, elements);
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
			return PrependKernel<TElement>(collection.Span, elements);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="Span{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		public static Span<TElement> Prepend<TElement>(this Span<TElement> collection, [AllowNull] params TElement[] elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			return PrependKernel<TElement>(collection, elements);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		public static ReadOnlySpan<TElement> Prepend<TElement>(this ReadOnlySpan<TElement> collection, [AllowNull] params TElement[] elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			return PrependKernel<TElement>(collection, elements);
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
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and prepended elements.</returns>
		public static ReadOnlyMemory<Char> Prepend([AllowNull] this String collection, Memory<Char> elements) {
			if (elements.Length == 0) {
				return collection.AsMemory();
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			return PrependKernel<Char>(collection, elements.Span);
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
			return PrependKernel<TElement>(collection, elements.Span);
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
			return PrependKernel<TElement>(collection.Span, elements.Span);
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
			return PrependKernel<TElement>(collection.Span, elements.Span);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="Span{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		public static Span<TElement> Prepend<TElement>(this Span<TElement> collection, Memory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements.Span;
			}
			return PrependKernel<TElement>(collection, elements.Span);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		public static ReadOnlySpan<TElement> Prepend<TElement>(this ReadOnlySpan<TElement> collection, Memory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements.Span;
			}
			return PrependKernel<TElement>(collection, elements.Span);
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
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and prepended elements.</returns>
		public static ReadOnlyMemory<Char> Prepend([AllowNull] this String collection, ReadOnlyMemory<Char> elements) {
			if (elements.Length == 0) {
				return collection.AsMemory();
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			return PrependKernel<Char>(collection, elements.Span);
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
			return PrependKernel<TElement>(collection, elements.Span);
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
			return PrependKernel<TElement>(collection.Span, elements.Span);
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
			return PrependKernel<TElement>(collection.Span, elements.Span);
		}
		#endregion

		#region Prepend(Collection, Span<TElement>)
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
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and prepended elements.</returns>
		public static ReadOnlySpan<Char> Prepend([AllowNull] this String collection, Span<Char> elements) {
			if (elements.Length == 0) {
				return collection.AsSpan();
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			return PrependKernel<Char>(collection, elements);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="Span{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		public static Span<TElement> Prepend<TElement>([AllowNull] this TElement[] collection, Span<TElement> elements) {
			if (elements.Length == 0) {
				return collection.AsSpan();
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			return PrependKernel<TElement>(collection, elements);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="Span{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		public static Span<TElement> Prepend<TElement>(this Memory<TElement> collection, Span<TElement> elements) {
			if (elements.Length == 0) {
				return collection.Span;
			} else if (collection.Length == 0) {
				return elements;
			}
			return PrependKernel<TElement>(collection.Span, elements);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		public static ReadOnlySpan<TElement> Prepend<TElement>(this ReadOnlyMemory<TElement> collection, Span<TElement> elements) {
			if (elements.Length == 0) {
				return collection.Span;
			} else if (collection.Length == 0) {
				return elements;
			}
			return PrependKernel<TElement>(collection.Span, elements);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="Span{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		public static Span<TElement> Prepend<TElement>(this Span<TElement> collection, Span<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			return PrependKernel<TElement>(collection, elements);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		public static ReadOnlySpan<TElement> Prepend<TElement>(this ReadOnlySpan<TElement> collection, Span<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			return PrependKernel<TElement>(collection, elements);
		}
		#endregion

		#region Prepend(Collection, ReadOnlySpan<TElement>)
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

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and prepended elements.</returns>
		public static ReadOnlySpan<Char> Prepend([AllowNull] this String collection, ReadOnlySpan<Char> elements) {
			if (elements.Length == 0) {
				return collection.AsSpan();
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			return PrependKernel<Char>(collection, elements);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		public static ReadOnlySpan<TElement> Prepend<TElement>([AllowNull] this TElement[] collection, ReadOnlySpan<TElement> elements) {
			if (elements.Length == 0) {
				return collection.AsSpan();
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			return PrependKernel<TElement>(collection, elements);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		public static ReadOnlySpan<TElement> Prepend<TElement>(this Memory<TElement> collection, ReadOnlySpan<TElement> elements) {
			if (elements.Length == 0) {
				return collection.Span;
			} else if (collection.Length == 0) {
				return elements;
			}
			return PrependKernel<TElement>(collection.Span, elements);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		public static ReadOnlySpan<TElement> Prepend<TElement>(this ReadOnlyMemory<TElement> collection, ReadOnlySpan<TElement> elements) {
			if (elements.Length == 0) {
				return collection.Span;
			} else if (collection.Length == 0) {
				return elements;
			}
			return PrependKernel<TElement>(collection.Span, elements);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		public static ReadOnlySpan<TElement> Prepend<TElement>(this Span<TElement> collection, ReadOnlySpan<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			return PrependKernel<TElement>(collection, elements);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		public static ReadOnlySpan<TElement> Prepend<TElement>(this ReadOnlySpan<TElement> collection, ReadOnlySpan<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			return PrependKernel<TElement>(collection, elements);
		}
		#endregion

		#region Prepend(Collection, TElement*, Int32)
		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>If the prepend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and prepended elements; otherwise, <see langword="null"/>.</returns>
		[CLSCompliant(false)]
		[return: MaybeNull]
		public static unsafe TResult Prepend<TElement, TResult>([AllowNull] this IPrependUnsafe<TElement, TResult> collection, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged where TResult : IPrependUnsafe<TElement, TResult> => collection is not null ? collection.Prepend(elements, length) : (TResult)collection;

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and prepended elements.</returns>
		[CLSCompliant(false)]
		public static unsafe ReadOnlySpan<Char> Prepend([AllowNull] this String collection, [AllowNull] Char* elements, Int32 length) {
			if (elements is null || length == 0) {
				return collection.AsSpan();
			} else if (collection is null || collection.Length == 0) {
				return new ReadOnlySpan<Char>(elements, length);
			}
			return PrependKernel<Char>(collection, elements, length);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>Returns a <see cref="Span{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		[CLSCompliant(false)]
		public static unsafe Span<TElement> Prepend<TElement>([AllowNull] this TElement[] collection, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged {
			if (elements is null || length == 0) {
				return collection.AsSpan();
			} else if (collection is null || collection.Length == 0) {
				return new Span<TElement>(elements, length);
			}
			return PrependKernel<TElement>(collection, elements, length);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>Returns a <see cref="Span{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		[CLSCompliant(false)]
		public static unsafe Span<TElement> Prepend<TElement>(this Memory<TElement> collection, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged {
			if (elements is null || length == 0) {
				return collection.Span;
			} else if (collection.Length == 0) {
				return new Span<TElement>(elements, length);
			}
			return PrependKernel<TElement>(collection.Span, elements, length);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		[CLSCompliant(false)]
		public static unsafe ReadOnlySpan<TElement> Prepend<TElement>(this ReadOnlyMemory<TElement> collection, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged {
			if (elements is null || length == 0) {
				return collection.Span;
			} else if (collection.Length == 0) {
				return new ReadOnlySpan<TElement>(elements, length);
			}
			return PrependKernel<TElement>(collection.Span, elements, length);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>Returns a <see cref="Span{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		[CLSCompliant(false)]
		public static unsafe Span<TElement> Prepend<TElement>(this Span<TElement> collection, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged {
			if (elements is null || length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return new Span<TElement>(elements, length);
			}
			return PrependKernel<TElement>(collection, elements, length);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and prepended elements.</returns>
		[CLSCompliant(false)]
		public static unsafe ReadOnlySpan<TElement> Prepend<TElement>(this ReadOnlySpan<TElement> collection, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged {
			if (elements is null || length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return new ReadOnlySpan<TElement>(elements, length);
			}
			return PrependKernel<TElement>(collection, elements, length);
		}
		#endregion

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
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and prepended elements.</returns>
		public static ReadOnlyMemory<Char> Prepend([AllowNull] this String collection, [AllowNull] String elements) {
			if (elements is null || elements.Length == 0) {
				return collection.AsMemory();
			} else if (collection is null || collection.Length == 0) {
				return elements.AsMemory();
			}
			return PrependKernel<Char>(collection, elements);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and prepended elements.</returns>
		public static ReadOnlyMemory<Char> Prepend([AllowNull] this Char[] collection, [AllowNull] String elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection is null || collection.Length == 0) {
				return elements.AsMemory();
			}
			return PrependKernel<Char>(collection, elements);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and prepended elements.</returns>
		public static ReadOnlyMemory<Char> Prepend(this Memory<Char> collection, [AllowNull] String elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements.AsMemory();
			}
			return PrependKernel<Char>(collection.Span, elements);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and prepended elements.</returns>
		public static ReadOnlyMemory<Char> Prepend(this ReadOnlyMemory<Char> collection, [AllowNull] String elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements.AsMemory();
			}
			return PrependKernel<Char>(collection.Span, elements);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and prepended elements.</returns>
		public static ReadOnlySpan<Char> Prepend(this Span<Char> collection, [AllowNull] String elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements.AsSpan();
			}
			return PrependKernel<Char>(collection, elements);
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and prepended elements.</returns>
		public static ReadOnlySpan<Char> Prepend(this ReadOnlySpan<Char> collection, [AllowNull] String elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements.AsSpan();
			}
			return PrependKernel<Char>(collection, elements);
		}
		#endregion

		[return: NotNull]
		private static TElement[] PrependKernel<TElement>(ReadOnlySpan<TElement> collection, [DisallowNull] TElement element) {
			TElement[] array = new TElement[collection.Length + 1];
			collection.CopyTo(array.Slice(1));
			array[0] = element;
			return array;
		}

		[return: NotNull]
		private static TElement[] PrependKernel<TElement>(ReadOnlySpan<TElement> collection, ReadOnlySpan<TElement> elements) {
			TElement[] array = new TElement[collection.Length + elements.Length];
			collection.CopyTo(array.Slice(elements.Length));
			elements.CopyTo(array);
			return array;
		}

		[return: NotNull]
		private static unsafe TElement[] PrependKernel<TElement>(ReadOnlySpan<TElement> collection, TElement* elements, Int32 length) where TElement : unmanaged {
			TElement[] array = new TElement[collection.Length + length];
			collection.CopyTo(array.Slice(length));
			Pointer.Copy(elements, length, array);
			return array;
		}
	}
}
