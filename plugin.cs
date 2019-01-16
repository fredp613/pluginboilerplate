using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Net;

// Microsoft Dynamics CRM namespace(s)
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace Microsoft.Crm.Sdk.Samples
{
    /// <summary>
    /// A sandboxed plug-in that can access network (Web) resources.
    /// </summary>
    /// <remarks>Register this plug-in in the sandbox. You can provide an unsecure string
    /// during registration that specifies the Web address (URI) to access from the plug-in.
    /// </remarks>
    public sealed class CreateRecordAPI : IPlugin
    {

        public void Execute(IServiceProvider serviceProvider)
        {


            ITracingService tracingService =
               (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            IPluginExecutionContext context = (IPluginExecutionContext)
                serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            var _service = serviceFactory.CreateOrganizationService(context.UserId);
            OrganizationServiceContext ctx = new OrganizationServiceContext(_service);

            
            // The InputParameters collection contains all the data passed in the message request.
            if (context.InputParameters.Contains("Target") &&
                context.InputParameters["Target"] is Entity)
            {
                // Obtain the target entity from the input parameters.
                Entity entity = (Entity)context.InputParameters["Target"];

                // Verify that the target entity represents an inquiry record.
                // If not, this plug-in was not registered correctly.
                if (entity.LogicalName != "new_inquiry")
                    return;

                try
                {
                   
                }

                catch (WebException exception)
                {
                   
                    throw new InvalidPluginExecutionException("An error has occurred");
                }

            }

        }
    }

    

}