namespace Langly.DataStructures

open Langly

/// <summary>
/// Represents an array of contiguous elements.
/// </summary>
type array< ^element> = Array< ^element>

/// <summary>
/// Represents any possible data structure.
/// </summary>
type datastructure< ^element, ^self, ^enumerator when ^self :> DataStructure< ^element, ^self, ^enumerator> and ^enumerator :> IEnumerator< ^element>> = DataStructure< ^element, ^self, ^enumerator>

/// <summary>
/// Indicates the <see cref="Filter{TIndex, TElement}"/> that should be set up for the data structure.
/// </summary>
type filter = Filter

/// <summary>
/// Represents the base node type of any associative data structure.
/// </summary>
type node< ^index, ^element, ^self when ^self :> Node< ^index, ^element, ^self>> = Node< ^index, ^element, ^self>
