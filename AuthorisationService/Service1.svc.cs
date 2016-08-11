using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AuthorisationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuthorisationService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AuthorisationService.svc or AuthorisationService.svc.cs at the Solution Explorer and start debugging.
    public class AuthorisationService: IAuthorisationService
    {
        private readonly DataBaseService.IDataBaseService dataBaseService = new DataBaseService.DataBaseService();

        public Guid Registration(string name, string password)
        {
            if (dataBaseService.Registration(name, password))
            {
                return dataBaseService.SignIn(name, password);
            }
            return Guid.Empty;
        }

        public Guid SignIn(string name, string password)
        {
            return dataBaseService.SignIn(name, password);
        }

        public bool SignOut(Guid sessionId)
        {
            return dataBaseService.SignOn(sessionId);
        }
    }
}
