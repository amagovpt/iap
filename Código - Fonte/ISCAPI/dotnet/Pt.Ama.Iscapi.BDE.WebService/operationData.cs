using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Pt.Ama.Iscapi.Models.Model.BDE.Contract
{

    //De acordo com a espicificação da AMA, 
    //Do not fix naming violations.
    public class OperationData
    {
        [XmlElement(elementName: "operationCode")]
       
        public string OperationCode { get; set; }

        [XmlElement(elementName: "operationVersion")]
       
        public string OperationVersion { get; set; }

        [XmlAnyElementAttribute]
        public XmlNode Operation { get; set; }

        [XmlElement(elementName: "paymentValue")]
        public string PaymentValue { get; set; }

        [XmlElement(elementName: "feeType")]
        public string FeeType { get; set; }

        [XmlElement(elementName: "requests")]
        public Request[] Requests { get; set; }

        

    }
}
