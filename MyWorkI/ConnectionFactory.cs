using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorkI
{
    internal class ConnectionFactory
    {
        public static IOrganizationService GetService()
        {
            string connectionString =
                "AuthType=OAuth;" +
                "username=claraadao@clara321.onmicrosoft.com; " +
                "Password=clara@123;" +
                "Url=https://clara.crm2.dynamics.com;" +
                "AppId=d1fb099a-c910-4413-bd91-8e6a0434c483;" +
                "RedirectUri = app://58145891-0C36-4500-8554-080854F2AC97;";

            CrmServiceClient crmServiceClient = new CrmServiceClient(connectionString);
            return crmServiceClient.OrganizationWebProxyClient;
        }
    }
}
