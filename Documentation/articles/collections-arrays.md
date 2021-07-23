# Arrays

The standard [`Array`](https://docs.microsoft.com/en-us/dotnet/api/system.array) is pretty well designed. However, there are more complex situations where arrays are justified, but tricky to get right. **Collectathon** provides several options, including SQL-style bounded arrays and dynamically resizing arrays. In all cases, there are also associative varients.

Generally speaking, arrays are similar to lists, especially in functionality. It is very important to understand that their performance characteristics are radically different however. Arrays pack elements together contiguously, while lists scatter elements around, linking together the parts with pointers. This means arrays are very fast to traverse and randomly access elements of. Reads will always be very efficient. Writes are where you potentially get into problems. With the dynamically resized varient, writes are efficient until resizing occurrs. Resizes are extremely expensive and are best avoided. With the bounded varient writes are efficient but will eventually exceed capacity and throw an exception.

Arrays of any kind can be highly useful tools in your toolbox, but they are very niche.