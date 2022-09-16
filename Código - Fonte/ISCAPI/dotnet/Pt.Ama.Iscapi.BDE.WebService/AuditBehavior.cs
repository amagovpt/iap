
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web;
using System.Xml.Linq;

namespace Pt.Ama.Iscapi.BDE.WebService
{
    public class AuditBehaviorAttribute : Attribute, IServiceBehavior
    {
        public string Servico { get; set; }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            for (int i = 0; i < serviceHostBase.ChannelDispatchers.Count; i++)
            {
                if (serviceHostBase.ChannelDispatchers[i] is ChannelDispatcher channelDispatcher)
                {
                    foreach (EndpointDispatcher endpointDispatcher in channelDispatcher.Endpoints)
                    {
                        endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new AuditMessageInspector(Servico));
                    }
                }
            }
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
    }

    public class AuditMessageInspector : IDispatchMessageInspector
    {
        private string Servico { get; set; }
        public AuditMessageInspector(string servico) : base()
        {
            Servico = servico;
        }
        public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, IClientChannel channel, InstanceContext instanceContext)
        {

            string logLocation = ConfigurationManager.AppSettings.Get("logFileLocation");
       /*     Log.Logger = new LoggerConfiguration()
                .WriteTo.RollingFile(logLocation + "Log-{Date}.txt")
                .CreateLogger();

            Logging.LogInfo("A obter Message...");
            var message = request.ToString();
            Logging.LogInfo(message);
            */
       //     WebApiWrapper<AuditRequest> wrapper = new WebApiWrapper<AuditRequest>();

            try
            {
                //wrapper.Post("Audit", "Audit", new AuditRequest
                //{
                //    Data = DateTime.Now,
                //    Message = message,
                //    Service = Servico
                //});
            }
            catch (Exception e)
            {
                //int i = 2;
                throw e;
            }
           

            return request;
        }

        public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
        }
    }
}