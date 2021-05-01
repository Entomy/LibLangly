namespace Numbersome

open System
open System.Runtime.InteropServices
open Numbersome

/// <summary>
/// Represents a counter, a structure to assist with sophisticated counting operations.
/// </summary>
type counter<'e> = Counter<'e>

[<AutoOpen>]
module Functions =
    [<assembly: CLSCompliant(false)>]
    [<assembly: ComVisible(false)>]
    [<assembly: Guid("CAA38B3B-7CDE-48D2-A96E-3056A3D6925A")>]
    do ()

