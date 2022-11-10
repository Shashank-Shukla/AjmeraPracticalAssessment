using System;
using System.Collections.Generic;
using System.Text;

namespace AjmeraPracticalAssessment.Contracts.ReturnObject
{
    public class ControllerResponse
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public object ResponseObject { get; set; }
    }
}
