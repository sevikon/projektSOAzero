using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Runtime.Serialization;

namespace NServiceRepository
{
    /**
     *  Udostępniany interfejs ServiceRepository
     * */
    [ServiceContract]
    public interface IServiceRepository
    {
        [OperationContract]
        void RegisterService(String Name, String Address);

        [OperationContract]
        string GetServiceLocation(String Name);

        [OperationContract]
        void Unregister(String Name);

        [OperationContract]
        void Alive(String Name);
    }
}
