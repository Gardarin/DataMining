using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AuthorisationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAuthorisationService" in both code and config file together.
    [ServiceContract]
    public interface IAuthorisationService
    {
        [OperationContract]
        Guid Registration(string name, string password);

        [OperationContract]
        Guid SignIn(string name, string password);

        [OperationContract]
        bool SignOut(Guid sessionId);
    }
}
