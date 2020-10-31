# Streamy

## Streams

.NET [Streams](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream) are tragically flawed in some not obvious ways. **Streamy** intends to fix these flaws by introducing a completely new Stream API with its own design. The public API isn't radically different, although there are some modernizations. Most of the redesign has to do with internals, especially striving for a much higher degree of modularity.

## Serialization

How serialization in .NET is done is [tragically flawed](https://owasp.org/www-project-top-ten/2017/A8_2017-Insecure_Deserialization). I'll write up an article about this at some point and link to it here. **Streamy**'s serialization framework is meant to supplant .NET's by building on the years of security research and awareness of how potentially dangerous this technology is.
