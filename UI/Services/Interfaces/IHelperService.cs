namespace UI.Services.Interfaces
{
    public interface IHelperService
    {
        Task HandleHttpResponse(HttpResponseMessage response);
    }
}