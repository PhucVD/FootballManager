using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballManager.Web.Common
{
    public class JsonInfo
    {
        public JsonStatus Status { get; set; }

        public string Message { get; set; }

        public string Exception { get; set; }

        public JsonInfo(JsonStatus status)
        {
            Status = status;
            Message = status == JsonStatus.Success ? "Save data successfully!" : "Save data failed!";
        }

    }

    public enum JsonStatus
    {
        Failed = 0,
        Success = 1
    }
}