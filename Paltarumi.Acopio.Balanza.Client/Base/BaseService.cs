using Newtonsoft.Json;
using Paltarumi.Acopio.Dto.Base;
using System.Net.Http.Json;

namespace Paltarumi.Acopio.Balanza.Client.Base
{
    public class BaseService
    {
        protected string BaseUrl { get; }
        protected Dictionary<string, string> Headers { get; }
        protected virtual string ApiController { get; } = null!;

        public BaseService(ServiceOptions options)
        {
            BaseUrl = options?.BaseUrl ?? string.Empty;
            Headers = options?.Headers ?? new Dictionary<string, string>();
        }

        protected async Task<ResponseDto>? Get(string resource = "")
        {
            try
            {
                return await GetEntity<ResponseDto>(resource)!;
            }
            catch (Exception ex)
            {
                var response = GetErrorResult(ex);
                return response;
            }
        }

        protected async Task<ResponseDto<TResponse>>? Get<TResponse>(string resource = "")
        {
            try
            {
                return await GetEntity<ResponseDto<TResponse>>(resource)!;
            }
            catch (Exception ex)
            {
                var response = GetErrorResult<TResponse>(ex);
                return response;
            }
        }

        protected async Task<TResponse>? GetEntity<TResponse>(string resource = "")
        {
            var http = GetHttpClient();
            var response = await http.GetStringAsync($"{BaseUrl}{ApiController}{resource}");
            var resultado = JsonConvert.DeserializeObject<TResponse>(response!);
            return resultado!;
        }

        protected async Task<ResponseDto>? Post<TRequest>(string resource = "", TRequest? body = default)
        {
            try
            {
                return await PostEntity<TRequest, ResponseDto>(resource, body)!;
            }
            catch (Exception ex)
            {
                var response = GetErrorResult(ex);
                return response;
            }
        }

        protected async Task<ResponseDto<TResponse>>? Post<TRequest, TResponse>(string resource = "", TRequest? body = default)
        {
            try
            {
                return await PostEntity<TRequest, ResponseDto<TResponse>>(resource, body)!;
            }
            catch (Exception ex)
            {
                var response = GetErrorResult<TResponse>(ex);
                return response;
            }
        }

        protected async Task<TResponse>? PostEntity<TRequest, TResponse>(string resource = "", TRequest? body = default)
        {
            var http = GetHttpClient();
            var payload = JsonConvert.SerializeObject(body);
            var response = await http.PostAsJsonAsync($"{BaseUrl}{ApiController}{resource}", payload);
            var responseString = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<TResponse>(responseString!);
            return resultado!;
        }

        protected async Task<ResponseDto>? Put<TRequest>(string resource = "", TRequest? body = default)
        {
            try
            {
                return await PutEntity<TRequest, ResponseDto>(resource, body)!;
            }
            catch (Exception ex)
            {
                var response = GetErrorResult(ex);
                return response;
            }
        }

        protected async Task<ResponseDto<TResponse>>? Put<TRequest, TResponse>(string resource = "", TRequest? body = default)
        {
            try
            {
                return await PutEntity<TRequest, ResponseDto<TResponse>>(resource, body)!;
            }
            catch (Exception ex)
            {
                var response = GetErrorResult<TResponse>(ex);
                return response;
            }
        }

        protected async Task<TResponse>? PutEntity<TRequest, TResponse>(string resource = "", TRequest? body = default)
        {
            var http = GetHttpClient();
            var payload = JsonConvert.SerializeObject(body);
            var response = await http.PutAsJsonAsync($"{BaseUrl}{ApiController}{resource}", payload);
            var responseString = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<TResponse>(responseString!);
            return resultado!;
        }

        protected async Task<ResponseDto>? Patch<TRequest>(string resource = "", HttpContent? body = default)
        {
            try
            {
                return await PatchEntity<TRequest, ResponseDto>(resource, body)!;
            }
            catch (Exception ex)
            {
                var response = GetErrorResult(ex);
                return response;
            }
        }

        protected async Task<ResponseDto<TResponse>>? Patch<TRequest, TResponse>(string resource = "", HttpContent? body = default)
        {
            try
            {
                return await PatchEntity<TRequest, ResponseDto<TResponse>>(resource, body)!;
            }
            catch (Exception ex)
            {
                var response = GetErrorResult<TResponse>(ex);
                return response;
            }
        }

        protected async Task<TResponse>? PatchEntity<TRequest, TResponse>(string resource = "", HttpContent? body = default)
        {
            var http = GetHttpClient();
            var response = await http.PatchAsync($"{BaseUrl}{ApiController}{resource}", body);
            var responseString = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<TResponse>(responseString!);
            return resultado!;
        }

        protected async Task<ResponseDto>? Delete(string resource = "")
        {
            try
            {
                return await DeleteEntity<ResponseDto>()!;
            }
            catch (Exception ex)
            {
                var response = GetErrorResult(ex);
                return response;
            }
        }

        protected async Task<ResponseDto<TResponse>>? Delete<TResponse>(string resource = "")
        {
            try
            {
                return await DeleteEntity<ResponseDto<TResponse>>()!;
            }
            catch (Exception ex)
            {
                var response = GetErrorResult<TResponse>(ex);
                return response;
            }
        }

        protected async Task<TResponse>? DeleteEntity<TResponse>(string resource = "")
        {
            var http = GetHttpClient();
            var response = await http.DeleteAsync($"{BaseUrl}{ApiController}{resource}");
            var responseString = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<TResponse>(responseString!);
            return resultado!;
        }

        private HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient();

            if (httpClient.DefaultRequestHeaders != null && Headers != null)
            {
                Headers.ToList().ForEach(h =>
                {
                    httpClient.DefaultRequestHeaders.Add(h.Key, h.Value);
                });
            }

            return httpClient;
        }

        private ResponseDto GetErrorResult(Exception ex)
            => new ResponseDto { Messages = GetMessages(ex) };

        private ResponseDto<T> GetErrorResult<T>(Exception ex)
            => new ResponseDto<T> { Messages = GetMessages(ex) };

        private List<ApplicationMessageDto> GetMessages(Exception ex)
        {
            return new List<ApplicationMessageDto>
            {
                new ApplicationMessageDto
                {
                    Message = ex.Message.Contains("connection attempt failed") ? "Error de conexión" : $"{ex.Message}{Environment.NewLine}{ex.StackTrace}",
                    MessageType = ApplicationMessageType.Error
                }
            };
        }
    }
}
