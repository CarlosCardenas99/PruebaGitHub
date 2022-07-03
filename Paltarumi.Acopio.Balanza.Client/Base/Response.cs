namespace Paltarumi.Acopio.Balanza.Client.Base
{
    public class Response
    {
        public string responseTitle { get; set; }
        public int responseCode { get; set; }
        public string responseMessage { get; set; }
        public string responseSubMessage { get; set; }
        public dynamic objectDynamic { get; set; }

        public Response()
        {
            this.responseTitle = string.Empty;
            this.responseCode = 0;
            this.responseMessage = string.Empty;
            this.responseSubMessage = string.Empty;
        }
        public Response(Object objeto)
        {
            this.responseTitle = string.Empty;
            this.responseCode = 0;
            this.responseMessage = string.Empty;
            this.responseSubMessage = string.Empty;
            this.objectDynamic = objeto;
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
                this.responseTitle = "Sistema";
            else
                this.responseTitle = string.Empty;

            this.responseCode = responseCode;
            this.responseMessage = responseMessage;
            this.responseSubMessage = string.Empty;
        }
    }
}
