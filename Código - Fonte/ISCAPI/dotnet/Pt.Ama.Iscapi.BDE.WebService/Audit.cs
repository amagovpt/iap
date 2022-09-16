using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt.Ama.Iscapi.Models.Model.BDE.Contract
{
    public class AuditRequest
    {
        public string Message { get; set; }
        public DateTime Data { get; set; }
        public string Service { get; set; }
    }
}
