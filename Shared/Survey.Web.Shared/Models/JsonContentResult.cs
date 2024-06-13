using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace Survey.Web.Shared.Models
{
    public sealed class JsonContentResult : ContentResult
    {
        public JsonContentResult()
        {
            ContentType = "application/json";
        }

        public static JsonContentResult Success()
        {
            return new JsonContentResult
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        public static JsonContentResult Success(object response)
        {
            return new JsonContentResult
            {
                StatusCode = (int)HttpStatusCode.OK,
                Content = JsonConvert.SerializeObject(response)
            };
        }

        public static JsonContentResult Error(object response)
        {
            return new JsonContentResult
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Content = JsonConvert.SerializeObject(response)
            };
        }
    }
}
