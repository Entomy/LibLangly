namespace Langly

open System
open Bindings

[<AutoOpen>]
module Functions =
    /// <summary>
    /// Adds the elements to the collection.
    /// </summary>
    /// <param name="collection">This collection.</param>
    /// <param name="element">The element to add.</param>
    /// <returns>If the add occurred successfully, returns an object containing the original and added elements; otherwise, <see langword="null"/>.</returns>
    /// <remarks>
    /// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
    /// </remarks>
    let inline add (collection:^collection)(elements:^elements):^result = Add<TraitExtensions, ^collection, ^elements, ^result> collection elements

    /// <summary>
    /// The maximum capacity of the collection.
    /// </summary>
    let inline capacity (collection:#ICapacity):nativeint = collection.Capacity

    /// <summary>
    /// Clears the <paramref name="collection"/>.
    /// </summary>
    /// <param name="collection">This collection.</param>
    let inline clear (collection:^collection):^result = Clear<TraitExtensions, ^collection, ^result> collection

    //TODO: concat

    /// <summary>
    /// Determines whether this collection contains the specified <paramref name="element"/>.
    /// </summary>
    /// <param name="collection">This collection.</param>
    /// <param name="element">The element to attempt to find.</param>
    /// <returns><see langword="true"/> if <paramref name="element"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
    let inline contains (collection:^collection)(element:^element):bool = Contains<TraitExtensions, ^collection, ^element> collection element

    /// <summary>
    /// Determines whether this collection contains any of the specified <paramref name="elements"/>.
    /// </summary>
    /// <param name="collection">This collection.</param>
    /// <param name="elements">The elements to attempt to find.</param>
    /// <returns><see langword="true"/> if any of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
    let inline containsAny (collection:^collection)(elements:^elements):bool = ContainsAny<TraitExtensions, ^collection, ^elements> collection elements

    /// <summary>
    /// Determines whether this collection contains all of the specified <paramref name="elements"/>.
    /// </summary>
    /// <param name="collection">This collection.</param>
    /// <param name="elements">The elements to attempt to find.</param>
    /// <returns><see langword="true"/> if all of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
    let inline containsAll (collection:^collection)(elements:^elements):bool = ContainsAll<TraitExtensions, ^collection, ^elements> collection elements

    /// <summary>
    /// Gets the number of elements contained in the collection.
    /// </summary>
    let inline count (collection:#ICount):nativeint = collection.Count

    /// <summary>
    /// Folds the collection into a single element as described by <paramref name="func"/>.
    /// </summary>
    /// <param name="func">The function describing the folding operation. This is a magma.</param>
    /// <param name="identity">The identity value for <paramref name="func"/>.</param>
    /// <returns>A single element after folding the entire collection.</returns>
    /// <remarks>
    /// <para><paramref name="func"/> is a magma, so associativity like left-fold and right-fold are completely irrelevant.</para>
    /// <para><paramref name="identity"/> is required as a start point for the fold. It needs to be the identity of the <paramref name="func"/> to function properly. For example, the identity of addition is <c>0</c>, and the identity of multiplication is <c>1</c>. Without an appropriate identity, the results will be wrong.</para>
    /// </remarks>
    let inline fold (collection:^collection)(func:^element -> ^element -> ^element)(identity:^element):^element = Fold<TraitExtensions, ^collection, ^func, ^element> (collection) (Func< ^element, ^element, ^element>(func)) (identity)

    /// <summary>
    /// Grows the collection by a computed factor.
    /// </summary>
    let inline grow (collection:^collection):^result = Grow<TraitExtensions, ^collection, ^result> collection

    /// <summary>
    /// Searches for the specified <paramref name="element"/> and returns the index of its first occurrence.
    /// </summary>
    /// <param name="collection">The collection to search.</param>
    /// <param name="element">The item to locate in the collection.</param>
    /// <returns>The index of the first occurrence of <paramref name="element"/> in <paramref name="collection"/>, if found; otherwise, <c>-1</c>.</returns>
    let inline indexOfFirst (collection:^collection)(element:^element):nativeint = IndexOfFirst<TraitExtensions, ^collection, ^element> collection element

    /// <summary>
    /// Searches for the specified <paramref name="element"/> and returns the index of its last occurrence.
    /// </summary>
    /// <typeparam name="TElement">The type of the elements of the collection.</typeparam>
    /// <param name="collection">The collection to search.</param>
    /// <param name="element">The item to locate in the collection.</param>
    /// <returns>The index of the last occurrence of <paramref name="element"/> in <paramref name="collection"/>, if found; otherwise, <c>-1</c>.</returns>
    let inline indexOfLast (collection:^collection)(element:^element):nativeint = IndexOfLast<TraitExtensions, ^collection, ^element> collection element    

    /// <summary>
    /// Insert an element into the collection at the specified index.
    /// </summary>
    /// <typeparam name="TElement">The type of the elements.</typeparam>
    /// <typeparam name="TResult">The resulting type; often itself.</typeparam>
    /// <param name="collection">This collection.</param>
    /// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
    /// <param name="element">The element to insert.</param>
    /// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
    let inline insert (collection:^collection)(index:^index)(element:^element):^result = Insert<TraitExtensions, ^collection, ^index, ^element, ^result> collection index element

    //TODO: map

    /// <summary>
    /// Count all occurrences of <paramref name="element"/> in the collection.
    /// </summary>
    /// <param name="element">The element to count.</param>
    /// <returns>The amount of occurrences found.</returns>
    let inline occurrences (collection:^collection)(element:^element):nativeint = Occurrences<TraitExtensions, ^collection, ^element> collection element

    //TODO: peek

    //TODO: pop

    /// <summary>
    /// Pushes the elements onto the top of this object.
    /// </summary>
    /// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
    /// <typeparam name="TResult">The resulting type; often itself.</typeparam>
    /// <param name="collection">This collection.</param>
    /// <param name="elements">The elements to push.</param>
    /// <returns>The result of pushing the <paramref name="elements"/> onto this object.</returns>
    let inline push (collection:^collection)(elements:^elements):^result = Push<TraitExtensions, ^collection, ^elements, ^result> collection elements

    //TODO: read

    /// <summary>
    /// Can this be read from?
    /// </summary>
    /// <remarks>
    /// This is a state indicator. Of course an <see cref="IRead{TElement, TError}"/> can be read from, but that doesn't mean it can always be read from. Rather, this being <see langword="true"/> indicates the type can currently be read from.
    /// </remarks>
    let inline readable (stream:#IRead<_, _>):bool = stream.Readable

    /// <summary>
    /// Replaces all instances of <paramref name="search"/> with <paramref name="replace"/>.
    /// </summary>
    /// <param name="collection">This collection.</param>
    /// <param name="search">The element to replace.</param>
    /// <param name="replace">The element to use instead.</param>
    /// <returns>The result of replacing <paramref name="search"/> with <paramref name="replace"/>.</returns>
    let inline replace (collection:^collection)(search:^search)(replace:^replace):^result = Replace<TraitExtensions, ^collection, ^search, ^replace, ^result> collection search replace

    /// <summary>
    /// Resize the collection to the specified <paramref name="capacity"/>.
    /// </summary>
    /// <param name="capacity">The new capacity of the collection.</param>
    let inline resize (collection:^collection)(capacity:nativeint):^result = Resize<TraitExtensions, ^collection, ^result> collection capacity
    
    /// <summary>
    /// Seeks to the <paramref name="offset"/>.
    /// </summary>
    /// <param name="offset">The offset of <typeparamref name="TElement"/> from the current position to seek to.</param>
    let inline seek (collection:^collection)(offset:nativeint):^result = Seek<TraitExtensions, ^collection, ^result> collection offset

    /// <summary>
    /// Can this be seeked?
    /// </summary>
    /// <remarks>
    /// This is a state indicator. Of course an <see cref="ISeek{TElement, TError}"/> can be seeked, but that doesn't mean it can always be seeked. Rather, this being <see langword="true"/> indicates the type can currently be seeked.
    /// </remarks>
    let inline seekable (stream:#ISeek<_, _>):bool = stream.Seekable

    //TODO: shiftLeft

    //TODO: shiftRight

    /// <summary>
    /// Shrinks the collection by a computed factor.
    /// </summary>
    let inline shrink (collection:^collection):^result = Shrink<TraitExtensions, ^collection, ^result> collection

    /// <summary>
    /// Writes the <paramref name="elements"/> to the <paramref name="stream"/>.
    /// </summary>
    /// <typeparam name="TElement">The type of the element to write.</typeparam>
    /// <typeparam name="TResult">The type of the error object.</typeparam>
    /// <param name="stream">The stream to write to.</param>
    /// <param name="elements">The elements to write.</param>
    /// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
    let inline write (collection:^collection)(elements:^elements):^result = Write<TraitExtensions, ^collection, ^elements, ^result> collection elements

    /// <summary>
    /// Can this be written to?
    /// </summary>
    /// <remarks>
    /// This is a state indicator. Of course an <see cref="IWrite{TElement, TResult}"/> can be written to, but that doesn't mean it can always be written to. Rather, this being <see langword="true"/> indicates the type can currently be written to.
    /// </remarks>
    let inline writable (collection:#IWrite<_, _>):bool = collection.Writable
