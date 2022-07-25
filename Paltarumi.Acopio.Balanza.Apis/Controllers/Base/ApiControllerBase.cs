using Microsoft.AspNetCore.Mvc;
using Paltarumi.Acopio.Dto.Base;
using System.Net.Mime;
using System.Text;

namespace Paltarumi.Acopio.Balanza.Apis.Controllers.Base
{
    public class ApiControllerBase : ControllerBase
    {
        private readonly IConfiguration? _configuration;
        private readonly IWebHostEnvironment? _webHostEnvironment;

        public ApiControllerBase(IServiceProvider serviceProvider)
        {
            _configuration = serviceProvider.GetService<IConfiguration>();
            _webHostEnvironment = serviceProvider.GetService<IWebHostEnvironment>();
        }

        protected T? GetSetting<T>(string key)
            => _configuration != null ? (_configuration.GetValue<T>(key) ?? default) : default;

        protected string GetFilePath(string directory, string fileName)
        {
            var webRootPath = (_webHostEnvironment?.WebRootPath ?? _webHostEnvironment?.ContentRootPath) ?? string.Empty;
            var filePath = Path.Combine(webRootPath, directory, fileName);

            return filePath;
        }

        protected string GetSettingFilePath(string key, string fileName)
        {
            var webRootPath = (_webHostEnvironment?.WebRootPath ?? _webHostEnvironment?.ContentRootPath) ?? string.Empty;
            var directory = GetSetting<string>(key) ?? string.Empty;
            var filePath = Path.Combine(webRootPath, directory, fileName);

            return filePath;
        }

        protected async Task<FileResult> DownloadFile(byte[] bytes, string fileName)
        {
            bytes = bytes ?? new byte[0];
            var fileResult = File(bytes, MediaTypeNames.Application.Octet, fileName);

            Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");

            return await Task.FromResult(fileResult);
        }

        protected async Task<FileResult> DownloadFile(ResponseDto<byte[]> reponseDto, string fileName)
        {
            byte[] bytes = reponseDto?.Data ?? new byte[0];
            var fileResult = File(bytes, MediaTypeNames.Application.Octet, fileName);

            Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");

            return await Task.FromResult(fileResult);
        }

        protected async Task<FileResult> DownloadFile(ResponseDto<string> reponseDto, string fileName)
        {
            var response = new ResponseDto<byte[]>();
            response.UpdateData(Encoding.UTF8.GetBytes(reponseDto?.Data ?? string.Empty));
            return await DownloadFile(response, fileName);
        }

        protected async Task<FileStreamResult> ViewFile(ResponseDto<byte[]> reponseDto, string fileName)
        {
            byte[] bytes = reponseDto?.Data ?? new byte[0];
            var memoryStream = new MemoryStream(bytes);
            try
            {
                return await Task.FromResult(new FileStreamResult(memoryStream, "application/pdf"));
            }
            catch
            {
                memoryStream.Dispose();
                throw;
            }
        }
    }
}
