using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace LamianFunction;

public class Function1
{
    private readonly ILogger<Function1> _logger;

    public Function1(ILogger<Function1> logger)
    {
        _logger = logger;
    }


    //  http://localhost:7246/api/ReturnHtmlPage
    // https://functer2025ab.azurewebsites.net/api/ReturnHtmlPage

    [Function("ReturnHtmlPage")]
    public static IActionResult Run(
      //   [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
 [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req,

         ExecutionContext context,
         ILogger log)
    {
        log.LogInformation("HTML page request received.");

         
 

        string htmlContent = """

              <html>
            <head>
                <title>Welcome</title>
            </head>
            <body>
                <h1>Hello from Azure Function!</h1>
                <p>This is a static HTML page served by an Azure Function.</p>
            </body>
            </html>


            """;
        return new ContentResult
        {
            Content = htmlContent,
            ContentType = "text/html",
            StatusCode = 200
        };
    }
}
