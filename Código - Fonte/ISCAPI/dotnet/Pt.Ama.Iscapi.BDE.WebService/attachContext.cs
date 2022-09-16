using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Xml.Serialization;

namespace Pt.Ama.Iscapi.Models.Model.BDE.Contract
{
    public class AttachContext
    {
        [XmlElement(elementName: "TTL")]
        public int TTL { get; set; }

        [XmlElement(elementName: "fileGuid")]
       
        public string FileGuid { get; set; }

        [XmlElement(elementName: "fileName")]
       
        public string FileName { get; set; }

        [XmlElement(elementName: "fileType")]
        
        public string FileType { get; set; }

        [XmlElement(elementName: "filePath")]
      
        public string FilePath { get; set; }
    }

  


}
