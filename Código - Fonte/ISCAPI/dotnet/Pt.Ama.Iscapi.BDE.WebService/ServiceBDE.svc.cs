
using Pt.Ama.Iscapi.Models.Model.BDE.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

using System.ServiceModel;

using Message = Pt.Ama.Iscapi.Model.BDE.Contract.Message;

namespace Pt.Ama.Iscapi.BDE.WebService
{
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
   [AuditBehavior(Servico = "BDE")]
    public class ServiceBDE : IServiceBDE
    {
        /* public  Task GetMessageRequest(Message message)
         {
             var taskRun = Task.Run(() =>
             {
                 OperationAction action = new OperationAction(message.MessageData, message.RequestData, message.OperationData, message.AttachContext);
                 action.RunAction();
             });

             await taskRun.ConfigureAwait(false);
         }*/

        /*  public async Task GetMessageRequestAsync(Message message)
           {
               var taskRun = Task.Run(() =>
               {
                   OperationAction action = new OperationAction(message.MessageData, message.RequestData, message.OperationData, message.AttachContext);
                   action.RunAction();
               });

               await taskRun.ConfigureAwait(false);
           }
           */
        public async Task GetMessageRequestAsync(Message message)
        {
            var taskRun = Task.Run(() =>
            {
                OperationAction action = new OperationAction(message.MessageData, message.RequestData, message.OperationData, message.AttachContext);
                action.RunAction();
            });

            await taskRun.ConfigureAwait(false);
        }
    }
}
