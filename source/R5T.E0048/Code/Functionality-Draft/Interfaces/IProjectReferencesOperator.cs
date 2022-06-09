using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.D0079;
using R5T.D0083;

using R5T.T0132;


namespace R5T.E0048
{
    [DraftFunctionalityMarker]
    public interface IProjectReferencesOperator : IDraftFunctionalityMarker
    {
        public async Task EnsureHasProjectReferencesInRecursiveReferences(
            string projectFilePathToModify,
            IEnumerable<string> projectReferenceFilePaths,
            IVisualStudioProjectFileOperator visualStudioProjectFileOperator,
            IVisualStudioProjectFileReferencesProvider visualStudioProjectFileReferencesProvider)
        {
            var allRecursiveProjectReferences_Inclusive = await visualStudioProjectFileReferencesProvider.GetAllRecursiveProjectReferenceDependencies_Inclusive(
                projectFilePathToModify);

            await this.EnsureHasProjectReferencesInRecursiveReferences(
                projectFilePathToModify,
                projectReferenceFilePaths,
                allRecursiveProjectReferences_Inclusive,
                visualStudioProjectFileOperator);
        }

        public async Task EnsureHasProjectReferencesInRecursiveReferences(
            string projectFilePathToModify,
            IEnumerable<string> projectReferenceFilePaths,
            IEnumerable<string> allRecursiveProjectReferences_Inclusive,
            IVisualStudioProjectFileOperator visualStudioProjectFileOperator)
        {
            var projectReferenceFilePathsToAdd = projectReferenceFilePaths.Except(allRecursiveProjectReferences_Inclusive).Now();

            await visualStudioProjectFileOperator.AddProjectReferences(
                projectFilePathToModify,
                projectReferenceFilePathsToAdd);
        }
    }
}
