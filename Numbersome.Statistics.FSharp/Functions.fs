namespace Numbersome

open System
open System.Runtime.InteropServices
open Numbersome
open Bindings

[<AutoOpen>]
module Functions =
    [<assembly: CLSCompliant(false)>]
    [<assembly: ComVisible(false)>]
    [<assembly: Guid("7E3A07AC-9942-490A-A8BA-1B4E6253D986")>]
    do ()

    /// <summary>
    /// Averages the <paramref name="values"/>.
    /// </summary>
    /// <param name="values">The values to find the mean of.</param>
    /// <returns>The mean of the <paramref name="values"/>.</returns>
    let inline arithmeticMean (values:^values):^result = ArithmeticMean<StatisticExtensions, ^values, ^result> values

    /// <summary>
    /// Averages the <paramref name="values"/>.
    /// </summary>
    /// <param name="values">The values to find the mean of.</param>
    /// <returns>The mean of the <paramref name="values"/>.</returns>
    let inline geometricMean (values:^values):^result = GeometricMean<StatisticsExtensions, ^values, ^result> values

    /// <summary>
    /// Finds the maximum of the <paramref name="values"/>.
    /// </summary>
    /// <param name="values">The values to find the maximum of.</param>
    /// <returns>The maximum of the <paramref name="values"/>.</returns>
    let inline max (values:^values):^result = Max<StatisticsExtensions, ^values, ^result> values

    /// <summary>
    /// Finds the minimum of the <paramref name="values"/>.
    /// </summary>
    /// <param name="values">The values to find the minimum of.</param>
    /// <returns>The minimum of the <paramref name="values"/>.</returns>
    let inline min (values:^values):^result = Min<StatisticsExtensions, ^values, ^result> values

    /// <summary>
    /// Finds the mode of the <paramref name="values"/>.
    /// </summary>
    /// <param name="values">The values to find the mode of.</param>
    /// <returns>The mode of the <paramref name="values"/>.</returns>
    let inline mode (values:^values):^result = Mode<StatisticsExtensions, ^values, ^result> values
