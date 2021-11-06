using System;
using System.Net;
using System.Text.Json.Serialization;

namespace MusalaDrones.Core
{
    public class BaseResult
    {
        [JsonIgnore]
        public HttpStatusCode Status { get; set; }

        [JsonIgnore]
        public string ErrorMessage { get; set; }

        public BaseResult(string errorMessage)
        {
            ErrorMessage = errorMessage;
            Status = HttpStatusCode.BadRequest;
        }

        public BaseResult()
        {
            Status = HttpStatusCode.OK;
        }

        public BaseResult(HttpStatusCode status)
        {
            Status = status;
        }
    }
}
