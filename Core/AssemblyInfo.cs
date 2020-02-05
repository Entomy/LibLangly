using System;
using System.Runtime.InteropServices;
#if !NETSTANDARD2_0
using System.Runtime.CompilerServices;
using System.Text;
#endif

[assembly: CLSCompliant(true)]
[assembly: ComVisible(true)]
[assembly: Guid("172c2989-b693-42eb-8aea-b5c58d751186")]

#if !NETSTANDARD2_0
[assembly: TypeForwardedTo(typeof(Rune))]
#endif