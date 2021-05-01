namespace Collectathon

open System
open System.Runtime.InteropServices
open Collectathon

/// <summary>
/// Represents a filter, a psuedostructure which helps a proper data structure to behave differently.
/// </summary>
type filter<'i, 'e> = Filter<'i, 'e>

[<AutoOpen>]
module Functions =
    [<assembly: CLSCompliant(false)>]
    [<assembly: ComVisible(false)>]
    [<assembly: Guid("8D94C334-AF68-46B6-B0FA-4F0A3BC0D560")>]
    do ()
