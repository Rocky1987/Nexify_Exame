using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nexify.Web.Models
{
    public class WebApiViewModel<T>        
    {
        public int status { get; set; }

        public string errorMessage { get; set; }

        public T Data { get; set; }
    }
}