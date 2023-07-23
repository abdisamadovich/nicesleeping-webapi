using System.Net;

namespace NicesleepingShop.Domain.Exception;

public class NotFoundException : WebException
{
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.NotFound;

    public string TitleMessage { get;protected set; } =string.Empty;
}
