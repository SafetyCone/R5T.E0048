using System;


namespace R5T.E0048
{
    public class ProjectReferencesOperator : IProjectReferencesOperator
    {
        #region Infrastructure

        public static ProjectReferencesOperator Instance { get; } = new();

        private ProjectReferencesOperator()
        {
        }

        #endregion
    }
}
