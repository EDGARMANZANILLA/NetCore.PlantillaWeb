using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Entidades.DTOs
{
    public class Reply
    {
        public object result { get; set; }
        public string message { get; set; }
        public HttpStatusCode statusCode { get; set; }
    }

    public class ReplyPaginacion
    {
        public object resul { get; set; }
        public object paginacion { get; set; }
        public object data { get; set; }
        public string message { get; set; }
        public HttpStatusCode statusCode { get; set; }
    }
}
