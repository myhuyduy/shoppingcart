namespace ShoppingCart.AuthenticationHandler
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Security.Principal;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;

    using ShoppingCart.Interfaces;

    /// <summary>
    /// The basic authentication handler.
    /// </summary>
    public class BasicAuthenticationHandler : DelegatingHandler
    {
        /// <summary>
        /// The authentication service.
        /// </summary>
        private readonly IAuthenticationService authenticationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicAuthenticationHandler"/> class.
        /// </summary>
        /// <param name="authenticationService">
        /// The authentication service.
        /// </param>
        public BasicAuthenticationHandler(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        /// <summary>
        /// The send async.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// The response
        /// </returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            AuthenticationHeaderValue authHeader = request.Headers.Authorization;
            if (authHeader == null || authHeader.Scheme != "Basic")
            {
                return Unauthorised(request);
            }

            // Expected username:password in base64
            byte[] credentialBytes = Convert.FromBase64String(authHeader.Parameter);
            string[] credentials = Encoding.ASCII.GetString(credentialBytes).Split(':');

            if (!this.authenticationService.Authenticate(credentials[0], credentials[1]))
            {
                return Unauthorised(request);
            }

            // Create identity
            var identity = new GenericIdentity(credentials[0], "Basic");
            HttpContext.Current.User = new GenericPrincipal(identity, null);

            // Call the inner handler.
            return base.SendAsync(request, cancellationToken);
        }

        /// <summary>
        /// The unauthorized.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The response.
        /// </returns>
        private static Task<HttpResponseMessage> Unauthorised(HttpRequestMessage request)
        {
            var response = request.CreateResponse(HttpStatusCode.Unauthorized);

            response.Headers.Add("WWW-Authenticate", "Basic");

            TaskCompletionSource<HttpResponseMessage> task = new TaskCompletionSource<HttpResponseMessage>();
            task.SetResult(response);

            return task.Task;
        }
    }
}