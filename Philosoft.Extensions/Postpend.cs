using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Langly;

namespace System {
	public static partial class PhilosoftExtensions {
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
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and postpended elements.</returns>
		public static ReadOnlyMemory<Char> Postpend([AllowNull] this String collection, Char element) {
			if (collection is null || collection.Length == 0) {
				return new Char[] { element };
			}
			return PostpendKernel<Char>(collection, element);
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to postpend.</param>
		/// <returns>Returns a <see cref="Array"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static Memory<TElement> Postpend<TElement>([AllowNull] this TElement[] collection, [AllowNull] TElement element) {
			if (element is null) {
				return collection;
			} else if (collection is null || collection.Length == 0) {
				return new[] { element };
			}
			return PostpendKernel<TElement>(collection, element);
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
			return PostpendKernel<TElement>(collection.Span, element);
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
			return PostpendKernel<TElement>(collection.Span, element);
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to postpend.</param>
		/// <returns>Returns a <see cref="Span{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static Span<TElement> Postpend<TElement>([AllowNull] this Span<TElement> collection, [AllowNull] TElement element) {
			if (element is null) {
				return collection;
			} else if (collection.Length == 0) {
				return new[] { element };
			}
			return PostpendKernel<TElement>(collection, element);
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static ReadOnlySpan<TElement> Postpend<TElement>([AllowNull] this ReadOnlySpan<TElement> collection, [AllowNull] TElement element) {
			if (element is null) {
				return collection;
			} else if (collection.Length == 0) {
				return new[] { element };
			}
			return PostpendKernel<TElement>(collection, element);
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
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and postpended elements.</returns>
		public static ReadOnlyMemory<Char> Postpend([AllowNull] this String collection, [AllowNull] params Char[] elements) {
			if (elements is null || elements.Length == 0) {
				return collection.AsMemory();
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			return PostpendKernel<Char>(collection, elements);
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="Memory{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static Memory<TElement> Postpend<TElement>([AllowNull] this TElement[] collection, [AllowNull] params TElement[] elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			return PostpendKernel<TElement>(collection, elements);
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
			return PostpendKernel<TElement>(collection.Span, elements);
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
			return PostpendKernel<TElement>(collection.Span, elements);
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="Span{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static Span<TElement> Postpend<TElement>([AllowNull] this Span<TElement> collection, [AllowNull] params TElement[] elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			return PostpendKernel<TElement>(collection, elements);
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static ReadOnlySpan<TElement> Postpend<TElement>([AllowNull] this ReadOnlySpan<TElement> collection, [AllowNull] params TElement[] elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			return PostpendKernel<TElement>(collection, elements);
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
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and postpended elements.</returns>
		public static ReadOnlyMemory<Char> Postpend([AllowNull] this String collection, Memory<Char> elements) {
			if (elements.Length == 0) {
				return collection.AsMemory();
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			return PostpendKernel<Char>(collection, elements.Span);
		}

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
			return PostpendKernel<TElement>(collection, elements.Span);
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
			return PostpendKernel<TElement>(collection.Span, elements.Span);
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
			return PostpendKernel<TElement>(collection.Span, elements.Span);
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="Span{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static Span<TElement> Postpend<TElement>([AllowNull] this Span<TElement> collection, Memory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements.Span;
			}
			return PostpendKernel<TElement>(collection, elements.Span);
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static ReadOnlySpan<TElement> Postpend<TElement>([AllowNull] this ReadOnlySpan<TElement> collection, Memory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements.Span;
			}
			return PostpendKernel<TElement>(collection, elements.Span);
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
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and postpended elements.</returns>
		public static ReadOnlyMemory<Char> Postpend([AllowNull] this String collection, ReadOnlyMemory<Char> elements) {
			if (elements.Length == 0) {
				return collection.AsMemory();
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			return PostpendKernel<Char>(collection, elements.Span);
		}

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
			return PostpendKernel<TElement>(collection, elements.Span);
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
			return PostpendKernel<TElement>(collection.Span, elements.Span);
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
			return PostpendKernel<TElement>(collection.Span, elements.Span);
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static ReadOnlySpan<TElement> Postpend<TElement>([AllowNull] this Span<TElement> collection, ReadOnlyMemory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements.Span;
			}
			return PostpendKernel<TElement>(collection, elements.Span);
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static ReadOnlySpan<TElement> Postpend<TElement>([AllowNull] this ReadOnlySpan<TElement> collection, ReadOnlyMemory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements.Span;
			}
			return PostpendKernel<TElement>(collection, elements.Span);
		}
		#endregion

		#region Postpend(Collection, Span<TElement>)
		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Postpend<TElement, TResult>([AllowNull] this IPostpendSpan<TElement, TResult> collection, Span<TElement> elements) where TResult : IPostpendSpan<TElement, TResult> => collection is not null ? collection.Postpend(elements) : (TResult)collection;

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and postpended elements.</returns>
		public static ReadOnlySpan<Char> Postpend([AllowNull] this String collection, Span<Char> elements) {
			if (elements.Length == 0) {
				return collection.AsSpan();
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			return PostpendKernel<Char>(collection, elements);
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="Span{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static Span<TElement> Postpend<TElement>([AllowNull] this TElement[] collection, Span<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			return PostpendKernel<TElement>(collection, elements);
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="Span{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static Span<TElement> Postpend<TElement>([AllowNull] this Memory<TElement> collection, Span<TElement> elements) {
			if (elements.Length == 0) {
				return collection.Span;
			} else if (collection.Length == 0) {
				return elements;
			}
			return PostpendKernel<TElement>(collection.Span, elements);
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static ReadOnlySpan<TElement> Postpend<TElement>([AllowNull] this ReadOnlyMemory<TElement> collection, Span<TElement> elements) {
			if (elements.Length == 0) {
				return collection.Span;
			} else if (collection.Length == 0) {
				return elements;
			}
			return PostpendKernel<TElement>(collection.Span, elements);
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="Span{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static Span<TElement> Postpend<TElement>([AllowNull] this Span<TElement> collection, Span<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			return PostpendKernel<TElement>(collection, elements);
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static ReadOnlySpan<TElement> Postpend<TElement>([AllowNull] this ReadOnlySpan<TElement> collection, Span<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			return PostpendKernel<TElement>(collection, elements);
		}
		#endregion

		#region Postpend(Collection, ReadOnlySpan<TElement>)
		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Postpend<TElement, TResult>([AllowNull] this IPostpendSpan<TElement, TResult> collection, ReadOnlySpan<TElement> elements) where TResult : IPostpendSpan<TElement, TResult> => collection is not null ? collection.Postpend(elements) : (TResult)collection;

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and postpended elements.</returns>
		public static ReadOnlySpan<Char> Postpend([AllowNull] this String collection, ReadOnlySpan<Char> elements) {
			if (elements.Length == 0) {
				return collection.AsSpan();
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			return PostpendKernel<Char>(collection, elements);
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static ReadOnlySpan<TElement> Postpend<TElement>([AllowNull] this TElement[] collection, ReadOnlySpan<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			return PostpendKernel<TElement>(collection, elements);
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static ReadOnlySpan<TElement> Postpend<TElement>([AllowNull] this Memory<TElement> collection, ReadOnlySpan<TElement> elements) {
			if (elements.Length == 0) {
				return collection.Span;
			} else if (collection.Length == 0) {
				return elements;
			}
			return PostpendKernel<TElement>(collection.Span, elements);
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static ReadOnlySpan<TElement> Postpend<TElement>([AllowNull] this ReadOnlyMemory<TElement> collection, ReadOnlySpan<TElement> elements) {
			if (elements.Length == 0) {
				return collection.Span;
			} else if (collection.Length == 0) {
				return elements;
			}
			return PostpendKernel<TElement>(collection.Span, elements);
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static ReadOnlySpan<TElement> Postpend<TElement>([AllowNull] this Span<TElement> collection, ReadOnlySpan<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			return PostpendKernel<TElement>(collection, elements);
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and postpended elements.</returns>
		public static ReadOnlySpan<TElement> Postpend<TElement>([AllowNull] this ReadOnlySpan<TElement> collection, ReadOnlySpan<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			return PostpendKernel<TElement>(collection, elements);
		}
		#endregion

		#region Postpend(Collection, TElement*, Int32)
		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[CLSCompliant(false)]
		[return: MaybeNull]
		public static unsafe TResult Postpend<TElement, TResult>([AllowNull] this IPostpendUnsafe<TElement, TResult> collection, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged where TResult : IPostpendUnsafe<TElement, TResult> => collection is not null ? collection.Postpend(elements, length) : (TResult)collection;

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and postpended elements.</returns>
		[CLSCompliant(false)]
		[return: MaybeNull]
		public static unsafe ReadOnlySpan<Char> Postpend([AllowNull] this String collection, [AllowNull] Char* elements, Int32 length) {
			if (length == 0) {
				return collection.AsSpan();
			} else if (collection is null || collection.Length == 0) {
				return new ReadOnlySpan<Char>(elements, length);
			}
			return PostpendKernel<Char>(collection, elements, length);
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and postpended elements.</returns>
		[CLSCompliant(false)]
		[return: MaybeNull]
		public static unsafe ReadOnlySpan<TElement> Postpend<TElement>([AllowNull] this TElement[] collection, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged {
			if (length == 0) {
				return collection.AsSpan();
			} else if (collection is null || collection.Length == 0) {
				return new ReadOnlySpan<TElement>(elements, length);
			}
			return PostpendKernel<TElement>(collection, elements, length);
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and postpended elements.</returns>
		[CLSCompliant(false)]
		[return: MaybeNull]
		public static unsafe ReadOnlySpan<TElement> Postpend<TElement>(this Memory<TElement> collection, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged {
			if (length == 0) {
				return collection.Span;
			} else if (collection.Length == 0) {
				return new ReadOnlySpan<TElement>(elements, length);
			}
			return PostpendKernel<TElement>(collection.Span, elements, length);
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and postpended elements.</returns>
		[CLSCompliant(false)]
		[return: MaybeNull]
		public static unsafe ReadOnlySpan<TElement> Postpend<TElement>(this ReadOnlyMemory<TElement> collection, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged {
			if (length == 0) {
				return collection.Span;
			} else if (collection.Length == 0) {
				return new ReadOnlySpan<TElement>(elements, length);
			}
			return PostpendKernel<TElement>(collection.Span, elements, length);
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and postpended elements.</returns>
		[CLSCompliant(false)]
		[return: MaybeNull]
		public static unsafe ReadOnlySpan<TElement> Postpend<TElement>(this Span<TElement> collection, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged {
			if (length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return new ReadOnlySpan<TElement>(elements, length);
			}
			return PostpendKernel<TElement>(collection, elements, length);
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and postpended elements.</returns>
		[CLSCompliant(false)]
		[return: MaybeNull]
		public static unsafe ReadOnlySpan<TElement> Postpend<TElement>(this ReadOnlySpan<TElement> collection, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged {
			if (length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return new ReadOnlySpan<TElement>(elements, length);
			}
			return PostpendKernel<TElement>(collection, elements, length);
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

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="String"/> containing the original and postpended elements.</returns>
		public static ReadOnlyMemory<Char> Postpend([AllowNull] this String collection, [AllowNull] String elements) {
			if (elements is null || elements.Length == 0) {
				return collection.AsMemory();
			} else if (collection is null || collection.Length == 0) {
				return elements.AsMemory();
			}
			return PostpendKernel<Char>(collection, elements);
		}

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and postpended elements.</returns>
		public static ReadOnlyMemory<Char> Postpend([AllowNull] this Char[] collection, [AllowNull] String elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection is null || collection.Length == 0) {
				return elements.AsMemory();
			}
			return PostpendKernel<Char>(collection, elements);
		}

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and postpended elements.</returns>
		public static ReadOnlyMemory<Char> Postpend(this Memory<Char> collection, [AllowNull] String elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements.AsMemory();
			}
			return PostpendKernel<Char>(collection.Span, elements);
		}

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and postpended elements.</returns>
		public static ReadOnlyMemory<Char> Postpend(this ReadOnlyMemory<Char> collection, [AllowNull] String elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements.AsMemory();
			}
			return PostpendKernel<Char>(collection.Span, elements);
		}

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and postpended elements.</returns>
		public static ReadOnlySpan<Char> Postpend(this Span<Char> collection, [AllowNull] String elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements.AsSpan();
			}
			return PostpendKernel<Char>(collection, elements);
		}

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and postpended elements.</returns>
		public static ReadOnlySpan<Char> Postpend(this ReadOnlySpan<Char> collection, [AllowNull] String elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements.AsSpan();
			}
			return PostpendKernel<Char>(collection, elements);
		}
		#endregion

		[return: NotNull]
		private static TElement[] PostpendKernel<TElement>(ReadOnlySpan<TElement> collection, [DisallowNull] TElement element) {
			TElement[] array = new TElement[collection.Length + 1];
			collection.CopyTo(array);
			array[collection.Length] = element;
			return array;
		}

		[return: NotNull]
		private static TElement[] PostpendKernel<TElement>(ReadOnlySpan<TElement> collection, ReadOnlySpan<TElement> elements) {
			TElement[] array = new TElement[collection.Length + elements.Length];
			collection.CopyTo(array);
			elements.CopyTo(array.Slice(collection.Length, elements.Length));
			return array;
		}

		[CLSCompliant(false)]
		[return: NotNull]
		private static unsafe TElement[] PostpendKernel<TElement>(ReadOnlySpan<TElement> collection, TElement* elements, Int32 length) where TElement : unmanaged {
			TElement[] array = new TElement[collection.Length + length];
			collection.CopyTo(array);
			Pointer.Copy(elements, length, array.Slice(collection.Length, length));
			return array;
		}
	}
}
