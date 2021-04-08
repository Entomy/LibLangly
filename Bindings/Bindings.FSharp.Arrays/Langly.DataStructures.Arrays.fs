namespace Langly.DataStructures.Arrays

open Langly.DataStructures.Arrays

/// <summary>
/// Represents a bounded array, a type of flexible array who's size can not grow above its capacity, but can freely resize below that capacity.
/// </summary>
type bounded<'t> = BoundedArray<'t>

/// <summary>
/// Represents a dynamic array, a type of flexible array who's capacity can freely grow and shrink.
/// </summary>
type dynamic<'t> = DynamicArray<'t>

[<AutoOpen>]
module Functions =
    /// <summary>
    /// Converts the <paramref name="array"/> to a <see cref="BoundedArray{TElement}"/>.
    /// </summary>
    /// <param name="array">The <see cref="Array"/> to convert.</param>
    let inline bounded (array:^t array) = bounded< ^t>.op_Implicit(array)

    /// <summary>
    /// Converts the <paramref name="array"/> to a <see cref="DynamicArray{TElement}"/>.
    /// </summary>
    /// <param name="array">The <see cref="Array"/> to convert.</param>
    let inline dynamic (array:^t array) = dynamic< ^t>.op_Implicit(array)
