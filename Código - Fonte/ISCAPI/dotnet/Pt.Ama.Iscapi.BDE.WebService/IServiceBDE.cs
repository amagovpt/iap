using Pt.Ama.Iscapi.Model.BDE.Contract;
using Pt.Ama.Iscapi.Models.Model.BDE.Contract;
using System.ServiceModel;

using System.Threading.Tasks;

namespace Pt.Ama.Iscapi.BDE.WebService
{
    [ServiceContract(Namespace = "http://ama.gov.pt/services/xsd")]
    //[RequiredBehavior]
    [XmlSerializerFormat]
    public interface IServiceBDE
    {
        [OperationContract(Action = "http://ama.gov.pt/services/messageRequest", Name ="messageRequest")]
        Task GetMessageRequestAsync(Message message);
    }
}
