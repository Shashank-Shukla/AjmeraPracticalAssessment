using System;
using System.Collections.Generic;
using System.Text;

namespace AjmeraPracticalAssessment.Contracts.ReturnObject
{
    public class ControllerResponse
    {
        public string Success { get; set; }
        public int StatusCode { get; set; }
        public object ResponseObject { get; set; }
    }
}
