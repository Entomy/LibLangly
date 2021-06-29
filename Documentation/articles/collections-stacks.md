# Stacks

Stacks are a common collection type with many uses. Unlike most collections libraries **Collectathon** does not provide an explicit `Stack<>` type, instead opting to allow any compatible data structure as a stack. If a type has `Push` and `Pop` methods, congratulations, you've got a stack.

Honestly though, that's not very interesting, so instead, let's discuss the things that make these stacks so special.

## Math Specializations

Inside of the **Numbersome** libraries are extensions for stacks when they are of numeric types. Got a stack of `Double`? You'll see tons of additional operations that perform stack math, based on what operations `Math` from the standard library has.

This is applied across all numeric types. Arithmetic operators are given their full name. Otherwise, the name and behavior is copied from `Math` or `MathF`. There is a limitation however: the return type must be compatible with the type of elements in the stack. If this is not the case, the operation will not be supported.