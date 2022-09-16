using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Pt.Ama.Iscapi.Models.Model.BDE.Contract
{
    public class Request
    {
        [XmlElement(elementName: "requestNumber")]
        public string RequestNumber { get; set; }
        [XmlElement(elementName: "serviceCode")]
        public string ServiceCode { get; set; }
        [XmlElement(elementName: "entityCode")]
        public string EntityCode { get; set; }
    }
}
