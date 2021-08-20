namespace Collectathon

/// <summary>
/// Represents a singly-linked list.
/// </summary>
type singlylinked<'t> = SinglyLinkedList<'t>

/// <summary>
/// Represents an associative singly-linked list.
/// </summary>
type singlylinked<'i, 'e> = SinglyLinkedList<'i, 'e>

[<AutoOpen>]
module Functions =
    /// <summary>
    /// Converts the <paramref name="sequence"/> into a <see cref="SinglyLinkedList{TElement}"/>.
    /// </summary>
    let inline sll (sequence:^a seq) =
        let result = SinglyLinkedList< ^a>()
        for item in sequence do
            result.Add item
        result
