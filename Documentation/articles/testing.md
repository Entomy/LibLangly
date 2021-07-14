# Testing

Your testing framework generally isn't something you give too much thought to. But what if a framework you depend on ceases to be developed? Okay, obviously the community will step in. But more realistically and to the same point, what if a framework doesn't adopt the necessary features to test things introduced _several years ago_. It's happened numerous times, and leaves developers writing awkward unit tests to get around limitations in various frameworks. Alternatively, developers write massive amount of test extenders to kludge necessary behavior into a specific framework. Do you know where all these extenders are, and which frameworks they cover? Do you know which framework has which limitations? Do you know what requirements your product is going to have and will it fit in those limitations? ***Should it?***

With the rise of test-first development strategies like TDD, it's become increasingly ridiculous for your testing framework to dictate anything about your code. And yet, because of the concessions we have to make for the frameworks, this is a very real phenomenon.

## The Problem

From all this, we can piece together a few key issues driving the problem:

* Testing frameworks make assumptions about your code: either kludge or conform.
* Testing frameworks aren't extensible by design: testing new complex types requires learning new API's. Kludges like new static classes hamper discoverability.
* Extensions to testing frameworks are tied to test discoverers and test runners.
* Frameworks that claim to deal with these issues introduces drastically different styles of testing that require relearning your approach.
* Frameworks that claim to deal with these issues introduces extensions onto the instance being tested, polluting IntelliSense and convoluting what belongs to whom. Is a given method an extension method within the library, or one from the test framework? What happens if these names collide?

Most of the problems stem from conflation of the test discoverer, test runner, and test framework. The discoverer and runner probably should be tied together. Does the framework?

Furthermore, when trying to address these concerns I learned of another issue: some frameworks like [xUnit](https://xunit.net/) make it difficult to test some of your code, because they provide their own implementations for things! What? No!

## The Solution

When digging through the test protocol .NET uses, it was clear nothing required the test framework to be tied to the test discoverer or test runner. I'm not 100% certain if the test discoverer and test runner have to be tied together, but it's fine if they are. So, if a test framework was developed with _no_ dependency on the other two components, we can start to address these issues. [`Philosoft.Testing`](https://www.nuget.org/packages?q=Philosoft.Testing) does exactly this!

To use the framework, simply include the `System.Traits.Testing` namespace, and derive your test class from `Tests`. Testing is done through fluent-style assertions, which enables the framework to provide you with _only_ the relevant assertions for the type you're working with. You can easily see what the framework is doing, and don't have to mess around with the framework converting types behind your back. Now you have access to an `Assert` property within your test methods.

`Assert` provides an extensible source for assertions. Originally, I thought providing some overloads of `Assert()` would be fine. Imagine Samuel Jackson saying: It was not fine. When writing an extender to support testing Roslyn Analyzers with a much friendlier approach, the problem became clear: we can't provide a good experience for extension methods on `Test` to handle new situations. Providing an `Assert` property and having extenders operate off the associated type works though. So, setting up an assertion looks like the follow:

# [C#](#tab/cs)

~~~~csharp
[Theory]
public void TestMethod<T>(T actual, String expected) =>
	Assert.That(actual);
~~~~

# [VB](#tab/vb)

~~~~visualbasic
<Theory>
Public Sub TestMethod(Of T)(actual As T, expected As String)
	Assert.That(actual)
End Sub
~~~~

# [F#](#tab/fs)
~~~~fsharp
[<Theory>]
let testMethod<'t> (actual:'t) (expected:string) =
	Assert.That(actual) |> ignore
~~~~

***

From there you call assertions off the type returned by `.That(actual)`, which, thanks to IntelliSense and strong typing, only shows relevant assertions for whatever `T` is in your case. Of course, you don't have to write generic test methods, but this is a generic example. Let's do a simple assertion.

# [C#](#tab/cs)

~~~~csharp
[Theory]
public void TestMethod<T>(T actual, String expected) =>
	Assert.That(actual.ToString()).Equals(expected);
~~~~

# [VB](#tab/vb)

~~~~visualbasic
<Theory>
Public Sub TestMethod(Of T)(actual As T, expected As String)
	Assert.That(actual.ToString()).Equals(expected)
End Sub
~~~~

# [F#](#tab/fs)

~~~~fsharp
[<Theory>]
let testMethod<'t> (actual:'t) (expected:string) =
	Assert.That(actual.ToString()).Equals(expected)
~~~~

***

