// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if !NETSTANDARD2_1_OR_GREATER && !NETCOREAPP
namespace System.Diagnostics.CodeAnalysis {
	/// <summary>Applied to a method that will never return under any circumstance.</summary>
	[AttributeUsage(AttributeTargets.Method, Inherited = false)]
	public sealed class DoesNotReturnAttribute : Attribute { }
}
#else
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

[assembly: TypeForwardedTo(typeof(DoesNotReturnAttribute))]
#endif
