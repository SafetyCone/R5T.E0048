using System;
using System.Threading.Tasks;

using R5T.E0048.Contexts.N001;


namespace System
{
    public static class ICodeFileContextProviderExtensions
    {
        public static Task<CodeFileContext> GetCodeFileContext(this ICodeFileContextProvider codeFileContextProvider,
            string codeFilePath,
            string[] projectFilePaths,
            string[] solutionFilePaths)
        {
            var output = new CodeFileContext
            {
                StringlyTypedPathOperator = codeFileContextProvider.StringlyTypedPathOperator,
                UsingDirectivesFormatter = codeFileContextProvider.UsingDirectivesFormatter,
                VisualStudioProjectFileOperator = codeFileContextProvider.VisualStudioProjectFileOperator,
                VisualStudioProjectFileReferencesProvider = codeFileContextProvider.VisualStudioProjectFileReferencesProvider,
                VisualStudioSolutionFileOperator = codeFileContextProvider.VisualStudioSolutionFileOperator,

                CodeFilePath = codeFilePath,
                ProjectFilePaths = projectFilePaths,
                SolutionFilePaths = solutionFilePaths,
            };

            return Task.FromResult(output);
        }

        public static Task<CodeFileContext> GetCodeFileContext(this ICodeFileContextProvider codeFileContextProvider,
            string codeFilePath)
        {
            var output = codeFileContextProvider.GetCodeFileContext(
                codeFilePath,
                Array.Empty<string>(),
                Array.Empty<string>());

            return output;
        }
    }
}
