using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace QualAnalyzer.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class PreemptiveCastValidator : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "CastCheck001";
        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(
            DiagnosticId,
            "Invalid cast target",
            "Type '{0}' cannot be cast to '{1}'. {2}",
            "Usage",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

        public override void Initialize(AnalysisContext context)
        {
            context.EnableConcurrentExecution();
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.NamedType);
        }

        private void AnalyzeSymbol(SymbolAnalysisContext context)
        {
            var namedType = (INamedTypeSymbol)context.Symbol;

            foreach (var attribute in namedType.GetAttributes())
            {
                if (attribute.AttributeClass?.Name == "CastCheckAttribute" &&
                    attribute.ConstructorArguments.Length >= 1)
                {
                    var targetTypeArg = attribute.ConstructorArguments[0];
                    var errorMessageArg = attribute.ConstructorArguments.Length > 1
                        ? attribute.ConstructorArguments[1].Value?.ToString()
                        : null;

                    if (targetTypeArg.Value is INamedTypeSymbol targetType)
                    {
                        if (!namedType.AllInterfaces.Contains(targetType) &&
                            !IsDerivedFrom(namedType, targetType))
                        {
                            var message = errorMessageArg ?? $"Type '{namedType.Name}' cannot be cast to '{targetType.Name}'.";
                            var diagnostic = Diagnostic.Create(Rule, namedType.Locations[0], namedType.Name, targetType.Name, message);
                            context.ReportDiagnostic(diagnostic);
                        }
                    }
                }
            }
        }

        private bool IsDerivedFrom(INamedTypeSymbol type, INamedTypeSymbol baseType)
        {
            var current = type.BaseType;
            while (current != null)
            {
                if (SymbolEqualityComparer.Default.Equals(current, baseType))
                    return true;
                current = current.BaseType;
            }
            return false;
        }
    }
}
