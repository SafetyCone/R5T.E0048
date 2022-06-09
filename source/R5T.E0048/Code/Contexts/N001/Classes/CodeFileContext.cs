using System;
using R5T.D0078;
using R5T.D0079;
using R5T.D0083;
using R5T.D0116;
using R5T.Lombardy;
using R5T.T0137;


namespace R5T.E0048.Contexts.N001
{
    [ContextImplementationMarker]
    public class CodeFileContext : ICodeFileContext, IContextImplementationMarker
    {
        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; set; }
        public IUsingDirectivesFormatter UsingDirectivesFormatter { get; set; }
        public IVisualStudioProjectFileOperator VisualStudioProjectFileOperator { get; set; }
        public IVisualStudioProjectFileReferencesProvider VisualStudioProjectFileReferencesProvider { get; set; }
        public IVisualStudioSolutionFileOperator VisualStudioSolutionFileOperator { get; set; }

        public string CodeFilePath { get; set; }
        public string[] ProjectFilePaths { get; set; }
        public string[] SolutionFilePaths { get; set; }



        ICodeFileContext IHasCodeFileContext.CodeFileContext => this;
    }
}
