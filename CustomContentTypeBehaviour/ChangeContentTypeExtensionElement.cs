using System;
using System.ComponentModel;
using System.Configuration;
using System.ServiceModel.Configuration;

namespace CustomContentTypeBehaviour

{
	public class ChangeContentTypeExtensionElement : BehaviorExtensionElement
	{
		[Description("The target's system ContentType, e.g. application/xml")]
		[ConfigurationProperty("ContentType", IsRequired = true, DefaultValue = "application/xml")]
		public string ContentType
		{
			get { return (string)base["ContentType"]; }
			set { base["ContentType"] = value; }
		}

		public ChangeContentTypeExtensionElement()
		{
		}

		public ChangeContentTypeExtensionElement(string contentType)
		{
			ContentType = contentType;
		}

		protected override object CreateBehavior()
		{
			return new ChangeContentTypeEndpointBehavior(ContentType);
		}

		public override Type BehaviorType => typeof(ChangeContentTypeEndpointBehavior);
	}
}