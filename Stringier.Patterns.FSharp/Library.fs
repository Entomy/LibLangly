namespace Stringier.Patterns

/// <summary>
/// Represents a textual pattern.
/// </summary>
type pattern = Pattern

[<AutoOpen>]
module Function =
    /// <summary>
    /// Creates a <see cref="Pattern"/> exactly matching the <paramref name="literal"/>.
    /// </summary>
    /// <param name="literal">The literal to match.</param>
    let inline p (literal:^a):^b = ((^a or ^b) : (static member op_Implicit : ^a -> ^b)(literal))

    /// <summary>
    /// Check for the end of the line.
    /// </summary>
    let endOfLine = Pattern.EndOfLine

    /// <summary>
    /// Check for the end of the source.
    /// </summary>
    let endOfSource = Pattern.EndOfSource

    /// <summary>
    /// Creates a pattern representing a line comment introduced by the <paramref name="start"/> and ended by the <paramref name="stop"/> delimiters.
    /// </summary>
    /// <param name="start">The token delimiting the start of a block comment.</param>
    /// <param name="stop">The token delimiting the stop of a block comment.</param>
    let blockComment (start) (stop) = Pattern.BlockComment(start, stop)

    /// <summary>
    /// Creates a pattern representing a line comment introduced by the delimiter.
    /// </summary>
    /// <param name="delimiter">The token delimiting the start of a line comment.</param>
    let lineComment (delimiter) = Pattern.LineComment(delimiter)

    /// <summary>
    /// Parses the <paramref name="source"/>.
    /// </summary>
    /// <param name="source">The source to parse.</param>
    /// <param name="location">The location within the source to begin parsing, updated to the end of the match.</param>
    /// <param name="pattern">The pattern to parse.</param>
    let parse (source:string) (location) (pattern:pattern) = pattern.Parse(source, location)

    /// <summary>
    /// Parses the <paramref name="source"/>.
    /// </summary>
    /// <param name="source">The source to parse.</param>
    /// <param name="location">The location within the source to begin parsing, updated to the end of the match.</param>
    /// <param name="trace">The object to trace the steps through the pattern graph in.</param>
    /// <param name="pattern">The pattern to parse.</param>
    let parseDbg (source:string) (location) (trace) (pattern:pattern) = pattern.Parse(source, location, trace)

    /// <summary>
    /// Creates a pattern representing a string literal contained by the <paramref name="delimiter"/>.
    /// </summary>
    /// <param name="delimiter">The token delimiting the start and end of the literal.</param>
    let stringLiteral (delimiter) = Pattern.StringLiteral(delimiter)

    /// <summary>
    /// Creates a pattern representing a string literal contained by the <paramref name="delimiter"/>.
    /// </summary>
    /// <param name="delimiter">The token delimiting the start and end of the literal.</param>
    /// <param name="escape">The token escaping the delimiter.</param>
    let stringLiteralEsc (delimiter) (escape) = Pattern.StringLiteral(delimiter, escape)
