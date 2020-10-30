# Philosoft

**Philosoft** provides a rich [trait-oriented](https://dev.to/entomy/real-traits-in-c-4fpk) set of interfaces together with extension methods for them to enable [null-tolerance](https://dev.to/entomy/avoiding-nulls-with-extension-methods-3mkc). The idea is to help encourage robust and resilient code bases while keeping a common framework for talking about disparate types. Furthermore, You only need to implement a few key methods and get tons of additional functionality _for free_.

So how do you use it? When implementing a new type, pass all the traits into the interface implementation list just like you normally would with any interface, and while you don't explicitly have to, when implementing the required methods you _should_ implement them explicitly. In doing so, the [null-tolerant](https://dev.to/entomy/avoiding-nulls-with-extension-methods-3mkc) extension methods will be used, allowing null objects to be gracefully handled while still calling the implementations you provided.

> But explicit methods aren't available to derived types...

> But explicit methods aren't callable off the instance and have to use interfaces for all interactions

There's more counterarguments, I'm sure. **Philosoft** was designed around this. In fact, the design around this is how you get "free" implementations of various functionality. You ***really** should implement all the interface functionality explicitly. Extension methods don't just add in [null-tolerance](https://dev.to/entomy/avoiding-nulls-with-extension-methods-3mkc), they also provide a way of calling any default-implementation an interface might have, off the _instance_. You really do get all that additional functionality without having to change how you go about using the types you write.