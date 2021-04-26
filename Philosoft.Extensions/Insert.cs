using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Langly;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TIndex">The type of the indicies.</typeparam>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Insert<TIndex, TElement, TResult>([AllowNull] this IInsert<TIndex, TElement, TResult> collection, [DisallowNull] TIndex index, [AllowNull] TElement element) where TResult : IInsert<TIndex, TElement, TResult> {
			if (index is null) {
				throw new IndexOutOfRangeException();
			}
			return collection is not null ? collection.Insert(index, element) : (TResult)collection;
		}

		#region Insert(Collection, nint, TElement)
		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Insert<TElement, TResult>([AllowNull] this IInsert<TElement, TResult> collection, nint index, [AllowNull] TElement element) where TResult : IInsert<TElement, TResult> => collection is not null ? ((IInsert<nint, TElement, TResult>)collection).Insert(index, element) : (TResult)collection;

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>Returns an <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and inserted elements.</returns>
		public static ReadOnlyMemory<Char> Insert([AllowNull] this String collection, nint index, Char element) {
			if (collection is null || collection.Length == 0) {
				return new[] { element };
			}
			return InsertKernel<Char>(collection.AsSpan(), index, element);
		}

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>Returns an <see cref="Array"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static Memory<TElement> Insert<TElement>([AllowNull] this TElement[] collection, nint index, [AllowNull] TElement element) {
			if (element is null) {
				return collection;
			} else if (collection is null || collection.Length == 0) {
				return new[] { element };
			}
			return InsertKernel<TElement>(collection.AsSpan(), index, element);
		}

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>Returns a <see cref="Memory{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static Memory<TElement> Insert<TElement>(this Memory<TElement> collection, nint index, [AllowNull] TElement element) {
			if (element is null) {
				return collection;
			} else if (collection.Length == 0) {
				return new[] { element };
			}
			return InsertKernel<TElement>(collection.Span, index, element);
		}

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static ReadOnlyMemory<TElement> Insert<TElement>(this ReadOnlyMemory<TElement> collection, nint index, [AllowNull] TElement element) {
			if (element is null) {
				return collection;
			} else if (collection.Length == 0) {
				return new[] { element };
			}
			return InsertKernel<TElement>(collection.Span, index, element);
		}

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>Returns a <see cref="Span{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static Span<TElement> Insert<TElement>(this Span<TElement> collection, nint index, [AllowNull] TElement element) {
			if (element is null) {
				return collection;
			} else if (collection.Length == 0) {
				return new[] { element };
			}
			return InsertKernel<TElement>(collection, index, element);
		}

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static ReadOnlySpan<TElement> Insert<TElement>(this ReadOnlySpan<TElement> collection, nint index, [AllowNull] TElement element) {
			if (element is null) {
				return collection;
			} else if (collection.Length == 0) {
				return new[] { element };
			}
			return InsertKernel<TElement>(collection, index, element);
		}
		#endregion

		#region Insert(Collection, nint, TElement[])
		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Insert<TElement, TResult>([AllowNull] this IInsert<TElement, TResult> collection, nint index, [AllowNull] params TElement[] elements) where TResult : IInsert<TElement, TResult> => collection is not null ? collection.Insert(index, elements) : (TResult)collection;

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and inserted elements.</returns>
		public static ReadOnlyMemory<Char> Insert([AllowNull] this String collection, nint index, [AllowNull] Char[] elements) {
			if (elements is null || elements.Length == 0) {
				return collection.AsMemory();
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			return InsertKernel<Char>(collection, index, elements);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="Memory{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static Memory<TElement> Insert<TElement>([AllowNull] this TElement[] collection, nint index, [AllowNull] params TElement[] elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			return InsertKernel<TElement>(collection, index, elements);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="Memory{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static Memory<TElement> Insert<TElement>(this Memory<TElement> collection, nint index, [AllowNull] params TElement[] elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			return InsertKernel<TElement>(collection.Span, index, elements);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static ReadOnlyMemory<TElement> Insert<TElement>(this ReadOnlyMemory<TElement> collection, nint index, [AllowNull] params TElement[] elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			return InsertKernel<TElement>(collection.Span, index, elements);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="Span{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static Span<TElement> Insert<TElement>(this Span<TElement> collection, nint index, [AllowNull] params TElement[] elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			return InsertKernel<TElement>(collection, index, elements);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static ReadOnlySpan<TElement> Insert<TElement>(this ReadOnlySpan<TElement> collection, nint index, [AllowNull] params TElement[] elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			return InsertKernel<TElement>(collection, index, elements);
		}
		#endregion

		#region Insert(Collection, nint, Memory<TElement>)
		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Insert<TElement, TResult>([AllowNull] this IInsert<TElement, TResult> collection, nint index, Memory<TElement> elements) where TResult : IInsert<TElement, TResult> => collection is not null ? collection.Insert(index, elements) : (TResult)collection;

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="Memory{T}"/> of <see cref="Char"/> containing the original and inserted elements.</returns>
		public static ReadOnlyMemory<Char> Insert([AllowNull] this String collection, nint index, Memory<Char> elements) {
			if (elements.Length == 0) {
				return collection.AsMemory();
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			return InsertKernel<Char>(collection, index, elements.Span);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="Memory{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static Memory<TElement> Insert<TElement>([AllowNull] this TElement[] collection, nint index, Memory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			return InsertKernel<TElement>(collection, index, elements.Span);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="Memory{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static Memory<TElement> Insert<TElement>(this Memory<TElement> collection, nint index, Memory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			return InsertKernel<TElement>(collection.Span, index, elements.Span);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static ReadOnlyMemory<TElement> Insert<TElement>(this ReadOnlyMemory<TElement> collection, nint index, Memory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			return InsertKernel<TElement>(collection.Span, index, elements.Span);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="Span{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static Span<TElement> Insert<TElement>(this Span<TElement> collection, nint index, Memory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements.Span;
			}
			return InsertKernel<TElement>(collection, index, elements.Span);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static ReadOnlySpan<TElement> Insert<TElement>(this ReadOnlySpan<TElement> collection, nint index, Memory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements.Span;
			}
			return InsertKernel<TElement>(collection, index, elements.Span);
		}
		#endregion

		#region Insert(Collection, nint, ReadOnlyMemory<TElement>)
		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Insert<TElement, TResult>([AllowNull] this IInsert<TElement, TResult> collection, nint index, ReadOnlyMemory<TElement> elements) where TResult : IInsert<TElement, TResult> => collection is not null ? collection.Insert(index, elements) : (TResult)collection;

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and inserted elements.</returns>
		public static ReadOnlyMemory<Char> Insert([AllowNull] this String collection, nint index, ReadOnlyMemory<Char> elements) {
			if (elements.Length == 0) {
				return collection.AsMemory();
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			return InsertKernel<Char>(collection.AsSpan(), index, elements.Span);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static ReadOnlyMemory<TElement> Insert<TElement>([AllowNull] this TElement[] collection, nint index, ReadOnlyMemory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			return InsertKernel<TElement>(collection, index, elements.Span);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static ReadOnlyMemory<TElement> Insert<TElement>(this Memory<TElement> collection, nint index, ReadOnlyMemory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			return InsertKernel<TElement>(collection.Span, index, elements.Span);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static ReadOnlyMemory<TElement> Insert<TElement>(this ReadOnlyMemory<TElement> collection, nint index, ReadOnlyMemory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			return InsertKernel<TElement>(collection.Span, index, elements.Span);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static ReadOnlySpan<TElement> Insert<TElement>(this Span<TElement> collection, nint index, ReadOnlyMemory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements.Span;
			}
			return InsertKernel<TElement>(collection, index, elements.Span);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static ReadOnlySpan<TElement> Insert<TElement>(this ReadOnlySpan<TElement> collection, nint index, ReadOnlyMemory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements.Span;
			}
			return InsertKernel<TElement>(collection, index, elements.Span);
		}
		#endregion

		#region Insert(Collection, nint, Span<TElement>)
		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Insert<TElement, TResult>([AllowNull] this IInsertSpan<TElement, TResult> collection, nint index, Span<TElement> elements) where TResult : IInsertSpan<TElement, TResult> => collection is not null ? collection.Insert(index, elements) : (TResult)collection;

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and inserted elements.</returns>
		public static ReadOnlySpan<Char> Insert([AllowNull] this String collection, nint index, Span<Char> elements) {
			if (elements.Length == 0) {
				return collection.AsSpan();
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			return InsertKernel<Char>(collection, index, elements);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="Span{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static Span<TElement> Insert<TElement>([AllowNull] this TElement[] collection, nint index, Span<TElement> elements) {
			if (elements.Length == 0) {
				return collection.AsSpan();
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			return InsertKernel<TElement>(collection, index, elements);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="Span{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static Span<TElement> Insert<TElement>(this Memory<TElement> collection, nint index, Span<TElement> elements) {
			if (elements.Length == 0) {
				return collection.Span;
			} else if (collection.Length == 0) {
				return elements;
			}
			return InsertKernel<TElement>(collection.Span, index, elements);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static ReadOnlySpan<TElement> Insert<TElement>(this ReadOnlyMemory<TElement> collection, nint index, Span<TElement> elements) {
			if (elements.Length == 0) {
				return collection.Span;
			} else if (collection.Length == 0) {
				return elements;
			}
			return InsertKernel<TElement>(collection.Span, index, elements);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="Span{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static Span<TElement> Insert<TElement>(this Span<TElement> collection, nint index, Span<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			return InsertKernel<TElement>(collection, index, elements);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static ReadOnlySpan<TElement> Insert<TElement>(this ReadOnlySpan<TElement> collection, nint index, Span<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			return InsertKernel<TElement>(collection, index, elements);
		}
		#endregion

		#region Insert(Collection, nint, ReadOnlySpan<TElement>)
		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Insert<TElement, TResult>([AllowNull] this IInsertSpan<TElement, TResult> collection, nint index, ReadOnlySpan<TElement> elements) where TResult : IInsertSpan<TElement, TResult> => collection is not null ? collection.Insert(index, elements) : (TResult)collection;

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and inserted elements.</returns>
		public static ReadOnlySpan<Char> Insert([AllowNull] this String collection, nint index, ReadOnlySpan<Char> elements) {
			if (elements.Length == 0) {
				return collection.AsSpan();
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			return InsertKernel<Char>(collection, index, elements);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static ReadOnlySpan<TElement> Insert<TElement>([AllowNull] this TElement[] collection, nint index, ReadOnlySpan<TElement> elements) {
			if (elements.Length == 0) {
				return collection.AsSpan();
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			return InsertKernel<TElement>(collection, index, elements);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static ReadOnlySpan<TElement> Insert<TElement>(this Memory<TElement> collection, nint index, ReadOnlySpan<TElement> elements) {
			if (elements.Length == 0) {
				return collection.Span;
			} else if (collection.Length == 0) {
				return elements;
			}
			return InsertKernel<TElement>(collection.Span, index, elements);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static ReadOnlySpan<TElement> Insert<TElement>(this ReadOnlyMemory<TElement> collection, nint index, ReadOnlySpan<TElement> elements) {
			if (elements.Length == 0) {
				return collection.Span;
			} else if (collection.Length == 0) {
				return elements;
			}
			return InsertKernel<TElement>(collection.Span, index, elements);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static ReadOnlySpan<TElement> Insert<TElement>(this Span<TElement> collection, nint index, ReadOnlySpan<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			return InsertKernel<TElement>(collection, index, elements);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static ReadOnlySpan<TElement> Insert<TElement>(this ReadOnlySpan<TElement> collection, nint index, ReadOnlySpan<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			return InsertKernel<TElement>(collection, index, elements);
		}
		#endregion

		#region Insert(Collection, nint, TElement*, Int32)
		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <param name="length">The length of the <paramref name="collection"/>.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[CLSCompliant(false)]
		[return: MaybeNull]
		public static unsafe TResult Insert<TElement, TResult>([AllowNull] this IInsertUnsafe<TElement, TResult> collection, nint index, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged where TResult : IInsertUnsafe<TElement, TResult> => collection is not null ? collection.Insert(index, elements, length) : (TResult)collection;

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and inserted elements.</returns>
		[CLSCompliant(false)]
		public static unsafe ReadOnlySpan<Char> Insert([AllowNull] this String collection, nint index, [AllowNull] Char* elements, Int32 length) {
			if (elements is null || length == 0) {
				return collection.AsSpan();
			} else if (collection is null || collection.Length == 0) {
				return new ReadOnlySpan<Char>(elements, length);
			}
			return InsertKernel<Char>(collection, index, elements, length);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		[CLSCompliant(false)]
		public static unsafe ReadOnlySpan<TElement> Insert<TElement>([AllowNull] this TElement[] collection, nint index, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged {
			if (elements is null || length == 0) {
				return collection.AsSpan();
			} else if (collection is null || collection.Length == 0) {
				return new ReadOnlySpan<TElement>(elements, length);
			}
			return InsertKernel<TElement>(collection, index, elements, length);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		[CLSCompliant(false)]
		public static unsafe ReadOnlySpan<TElement> Insert<TElement>(this Memory<TElement> collection, nint index, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged {
			if (elements is null || length == 0) {
				return collection.Span;
			} else if (collection.Length == 0) {
				return new ReadOnlySpan<TElement>(elements, length);
			}
			return InsertKernel<TElement>(collection.Span, index, elements, length);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		[CLSCompliant(false)]
		public static unsafe ReadOnlySpan<TElement> Insert<TElement>(this ReadOnlyMemory<TElement> collection, nint index, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged {
			if (elements is null || length == 0) {
				return collection.Span;
			} else if (collection.Length == 0) {
				return new ReadOnlySpan<TElement>(elements, length);
			}
			return InsertKernel<TElement>(collection.Span, index, elements, length);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		[CLSCompliant(false)]
		public static unsafe ReadOnlySpan<TElement> Insert<TElement>(this Span<TElement> collection, nint index, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged {
			if (elements is null || length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return new ReadOnlySpan<TElement>(elements, length);
			}
			return InsertKernel<TElement>(collection, index, elements, length);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		[CLSCompliant(false)]
		public static unsafe ReadOnlySpan<TElement> Insert<TElement>(this ReadOnlySpan<TElement> collection, nint index, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged {
			if (elements is null || length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return new ReadOnlySpan<TElement>(elements, length);
			}
			return InsertKernel<TElement>(collection, index, elements, length);
		}
		#endregion

		#region Insert(Collection, nint, Sequence)
		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Insert<TElement, TResult, TEnumerator>([AllowNull] this IInsert<TElement, TResult> collection, nint index, [AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> where TResult : IInsert<TElement, TResult> => collection is not null ? collection.Insert(index, elements) : (TResult)collection;
		#endregion

		#region Insert(Collection, nint, String)
		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Insert<TResult>([AllowNull] this IInsert<Char, TResult> collection, nint index, [AllowNull] String elements) where TResult : IInsert<Char, TResult> => collection is not null ? collection.Insert(index, elements) : (TResult)collection;

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and inserted elements.</returns>
		public static ReadOnlyMemory<Char> Insert([AllowNull] this String collection, nint index, [AllowNull] String elements) {
			if (elements is null || elements.Length == 0) {
				return collection.AsMemory();
			} else if (collection is null || collection.Length == 0) {
				return elements.AsMemory();
			}
			return InsertKernel<Char>(collection, index, elements);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and inserted elements.</returns>
		public static ReadOnlyMemory<Char> Insert([AllowNull] this Char[] collection, nint index, [AllowNull] String elements) {
			if (elements is null || elements.Length == 0) {
				return collection.AsMemory();
			} else if (collection is null || collection.Length == 0) {
				return elements.AsMemory();
			}
			return InsertKernel<Char>(collection, index, elements);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and inserted elements.</returns>
		public static ReadOnlyMemory<Char> Insert(this Memory<Char> collection, nint index, [AllowNull] String elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements.AsMemory();
			}
			return InsertKernel<Char>(collection.Span, index, elements);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and inserted elements.</returns>
		public static ReadOnlyMemory<Char> Insert(this ReadOnlyMemory<Char> collection, nint index, [AllowNull] String elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements.AsMemory();
			}
			return InsertKernel<Char>(collection.Span, index, elements);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and inserted elements.</returns>
		public static ReadOnlySpan<Char> Insert(this Span<Char> collection, nint index, [AllowNull] String elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements.AsSpan();
			}
			return InsertKernel<Char>(collection, index, elements);
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and inserted elements.</returns>
		public static ReadOnlySpan<Char> Insert(this ReadOnlySpan<Char> collection, nint index, [AllowNull] String elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements.AsSpan();
			}
			return InsertKernel<Char>(collection, index, elements);
		}
		#endregion

		[return: NotNull]
		public static TElement[] InsertKernel<TElement>(ReadOnlySpan<TElement> collection, nint index, [DisallowNull] TElement element) {
			TElement[] array = new TElement[collection.Length + 1];
			collection.Slice(0, index).CopyTo(array);
			array[index] = element;
			collection.Slice(index).CopyTo(array.Slice(index + 1));
			return array;
		}

		[return: NotNull]
		public static TElement[] InsertKernel<TElement>(ReadOnlySpan<TElement> collection, nint index, ReadOnlySpan<TElement> elements) {
			TElement[] array = new TElement[collection.Length + elements.Length];
			collection.Slice(0, index).CopyTo(array);
			elements.CopyTo(array.Slice(index));
			collection.Slice(index).CopyTo(array.Slice(index + elements.Length));
			return array;
		}

		[return: NotNull]
		public static unsafe TElement[] InsertKernel<TElement>(ReadOnlySpan<TElement> collection, nint index, [DisallowNull] TElement* elements, Int32 length) where TElement : unmanaged {
			TElement[] array = new TElement[collection.Length + length];
			collection.Slice(0, index).CopyTo(array);
			Pointer.Copy(elements, length, array.Slice(index));
			collection.Slice(index).CopyTo(array.Slice(index + length));
			return array;
		}
	}
}
