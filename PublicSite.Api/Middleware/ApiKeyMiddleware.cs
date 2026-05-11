namespace PublicSite.Api.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string APIKEYHEADER = "X-API-KEY";

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IConfiguration configuration)
        {
            if (context.Request.Method == HttpMethods.Get)
            {
                await _next(context);
                return;
            }
            var path = context.Request.Path.Value?.ToLower();
            // Autoriser certains POST spécifiques
            if (context.Request.Method == HttpMethods.Post &&
                (
                    path == "/api/contact" ||
                    path == "/api/newsletter"
                ))
            {
                await _next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue(APIKEYHEADER, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key manquante");
                return;
            }

            var apiKey = configuration["ApiKey"];

            if (apiKey != null && !apiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key invalide");
                return;
            }

            await _next(context);
        }
    }
}
