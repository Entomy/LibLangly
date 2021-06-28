# Queues

Queues are a common collection type with many uses. Unlike most collections libraries **Collectathon** does not provide an explicit `Queue<>` type, instead opting to allow any compatible data structure as a queue. If a type has `Enqueue` and `Dequeue` methods, congratulations, you've got a queue.

Honestly though, that's not very interesting, so instead, let's discuss the things that make these queues so special.

## General Additions

The majority, and ideally all, queues will support a `Requeue` extension as well. Due to a limitation in C#, this is only possible if the type has the `IQueue<TElement>` concept, rather than the individual traits. In practice, this limitation shouldn't typically be an issue.

## Delegate Specializations

**Philosoft** provides, together with the standard extensions, a number of queue specializations for queues of delegates. For delegates of `Action`, `Func`, and `Predicate`, an `Invoke` extension is provided, which behaves like the `Invoke` for that delegate. It dequeues that delegate, invoking it, passing any additional arguments, and returning the result if there is one.