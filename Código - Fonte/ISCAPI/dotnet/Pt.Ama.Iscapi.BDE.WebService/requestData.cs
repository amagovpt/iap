using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Xml.Serialization;

namespace Pt.Ama.Iscapi.Models.Model.BDE.Contract
{
    //De acordo com a espicificação da AMA, 
    //Do not fix naming violations.
    public class RequestData
    {
        [XmlElement(elementName: "processNumber")]
        public string ProcessNumber { get; set; }

        [XmlElement(elementName: "requestNumber")]
       
        public string RequestNumber { get; set; }

        [XmlElement(elementName: "requestExternalNumber")]
        public string RequestExternalNumber { get; set; }

        [XmlElement(elementName: "requestDate")]
       
        public DateTime RequestDate { get; set; }

        [XmlElement(elementName: "serviceCode")]
       
        public string ServiceCode { get; set; }
        
        [XmlElement(elementName: "channel")]
        [MessageBodyMember(Name = "channel")]
       
        public string Channel { get; set; }

        [XmlElement(elementName: "entityCode")]
       
        public string EntityCode { get; set; }

        [XmlElement(elementName: "localCode")]
        public string LocalCode { get; set; }

        [XmlElement(elementName: "userCode")]
       
        public string UserCode { get; set; }

        [XmlElement(elementName: "userName")]
       
        public string UserName { get; set; }

    }
}
