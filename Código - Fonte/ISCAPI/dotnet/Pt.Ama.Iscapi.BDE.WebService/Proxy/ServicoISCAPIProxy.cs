using Pt.Ama.Iscapi.Model.BDE.Contract;
using Pt.Ama.Iscapi.Models.Model.BDE.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pt.Ama.Iscapi.BDE.Proxy
{
    public class ServicoISCAPIProxy
    {
        private static Response response;

        public static Response MessageRequest(Message request)
        {
          //  WebApiWrapper.WebApiWrapper<Response> wrapper = new WebApiWrapper.WebApiWrapper<Response>();

         //   var response = wrapper.Post("ServicoISCAPI", "MessageRequest", request);

            return response;

        }

    }
}