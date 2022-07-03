using Newtonsoft.Json;
using Paltarumi.Acopio.Dto.Base;
using System.Net.Http.Json;

namespace Paltarumi.Acopio.Client.Base
{
    public class BaseService
    {
        protected string BaseUrl { get; }
        protected Dictionary<string, string> Headers { get; }
        protected virtual string ApiController { get; } = null!;

        public BaseService(ServiceOptions options)
        {
            BaseUrl = options?.BaseUrl ?? String.Empty;
            Headers = options?.Headers ?? new Dictionary<string, string>();
        }

        protected IEnumerable<T>? ListGet<T>(string resource = "")
        {
            HttpClient http = GetHttpClient();

            string _json = http.GetStringAsync($"{BaseUrl}{ApiController}{resource}").Result;
            IEnumerable<T>? resultado = JsonConvert.DeserializeObject<IEnumerable<T>>(_json!);
            return resultado;
        }

        protected T? EntityGetNoResponse<T>(string resource = "") where T : class
        {
            try
            {
                HttpClient http = GetHttpClient();
                string _json = http.GetStringAsync($"{BaseUrl}{ApiController}{resource}").Result;
                T? resultado = JsonConvert.DeserializeObject<T>(_json!);
                return resultado;
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        protected T? EntityGet<T>(string resource = "") where T : ResponseDto, new()
        {
            try
            {
                HttpClient http = GetHttpClient();
                string _json = http.GetStringAsync($"{BaseUrl}{ApiController}{resource}").Result;
                T? resultado = JsonConvert.DeserializeObject<T>(_json);
                return resultado;
            }
            catch (Exception ex)
            {
                var response = GetErrorResult<T>(ex);
                return response;
            }
        }

        protected M? EntityPost<T, M>(string resource = "", T? paramt = default) where M : ResponseDto, new()
        {
            try
            {
                HttpClient http = GetHttpClient();

                string a = JsonConvert.SerializeObject(paramt);

                HttpResponseMessage response = http.PostAsJsonAsync($"{BaseUrl}{ApiController}{resource}", paramt).Result;
                string resulstring = response.Content.ReadAsStringAsync().Result;
                M? resultado = JsonConvert.DeserializeObject<M>(resulstring);
                return resultado;
            }
            catch (Exception ex)
            {
                var response = GetErrorResult<M>(ex);
                return response;
            }
        }

        protected M? EntityPut<T, M>(string resource = "", T? paramt = default) where M : ResponseDto, new()
        {
            try
            {
                HttpClient http = GetHttpClient();

                string a = JsonConvert.SerializeObject(paramt);

                HttpResponseMessage response = http.PutAsJsonAsync($"{BaseUrl}{ApiController}{resource}", paramt).Result;

                string resultstring = response.Content.ReadAsStringAsync().Result;
                M? resultado = JsonConvert.DeserializeObject<M>(resultstring);
                return resultado;
            }
            catch (Exception ex)
            {
                var response = GetErrorResult<M>(ex);
                return response;
            }
        }

        protected M? EntityDelete<M>(string resource = "") where M : ResponseDto, new()
        {
            try
            {
                HttpClient http = GetHttpClient();
                HttpResponseMessage response = http.DeleteAsync($"{BaseUrl}{ApiController}{resource}").Result;
                string resulstring = response.Content.ReadAsStringAsync().Result;
                M? resultado = JsonConvert.DeserializeObject<M>(resulstring);
                return resultado;
            }
            catch (Exception ex)
            {
                var response = GetErrorResult<M>(ex);
                return response as M;
            }
        }

        protected Response ResponseData<T>(ResponseDto<T> response)
        {
            if (response.IsValid)
                return new Response(response.Data!);
            else
            {
                string? mensaje = null;
                response.Messages.ToList().ForEach(x =>
                {
                    mensaje += x.Message;
                });
                return new Response(-1, mensaje!);
            }
        }

        protected Response ResponseNoData(ResponseDto response)
        {
            if (response.IsValid)
                return new Response(response);
            else
            {
                string? mensaje = null;
                response.Messages.ToList().ForEach(x =>
                {
                    mensaje += x.Message;
                });
                return new Response(-1, mensaje!);
            }
        }

        protected Response ResponseSearchResult<T>(ResponseDto<SearchResultDto<T>> response)
        {
            if (response.IsValid)
                return new Response(response.Data?.Items!);
            else
            {
                string? mensaje = null;
                response.Messages.ToList().ForEach(x =>
                {
                    mensaje += x.Message;
                });
                return new Response(-1, mensaje!);
            }
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

        private static T GetErrorResult<T>(Exception ex) where T : ResponseDto, new()
        {
            var response = new T();
            var messages = new List<ApplicationMessageDto>();

            messages.Add(new ApplicationMessageDto
            {
                Message = ex.Message.Contains("connection attempt failed") ? "Error de conexión" : ex.Message,
                MessageType = ApplicationMessageType.Error
            });

            response.Messages = messages;

            return response;
        }
    }
}
