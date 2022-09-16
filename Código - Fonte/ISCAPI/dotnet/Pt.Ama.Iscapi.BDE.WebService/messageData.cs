using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Xml.Serialization;

namespace Pt.Ama.Iscapi.Models.Model.BDE.Contract
{
    public class MessageData
    {
        [XmlElement(elementName: "messageEntityId")]
       
        [MessageBodyMember(Name = "messageEntityId")]
        public string MessageEntityId { get; set; }

        [XmlElement(elementName: "messageRelatesTold")]
        [MessageBodyMember(Name = "messageRelatesTold")]
        public string MessageRelatesTold { get; set; }

        [XmlElement(elementName: "messageRelatesToEntityId")]
        [MessageBodyMember(Name = "messageRelatesToEntityId")]
     
        public string MessageRelatesToEntityId { get; set; }

        [XmlElement(elementName: "messageDate")]
        [MessageBodyMember(Name = "messageDate")]
       
        public DateTime MessageDate { get; set; }
    }
}
