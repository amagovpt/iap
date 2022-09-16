using Pt.Ama.Iscapi.BDE.Proxy;
using Pt.Ama.Iscapi.Models.Model;
using Pt.Ama.Iscapi.Models.Model.BDE.Contract;
using Pt.Ama.Iscapi.Model.BDE.Contract;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pt.Ama.Iscapi.BDE.WebService
{
    public class OperationAction
    {

        private Message Message { get; set; }

        public OperationAction(MessageData messageData, RequestData requestData, OperationData operationData, AttachContext[] attachContext)
        {

            Message = new Message
            {
                MessageData = messageData,
                RequestData = requestData,
                OperationData = operationData,
                AttachContext = attachContext
            };
            
        }

        public Response RunAction()
        {
            var response = ServicoISCAPIProxy.MessageRequest(Message);
            return response;
        }

        private void ReceiveFormularioAction()
        {
          //  WebApiWrapper<GenericResponse> wrapper = new WebApiWrapper<GenericResponse>();

            //wrapper.Post("","")
        }
    }

    public static class Operation
    {
        public const string Formulario = "eletronicForm";
        public const string FormAuthRequest = "formAuthRequest";
        public const string FormAuthReply = "formAutReply";

        public const string InfoRequest = "additionalInfoRequest";
        public const string InfoReply = "additionalInfoReply";

        public const string RegistarDecisao = "processDecision";
        public const string RegistarNumeroProcesso = "processNumbers";
        public const string DadosPagamento = "paymentDataCommunication";

        public const string AlterarEstado = "requestStatusChange";
        public const string AlterarInfo = "serviceResumeInfo";

        public const string Erro = "processError";
    }

    public static class Servico
    {
        public const string FormularioDetalhe = "";
    }
}