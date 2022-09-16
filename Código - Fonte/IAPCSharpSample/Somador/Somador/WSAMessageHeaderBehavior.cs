using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Security;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Configuration;

namespace Somador
{
    /// <summary>
    /// Classe Auxiliar para WS-Addressing
    /// </summary>
    public class WSAMessageHeaderBehavior : Attribute, IEndpointBehavior
    {
        // Constantes
        const string WSA_ACTION = "WSA.Action";

        // Variáveis
        string messageId;

        public WSAMessageHeaderBehavior(Guid messageId)
        {
            this.messageId = messageId.ToString();
        }

        public void Validate(ServiceEndpoint endpoint)
        {

        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {

        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {

        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new AddHeaderMessageInspector(this.messageId));
        }

    }

    [DataContract(Namespace = "http://www.w3.org/2005/08/addressing")]
    public class ReplyToHeader
    {
        [DataMember]
        public string Address { get; set; }
    }


    /// <summary>
    /// Adiciona Cabeçalhos
    /// </summary>
    public class AddHeaderMessageInspector : IClientMessageInspector
    {
        // Constantes
        const string WSA_ACTION = "WSA.Action";
        const string WSA_REPLY_TO = "WSA.Reply.To";
        const string WSA_TO = "WSA.To";

        string messageId { get; set; }

        public AddHeaderMessageInspector(string messageId)
        {
            this.messageId = messageId;
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            string wsaAction = ConfigurationManager.AppSettings[WSA_ACTION];
            string wsaReplyTo = ConfigurationManager.AppSettings[WSA_REPLY_TO];
            string wsaTo = ConfigurationManager.AppSettings[WSA_TO];

            request.Headers.Add(MessageHeader.CreateHeader("Action", "http://www.w3.org/2005/08/addressing", wsaAction));
            request.Headers.Add(MessageHeader.CreateHeader("MessageID", "http://www.w3.org/2005/08/addressing", this.messageId));
            request.Headers.Add(MessageHeader.CreateHeader("ReplyTo", "http://www.w3.org/2005/08/addressing", new ReplyToHeader() { Address = wsaReplyTo }));
            request.Headers.Add(MessageHeader.CreateHeader("To", "http://www.w3.org/2005/08/addressing", wsaTo));

            return request;

        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }
    }
}