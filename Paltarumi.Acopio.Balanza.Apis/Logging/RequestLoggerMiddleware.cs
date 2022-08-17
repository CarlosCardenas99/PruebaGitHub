using Microsoft.AspNetCore.Http.Extensions;
using System.Text;

namespace Paltarumi.Acopio.Balanza.Apis.Logging
{
    public class RequestLoggerMiddleware : IMiddleware
    {
        private readonly ILogger<RequestLoggerMiddleware> _logger;

        public RequestLoggerMiddleware(ILogger<RequestLoggerMiddleware> logger)
            => _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var displayUrl = context.Request.GetDisplayUrl();
            var originalBodyStream = context.Response.Body;

            if (!displayUrl.Contains("/api/"))
            {
                await next(context);
                return;
            }

            try
            {
                _logger.LogInformation("********************** REQUEST BEGIN **********************");

                context.Request.EnableBuffering();

                if (context.Request.Body.CanRead)
                {
                    context.Request.Body.Position = 0;

                    using var requestReader = new StreamReader(
                        context.Request.Body,
                        Encoding.UTF8,
                        detectEncodingFromByteOrderMarks: false,
                        bufferSize: 512,
                        leaveOpen: true
                    );

                    var requestBody = await requestReader.ReadToEndAsync();

                    context.Request.Body.Position = 0;

                    _logger.LogInformation($"Request Url: {context.Request.GetDisplayUrl()}");
                    if (!string.IsNullOrEmpty(requestBody))
                        _logger.LogInformation($"Request Body:{Environment.NewLine}{requestBody}");
                }

                using var memoryStream = new MemoryStream();
                context.Response.Body = memoryStream;

                await next(context);

                memoryStream.Position = 0;
                var reader = new StreamReader(memoryStream);
                var responseBody = await reader.ReadToEndAsync();

                memoryStream.Position = 0;
                await memoryStream.CopyToAsync(originalBodyStream);

                if (!string.IsNullOrEmpty(responseBody))
                    _logger.LogInformation($"Response Body:{Environment.NewLine}{responseBody}");
                _logger.LogInformation("*********************** REQUEST END ***********************");
            }
            finally
            {
                context.Response.Body = originalBodyStream;
            }
        }
    }
}
