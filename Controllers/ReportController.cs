using System.Linq;
using System.Net;
using System.Security.Claims;
using System.ServiceModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Ormawa.Controllers
{
    public class ReportController : AlanJuden.MvcReportViewer.ReportController
    {
        private readonly IConfiguration _configuration;

        public ReportController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Configuration
        protected override ICredentials NetworkCredentials => new NetworkCredential(_configuration["ReportServer:User"], _configuration["ReportServer:Password"]);
        protected override HttpClientCredentialType ClientCredentialType => HttpClientCredentialType.Basic;
        protected override string ReportServerUrl => _configuration["ReportServer:Url"];
        #endregion

    }
}