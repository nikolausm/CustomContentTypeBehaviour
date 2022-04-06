using System.Configuration;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace CustomContentTypeBehaviour
{
    /// <summary>
    /// Source: https://docs.microsoft.com/en-us/dotnet/framework/wcf/samples/message-inspectors
    /// </summary>
    public class ChangeContentTypeEndpointBehavior : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint serviceEndpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint serviceEndpoint, System.ServiceModel.Dispatcher.ClientRuntime behavior)
        {      
            
            behavior.ClientMessageInspectors.Add(new ChangeContentTypeMessageInspector());
        }
        public void ApplyDispatchBehavior(ServiceEndpoint serviceEndpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
        {
        }
        public void Validate(ServiceEndpoint serviceEndpoint)
        {
        }
    }
}
