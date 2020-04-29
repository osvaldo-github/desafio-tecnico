namespace WebApi.UseCases.V1.ShowMeTheCode
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     The Customer Details.
    /// </summary>
    public sealed class ShowMeTheCodeResponse
    {
        private const string _linkGitHubProject = "https://github.com/osvaldo-github/desafio-tecnico";

        public ShowMeTheCodeResponse()
        {
            LinkGitHubProject = _linkGitHubProject;
        }

        /// <summary>
        ///     Gets LinkGitHubProject.
        /// </summary>
        [Required]
        public string LinkGitHubProject { get; }
    }
}
