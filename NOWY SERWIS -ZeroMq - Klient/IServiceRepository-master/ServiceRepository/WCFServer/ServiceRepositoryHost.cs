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
     * Klasa upraszczająca
     * */
    class ServiceRepositoryHost : ServiceHost
    {
        public ServiceRepositoryHost(ServiceRepository Repository, String Address) 
        : base(Repository, new Uri[] { new Uri(Address) })
        {
        }

        /**
         *  Ustawienie metadanych
         * */
        public void SetMetaData()
        {
            ServiceMetadataBehavior metadata = Description.Behaviors.Find<ServiceMetadataBehavior>();
            if (metadata == null)
            {
                metadata = new ServiceMetadataBehavior();
                Description.Behaviors.Add(metadata);
            }
            metadata.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;

            AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
        }

        /**
         *  Dodanie domyślnego endpointu
         * */
        public void AddDefaultEndpoint(String Address)
        {
            AddServiceEndpoint(typeof(IServiceRepository), new NetTcpBinding(SecurityMode.None), Address);
        }
    }
}
