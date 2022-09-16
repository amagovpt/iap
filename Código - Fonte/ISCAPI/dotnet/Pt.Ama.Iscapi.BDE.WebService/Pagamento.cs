using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Pt.Ama.Iscapi.Models.Model.BDE.Contract
{
    [MessageContract(IsWrapped = true, WrapperName = "requestData")]

    public class GetPaymentMethodsRequest
    {
        [XmlElement(elementName: "requestNumber")]
        [MessageBodyMember(Name = "requestNumber")]
        public string RequestNumber { get; set; }
        
        [XmlElement(elementName: "processNumber")]
        [MessageBodyMember(Name = "processNumber")]
        public string ProcessNumber { get; set; }

        [XmlElement(elementName: "requestDate")]
        [MessageBodyMember(Name = "requestDate")]
        public string RequestDate{ get; set; }

        [XmlElement(elementName: "serviceCode")]
        [MessageBodyMember(Name = "serviceCode")]
        public string ServiceCode { get; set; }

        [XmlElement(elementName: "channel")]
        [MessageBodyMember(Name = "channel")]
        public string Channel { get; set; }

        [XmlElement(elementName: "entityCode")]
        [MessageBodyMember(Name = "entityCode")]
        public string EntityCode { get; set; }

        [XmlElement(elementName: "localCode")]
        [MessageBodyMember(Name = "localCode")]
        public string LocalCode { get; set; }

        [XmlElement(elementName: "userCode")]
        [MessageBodyMember(Name = "userCode")]
        public string UserCode { get; set; }

        [MessageBodyMember(Name = "userName")]
        [XmlElement(elementName: "userName")]
        public string UserName { get; set; }
    }

    [XmlRoot(elementName: "operation", Namespace = "")]
    public class PaymentDataCommunication
    {
        [XmlElement(elementName: "paymentMovementId")]
        public string PaymentMovementId { get; set; }

        [XmlElement(elementName: "paymentDate")]
        public DateTime PaymentDate { get; set; }

        [XmlElement(elementName: "paymentValue")]
        public string PaymentValue { get; set; }

        [XmlElement(elementName: "paymentTypeId")]
        public string PaymentTypeId { get; set; }

        [XmlElement(elementName: "paymentTypeData")]
        public string PaymentTypeData { get; set; }

        [XmlElement(elementName: "feeType")]
        public string FeeType { get; set; }

        [XmlElement(elementName: "paymentUrl")]
        public string PaymentUrl { get; set; }
    }
}
