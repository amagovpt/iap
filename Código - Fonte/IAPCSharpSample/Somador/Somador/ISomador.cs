using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Somador
{
    [ServiceContract]
    [XmlSerializerFormat]
    public interface ISomador
    {
        [OperationContract]
        bool SomadorService(int numero1, int numero2);
    }
}
