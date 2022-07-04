namespace Paltarumi.Acopio.Balanza.Client.Base
{
    public class Response
    {
        public string responseTitle { get; set; }
        public int responseCode { get; set; }
        public string responseMessage { get; set; }
        public string responseSubMessage { get; set; }

        public Response()
        {
            this.responseTitle = string.Empty;
            this.responseCode = 0;
            this.responseMessage = string.Empty;
            this.responseSubMessage = string.Empty;
        }

        public Response(string strResponseTitle)
        {
            this.responseTitle = strResponseTitle;
            this.responseCode = 0;
            this.responseMessage = string.Empty;
            this.responseSubMessage = string.Empty;
        }

        public Response(int responseCode, string responseMessage)
        {
            if (responseCode < 0)
                responseTitle = "Sistema";
            else
                responseTitle = string.Empty;

            this.responseCode = responseCode;
            this.responseMessage = responseMessage;
            this.responseSubMessage = string.Empty;
        }
    }

    public class Response<T> : Response
    {
        public T Data { get; set; }

        public Response(T data)
        {
            this.responseTitle = string.Empty;
            this.responseCode = 0;
            this.responseMessage = string.Empty;
            this.responseSubMessage = string.Empty;
            this.Data = data;
        }

        public Response(int responseCode, string responseMessage) : base(responseCode, responseMessage)
        {
            this.Data = default(T)!;
        }
    }
}
