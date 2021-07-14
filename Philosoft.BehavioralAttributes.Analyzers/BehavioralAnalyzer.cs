using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;

namespace System.Diagnostics.CodeAnalysis {
	/// <summary>
	/// Represents the Philosoft Behavioral Analyzers.
	/// </summary>
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public sealed class BehavioralAnalyzer : DiagnosticAnalyzer {
		/// <summary>
		/// Initializes a new <see cref="BehavioralAnalyzer"/>.
		/// </summary>
		public BehavioralAnalyzer() => SupportedDiagnostics = ImmutableArray.Create(
			new DiagnosticDescriptor(
				id: "BA00",
				title: "Handle or declare thrown exceptions",
				messageFormat: "'{0}' should be handled or declared as thrown.",
				category: "Behavioral",
				defaultSeverity: DiagnosticSeverity.Warning,
				isEnabledByDefault: true,
				description: "Exceptions that are thrown should be handled or declared, so callers know what to expect."),
			new DiagnosticDescriptor(
				id: "BA01",
				title: "Duplicate throws annotation",
				messageFormat: "'{0}' is already declared.",
				category: "Behavioral",
				defaultSeverity: DiagnosticSeverity.Warning,
				isEnabledByDefault: true,
				description: "Exception annotations shouldn't be declared multiple times."),
			new DiagnosticDescriptor(
				id: "BA02",
				title: "Redundant throws annotation",
				messageFormat: "'{0}' is reundant.",
				category: "Behavioral",
				defaultSeverity: DiagnosticSeverity.Warning,
				isEnabledByDefault: true,
				description: "Exceptions declared on an overridden method don't need to be redeclared."));

		/// <inheritdoc/>
		public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; }

		/// <inheritdoc/>
		public override void Initialize(AnalysisContext context) {
			context.EnableConcurrentExecution();
			context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
			context.RegisterSyntaxNodeAction(BA00, SyntaxKind.MethodDeclaration);
			context.RegisterSyntaxNodeAction(BA01, SyntaxKind.MethodDeclaration);
			context.RegisterSyntaxNodeAction(BA02, SyntaxKind.MethodDeclaration);
		}

		private void BA00(SyntaxNodeAnalysisContext context) { }

		private void BA01(SyntaxNodeAnalysisContext context) { }

		private void BA02(SyntaxNodeAnalysisContext context) { }
	}
}
