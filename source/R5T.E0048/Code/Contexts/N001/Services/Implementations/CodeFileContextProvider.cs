using System;

using R5T.Lombardy;

using R5T.D0078;
using R5T.D0079;
using R5T.D0083;
using R5T.D0116;
using R5T.T0064;


namespace R5T.E0048.Contexts.N001
{
    [ServiceImplementationMarker]
    public class CodeFileContextProvider : ICodeFileContextProvider, IServiceImplementation
    {
        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; }
        public IUsingDirectivesFormatter UsingDirectivesFormatter { get; }
        public IVisualStudioProjectFileOperator VisualStudioProjectFileOperator { get; set; }
        public IVisualStudioProjectFileReferencesProvider VisualStudioProjectFileReferencesProvider { get; set; }
        public IVisualStudioSolutionFileOperator VisualStudioSolutionFileOperator { get; set; }


        public CodeFileContextProvider(
            IStringlyTypedPathOperator stringlyTypedPathOperator,
            IUsingDirectivesFormatter usingDirectivesFormatter,
            IVisualStudioProjectFileOperator visualStudioProjectFileOperator,
            IVisualStudioProjectFileReferencesProvider visualStudioProjectFileReferencesProvider,
            IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator)
        {
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
            this.UsingDirectivesFormatter = usingDirectivesFormatter;
            this.VisualStudioProjectFileOperator = visualStudioProjectFileOperator;
            this.VisualStudioProjectFileReferencesProvider = visualStudioProjectFileReferencesProvider;
            this.VisualStudioSolutionFileOperator = visualStudioSolutionFileOperator;
        }
    }
}
