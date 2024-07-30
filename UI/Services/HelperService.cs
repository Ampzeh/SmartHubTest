using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using Blazored.Toast.Services;
using UI.Services.Interfaces;

namespace UI.Services
{
    public class HelperService : IHelperService
    {
        private readonly IToastService _toastService;

        public HelperService(IToastService toastService)
        {
            _toastService = toastService;
        }

        public async Task HandleHttpResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                _toastService.ShowSuccess(await response.Content.ReadAsStringAsync());
                return;
            }

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                var problem = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                _toastService.ShowError(problem.Detail);
                return;
            }

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var problem = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();
                _toastService.ShowError(problem.Title);
                return;
            }
        }
    }
}
