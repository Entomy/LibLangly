namespace Langly

type internal meanEnum = Mean

/// <summary>
/// Indicates the type of mean to calculate.
/// </summary>
[<Struct>]
type Mean =
    /// <summary>
    /// The sum of the members divided by the number of members.
    /// </summary>
    | Arithmetic

    /// <summary>
    /// The square root of the product of the members
    /// </summary>
    | Geometric

/// <summary>
/// Indicates the type of mean to calculate.
/// </summary>
type mean = Mean
