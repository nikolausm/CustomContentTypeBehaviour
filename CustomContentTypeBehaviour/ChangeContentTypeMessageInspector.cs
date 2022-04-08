using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace CustomContentTypeBehaviour
{
	public class ChangeContentTypeMessageInspector : IClientMessageInspector
	{
		private readonly string _contentType;

		public ChangeContentTypeMessageInspector(string contentType)
		{
			_contentType = contentType;
		}
		public void AfterReceiveReply(ref Message reply, object correlationState)
		{
			if (reply.Properties.TryGetValue(HttpResponseMessageProperty.Name, out var message))
			{
				var httpRequestMessage = (HttpResponseMessageProperty)message;
				httpRequestMessage.StatusCode = HttpStatusCode.OK;
			}
			else
			{
				var httpRequestMessage = new HttpResponseMessageProperty();
				httpRequestMessage.StatusCode = HttpStatusCode.OK;
				reply.Properties.Add(HttpResponseMessageProperty.Name, httpRequestMessage);
			}
		}

		public object BeforeSendRequest(ref Message request, IClientChannel channel)
		{
			
			const string headerName = "Content-Type";
			
			if (request.Properties.TryGetValue(HttpRequestMessageProperty.Name, out var httpRequestMessageObject))
			{
				var httpRequestMessage = (HttpRequestMessageProperty)httpRequestMessageObject;
				httpRequestMessage.Headers[headerName] = _contentType;
			}
			else
			{
				var httpRequestMessage = new HttpRequestMessageProperty();
				httpRequestMessage.Headers.Add(headerName, _contentType);
				request.Properties.Add(HttpRequestMessageProperty.Name, httpRequestMessage);
			}
			return null;
		}
	}
}


