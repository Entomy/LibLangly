namespace Collectathon.Arrays

open System
open System.Runtime.InteropServices

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
    [<assembly: CLSCompliant(true)>]
    [<assembly: ComVisible(true)>]
    [<assembly: Guid("577A3143-08EC-4491-894D-88CA0341EC9D")>]
    do ()
    
    /// <summary>
    /// Converts the array to a bounded array.
    /// </summary>
    let bounded (array:'t array) = BoundedArray<'t>.op_Implicit(array)

    /// <summary>
    /// Converts the array to a dynamic array.
    /// </summary>
    let dynamic (array:'t array) = DynamicArray<'t>.op_Implicit(array)
