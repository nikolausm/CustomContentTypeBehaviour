using System;
using System.Configuration;
using System.ServiceModel.Configuration;

namespace CustomContentTypeBehaviour
{
    public sealed class ChangeContentTypeExtensionElement : BehaviorExtensionElement
    {
        public override Type BehaviorType => typeof(ChangeContentTypeEndpointBehavior);

        protected override ConfigurationPropertyCollection Properties =>
            new ConfigurationPropertyCollection 
            {
                new ConfigurationProperty(
                    "Content-Type",
                    typeof(string), 
                    "application/xml", 
                    null, 
                    null,
                    ConfigurationPropertyOptions.IsRequired
                )
            };

        protected override object CreateBehavior()
        {
            return new ChangeContentTypeEndpointBehavior();
        }
    }
}
