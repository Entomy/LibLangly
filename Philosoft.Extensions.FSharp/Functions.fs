namespace System

open System
open System.Runtime.InteropServices
open System.Traits
open Bindings

[<AutoOpen>]
module Functions =
    [<assembly: CLSCompliant(true)>]
    [<assembly: ComVisible(true)>]
    [<assembly: Guid("C3C9244D-E1A2-4CF1-988C-12CAE90F6F35")>]
    do ()

    /// <summary>
    /// Adds the elements to the collection.
    /// </summary>
    /// <param name="collection">This collection.</param>
    /// <param name="elements">The elements to add.</param>
    /// <returns>If the add occurred successfully, returns an object containing the original and added elements; otherwise, <see langword="null"/>.</returns>
    /// <remarks>
    /// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
    /// </remarks>
    let inline add (elements:^elements)(collection:^collection):^result = Add<TraitExtensions, ^collection, ^elements, ^result> collection elements

    /// <summary>
    /// The maximum capacity of the collection.
    /// </summary>
    let inline capacity (collection:#ICapacity):nativeint = collection.Capacity

    /// <summary>
    /// Clears the <paramref name="collection"/>.
    /// </summary>
    /// <param name="collection">This collection.</param>
    let inline clear (collection:^collection):^result = Clear<TraitExtensions, ^collection, ^result> collection

    //TODO: concat operator?

    /// <summary>
    /// Determines whether this collection contains the specified <paramref name="element"/>.
    /// </summary>
    /// <param name="collection">This collection.</param>
    /// <param name="element">The element to attempt to find.</param>
    /// <returns><see langword="true"/> if <paramref name="element"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
    let inline contains (element:^element)(collection:^collection):bool = Contains<TraitExtensions, ^collection, ^element> collection element

    /// <summary>
    /// Determines whether this collection contains all of the specified <paramref name="elements"/>.
    /// </summary>
    /// <param name="collection">This collection.</param>
    /// <param name="elements">The elements to attempt to find.</param>
    /// <returns><see langword="true"/> if all of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
    let inline containsAll (elements:^element array)(collection:^collection):bool = ContainsAll<TraitExtensions, ^collection, ^element> collection elements

    /// <summary>
    /// Determines whether this collection contains any of the specified <paramref name="elements"/>.
    /// </summary>
    /// <param name="collection">This collection.</param>
    /// <param name="elements">The elements to attempt to find.</param>
    /// <returns><see langword="true"/> if any of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
    let inline containsAny (elements:^element array)(collection:^collection):bool = ContainsAny<TraitExtensions, ^collection, ^element> collection elements

    //TODO: copyto

    /// <summary>
    /// Gets the number of elements contained in the collection.
    /// </summary>
    let inline count (collection:#ICount):nativeint = collection.Count

    //TODO: ensureLoaded

    /// <summary>
    /// Folds the collection into a single element as described by <paramref name="func"/>.
    /// </summary>
    /// <param name="collection">This collection</param>
    /// <param name="func">The function describing the folding operation. This is a magma.</param>
    /// <param name="identity">The identity value for <paramref name="func"/>.</param>
    /// <returns>A single element after folding the entire collection.</returns>
    /// <remarks>
    /// <para><paramref name="func"/> is a magma, so associativity like left-fold and right-fold are completely irrelevant.</para>
    /// <para><paramref name="identity"/> is required as a start point for the fold. It needs to be the identity of the <paramref name="func"/> to function properly. For example, the identity of addition is <c>0</c>, and the identity of multiplication is <c>1</c>. Without an appropriate identity, the results will be wrong.</para>
    /// </remarks>
    let inline fold (func:^element -> ^element -> ^element)(identity:^element)(collection:^collection):^element = Fold<TraitExtensions, ^collection, ^func, ^element> (collection) (Func< ^element, ^element, ^element>(func)) (identity)

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
    let inline indexOfFirst (element:^element)(collection:^collection):nativeint = IndexOfFirst<TraitExtensions, ^collection, ^element> collection element

    /// <summary>
    /// Searches for the specified <paramref name="element"/> and returns the index of its last occurrence.
    /// </summary>
    /// <typeparam name="TElement">The type of the elements of the collection.</typeparam>
    /// <param name="collection">The collection to search.</param>
    /// <param name="element">The item to locate in the collection.</param>
    /// <returns>The index of the last occurrence of <paramref name="element"/> in <paramref name="collection"/>, if found; otherwise, <c>-1</c>.</returns>
    let inline indexOfLast (element:^element)(collection:^collection):nativeint = IndexOfLast<TraitExtensions, ^collection, ^element> collection element    

    /// <summary>
    /// Insert an element into the collection at the specified index.
    /// </summary>
    /// <typeparam name="TElement">The type of the elements.</typeparam>
    /// <typeparam name="TResult">The resulting type; often itself.</typeparam>
    /// <param name="collection">This collection.</param>
    /// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
    /// <param name="element">The element to insert.</param>
    /// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
    let inline insert (index:^index)(element:^element)(collection:^collection):^result = Insert<TraitExtensions, ^collection, ^index, ^element, ^result> collection index element

    //TODO: load

    //TODO: map

    /// <summary>
    /// Count all occurrences of <paramref name="element"/> in the collection.
    /// </summary>
    /// <param name="collection">This collection.</param>
    /// <param name="element">The element to count.</param>
    /// <returns>The amount of occurrences found.</returns>
    let inline occurrences (element:^element)(collection:^collection):nativeint = Occurrences<TraitExtensions, ^collection, ^element> collection element

    //TODO: parse

    /// <summary>
    /// Peeks at an element from the <paramref name="stream"/>.
    /// </summary>
    /// <param name="stream">This stream.</param>
    /// <returns>The value that was peeked.</returns>
    let inline peek (stream:#IPeek< ^e, ^r>):^e =
        let element:^e ref = ref Unchecked.defaultof< ^e>
        stream.Peek(element) |> ignore
        !element

    //TODO: postpend

    //TODO: prepend

    /// <summary>
    /// Reads an element from the <paramref name="stream"/>.
    /// </summary>
    /// <param name="stream">This stream.</param>
    /// <returns>The value that was read.</returns>
    let inline read (stream:#IRead< ^e, ^r>):^e =
        let element:^e ref = ref Unchecked.defaultof< ^e>
        stream.Read(element) |> ignore
        !element

    /// <summary>
    /// Can this be read from?
    /// </summary>
    /// <remarks>
    /// This is a state indicator. Of course an <see cref="IRead{TElement, TError}"/> can be read from, but that doesn't mean it can always be read from. Rather, this being <see langword="true"/> indicates the type can currently be read from.
    /// </remarks>
    let inline readable (stream:#IRead<_, _>):bool = stream.Readable

    //TODO: remove

    //TODO: removeFirst

    //TODO: removeLast

    /// <summary>
    /// Replaces all instances of <paramref name="search"/> with <paramref name="replace"/>.
    /// </summary>
    /// <param name="collection">This collection.</param>
    /// <param name="search">The element to replace.</param>
    /// <param name="replace">The element to use instead.</param>
    /// <returns>The result of replacing <paramref name="search"/> with <paramref name="replace"/>.</returns>
    let inline replace (search:^search)(replace:^replace)(collection:^collection):^result = Replace<TraitExtensions, ^collection, ^search, ^replace, ^result> collection search replace

    /// <summary>
    /// Resize the collection to the specified <paramref name="capacity"/>.
    /// </summary>
    /// <param name="collection">This collection.</param>
    /// <param name="capacity">The new capacity of the collection.</param>
    let inline resize (capacity:nativeint)(collection:^collection):^result = Resize<TraitExtensions, ^collection, ^result> collection capacity
    
    /// <summary>
    /// Seeks to the <paramref name="offset"/>.
    /// </summary>
    /// <param name="stream">This stream.</param>
    /// <param name="offset">The offset of <typeparamref name="TElement"/> from the current position to seek to.</param>
    let inline seek (offset:nativeint)(stream:^stream):^result = Seek<TraitExtensions, ^stream, ^result> stream offset

    /// <summary>
    /// Can this be seeked?
    /// </summary>
    /// <remarks>
    /// This is a state indicator. Of course an <see cref="ISeek{TElement, TError}"/> can be seeked, but that doesn't mean it can always be seeked. Rather, this being <see langword="true"/> indicates the type can currently be seeked.
    /// </remarks>
    let inline seekable (stream:#ISeek<_, _>):bool = stream.Seekable

    /// <summary>
    /// Shifts the collection left by <paramref name="amount"/>.
    /// </summary>
    /// <param name="collection">This collection.</param>
    /// <param name="amount">The amount of positions to shift.</param>
    /// <returns>A <typeparamref name="TResult"/> after the elements are shifted.</returns>
    let inline ( <<< ) (collection:^collection)(amount:nativeint) = ShiftLeft<TraitExtensions, ^collection, ^result> collection amount

    /// <summary>
    /// Shifts the collection right by <paramref name="amount"/>.
    /// </summary>
    /// <param name="collection">This collection.</param>
    /// <param name="amount">The amount of positions to shift.</param>
    /// <returns>A <typeparamref name="TResult"/> after the elements are shifted.</returns>
    let inline ( >>> ) (collection:^collection)(amount:nativeint) = ShiftRight<TraitExtensions, ^collection, ^result> collection amount

    /// <summary>
    /// Shrinks the collection by a computed factor.
    /// </summary>
    let inline shrink (collection:^collection):^result = Shrink<TraitExtensions, ^collection, ^result> collection

    type ISlice<'result> with
        member this.GetSlice(start:int option, stop:int option):'result =
            let str = nativeint (defaultArg start 0)
            let stp = nativeint (defaultArg stop (int this.Count))
            this.Slice(str, stp - str)

    /// <summary>
    /// Writes the <paramref name="elements"/> to the <paramref name="stream"/>.
    /// </summary>
    /// <typeparam name="TElement">The type of the element to write.</typeparam>
    /// <typeparam name="TResult">The type of the error object.</typeparam>
    /// <param name="stream">The stream to write to.</param>
    /// <param name="elements">The elements to write.</param>
    /// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
    let inline write (elements:^elements)(stream:^stream):^result = Write<TraitExtensions, ^stream, ^elements, ^result> stream elements

    /// <summary>
    /// Can this be written to?
    /// </summary>
    /// <remarks>
    /// This is a state indicator. Of course an <see cref="IWrite{TElement, TResult}"/> can be written to, but that doesn't mean it can always be written to. Rather, this being <see langword="true"/> indicates the type can currently be written to.
    /// </remarks>
    let inline writable (stream:#IWrite<_, _>):bool = stream.Writable
