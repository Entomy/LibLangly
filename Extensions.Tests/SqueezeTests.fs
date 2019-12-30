namespace Tests.Extensions

open System
open Stringier.Extensions
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type SqueezeTests () =
    [<DataTestMethod>]
    [<DataRow("helo", "hello")>]
    [<DataRow("Leroy Jenkins", "Leeeeeeeerooooooooooyyyyyyyy Jeeeeeeeenkiiiiiiiiins")>]
    member _.``squeeze string`` (exp:string, src:string) =
        Assert.AreEqual(exp, squeeze src)