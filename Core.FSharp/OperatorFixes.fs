#if NETSTANDARD2_0
namespace Stringier

// Because of #2340 (https://github.com/dotnet/runtime/issues/2340), Rune originally did not implement IComparable. This was a mistake. These fixes allow comparison operators to still work with Rune. Hopefully these do not interfere with the intended behavior of the operator. In case they do, this module must be manually opened.
#nowarn "86"

module OperatorFixes =

    let inline (<)(left:^a)(right:^b) = (^a : (member CompareTo : ^b -> int) (left, right)) < 0

    let inline (<=)(left:^a)(right:^b) = (^a : (member CompareTo : ^b -> int) (left, right)) <= 0

    let inline (>)(left:^a)(right:^b) = (^a : (member CompareTo : ^b -> int) (left, right)) > 0

    let inline (>=)(left:^a)(right:^b) = (^a : (member CompareTo : ^b -> int) (left, right)) >= 0

#endif 