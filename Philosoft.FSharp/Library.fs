namespace Philosoft

open Bindings
open System

[<AutoOpen>]
module Functions =
    /// <summary>
    /// Adds the elements into the collection.
    /// </summary>
    /// <param name="collection">This collection.</param>
    /// <param name="elements">The elements to add to the collection.</param>
    /// <typeparam name="TElement">The type of elements in the collection.</typeparam>
    /// <remarks>
    /// The behavior of this operation is collection dependent, and no particular location in the collection should be assumed.
    /// </remarks>
    let inline add (elements) (collection) =
        Add<Extensions, _, _> collection elements
        collection

    /// <summary>
    /// Clears all items from the collection.
    /// </summary>
    /// <param name="collection">This collection.</param>
    let inline clear (collection) =
        Clear<Extensions, _> collection
        collection

    /// <summary>
    /// Creates a new object that is a copy of the current instance.
    /// </summary>
    /// <param name="collection">This collection.</param>
    /// <returns>A new object that is a copy of this instance.</returns>
    /// <remarks>
    /// <para>The resulting clone must be of the same type as, or compatible with, the original instance.</para>
    /// <para>An implementation of <see cref="ICloneable{TSelf}.Clone"/> can perform either a deep copy or a shallow copy. In a deep copy, all objects are duplicated; in a shallow copy, only the top-level objects are duplicated and the lower levels contain references. Because callers of <see cref="ICloneable{TSelf}.Clone"/> cannot depend on the method performing a predictable cloning operation, we recommend that <see cref="ICloneable{TSelf}"/> not be implemented in public APIs.</para>
    /// <para>See <see cref="Object.MemberwiseClone"/> for more information on cloning, deep versus shallow copies, and examples.</para>
    /// </remarks>
    let inline clone (collection) = Clone<Extensions, _, _> collection

    /// <summary>
    /// Determines whether this collection contains a specific <paramref name="element"/>.
    /// </summary>
    /// <param name="collection">This collection.</param>
    /// <param name="element">The object to locate in the collection.</param>
    /// <returns><see langword="true"/> if <paramref name="element"/> is found in the collection; otherwise, <see langword="false"/>.</returns>
    let inline contains (elements) (collection) = Contains<Extensions, _, _> collection elements

    /// <summary>
    /// Removes and returns the element from the beginning of the collection.
    /// </summary>
    /// <param name="collection">This collection.</param>
    /// <returns>The element that is removed from the beginning of the collection.</returns>
    /// <exception cref="NullReferenceException">Thrown if <paramref name="collection"/> is <see langword="null"/>.</exception>
    let inline dequeue (collection) = Dequeue<Extensions, _, _> collection

    /// <summary>
    /// Adds the elements to the end of the collection.
    /// </summary>
    /// <param name="collection">This collection.</param>
    /// <param name="elements">The elements to add to the collection.</param>
    let inline enqueue (elements) (collection) =
        Enqueue<Extensions, _, _> collection elements
        collection

    /// <summary>
    /// Folds the collection into a single element as described by the <paramref name="func"/>.
    /// </summary>
    /// <param name="func">The function describing the folding operation. This is a magma.</param>
    /// <param name="identity">The identity value for <paramref name="func"/>.</param>
    /// <returns>A single element after folding the entire collection.</returns>
    /// <remarks>
    /// <para><paramref name="func"/> is a magma, so associativity like left-fold and right-fold are completely irrelevant.</para>
    /// <para><paramref name="identity"/> is required as a start point for the fold. It needs to be the identity of the <paramref name="func"/> to function properly. For example, the identity of addition is <c>0</c>, and the identity of multiplication is <c>1</c>. Without an appropriate identity, the results will be wrong.</para>
    /// </remarks>
    let inline fold (func) (identity) (collection) = Fold<Extensions, _, _, _> (collection) (Func<_, _, _>(func)) (identity)

    /// <summary>
    /// Applies the <paramref name="func"/> to each element of the <paramref name="collection"/>.
    /// </summary>
    /// <param name="collection">This collection.</param>
    /// <param name="func">The <see cref="Func{T, TResult}"/> to apply to each element.</param>
    /// <remarks>
    /// This is a mutating operation. It mutates <paramref name="collection"/> rather than constructing a new collection for the result. This is done for two reasons. First is that we can't generalize <see cref="Map{TElement}(IIndexable{TElement}, Func{TElement, TElement})"/> like this while also allowing arbitrary collections to be constructed. Second is performance, as mutating in-place is substantially more efficient. <see cref="Philosoft"/> is not a pure functional programming library, it just takes inspiration in the form of more practical application of many functional principals.
    /// </remarks>
    let inline map (func) (collection) =
        Map<Extensions, _, _> (collection) (Func<_, _>(func))
        collection

    /// <summary>
    /// Count all occurrences of <paramref name="element"/> in the collection.
    /// </summary>
    /// <param name="element">The element to count.</param>
    /// <returns>The amount of occurrences found.</returns>
    let inline occurrences (elements) (collection) = Occurrences<Extensions, _, _> collection elements

    /// <summary>
    /// Removes and returns the element at from top of the collection.
    /// </summary>
    /// <param name="collection">This collection.</param>
    /// <returns>The element removed from the top of the collection.</returns>
    /// <exception cref="NullReferenceException">Thrown if <paramref name="collection"/> is <see langword="null"/>.</exception>
    let inline pop (collection) = Pop<Extensions, _, _> collection

    /// <summary>
    /// Inserts the elements at the top of the collection.
    /// </summary>
    /// <param name="collection">This collection.</param>
    /// <param name="elements">The element to push onto the collection.</param>
    let inline push (elements) (collection) =
        Push<Extensions, _, _> collection elements
        collection

    /// <summary>
    /// Removes all instances of the <paramref name="elements"/> from the collection.
    /// </summary>
    /// <param name="collection">This collection.</param>
    /// <param name="elements">The elements to remove from the collection.</param>
    let inline remove (elements) (collection) =
        Remove<Extensions, _, _> collection elements
        collection
