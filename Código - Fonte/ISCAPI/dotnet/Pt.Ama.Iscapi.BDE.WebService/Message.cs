using Pt.Ama.Iscapi.Models.Model.BDE.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Pt.Ama.Iscapi.Model.BDE.Contract
{
    [MessageContract(WrapperName = "messageRequest", IsWrapped = true, WrapperNamespace = "http://ama.gov.pt/services/xsd")]
    [XmlRoot(ElementName = "messageRequest", Namespace = "http://ama.gov.pt/services/xsd")]
    public class Message
    {
        [MessageBodyMember(Name = "messageData", Namespace = "", Order = 0)]
        [XmlElement]
     
        public MessageData MessageData { get; set; }
        
        [MessageBodyMember(Name = "requestData", Namespace = "", Order = 1)]
        [XmlElement]
      
        public RequestData RequestData { get; set; }

        [MessageBodyMember(Name = "operationData", Namespace = "", Order = 2)]
        [XmlElement]

        public OperationData OperationData { get; set; }

        [MessageBodyMember(Name = "attachContext", Namespace = "", Order = 3)]
        [XmlElement]
   
        public AttachContext[] AttachContext { get; set; }

     
      
        

        public Message()
        {
        }

        public Message(MessageData messageData, RequestData requestData, OperationData operationData, AttachContext[] attachContext)
        {
            this.MessageData = messageData;
            this.RequestData = requestData;
            this.OperationData = operationData;
            this.AttachContext = attachContext;
        }

       

    }
}
