using System;

using R5T.Lombardy;

using R5T.D0078;
using R5T.D0079;
using R5T.D0083;
using R5T.D0116;
using R5T.T0137;


namespace R5T.E0048.Contexts.N001
{
    [ContextDefinitionMarker]
    public interface ICodeFileContext : IHasCodeFileContext, IContextDefinitionMarker
    {
        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; }
        public IUsingDirectivesFormatter UsingDirectivesFormatter { get; }
        public IVisualStudioProjectFileOperator VisualStudioProjectFileOperator { get; }
        public IVisualStudioProjectFileReferencesProvider VisualStudioProjectFileReferencesProvider { get; }
        public IVisualStudioSolutionFileOperator VisualStudioSolutionFileOperator { get; }

        public string CodeFilePath { get; }
        public string[] ProjectFilePaths { get; }
        public string[] SolutionFilePaths { get; }
    }
}
