namespace Langly.DataStructures.Arrays

[<AutoOpen>]
module Functions =
    /// <summary>
    /// Casts the array to a <see cref="FixedArray{T}"/>.
    /// </summary>
    let fix<'a> (array:'a array) = FixedArray<'a>.op_Implicit(array)

    /// <summary>
    /// Casts the array to a <see cref="BoundedArray{T}"/>.
    /// </summary>
    let bnd<'a> (array:'a array) = BoundedArray<'a>.op_Implicit(array)

    /// <summary>
    /// Casts the array to a <see cref="DynamicArray{T}"/>.
    /// </summary>
    let dyn<'a> (array:'a array) = DynamicArray<'a>.op_Implicit(array)
