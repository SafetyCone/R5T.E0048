using System;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0133;

using R5T.E0048.Contexts.N001;

using Instances = R5T.E0048.Instances;


namespace System
{
    public static class IHasCodeFileContextExtensions
    {
        public static async Task WriteCompilation(this IHasCodeFileContext hasContext,
            CompilationRequirements<CompilationUnitSyntax> compilationRequirements,
            string compilationUnitLocalNamespaceName)
        {
            var context = hasContext.CodeFileContext;
            var compilationUnit = compilationRequirements.Node;

            // Add the compilation requirements's using namespace declarations to the compilation.
            compilationUnit = compilationUnit.AddUsings(
                compilationRequirements.NamespaceNames);

            compilationUnit = compilationUnit.AddUsings(
                compilationRequirements.NameAliases);

            // The format (block and order) the compilation's using declarations.
            compilationUnit = await context.UsingDirectivesFormatter.FormatUsingDirectives(
                compilationUnit,
                compilationUnitLocalNamespaceName);

            // Now actually write the compilation.
            await compilationUnit.WriteToFile(context.CodeFilePath);

            // Add the compilation requirements's project references to the code file context's projects.
            // Get all recursive project references of the project.
            // For each compilation requirement project reference, check if it's already in the recursive references of the project.
            // If not, add the project reference.
            foreach (var projectFilePath in context.ProjectFilePaths)
            {
                await Instances.ProjectReferencesOperator.EnsureHasProjectReferencesInRecursiveReferences(
                    projectFilePath,
                    compilationRequirements.ProjectReferenceFilePaths,
                    context.VisualStudioProjectFileOperator,
                    context.VisualStudioProjectFileReferencesProvider);
            }

            // Run Olympia functionality to add all recursive project reference dependencies to the code file context's solutions.
            foreach (var solutionFilePath in context.SolutionFilePaths)
            {
                await context.VisualStudioSolutionFileOperator.EnsureHasAllDependencyProjectReferences(
                    solutionFilePath,
                    compilationRequirements.ProjectReferenceFilePaths,
                    context.StringlyTypedPathOperator);
            }
        }

        /// <summary>
        /// Uses the <see cref="R5T.B0002.X001.NamespaceNames.NoNamespacesNamespaceName"/> value for the compilation unit local namespace name.
        /// </summary>
        public static Task WriteCompilation(this IHasCodeFileContext hasContext,
            CompilationRequirements<CompilationUnitSyntax> compilationRequirements)
        {
            return hasContext.WriteCompilation(
                compilationRequirements,
                Instances.NamespaceName.NoNamespacesNamespaceName());
        }
    }
}
