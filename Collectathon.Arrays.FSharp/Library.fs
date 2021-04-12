namespace Collectathon.Arrays

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
    /// Converts the array to a bounded array.
    /// </summary>
    let bounded (array:'t array) = BoundedArray<'t>.op_Implicit(array)

    /// <summary>
    /// Converts the array to a dynamic array.
    /// </summary>
    let dynamic (array:'t array) = DynamicArray<'t>.op_Implicit(array)
