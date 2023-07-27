using System.Net;
namespace NicesleepingShop.Domain.Exception;

public abstract class ClientException : WebException
{
    public abstract HttpStatusCode StatusCode { get; }

    public abstract string TitleMessage { get; protected set; }
}
