namespace Collectathon

/// <summary>
/// Represents a bounded array, a type of flexible array whos' size can not grow above its capacity, but can freely resize below that capacity.
/// </summary>
type boundedarray<'t> = BoundedArray<'t>

/// <summary>
/// Represents an associative bounded array, a type of flexible array who's size can not grow above its capacity, but can freely resize below that capacity.
/// </summary>
type boundedarray<'i, 'e> = BoundedArray<'i, 'e>

/// <summary>
/// Represents a dynamic array, a type of flexible array who's capacity can freely grow and shrink.
/// </summary>
type dynamicarray<'t> = DynamicArray<'t>

/// <summary>
/// Represents an associative dynamic array, a type of flexible array who's capacity can freely grow and shrink.
/// </summary>
type dynamicarray<'i, 'e> = DynamicArray<'i, 'e>

[<AutoOpen>]
module Functions =
    /// <summary>
    /// Converts the <paramref name="array"/> into a <see cref="BoundedArray{TElement}"/>.
    /// </summary>
    let inline bnd (array:^a array) = BoundedArray< ^a>(array)

    /// <summary>
    /// Converts the <paramref name="array"/> into a <see cref="DynamicArray{TElement}"/>.
    /// </summary>
    let inline dyn (array:^a array) = DynamicArray< ^a>(array)
