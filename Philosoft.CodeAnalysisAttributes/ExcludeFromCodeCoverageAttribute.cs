// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if !NETSTANDARD2_0_OR_GREATER && !NETCOREAPP
namespace System.Diagnostics.CodeAnalysis {
	/// <summary>
	/// Specifies that the attributed code should be excluded from code coverage information.
	/// </summary>
	/// <remarks>
	/// Placing this attribute on a class or a structure excludes all the members of that class or structure from the collection of code coverage information.
	/// </remarks>
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Event, Inherited = false, AllowMultiple = false)]
	public sealed class ExcludeFromCodeCoverageAttribute : Attribute {
		/// <summary>
		/// Initializes a new instance of the <see cref="ExcludeFromCodeCoverageAttribute"/> class.
		/// </summary>
		public ExcludeFromCodeCoverageAttribute() { }

		/// <summary>Gets or sets the justification for excluding the member from code coverage.</summary>
		public String? Justification { get; set; }
	}
}
#else
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

[assembly: TypeForwardedTo(typeof(ExcludeFromCodeCoverageAttribute))]
#endif