This is exactly identical to `Assert.Equal(expected, actual.ToString())` or similar in other frameworks. However, because of how easily extensible the framework is, we can actually write our intentions even more clear:

# [C#](#tab/cs)

~~~~csharp
[Theory]
public void TestMethod<T>(T actual, String expected) =>
	Assert.That(actual).ToString(expected);
~~~~

# [VB](#tab/vb)

~~~~visualbasic
Public Sub TestMethod(Of T)(actual As T, expected As String)
	Assert.That(actual).ToString(expected)
End Sub
~~~~

# [F#](#tab/fs)

~~~~fsharp
[<Theory>]
let testMethod<'t> (actual:'t) (expected:string) =
	Assert.That(actual).ToString(expected)
~~~~

***

Now we can go even further. Let's say in our case, `T` is some collection which, when converted to a string has the same length as the collections element count: that is, there's no formatting. For example, let's say an incredibly inefficient BigNum which links together the digits. We could do full property testing easily, like follows:

# [C#](#tab/cs)

~~~~csharp
[Theory]
public void TestMethod(BadBigNum actual, String expected) =>
	Assert.That(actual)
		.Count(expected.Length)
		.ToString(expected);
~~~~

# [VB](#tab/vb)

~~~~visualbasic
<Theory>
Public Sub TestMethod(actual As BadBigNum, expected As String)
	Assert.That(actual)
		.Count(expected.Length)
		.ToString(expected)
End Sub
~~~~

# [F#](#tab/fs)

~~~~fsharp
[<Theory>]
let testMethod (actual:BadBigNum) (expected:String) =
	Assert.That(actual)
		.Count(expected.Length))
		.ToString(expected)
~~~~

Yup. It's that easy.

Keep in mind that while these examples use the [xUnit](https://xunit.net/) attributes, you're free to use whatever you want. No changes need to occur other than conforming to how the test discoverer finds its tests. Iteration setup/cleanup, global setup/cleanup, state management, anything outside of how the assertions occur are handled by the runner.

You may have worked with some test extensions in the past that need information about what test runner is being used. Maybe it was like the Roslyn Analyzers where you download a unique package to match your runner. Maybe you passed the runner in as a generic type parameter somewhere. You might be wondering where that's done here. It's not. At all. Does this use reflection to figure that out? Also no. Turns out, the runner doesn't care what the framework is doing.

No seriously. The way the VSTest protocol works, the runners just sit there running the tests the discoverer found, listening for exceptions in those tests. It doesn't care _what_ the exceptions are, just whether or not there are exceptions. This means that we can simply provide our own exceptions to use internally, with our own error formatters, and everything _just works_.

So let's revisit the problem and see if the issues are adequately handled:

> Testing frameworks make assumptions about your code: either kludge or conform.

If everything is extensible nothing needs to be assumed. The assertions possible are entirely dependent on what the type being tested has, and uses those features directly. Cases like [xUnit](https://xunit.net/) using its own definition of equality won't happen. Extensions could be provided to do this, but are not the default action.

> Testing frameworks aren't extensible by design: testing new complex types requires learning new API's. Kludges like new static classes hamper discoverability.

Everything is set up to handle extension methods. Other than a few key assertions which collide with methods in [`Object`](https://docs.microsoft.com/en-us/dotnet/api/system.object), all functionality is implemented as extensions. The design was specifically chosen to have IntelliSense help as much as possible, while also looking as familiar as possible.

> Extensions to testing frameworks are tied to test discoverers and test runners.

Nothing about the test framework is tied to test discovered or test runners in any capacity.

> Frameworks that claim to deal with these issues introduces drastically different styles of testing that require relearning your approach.

Names of asserters were specifically chosen to look as similar as possible to those used in [MSTest](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest), [NUnit](https://nunit.org/), and [xUnit](https://xunit.net/). Similarly, the names of the asserters are as close as possible to what the method or property being tested is called. Convenient extensions are helpful, but in no way required, like what you saw with `ToString()`. The entire framework uses an `Assert.That(actual).<<Assertion>>` style approach. There's no superfluous methods.

> Frameworks that claim to deal with these issues introduces extensions onto the instance being tested, polluting IntelliSense and convoluting what belongs to whom. Is a given method an extension method within the library, or one from the test framework? What happens if these names collide?

This is precisely why the framework requires the actual instance being tested to be encapsulated by `Assert.That(actual)`. I understand why it's appealing in small examples and demos, but in large projects it becomes an absolute nightmare.
