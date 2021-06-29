// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if !NETSTANDARD2_1_OR_GREATER && !NETCOREAPP
namespace System.Diagnostics.CodeAnalysis {
	/// <summary>Specifies that an output may be null even if the corresponding type disallows it.</summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue, Inherited = false)]
	public sealed class MaybeNullAttribute : Attribute { }
}
#else
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

[assembly: TypeForwardedTo(typeof(MaybeNullAttribute))]
#endif
