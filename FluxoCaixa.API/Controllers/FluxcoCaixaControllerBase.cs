using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FluxoCaixa.API.Controllers
{
    public class FluxcoCaixaControllerBase : ControllerBase
    {
        public static ActionResult Result(HttpStatusCode statusCode, string reason) => new ContentResult
        {
            StatusCode = (int)statusCode,
            Content = $"Status Code: {(int)statusCode}; {statusCode}; {reason}",
            ContentType = "text/plain",
        };
    }
}
